namespace IoTVoiceControl.Speech
{
    public class Result<T> where T : class
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Error { get; set; }

        public Result(T data, bool success = true, string error = null)
        {
            Success = success;
            Data = data;
            Error = error;
        }
    }
}
