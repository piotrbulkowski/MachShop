using GraphQL.Types;
using System.Collections.Generic;
using MachShop.WebAPI.GraphQL.Configuration;

namespace MachShop.WebAPI.GraphQL
{
    public sealed class MachShopCompositeMutation : ObjectGraphType<object>
    {
        public MachShopCompositeMutation(IEnumerable<IGraphMutationMarker> graphMutationMarkers)
        {
            Name = nameof(MachShopCompositeMutation);
            foreach (var marker in graphMutationMarkers)
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
