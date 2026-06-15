using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Common
{
    public static class CommonRepositoryMessages
    {
        public const string NotFoundMessageEN = "No data found";
        
        public const string CannotInsertMessage = "Cannot add";
        public const string CannotInsertDetails= "Cannot add, Please contact technical support";

        public const string CannotUpdateMessage = "Cannot Update";
        public const string CannotUpdateDetails = "Cannot Update, Please contact technical support";

        public const string CannotDeleteMessage = "Cannot Delete";
        public const string CannotDeleteDetails = "Cannot Delete, Please contact technical support";

        public const string CannotFindByIDMessage = "No data found";
        public const string CannotFindByIDDetails = "No data found related to the current id";

        public const string CannotFindAllMessage = "No data found";
        public const string CannotFindAllDetails = "No data found";

        public const string FindAllMessage = "success";
        public const string FAILUREMessage = "failure";
        public const string DataFoundSuccessFully = "Data Found SuccessFully";

        public const string InsertSuccessMessage = "Saved successfully";

        public const string DeleteSuccessMessage = "Deleted successfully";

        public const string UpdateSuccessMessage = "Modified successfully";

        public const string RejectedSuccessMessage = "Rejected successfully";

        public const string ExceptionMessage = "An unexpected error occurred, please see the system administrator";
        public const string AlreadyExistMessage = "Record Already Exist";

        public const string GeneralMessageSuccess = "Operation completed successfully.";
        public const string LoginMessage = "MobileNo And Password Does Not Match.";
        public const string StudentMessage = "Either Email or Mobile No Already Exsist.";
        /// <summary>
        /// BY PARESH SIR
        /// </summary>
        public const string FileUploadMessage = "File uploaded successfully.";
        public const string FileMissingMessage = "Cannot Upload File .";
        public const string StudentNotFound = "Student Not Found";
        /// <summary>
        /// BY Zeel Patel
        /// </summary>
        public const string DeleteIDMessage = "ID Doesnot Exist";
        public const string BarcodeUsed = "Barcode Used";
        public const string BookIssued = "BookIssued";
        public const string BarcodeAdded = "Barcode Added";
        public const string TokenExprired = "Token has Exprired!";
    }
}
