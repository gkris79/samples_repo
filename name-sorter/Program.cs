// See https://aka.ms/new-console-template for more information
using name_sorter;

try
{
    List<FullName> inputFullNames= null;
    IEnumerable<FullName> outputFullNames= null;
    List<IFullNameDataWriter> outputFullNamesWriters= new List<IFullNameDataWriter>();

    try
    {
        // Read the input file (filename specfified in args[0]) and get the list of the names as List<FullName>
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
            // Sort the names by lastName and then by First Name
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
                    // write the sorted list to file and the Console.
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

