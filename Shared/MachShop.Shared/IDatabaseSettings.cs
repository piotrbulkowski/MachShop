namespace MachShop.Shared
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }
        bool UsePostgreSql { get; }
        bool UseMSSql { get; }
    }
}
