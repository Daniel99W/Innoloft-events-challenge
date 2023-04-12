using EventsAPI.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAPI.DAL
{
    public static class ExtensionMethods
    {
        public static Pagination<T>
            Paginate<T>(this IQueryable<T> query, int page, int itemsPerPage)
        {
            int rowsToBeSkiped = itemsPerPage * page - itemsPerPage;

            int totalItems = query.Count();

            List<T> results = query
                .Skip(rowsToBeSkiped)
                .Take(itemsPerPage)
                .ToList();

            Pagination<T> paginated = new()
            {
                CurrentPage = page,
                TotalPages =
                Convert.ToInt16(Math.Ceiling((double)totalItems / itemsPerPage)),
                Results = results
            };

            return paginated;
        }
    }
}
