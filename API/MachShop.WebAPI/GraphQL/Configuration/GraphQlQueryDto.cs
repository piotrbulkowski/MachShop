

namespace MachShop.WebAPI.GraphQL.Configuration
{
    public sealed class GraphQlQueryDto
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public string Variables { get; set; }
    }
}