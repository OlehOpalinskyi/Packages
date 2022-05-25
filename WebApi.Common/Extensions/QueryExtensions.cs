using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;

namespace WebApi.Common.Extensions
{
    public static class QueryExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int pageNumber, 
            int pageSize, out int totalItems)
            where T: class
        {
            totalItems = query.Count();

            if (pageNumber <= 0 || pageSize <= 0) return query;
            
            return totalItems == 0 ? query : query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
        
        public static IQueryable<T> ApplySort<T>(this IQueryable<T> entities, string orderByQueryString)
		{
            if (!entities.Any())
                return entities;
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return entities;
            }

            var orderQueryBuilder = new StringBuilder();
            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var navigationProperties = propertyInfos.Where(x =>
                !x.PropertyType.IsValueType && !x.PropertyType.IsGenericType && x.PropertyType != typeof(string));

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(' ')[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi =>
                    pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                var sortingOrder = param.EndsWith(" desc") ? "descending" : "ascending";
                if (objectProperty == null)
				{
                    var navigationProperty = CheckNavigationProperties(propertyFromQueryName, navigationProperties, sortingOrder);

                    if (!string.IsNullOrEmpty(navigationProperty))
                        orderQueryBuilder.Append(navigationProperty);

                    continue;
                }
                
                orderQueryBuilder.Append($"{objectProperty.Name} {sortingOrder}, ");
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            return string.IsNullOrEmpty(orderQuery) ? entities : entities.OrderBy(orderQuery);
        }

        private static string CheckNavigationProperties(string propertyFromQueryName, IEnumerable<PropertyInfo> navigationProperties, string sortingOrder)
		{
            foreach(var propInfo in navigationProperties)
			{
                var prop = propInfo.PropertyType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                var objectProperty = prop.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;

                return $"{propInfo.Name}.{objectProperty.Name} {sortingOrder}, ";
            }

            return string.Empty;
		}
    }
}