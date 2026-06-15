using System.ComponentModel;

namespace HotelBooking.Entity.Common.Enums
{
    
    public enum RequestHotelBookingrceType : byte
    {
        Android = 1,
        IPhone = 2,
        NajmWebPortal = 3,
        SubmissionProcess = 4
    }
    public enum ResponseStatus : short
    {
        Success = 1,
        EmptyResult = 2,
        ValidationError = 3,
        Exception = 4,
        Failed = 5,
        RequestParameterNotPassed = 6,
        ClaimNotExists = 7
    }
    public enum ResponseStatusCode
    {
        Success = 200,
        Created = 201,
        NoDataFound = 204,
        Unauthorized = 401,
        BadRequestError = 400,
        NotFound = 404,
        UnsupportedMediaType = 415,
        InternaServerError = 500,
        Timeouterror = 504,
        Datavalidation = 2,
        BusinessError = 3,
        TokenExpired = 419,
        RefreshTokenExpired = 420
    }
    public enum ErrorMessage
    {
        [Description("Not authorized")]
        NotAuthorize = 101,
        [Description("Authentication failure")]
        AuthenticationFail = 102,
        [Description("Unknown Error")]
        UnKnownError = 103,
        [Description("Bad Request")]
        BadRequest = 104,
        [Description("No Record Found")]
        NoRecodFound = 105,
        [Description("AM Server is Down")]
        OverQueryLimit = 106,
        [Description("Request parameter not correct")]
        RequestParameterNotPassed = 107,
        [Description("Required Parameter not passed")]
        RequiredParameterNotPassed = 108,
       
    }
}
