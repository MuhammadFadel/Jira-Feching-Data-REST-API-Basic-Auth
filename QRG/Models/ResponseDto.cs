namespace QRG.Models
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; } = true;
        public string DisplayMessage { get; set; }
        public object Result { get; set; }
        public List<string> ErrorMessage { get; set; }
    }
}
