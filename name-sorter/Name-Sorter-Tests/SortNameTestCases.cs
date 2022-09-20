using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NameSorter;

namespace Name_Sorter_Tests
{
    [TestClass]
    public class SortNameTestCases
    {
        [TestMethod]

        /// <summary>
        ///  Validate the Sort function does not return null for a valid list of Names. 
        /// </summary>
        public void ValidateGivenNameSortOrderReturnValueIsNotNull()
        {

            List<FullName> names = new List<FullName>();

            names.Add(new FullName("Hunter Uriah Nathan Clarke"));
            names.Add(new FullName("Hunter Uriah Clarke"));
            names.Add(new FullName("Hunter Uriah Mathew Clarke"));

            IEnumerable<FullName> result = names.SortNames();
            Assert.IsNotNull(result);
        }

        /// <summary>
        ///  Test to validate the Given Names are ordered as
        ///  1 Given Name > 2 Given Names > 3 Given Names 
        /// </summary>
        [TestMethod]

        
        public void ValidateGivenNameSortOrder()
        {

            List<FullName> names = new List<FullName>();

            names.Add(new FullName("Hunter Uriah Nathan Clarke"));
            names.Add(new FullName("Hunter Uriah Clarke"));
            names.Add(new FullName("Hunter Uriah Mathew Clarke"));
            names.Add(new FullName("Hunter Clarke"));


            IEnumerable<FullName> result = names.SortNames();

            Assert.AreEqual("Hunter Clarke", result.ElementAt(0).ToString());
            Assert.AreEqual("Hunter Uriah Clarke", result.ElementAt(1).ToString());
            Assert.AreEqual("Hunter Uriah Mathew Clarke", result.ElementAt(2).ToString());
            Assert.AreEqual("Hunter Uriah Nathan Clarke", result.ElementAt(3).ToString());

        }
       
    }
}
