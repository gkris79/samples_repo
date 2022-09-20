using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace name_sorter
{
    /// <summary>
    ///  Read FullNames data from a file in the file system
    /// </summary>
    public interface IFullNameDataReader
    {
        public List<FullName> GetData(string fileName);
    }

    /// <summary>
    ///  Write FullNames data from a file in the file system
    /// </summary>
    public interface IFullNameDataWriter
    {
        /// <summary>
        /// write the data to the output destination
        /// </summary>
       /// <param name="names">list of names to be written to the file</param>
        public void WriteToOutput(IEnumerable<FullName> names);
    }


    /// <summary>
    ///  To write data to file in a .txt format
    /// </summary>
    public class FullNameToTextFileWriter : IFullNameDataWriter
    {
        public string FileName { get; set; }

        public FullNameToTextFileWriter()
        {
            FileName = "output-list.txt";
        }

        public FullNameToTextFileWriter(string fileName)
        {
            FileName = fileName;
        }

        /// <summary>
        /// Write the list of the names to the .txt file specified in FileName property.
        /// </summary>
        /// <param name="names"></param>
        /// <exception cref="InvalidDataException"> Exception while writing output to the file. Inner Exception will have more details</exception>
        void IFullNameDataWriter.WriteToOutput(IEnumerable<FullName> names)
        {
            try
            {
                
                FileStreamOptions options = new FileStreamOptions();
                options.Access = FileAccess.Write;
                options.Mode = FileMode.Create;

                // Create an instance of StreamWriter to write to a file.
                // The using statement also closes the StreamWriter.
                using (StreamWriter writer = new StreamWriter(FileName, options))
                {
                    foreach (FullName name in names)
                    {
                        // write the name to the file.
                        writer.WriteLine(name.ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                throw new InvalidDataException($" Failed to write the data to file {FileName} .", ex);
            }

        }
    }


    /// <summary>
    ///  To write the data to the output Console 
    /// </summary>
    public class FullNameToConsoleWriter : IFullNameDataWriter
    {        
        /// <summary>
        ///  write the names  to the output console.
        /// </summary>
        /// <param name="names"></param>
        void IFullNameDataWriter.WriteToOutput(IEnumerable<FullName> names)
        {
            foreach (FullName name in names)
            {
                // write the name to the console screen.
               Console.WriteLine(name.ToString());
            }            

        }
    }

    /// <summary>
    ///  To read data from a .txt file
    /// </summary>
    public class FullNameTextFileReader : IFullNameDataReader
    {
        /// <summary>
        ///  Read the data from a .txt file.
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        /// <returns>Collection of FullName instances. Collection is empty if any excepion occurs.</returns>
        /// <exception cref="InvalidDataException"> Exception while reading names from the file. Inner Exception will have more details.</exception>
        List<FullName> IFullNameDataReader.GetData(string fileName)
        {
            List<FullName> fullNames = new List<FullName>();

            try
            {
                if (File.Exists(fileName))
                {
                    // Create an instance of StreamReader to read from a file.
                    // The using statement also closes the StreamReader.
                    using (StreamReader reader = new StreamReader(fileName))
                    {
                        string line;

                        // Read lines from the file until the end of
                        // the file is reached.
                        while ((line = reader.ReadLine()) != null)
                        {
                            // ignore empty new line entries
                            if (line.Trim().Length > 0)
                                fullNames.Add(new FullName(line));
                        }
                    }
                }
                else
                {
                    throw new FileNotFoundException($"File Not found : '{fileName}'");
                }

            }
            catch (Exception ex)
            {
                fullNames.Clear();
                throw new InvalidDataException($" Failed to read the data from file {fileName} .", ex);
            }

            return fullNames;

        }
    }
}
