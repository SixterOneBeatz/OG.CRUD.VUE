namespace OG.CRUD.VUE.Application.Common.Exceptions
{
    public class GlobalException : ApplicationException
    {
        public GlobalException(int statusCode, string details = null, string type = null, string instance = null)
        {
            Status = statusCode;
            Title = GetDefaultMessageStatusCode(statusCode);
            Detail = details;
            Type = type;
            Instance = instance;
        }

        public int? Status { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public string Type { get; set; }
        public string Instance { get; set; }

        private string GetDefaultMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Request sended has errors",
                401 => "You are not authorized",
                404 => "Resource requested was not found",
                500 => "Internal server error",
                _ => string.Empty
            };
        }
    }
}
