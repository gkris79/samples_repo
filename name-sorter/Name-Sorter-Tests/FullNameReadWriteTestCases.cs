
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using NameSorter;


namespace Name_Sorter_Tests
{
    

    [TestClass]
    public class FullNameWriterTestCases
    {
        [TestMethod]        
        public void WriteFileToFolderWithDefaultFilename()
        {
            IFullNameDataWriter writer = new FullNameToTextFileWriter();
            List<FullName> names = new List<FullName>();

            names.Add(new FullName("Hunter Uriah Nathan Clarke"));
            names.Add(new FullName("Hunter Uriah Clarke"));
            names.Add(new FullName("Hunter Uriah Mathew Clarke"));
            names.Add(new FullName("Hunter Clarke"));


            IEnumerable<FullName> result = names.SortNames();
            writer.WriteToOutput(result);

            Assert.IsTrue(File.Exists(@"output-list.txt"));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void WriteFileToFolderWithNoAccessPermissions()
        {
            IFullNameDataWriter writer = new FullNameToTextFileWriter(@"c:\out.txt");
            List<FullName> names = new List<FullName>();

            names.Add(new FullName("Hunter Uriah Nathan Clarke"));
            names.Add(new FullName("Hunter Uriah Clarke"));
            names.Add(new FullName("Hunter Uriah Mathew Clarke"));
            names.Add(new FullName("Hunter Clarke"));

           
            IEnumerable<FullName> result = names.SortNames();
            writer.WriteToOutput(result);
        }
    }

    [TestClass]
    public class FullNameTextFileReaderTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void ReadFromNonExistentFile()
        {
            IFullNameDataReader reader = new FullNameTextFileReader();
            reader.GetData("hello.txt");
        }
    }
}
