using GraphQL.Types;
using System.Collections.Generic;
using MachShop.WebAPI.GraphQL.Configuration;

namespace MachShop.WebAPI.GraphQL
{
    public sealed class MachShopCompositeQuery : ObjectGraphType<object>
    {
        public MachShopCompositeQuery(IEnumerable<IGraphQueryMarker> graphQueryMarkers)
        {
            Name = nameof(MachShopCompositeQuery);
            foreach (var marker in graphQueryMarkers)
            {
                if (marker is ObjectGraphType<object> graphObject)
                {
                    foreach (var field in graphObject.Fields)
                    {
                        AddField(field);
                    }
                }
            }
        }
    }
}