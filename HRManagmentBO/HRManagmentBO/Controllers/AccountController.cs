using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRManagmentBO.Models;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Text;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Drawing;
using System.IO;

namespace HRManagmentBO.Controllers
{
    public class AccountController : Controller
    {
        string StaticSalt = System.Configuration.ConfigurationManager.AppSettings["StaticSalt"];
        string StaticPepper = System.Configuration.ConfigurationManager.AppSettings["StaticPepper"];

        public ActionResult Login()
        {
            LoginModel retur = new LoginModel();
            DataContext db = new DataContext();
            String Error = "";
            String strusername = "";


            if (Session["Error"] != null)
            {
                strusername = Session["strusername"].ToString();
                Error = Session["Error"].ToString();
               
            }
            else
            {
                strusername = null;
            }
            Session["Error"] = null;
            try
            {
                System.Web.Security.FormsAuthentication.SignOut();
                System.Web.HttpContext.Current.User =
                     new GenericPrincipal(new GenericIdentity(string.Empty), null);
                Session["User"] = null;
                retur.ApplicationName = "HR Managment BO";
                retur.Error = Error;
                retur.strusername = strusername;
                return View(retur);
            }
            catch (Exception ex)
            {

                retur.Error = "An error has occurred!";
                return View(retur);
            }
        }

        [HttpPost]
        public ActionResult Login(LoginModel ret)
        {

            Session["strusername"] = ret.UserName.Trim();
            Functions function = new Functions();

            try
            {

               

                    DataContext db = new DataContext();
                    String aa = ret.TimeStamp + "U1DWUZCRVFGV1VVT0=";
                    byte[] Key = Encoding.UTF8.GetBytes(aa);
                    byte[] IV = Encoding.UTF8.GetBytes("YWlFLVEZZUFNaWl=");

                    byte[] encryptedBytes = Convert.FromBase64String(ret.Password);
                    AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                    aes.BlockSize = 128;
                    aes.KeySize = 256;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;
                    aes.Key = Key;
                    aes.IV = IV;
                    ICryptoTransform crypto = aes.CreateDecryptor(aes.Key, aes.IV);
                    byte[] secret = crypto.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
                    crypto.Dispose();
                    string res = System.Text.ASCIIEncoding.ASCII.GetString(secret);
                    ret.Password = res;
                    String IsSuccess = isTrueLogin(ret.UserName.Trim(), res);


                    if (IsSuccess == "1")
                    {
                        String username = Session["Username"].ToString();
                        var user = db.MBOUsers.Where(i => i.Username == username).FirstOrDefault();
                        Session["User"] = user;
                        return RedirectToAction("Index", "Home");
                           
                    }
                    else
                    {

                        ret.Error = "Incorrect Credentials";
                        ret.UserName = "";
                        ret.Password = "";
                        ret.IncorrectLogin = true;
                    
                        Session["Error"] = "Incorrect Credentials";

                    //return RedirectToAction("Login", "Account");
                    return View(ret);

                }


            
            }
            catch (Exception ex)
            {

               
                ret.Error = "An error has occurred!";
                Session["Error"] = "Incorrect Credentials";

                return RedirectToAction("Login", "Account");
            }
        }

