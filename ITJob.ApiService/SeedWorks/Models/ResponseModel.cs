namespace ITJob.ApiService.SeedWorks.Models
{
    public class ResponseModel
    {
        public string Message { get; set; }

        public ResponseMessageType Type { get; set; }

        public bool Success { get; set; }
    }

    public class ResponseContentModel : ResponseModel
    {
        public object Content { get; set; }
    }

    public enum ResponseMessageType
    {
        Error = 0,
        Success = 1,
        Warning = 2
    }
}