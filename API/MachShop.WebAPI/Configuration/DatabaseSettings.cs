using MachShop.Shared;

namespace MachShop.WebAPI.Configuration
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public bool UsePostgreSql { get; set; }
        public bool UseOracle { get; set; }
        public bool UseMSSql { get; set; }
    }
}
