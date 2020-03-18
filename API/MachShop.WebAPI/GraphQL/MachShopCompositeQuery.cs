using GraphQL.Types;
using MachShop.WebAPI.BuildingBlocks.Abstract;
using System.Collections.Generic;

namespace MachShop.WebAPI.GraphQL
{
    public sealed class MachShopCompositeQuery : ObjectGraphType<object>
    {
        public MachShopCompositeQuery(IEnumerable<IGraphQueryMarker> graphQueryMarkers)
        {
            Name = "MachShopCompositeQuery";
            foreach (var marker in graphQueryMarkers)
            {
                var q = marker as ObjectGraphType<object>;
                foreach (var field in q.Fields)
                    AddField(field);
            }
        }
    }
}