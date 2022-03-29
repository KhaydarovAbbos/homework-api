using System.Collections.Generic;
using System.Linq;

namespace Homework.Api.Service.Extensions
{
    public static class CollectionExtensions
    {
        public static IEnumerable<T> ToPagenation<T>(this IEnumerable<T> source, int pageSize, int pageIndex)
        {
            return pageSize >= 0 && pageIndex > 0 ? source.Skip(pageSize * (pageIndex - 1)).Take(pageSize) : source;
        }
    }
}
