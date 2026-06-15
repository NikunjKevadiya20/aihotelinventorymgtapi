using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Common
{
    public static class CommonRepositoryConstants
    {
        public static string DefaultConnectionString { set; get; }
        public const string SQLDBConnection = "SQLConnection";
        public const string PreSQLParameter = "@";


        public const string PageIndex = "PAGE_INDEX";
        public const string PageSize = "PAGE_SIZE";
        public const string OrderBy = "ORDER_BY";
        public const string ItemCount = "ITEM_COUNT";
        public const string TotalPages = "TOTAL_PAGES";
        public const string Query = "QUERY";

        public const string SqlDatabase = "sql";
        public const string Sql = "SQL";
        public const string DatabaseTypeSetting = "DBType";
        public const string DatabaseEncrypted = "DBEncrypted";
        public const string Yes = "yes";

        public const string Entity = "Entity";
        public const string RepositoryConstants = "RepositoryConstants";

        public const string IsDateTime = "DateTime";
        public const string DateFormat = "dd-MM-yyyy";

        public const string PageIndexParameter = PreSQLParameter + "PAGE_INDEX";
        public const string PageSizeParameter = PreSQLParameter + "PAGE_SIZE";
        public const string OrderByParameter = PreSQLParameter + "ORDER_BY";
        public const string ItemCountParameter = PreSQLParameter + "ITEM_COUNT";
        public const string TotalPagesParameter = PreSQLParameter + "TOTAL_PAGES";
        public const string QueryParameter = PreSQLParameter + "QUERY";

        public const int Insert = 1;
        public const int Update = 2;
        public const int Delete = 1;
        public const int FindByID = 2;
        public const int FindAllItems = 3;
        public const int FindAllActive = 1;
        public const int UpdateActive = 4;
        public const int FindByItemCode = 2;
        public const int HardDelete = 3;
        /// <summary>
        /// BY PARESH SIR
        /// </summary>
        public const string UploadFolder = "uploads";
        public const string documentsFolder = "documents";      
        public const string Excel = "Excel";
        public const string RecordFile = "RecordFile";//Added by AI009 on 28-03-23
        public const string CircularAttachment = "CircularAttachments";
        public const string UserImage = "UserImage";
        public const string VisitorImage = "VisitorImage";
        public const string TransferImage = "TransferImage";
        public const string TourImage = "TourImage";
        public const string SightseenImage = "SightseenImage";
        public const string HotelsImage = "HotelsImage";
        public const string PurchaseOrderNo = "Preffix";
        public const string EmployeeDocumentAttched = "EmployeeDocumentAttch";
        public const string EmployeeEducation = "EmployeeEducation";

        public const string BlogImage = "BlogImage";
        public const string TestimonialImage = "TestimonialImage";
        public const string WorkFlow = "WorkFlow";
        public const string Industry = "Industry";
        public const string BannerImage = "BannerImage";
        public const string ClientLogo = "ClientLogo";
        public const string Uniforms = "Uniforms";
        public const string Services = "Services";
        public const string TeamMember = "TeamMember";
        public const string CMS = "CMS";
        public const string WebsiteImage = "WebsiteImage";

        public const string RazorpayKeyId = "rzp_test_RuXTSL9lCDE7XJ"; //demo
        public const string RazorpaySecretKey = "nGgUK0tMA2lxK95hnpwqpV4a"; //demo

        // Easebuzz
        public const string EasebuzzMerchantKey = "K6U7CHDY2";
        public const string EasebuzzSalt = "MU7YIKOH6";
        public const string EasebuzzEnv = "test";

        public const string SMSGateway = "http://sms5.magicsms.co.in/V2/http-api.php?apikey=eVlt8XRsgGXnjwVz&senderid=AJMODI&format=json&";
        public const string SMTPAddress = "smtp.gmail.com";
        public const string SMTPPort = "587";
        public const string EmailAddress = "booking@aalpine.in";
        public const string EmailDisplayName = "HotelBooking Booking";
        public const string EmailPassword = "qcwd rvym vphn xvye";

        public const string SecretKey = "HotelBookingTOKENKEYSECRETWEBISTEPROJECTS01";

        public const string ImageFilePath = "D:\\Projects\\S\\SolarMitra\\images.novotrips.com\\SOLARMITRA\\Uploads\\HotelBooking\\"; ////Demo

        //public const string ImageFilePath = "D:\\Projects\\S\\HotelBookingWeb\\images.HotelBookingbooking.com\\"; ////Live

    }
}
