using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagmentBO.Models
{



    public class LoginModel
    {
        [Required(ErrorMessage = "Username Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public String ApplicationName { get; set; }
        public String TimeStamp { get; set; }
        public String Error { get; set; }

        public string strusername { get; set; }

        public Boolean IncorrectLogin { get; set; }
    }


    public class PasswordModel
    {
        [Required(ErrorMessage = "Username Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Old Password Required")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmation Password Required")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string Error { get; set; }

    }

    public class ViewPermissions
    {

        public Boolean ViewBOSettings { get; set; }
        public Boolean ViewBOUsers { get; set; }
        public Boolean ViewProfiles { get; set; }
        public Boolean ViewFunctions { get; set; }
        public Boolean ViewCreditTurnOver { get; set; }
        public Boolean ViewExternalLinks { get; set; }
        public Boolean ViewaddExternalLinks { get; set; }


        public Boolean ViewIndividualClients { get; set; }
        public Boolean ViewExpress { get; set; }
        public Boolean ViewICView { get; set; }
        public Boolean ViewLite { get; set; }
        public Boolean ViewMiscellaneousIR { get; set; }

        public Boolean ViewLogs { get; set; }
        public Boolean ViewBOLogs { get; set; }
        public Boolean ViewMPLogs { get; set; }
        public Boolean ViewBORequest { get; set; }
        public Boolean ViewMerchantSettings { get; set; }
        public Boolean ViewAccounts { get; set; }
        public Boolean ViewAddLoyalty { get; set; }
        public Boolean ViewAddOffer { get; set; }
        public Boolean ViewLoyaltyExceptions { get; set; }
        public Boolean ViewMerchantAppUsers { get; set; }
        public Boolean ViewMerchantCategory { get; set; }
        public Boolean ViewMerchantClient { get; set; }
        public Boolean ViewMerchantEnrollment { get; set; }
        public Boolean ViewMerchantRegion { get; set; }
        public Boolean ViewMerchantSubCategory { get; set; }
        public Boolean ViewviewLoyalty { get; set; }
        public Boolean ViewviewOffers { get; set; }

        public Boolean ViewMessages { get; set; }
        public Boolean ViewMarketingMessage { get; set; }
        public Boolean ViewReceivedMessages { get; set; }
        public Boolean ViewSMSMessages { get; set; }
        public Boolean ViewviewMessages { get; set; }

        public Boolean ViewArchivedVideo { get; set; }
        public Boolean ViewChatMessages { get; set; }





        public Boolean ViewMPSettings { get; set; }
        public Boolean ViewFAQ { get; set; }
        public Boolean ViewMobileRecharge { get; set; }
        public Boolean ViewMPAppParameters { get; set; }
        public Boolean ViewMPNumberParameters { get; set; }
        public Boolean ViewMPPaymentParameters { get; set; }
        public Boolean ViewMpSysAccounts { get; set; }
        public Boolean ViewPrivacyPolicy { get; set; }
        public Boolean ViewPrivacyPolicyExpress { get; set; }
        public Boolean ViewPrivacyPolicyLite { get; set; }
        public Boolean ViewSecurityAwarness { get; set; }
        public Boolean ViewTextChange { get; set; }
        public Boolean ViewFormLanguages { get; set; }
        public Boolean ViewProviders { get; set; }



        public Boolean ViewTranslatedData { get; set; }
        public Boolean ViewTransactions { get; set; }
        public Boolean ViewPaymentTransactions { get; set; }

        public Boolean ViewLoyaltyTransactions { get; set; }

        public Boolean ViewReports { get; set; }
        public Boolean ViewPTReports { get; set; }
        public Boolean ViewMPReports { get; set; }
        public Boolean ViewICReport { get; set; }
        public Boolean ViewExpirationLiteUsersReport { get; set; }
        public Boolean AllowListView { get; set; }
        public Boolean ViewLanguagesli { get; set; }
        public Boolean ViewUtilitiesli { get; set; }



        public Boolean ViewLanguagesPage { get; set; }
        public Boolean ViewVariables { get; set; }
        public Boolean ViewImportLanguage { get; set; }
        public Boolean ViewP2ETransaction { get; set; }
        public Boolean ViewUALogs { get; set; }


        public Boolean ViewPermissionPolicy { get; set; }

        public Boolean ViewBillType { get; set; }

        public Boolean ViewReferral { get; set; }


        public Boolean ViewUserInvitations { get; set; }
        public Boolean ViewLocationsPostalCodes { get; set; }


        public Boolean ViewUsersDraw { get; set; }
        public Boolean ViewUsersDrawResults { get; set; }

        public Boolean ViewSOHistory { get; set; }





        public Boolean ViewAMLBlockedUsers { get; set; }
        public Boolean ViewAMLList { get; set; }

        public Boolean ViewVideoChat { get; set; }




        public Boolean ViewServiceParameters { get; set; }
        public Boolean ViewDrawConfig { get; set; }


        public Boolean ViewInvitationSetting { get; set; }

        public Boolean ViewReconciliationSetting { get; set; }

        public Boolean ViewAMLSetting { get; set; }

        public Boolean ViewWalletSetting { get; set; }


        public Boolean ViewUserIdentityCheck { get; set; }
        public Boolean ViewSupport { get; set; }
        public Boolean ViewExternalTransfer { get; set; }
        public Boolean ViewDashBoard { get; set; }
        public Boolean ViewCallCenter { get; set; }



        public Boolean ViewBOQuestionSubmission { get; set; }
        public Boolean ViewBOAnswerSubmission { get; set; }
        public Boolean ViewAccounting { get; set; }


        public Boolean DefinitionPolicyView { get; set; }
        public Boolean FrameworkPolicyView { get; set; }
        public Boolean PrivacyPolicyInAppView { get; set; }

        public Boolean AllowVideoChat { get; set; }
        public Boolean AllowChat { get; set; }

        public Boolean ViewMerchantBranches { get; set; }
        public Boolean ViewTemplates { get; set; }
        public Boolean ViewReversePayment { get; set; }
        public Boolean ViewAmbassador { get; set; }

        public Boolean ViewAnnualReport { get; set; }


        public Boolean ViewMerchantOnlineProvider { get; set; }

        public Boolean ViewAuditIndividualClients { get; set; }
        public Boolean ViewAudit { get; set; }


        public Boolean ViewSpinAndWin { get; set; }
        public Boolean ViewAmbassadorPayment { get; set; }

        public Boolean ViewException { get; set; }

        public Boolean ViewBoomerang { get; set; }
        public Boolean ViewAcc2Acc { get; set; }

        public Boolean ViewAtmBranch { get; set; }
        public Boolean ViewCardAllowList { get; set; }


        public Boolean ViewCardPayment { get; set; }

        public Boolean ViewSMSException { get; set; }

        public Boolean ViewCardRequest { get; set; }

        public Boolean ViewUsersCards { get; set; }

        public Boolean ViewDocumentsManager { get; set; }

        public Boolean ViewDocuments { get; set; }
        public Boolean ViewDocumentsList { get; set; }

        public Boolean ViewMerchantBlackList { get; set; }


        public Boolean ViewCampaign { get; set; }
    }





    public class LayoutPermission
    {
        public Boolean AllowVideoChat { get; set; }
        public Boolean AllowChat { get; set; }
        public Boolean ViewFormLanguages { get; set; }
        public Boolean ViewTextChange { get; set; }
        public Boolean ViewUserIdentityCheck { get; set; }
        public Boolean ViewBORequest { get; set; }
        public Boolean ViewArchivedVideo { get; set; }
        public Boolean ViewAMLBlockedUsers { get; set; }

        public Boolean ViewCampaign { get; set; }
    }




    [Table("BOUsers")]
    public class BOUsers
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Decimal UserID { get; set; }
        public String Username { get; set; }
        public String UserPass { get; set; }
        public String UserStatus { get; set; }
        public String salt { get; set; }
        public String SessionID { get; set; }

    }


    [Table("BOUserProfiles")]
    public class BOUserProfiles
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Decimal ID { get; set; }
        public Decimal UserID { get; set; }
        public Decimal ProfileID { get; set; }
    }


    [Table("BOProfileFunctions")]

    public class BOProfileFunctions
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Decimal ID { get; set; }
        public Decimal ProfileID { get; set; }
        public Decimal FunctionID { get; set; }
        public String Status { get; set; }
    }


    [Table("BOProfiles")]
    public class BOProfiles
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Decimal ProfileID { get; set; }
        public String ProfileDesc { get; set; }


    }


}
