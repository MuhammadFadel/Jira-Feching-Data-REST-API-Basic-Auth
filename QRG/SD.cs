namespace QRG
{
    public static class SD
    {
        public static string? JiraApiBase { get; set; }
        public static string? GitlabApiBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