        public ViewPermissions getPermissions(BOUsers BOUsers)
        {
            try
            {
                ViewPermissions ViewPermissions = new ViewPermissions();
                BOUsers user = (BOUsers)Session["User"];
                DataContext db = new DataContext();
                Functions function = new Functions();

                //BOUsers
                if (function.HasPermission(2, user) || function.HasPermission(3, user) || function.HasPermission(4, user))
                {
                    ViewPermissions.ViewBOUsers = true;
                }

                //Functions
                if (function.HasPermission(5, user) || function.HasPermission(6, user) || function.HasPermission(7, user))
                {
                    ViewPermissions.ViewFunctions = true;
                }
                //Profiles
                if (function.HasPermission(8, user) || function.HasPermission(9, user) || function.HasPermission(10, user))
                {
                    ViewPermissions.ViewProfiles = true;
                }

                //BO Settings Catetgory
                if (ViewPermissions.ViewBOUsers || ViewPermissions.ViewProfiles)
                {
                    ViewPermissions.ViewBOSettings = true;
                }


                //addExternalLinks
                if (function.HasPermission(78, user) || function.HasPermission(79, user) || function.HasPermission(80, user))
                {
                    ViewPermissions.ViewaddExternalLinks = true;
                }

                if (function.HasPermission(78, user))
                {
                    ViewPermissions.ViewExternalLinks = true;
                }

                //ICView
                if (function.HasPermission(16, user) || function.HasPermission(17, user))
                {
                    ViewPermissions.ViewICView = true;
                    //ViewPermissions.ViewExpirationLiteUsersReport = true;
                }

                //Lite
                if (function.HasPermission(64, user))
                {

                    ViewPermissions.ViewLite = true;
                }


                if (function.HasPermission(130, user))
                {

                    ViewPermissions.ViewUsersDraw = true;
                }


                if (function.HasPermission(131, user))
                {

                    ViewPermissions.ViewUsersDrawResults = true;
                }


                if (function.HasPermission(132, user))
                {

                    ViewPermissions.ViewDrawConfig = true;
                }




                if (function.HasPermission(134, user))
                {

                    ViewPermissions.ViewAMLBlockedUsers = true;
                }

                if (function.HasPermission(136, user))
                {

                    ViewPermissions.ViewAMLList = true;
                }

                if (function.HasPermission(200, user))
                {

                    ViewPermissions.ViewAmbassador = true;


                }




                if (function.HasPermission(228, user) || function.HasPermission(229, user))
                {

                    ViewPermissions.ViewCardAllowList = true;


                }

                if (function.HasPermission(215, user) || function.HasPermission(216, user))
                {

                    ViewPermissions.ViewAmbassadorPayment = true;


                }



                if (function.HasPermission(213, user))
                {

                    ViewPermissions.ViewSpinAndWin = true;


                }


                if (function.HasPermission(217, user) || function.HasPermission(218, user) || function.HasPermission(219, user))
                {

                    ViewPermissions.ViewException = true;

                }


                if (function.HasPermission(220, user) || function.HasPermission(221, user))
                {

                    ViewPermissions.ViewBoomerang = true;

                }


                //Individual Clients Catetgory
                if (ViewPermissions.ViewUsersCards || ViewPermissions.ViewAmbassadorPayment || ViewPermissions.ViewAmbassador || ViewPermissions.ViewSpinAndWin || ViewPermissions.ViewICView || ViewPermissions.ViewLite || ViewPermissions.ViewUsersDraw || ViewPermissions.ViewUsersDrawResults || ViewPermissions.ViewAMLBlockedUsers || ViewPermissions.ViewAMLList || ViewPermissions.ViewException || function.HasPermission(220, user) || function.HasPermission(221, user))
                {
                    ViewPermissions.ViewIndividualClients = true;
                }




                if (function.HasPermission(256, user))
                {
                    ViewPermissions.ViewDocumentsManager = true;
                }
                if (function.HasPermission(266, user))
                {
                    ViewPermissions.ViewDocumentsList = true;
                }
                if (function.HasPermission(274, user))
                {
                    ViewPermissions.ViewMerchantBlackList = true;
                }
                if (function.HasPermission(280, user))
                {
                    ViewPermissions.ViewCampaign = true;
                }





                if (ViewPermissions.ViewDocumentsManager || ViewPermissions.ViewDocumentsList)
                {
                    ViewPermissions.ViewDocuments = true;
                }


                //BOLogs
                if (function.HasPermission(31, user) || function.HasPermission(32, user))
                {
                    ViewPermissions.ViewBOLogs = true;
                }

                //MPLogs
                if (function.HasPermission(29, user) || function.HasPermission(30, user))
                {
                    ViewPermissions.ViewMPLogs = true;
                }
                //UA Logs
                if (function.HasPermission(109, user))
                {
                    ViewPermissions.ViewUALogs = true;
                }

                //Logs Catetgory
                if (ViewPermissions.ViewBOLogs || ViewPermissions.ViewMPLogs || ViewPermissions.ViewUALogs)
                {
                    ViewPermissions.ViewLogs = true;
                }

                //MerchantClient
                if (function.HasPermission(14, user) || function.HasPermission(15, user))
                {
                    ViewPermissions.ViewMerchantClient = true;
                }

                //MerchantEnrollment
                if (function.HasPermission(34, user))
                {
                    ViewPermissions.ViewMerchantEnrollment = true;
                }
                //Accounts
                if (function.HasPermission(14, user) || function.HasPermission(15, user))
                {
                    ViewPermissions.ViewAccounts = true;
                }
                //MerchantAppUsers
                if (function.HasPermission(35, user))
                {
                    ViewPermissions.ViewMerchantAppUsers = true;
                }

                //MerchantCategory
                if (function.HasPermission(46, user) || function.HasPermission(47, user) || function.HasPermission(48, user))
                {
                    ViewPermissions.ViewMerchantCategory = true;
                }

                //MerchantSubCategory
                if (function.HasPermission(46, user) || function.HasPermission(47, user) || function.HasPermission(48, user))
                {
                    ViewPermissions.ViewMerchantSubCategory = true;
                }

                //MerchantRegion
                if (function.HasPermission(49, user) || function.HasPermission(50, user) || function.HasPermission(51, user))
                {
                    ViewPermissions.ViewMerchantRegion = true;
                }
                //LoyaltyExceptions
                if (function.HasPermission(55, user) || function.HasPermission(56, user) || function.HasPermission(57, user))
                {
                    ViewPermissions.ViewLoyaltyExceptions = true;
                }

                //AddLoyalty
                if (function.HasPermission(58, user))
                {
                    ViewPermissions.ViewAddLoyalty = true;
                }
                //viewLoyalty
                if (function.HasPermission(59, user) || function.HasPermission(60, user))
                {
                    ViewPermissions.ViewAddLoyalty = true;
                }

                //AddOffer
                if (function.HasPermission(68, user))
                {
                    ViewPermissions.ViewAddOffer = true;
                }

                //ViewOffers
                if (function.HasPermission(66, user) || function.HasPermission(67, user))
                {
                    ViewPermissions.ViewviewOffers = true;
                }
                //ViewLoyalty
                if (function.HasPermission(59, user) || function.HasPermission(60, user))
                {
                    ViewPermissions.ViewviewLoyalty = true;
                }
                //Merchant Settings Catetgory
                if (ViewPermissions.ViewAccounts || ViewPermissions.ViewAddLoyalty || ViewPermissions.ViewAddOffer || ViewPermissions.ViewLoyaltyExceptions || ViewPermissions.ViewMerchantAppUsers || ViewPermissions.ViewMerchantCategory || ViewPermissions.ViewMerchantClient || ViewPermissions.ViewMerchantEnrollment || ViewPermissions.ViewMerchantRegion || ViewPermissions.ViewMerchantSubCategory || ViewPermissions.ViewviewLoyalty || ViewPermissions.ViewviewOffers)
                {
                    ViewPermissions.ViewMerchantSettings = true;
                }

                //View Messages
                if (function.HasPermission(18, user))
                {
                    ViewPermissions.ViewviewMessages = true;
                }
                //Marketing Messages
                if (function.HasPermission(39, user))
                {
                    ViewPermissions.ViewMarketingMessage = true;
                }
                //SMSMessages
                if (function.HasPermission(33, user))
                {
                    ViewPermissions.ViewSMSMessages = true;
                }

                //Received Messages
                if (function.HasPermission(69, user))
                {
                    ViewPermissions.ViewReceivedMessages = true;
                }


                //ArchivedVideo
                if (function.HasPermission(116, user))
                {
                    ViewPermissions.ViewArchivedVideo = true;
                }


                //Chat messages
                if (function.HasPermission(117, user))
                {
                    ViewPermissions.ViewChatMessages = true;
                }



                //Messages Catetgory
                if (ViewPermissions.ViewReceivedMessages || ViewPermissions.ViewviewMessages || ViewPermissions.ViewMarketingMessage || ViewPermissions.ViewSMSMessages || ViewPermissions.ViewArchivedVideo || ViewPermissions.ViewChatMessages)
                {
                    ViewPermissions.ViewMessages = true;
                }

                //MPAppParameters
                if (function.HasPermission(19, user) || function.HasPermission(20, user) || function.HasPermission(21, user))
                {
                    ViewPermissions.ViewMPAppParameters = true;
                }
                //MPPaymentParameters
                if (function.HasPermission(11, user) || function.HasPermission(12, user) || function.HasPermission(13, user))
                {
                    ViewPermissions.ViewMPPaymentParameters = true;
                }
                //MPSysAccounts
                if (function.HasPermission(110, user) || function.HasPermission(111, user) || function.HasPermission(112, user))
                {
                    ViewPermissions.ViewMpSysAccounts = true;
                }



                //MPNumberParameter
                if (function.HasPermission(22, user) || function.HasPermission(23, user) || function.HasPermission(24, user))
                {
                    ViewPermissions.ViewMPNumberParameters = true;
                }
                //PrivacyPolicy
                if (function.HasPermission(25, user) || function.HasPermission(26, user))
                {
                    ViewPermissions.ViewPrivacyPolicy = true;
                    ViewPermissions.ViewPrivacyPolicyLite = true;
                    ViewPermissions.ViewPrivacyPolicyExpress = true;
                }

                //SecurityAwarness
                if (function.HasPermission(43, user) || function.HasPermission(44, user))
                {
                    ViewPermissions.ViewSecurityAwarness = true;
                }

                //MobileRecharge
                if (function.HasPermission(36, user) || function.HasPermission(37, user) || function.HasPermission(38, user))
                {
                    ViewPermissions.ViewMobileRecharge = true;
                }



                //Providers
                if (function.HasPermission(113, user) || function.HasPermission(114, user) || function.HasPermission(115, user))
                {
                    ViewPermissions.ViewProviders = true;
                }


                if (function.HasPermission(252, user))
                {
                    ViewPermissions.ViewTranslatedData = true;
                }


                //FAQ
                if (function.HasPermission(40, user) || function.HasPermission(41, user) || function.HasPermission(42, user))
                {
                    ViewPermissions.ViewFAQ = true;
                }

                //AllowListView
                if (function.HasPermission(95, user))
                {
                    ViewPermissions.AllowListView = true;
                }


                //Languages
                if (function.HasPermission(98, user))
                {
                    ViewPermissions.ViewLanguagesPage = true;
                }

                //Variables
                if (function.HasPermission(101, user))
                {
                    ViewPermissions.ViewVariables = true;
                }
                //ViewImportLanguage
                if (function.HasPermission(104, user))
                {
                    ViewPermissions.ViewImportLanguage = true;
                }
                //TextChange
                if (function.HasPermission(52, user) || function.HasPermission(53, user) || function.HasPermission(54, user))
                {
                    ViewPermissions.ViewTextChange = true;
                }
                //Languages li
                if (ViewPermissions.ViewTextChange || ViewPermissions.ViewFormLanguages || ViewPermissions.ViewImportLanguage || ViewPermissions.ViewLanguagesPage || ViewPermissions.ViewVariables)
                {
                    ViewPermissions.ViewLanguagesli = true;
                }

                //Utilities li
                if (ViewPermissions.ViewMobileRecharge || ViewPermissions.ViewProviders)
                {
                    ViewPermissions.ViewUtilitiesli = true;
                }



                //MP Settings Catetgory
                if (ViewPermissions.ViewLanguagesli || ViewPermissions.AllowListView || ViewPermissions.ViewTextChange || ViewPermissions.ViewFAQ || ViewPermissions.ViewMobileRecharge || ViewPermissions.ViewSecurityAwarness || ViewPermissions.ViewPrivacyPolicy || ViewPermissions.ViewMPNumberParameters || ViewPermissions.ViewMPPaymentParameters || ViewPermissions.ViewMPAppParameters || ViewPermissions.ViewMpSysAccounts || ViewPermissions.ViewUtilitiesli)
                {
                    ViewPermissions.ViewMPSettings = true;
                }

                //FormLanguages
                if (function.HasPermission(107, user) || function.HasPermission(108, user))
                {
                    ViewPermissions.ViewFormLanguages = true;
                }
                //PaymentTransactions
                if (function.HasPermission(27, user) || function.HasPermission(28, user))
                {
                    ViewPermissions.ViewPaymentTransactions = true;
                }

                //LotaltyTransactions

                if (function.HasPermission(196, user))
                {
                    ViewPermissions.ViewLoyaltyTransactions = true;
                }


                if (function.HasPermission(225, user))
                {
                    ViewPermissions.ViewAtmBranch = true;
                }


                //BranchTransaction
                if (function.HasPermission(70, user))
                {
                    ViewPermissions.ViewP2ETransaction = true;
                }

                //Transactions Catetgory
                if (ViewPermissions.ViewPaymentTransactions || ViewPermissions.ViewP2ETransaction || ViewPermissions.ViewLoyaltyTransactions || ViewPermissions.ViewReversePayment || ViewPermissions.ViewSpinAndWin || ViewPermissions.ViewAmbassadorPayment || ViewPermissions.ViewAcc2Acc || ViewPermissions.ViewCardPayment)
                {
                    ViewPermissions.ViewTransactions = true;
                }

                //ViewMPReports PTReports
                //if (function.HasPermission(45, user))
                //{
                //    ViewPermissions.ViewMPReports = true;
                //    ViewPermissions.ViewPTReports = true;
                //    ViewPermissions.ViewICReport = true;
                //}



                if (function.HasPermission(203, user))
                {
                    ViewPermissions.ViewAnnualReport = true;


                }


                if (function.HasPermission(204, user))
                {
                    ViewPermissions.ViewMPReports = true;


                }
                if (function.HasPermission(205, user))
                {
                    ViewPermissions.ViewPTReports = true;


                }
                if (function.HasPermission(206, user))
                {
                    ViewPermissions.ViewICReport = true;


                }

                if (function.HasPermission(250, user))
                {
                    ViewPermissions.ViewCreditTurnOver = true;


                }

                if (function.HasPermission(207, user))
                {
                    ViewPermissions.ViewMerchantOnlineProvider = true;


                }
                if (function.HasPermission(242, user))
                {

                    ViewPermissions.ViewUsersCards = true;

                }



                if (function.HasPermission(210, user))
                {
                    ViewPermissions.ViewAuditIndividualClients = true;


                }
                if (ViewPermissions.ViewAuditIndividualClients)
                {
                    ViewPermissions.ViewAudit = true;
                }



                //Reports Catetgory
                if (ViewPermissions.ViewAnnualReport || ViewPermissions.ViewMPReports || ViewPermissions.ViewPTReports || ViewPermissions.ViewICReport || ViewPermissions.ViewCreditTurnOver)
                {
                    ViewPermissions.ViewReports = true;
                }







                //Permission Policy
                if (function.HasPermission(118, user) || function.HasPermission(119, user))
                {
                    ViewPermissions.ViewPermissionPolicy = true;

                }


                //Invitation_Intro
                if (function.HasPermission(124, user) || function.HasPermission(125, user))
                {
                    ViewPermissions.ViewReferral = true;

                }






                if (function.HasPermission(163, user) || function.HasPermission(166, user))
                {
                    ViewPermissions.DefinitionPolicyView = true;

                }

                if (function.HasPermission(164, user) || function.HasPermission(167, user))
                {
                    ViewPermissions.FrameworkPolicyView = true;

                }

                if (function.HasPermission(165, user) || function.HasPermission(168, user))
                {
                    ViewPermissions.PrivacyPolicyInAppView = true;

                }






                if (function.HasPermission(121, user) || function.HasPermission(122, user) || function.HasPermission(123, user))
                {
                    ViewPermissions.ViewBillType = true;

                }

                if (function.HasPermission(126, user))
                {
                    ViewPermissions.ViewUserInvitations = true;

                }


                if (function.HasPermission(127, user) || function.HasPermission(128, user) || function.HasPermission(129, user))
                {
                    ViewPermissions.ViewLocationsPostalCodes = true;

                }


                if (function.HasPermission(139, user))
                {

                    ViewPermissions.ViewVideoChat = true;

                }



                if (function.HasPermission(172, user))
                {

                    ViewPermissions.AllowVideoChat = true;

                }






                if (function.HasPermission(171, user))
                {

                    ViewPermissions.AllowChat = true;

                }



                if (function.HasPermission(195, user))
                {

                    ViewPermissions.ViewSOHistory = true;

                }


                if (function.HasPermission(140, user))
                {

                    ViewPermissions.ViewServiceParameters = true;

                }

                if (function.HasPermission(141, user) || function.HasPermission(142, user))
                {

                    ViewPermissions.ViewInvitationSetting = true;

                }


                if (function.HasPermission(143, user) || function.HasPermission(144, user))
                {

                    ViewPermissions.ViewReconciliationSetting = true;

                }


                if (function.HasPermission(145, user) || function.HasPermission(146, user))
                {

                    ViewPermissions.ViewAMLSetting = true;

                }




                if (function.HasPermission(148, user) || function.HasPermission(149, user))
                {

                    ViewPermissions.ViewWalletSetting = true;

                }


                if (function.HasPermission(147, user) || function.HasPermission(150, user))
                {

                    ViewPermissions.ViewUserIdentityCheck = true;

                }
                if (function.HasPermission(152, user))
                {

                    ViewPermissions.ViewSupport = true;

                }


                if (function.HasPermission(137, user) || function.HasPermission(138, user))
                {


                    ViewPermissions.ViewExternalTransfer = true;
                }



                if (function.HasPermission(92, user))
                {
                    ViewPermissions.ViewDashBoard = true;

                }




                if (function.HasPermission(153, user))
                {
                    ViewPermissions.ViewCallCenter = true;

                }
                if (function.HasPermission(161, user))
                {
                    ViewPermissions.ViewAccounting = true;


                }
                if (function.HasPermission(174, user))
                {
                    ViewPermissions.ViewBORequest = true;

                }


                if (function.HasPermission(184, user))
                {

                    ViewPermissions.ViewMerchantBranches = true;


                }

                if (function.HasPermission(188, user))
                {

                    ViewPermissions.ViewTemplates = true;


                }

                if (function.HasPermission(199, user))
                {

                    ViewPermissions.ViewReversePayment = true;


                }

                if (function.HasPermission(222, user) || function.HasPermission(223, user) || function.HasPermission(224, user))
                {

                    ViewPermissions.ViewAcc2Acc = true;
                }




                if (function.HasPermission(230, user))
                {
                    ViewPermissions.ViewCardPayment = true;

                }


                if (function.HasPermission(231, user))
                {
                    ViewPermissions.ViewSMSException = true;

                }
                if (function.HasPermission(234, user))
                {
                    ViewPermissions.ViewCardRequest = true;

                }



                return ViewPermissions;
            }
            catch (Exception ex)
            {
                Functions function = new Functions();
       
                return null;
            }
        }

