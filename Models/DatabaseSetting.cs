namespace restertaunt.Models
{
    public class DatabaseSetting : IDatabaseSetting
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }
    public interface IDatabaseSetting
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }


    }
}