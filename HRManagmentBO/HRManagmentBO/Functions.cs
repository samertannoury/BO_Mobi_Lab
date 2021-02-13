using HRManagmentBO;
using HRManagmentBO.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.Script.Serialization;

public class Functions
{
    private JavaScriptSerializer JSONserializer = new JavaScriptSerializer();
    public Boolean HasPermission(Decimal FunctionID, BOUsers user)
    {
        DataContext db = new DataContext();
        List<BOUserProfiles> profiles = db.MBOUserProfiles.Where(o => o.UserID == user.UserID).ToList();
       
        foreach (BOUserProfiles profile in profiles)
        {
            List<Decimal> functions = db.MBOProfileFunctions.Where(o => o.ProfileID == profile.ProfileID && o.Status.ToUpper() == "ACTIVE").Select(o => o.FunctionID).ToList();
            foreach (Decimal function in functions)
            {
                if (function == FunctionID)
                {
                    return true;
                }
            }
        }
        return false;

    }

    public void callWebServices(ref RestAPIRequest api)
    {
        // string apiId = "";
        try
        {
            
            HttpWebRequest httpRequest = WebRequest.Create(api.URL) as HttpWebRequest;
            httpRequest.Timeout = 180000;
            httpRequest.KeepAlive = false;
            httpRequest.Method = api.methodType;
            if (api.headers != null)
            {
                foreach (KeyValuePair<string, string> header in api.headers)
                {
                    httpRequest.Headers.Add(header.Key, header.Value);
                }
            }

            if (api.requireAuthorization)
            {
                httpRequest.UseDefaultCredentials = true;
            }
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = (object sender2, X509Certificate certificate, X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors) => true;

            if (!api.methodType.Trim().ToLower().Equals("get"))
            {
                byte[] bodyBytes = Encoding.UTF8.GetBytes(api.body);
                httpRequest.ContentLength = bodyBytes.Length;

                httpRequest.ContentType = api.contentType;
                Stream reqStreamWritter = httpRequest.GetRequestStream();
                reqStreamWritter.Write(bodyBytes, 0, bodyBytes.Length);
                reqStreamWritter.Close();
            }


            HttpWebResponse httpResponse = httpRequest.GetResponse() as HttpWebResponse;
            StreamReader respStreamReader = new StreamReader(httpResponse.GetResponseStream(), System.Text.Encoding.GetEncoding("UTF-8"));
            var response = respStreamReader.ReadToEnd();
            api.response = response;
            api.httpStatus = httpResponse.StatusCode.ToString();
         

        }
        catch (WebException webEx)
        {
            // LogEvent("callWebService", "Error", "ErrorCode : " + webEx.Message);
            HttpWebResponse httpResponse = webEx.Response as HttpWebResponse;
            var response = "";
            if (httpResponse == null)
            {
                response = "WebException Error Message : " + webEx.Message;
            }
            else
            {
                StreamReader respStreamReader = new StreamReader(httpResponse.GetResponseStream(), System.Text.Encoding.GetEncoding("UTF-8"));
                response = respStreamReader.ReadToEnd();

            }
            
            api.response = response;
            api.httpStatus = httpResponse == null ? "" : httpResponse.StatusCode.ToString();
            
        }
        catch (Exception ex)
        {
            //ex.MEssage
        }


    }

    public T deserializeJSON<T>(string str)
    {

        T jsonObj = JSONserializer.Deserialize<T>(str);

        return jsonObj;

    }



    public List<EmployeePosition> getEmployeePosition()
    {
       
        List<EmployeePosition> EmployeePositionlst = new List<EmployeePosition>();
        DataContext db = new DataContext();
        try
        {

            EmployeePositionlst = db.MEmployeePosition.ToList();


            return EmployeePositionlst;

        }
        catch (Exception ex)
        {

            return EmployeePositionlst;
}
    }




    public List<Department> getDepartments()
    {

        List<Department> Departmentlst = new List<Department>();
        DataContext db = new DataContext();
        try
        {

            Departmentlst = db.MDepartment.ToList();


            return Departmentlst;

        }
        catch (Exception ex)
        {

            return Departmentlst;
        }
    }


}