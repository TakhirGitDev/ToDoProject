namespace ToDo.Web
{
    public static class SD
    {
        public static string ToDoAPIBase { get; set; }
        public enum ApiType
        {
            GET,
            POST, 
            PUT, 
            DELETE
        }
    }
}
