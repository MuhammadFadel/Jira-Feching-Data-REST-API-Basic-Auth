namespace QRG
{
    public static class SD
    {
        public static string? JiraApiBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
