namespace ExoTodo.Config
{
    public class Settings
    {
        public string DbConnectionString { get; set; }

        public string GetDbString()
        {
            var binder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            IConfiguration configuration = binder.Build();

            var SettingInfoDb = configuration.GetSection("Settings").Get<Settings>();

            string ConnectionString = SettingInfoDb.DbConnectionString;

            return ConnectionString;
        }
    }
}
