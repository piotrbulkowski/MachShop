namespace MachShop.WebAPI.BuildingBlocks
{
    public class GraphQlQuery
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
    }
}