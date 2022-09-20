using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace name_sorter
{ 
    
    /// <summary>
    /// Helper Class to perform Sorting of the 
    /// </summary>
    public static class SortNamesExtension
    {
        public static IEnumerable<FullName> SortNames(this IEnumerable<FullName> fullNames, IComparer<FullName> comparable)
        {
            IEnumerable<FullName> result = fullNames.ToList<FullName>();

            if (comparable != null)
                ((List<FullName>)result).Sort(comparable);
            else
            {
                // sort by Last Name
                ((List<FullName>)result).Sort();
            }

            return result;

        }

        public static IEnumerable<FullName> SortNames(this IEnumerable<FullName> fullNames)
        {
            // using LINQ query to orderby LastName and then by Given Name
            return fullNames.OrderBy(name => name.LastName).ThenBy(name => name.GivenName);
        }

    }


}
