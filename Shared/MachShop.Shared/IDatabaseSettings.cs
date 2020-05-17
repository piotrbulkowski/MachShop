namespace MachShop.Shared
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }
        bool UsePostgreSql { get; set; }
        bool UseOracle { get; set; }
        bool UseMSSql { get; set; }
    }
}
