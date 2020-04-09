using GraphQL.Types;
using MachShop.WebAPI.BuildingBlocks;
using System.Collections.Generic;

namespace MachShop.WebAPI.GraphQL
{
    public sealed class MachShopCompositeMutation : ObjectGraphType<object>
    {
        public MachShopCompositeMutation(IEnumerable<IGraphMutationMarker> graphMutationMarkers)
        {
            Name = "MachShopCompositeMutation";
            foreach (var marker in graphMutationMarkers)
            {
                var q = marker as ObjectGraphType<object>;
                foreach (var field in q.Fields)
                    AddField(field);
            }
        }
    }
}
