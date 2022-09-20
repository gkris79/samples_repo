using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using NameSorter;
using System.Collections.Generic;

namespace Name_Sorter_Tests
{
    [TestClass]
    public class FullNameTestCases
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]

        /// <summary>
        ///  Validate the input for the full name is in the format "Given Name" "Last Name"
        /// </summary>
        public void TestFullNameFormat()
        {
            FullName obj = new FullName("Girish");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]

        /// <summary>
        ///  Validate the input for the Given Name does not have more than 3 given names. 
        /// </summary>
        public void TestGivenNameCount()
        {
            FullName obj = new FullName("Hunter Uriah Nathan John Clarke");
        }


       

    }
}