        private String isTrueLogin(string Username, string Password)
        {
            try
            {
                Functions function = new Functions();
                DataContext db = new DataContext();

                var BOUser = db.MBOUsers.Where(i => i.Username == Username).FirstOrDefault();
                if (BOUser == null)
                {
                    return "-1";
                }
                else
                {
                    if (BOUser.UserStatus.ToUpper() == "INACTIVE")
                    {
                        Session["Username"] = Username.ToUpper();
                        Session["User"] = BOUser;
                        return "-3";
                    }
                    else
                    {


                        string salt = BOUser.salt;
                        string hashedPasswordFromDB = BOUser.UserPass;
                        string passwordToCompare = salt + Password + StaticPepper;
                        Boolean valid = false;

                            valid = BCrypt.CheckPassword(passwordToCompare, hashedPasswordFromDB);



                        if (valid)
                        {

                              
                            Decimal UserID = BOUser.UserID;
                            var Profiles = db.MBOUserProfiles.Where(i => i.UserID == UserID).ToList();
                            List<Decimal> ProfileIDs = new List<Decimal>();

                            foreach (BOUserProfiles profile in Profiles)
                            {
                                ProfileIDs.Add(profile.ProfileID);
                            }

                            var functions = db.MBOProfileFunctions.Where(i => ProfileIDs.Contains(i.ProfileID)).Select(m => m.FunctionID).Distinct().ToList();
                            List<Decimal> FunctionIDs = new List<Decimal>();
                            foreach (Decimal functionID in functions)
                            {
                                FunctionIDs.Add(functionID);
                            }
                            db.SaveChanges();
                            Session["Username"] = Username.ToUpper();
                            Session["User"] = BOUser;
                            return "1";
                        }
                        else
                            return "-1";
                        }
                    }
                

            }
            catch (Exception ex)
            {
                Functions function = new Functions();
                return "-1";
            }
        }

    }
}