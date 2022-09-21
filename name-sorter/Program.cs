// See https://aka.ms/new-console-template for more information
using NameSorter;

// the code snippet below will
// 1. read the list of names from a file,
// 2. sort the list based on Last Name and Given Name and
// 3. write the sorted list to a file and console screen

try
{
    // to store names read from input file.
    List<FullName> inputFullNames= null;

    // to store the names post sort
    IEnumerable<FullName> outputFullNames= null;

    // collection of output streams
    List<IFullNameDataWriter> outputFullNamesWriters= new List<IFullNameDataWriter>();

    
    try
    {
        // validate if the input file name was provided as a command line argument.
        if (args== null || args.Length == 0)
        {
            throw new ArgumentException($"Input file name is missing.\n\n use command : name-sorter.exe  filename.txt ");
        }

        // 1. Read the input file (filename specfified in args[0]) and get the list of the names as List<FullName>
        IFullNameDataReader dataReader = new FullNameTextFileReader();
        inputFullNames = dataReader.GetData(args[0]);        
    }
    catch (Exception ex)
    {
        // Let the user know what went wrong.
        Console.WriteLine(ex.Message);
    }

    if(inputFullNames != null)
    {
        if (inputFullNames.Count > 0)
        {
            // 2. Sort the names by lastName and then by First Name
            outputFullNames = inputFullNames.SortNames();
            if(outputFullNames != null)
            {
                // write the sorted output to the file
                IFullNameDataWriter fileWriter = new FullNameToTextFileWriter("sorted-names-list.txt");
                outputFullNamesWriters.Add(fileWriter);

                // write the sorted output to the console
                IFullNameDataWriter ConsoleWriter = new FullNameToConsoleWriter();
                outputFullNamesWriters.Add(ConsoleWriter);

                try
                {
                    // 3. write the sorted list to file and the Console.
                    foreach (IFullNameDataWriter writer in outputFullNamesWriters)
                    {
                        writer.WriteToOutput(outputFullNames);
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    } 

}
catch (Exception ex)
{
    // Let the user know what went wrong.
    Console.WriteLine(ex.Message);
}

