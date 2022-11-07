# MVRegistry
Easy to use registry

## Features
#### Key
- Create
- Delete
- Exists
- GetNames

#### Value
- CreateBinary
- CreateDWord
- CreateQWord
- CreateString
- CreateMultiString
- CreateExpandString
- CreateUnknown
- Delete
- GetNames
- GetValue

## using
````csharp
using MVRegistry;

try
{
    //Select HKEY_CURRENT_USER\Software
    RegEdit reg = new RegEdit(HKEY.CurrentUser, "Software");

    //Check if run as administrator
    if (reg.IsRunAsAdmin())
    {
        //Select HKEY_CURRENT_USER
        reg.HKEY = HKEY.CurrentUser;

        //This path exist this key or not?
        if (!reg.Key.Exists("MV Soft"))
        {
            //If not, create this key
            reg.Key.Create("MV Soft");
        }

        //Change path to "HKEY_CURRENT_USER\Software\MV Soft" for create value
        reg.Path = "Software\\MV Soft";

        //Create the Binary value in the byte array
        reg.Value.CreateBinary("Binary", new byte[] { 1, 2, 3, 4, 5, 6, 7 });

        //Create the DWord value in the Integer(32bit - 4byte)
        reg.Value.CreateDWord("DWord", 14);
        
        //Create the QWord value in the Integer(64bit - 8byte)
        reg.Value.CreateQWord("QWord", 14);
        
        //Create the String value in the string
        reg.Value.CreateString("String", "Coded By Soheil MV");

        //Create the ExpandString value in the string
        reg.Value.CreateExpandString("ExpandString", "Coded By Soheil MV");

        //Create the MultiString value in the string array
        reg.Value.CreateMultiString("MultiString", new string[] { "a", "b", "c", "d", "e", "f" });

        //Create the Unknown value in the Object
        reg.Value.CreateUnknown("Unknown", new string[] { "U", "N", "K", "N", "O", "W", "N" });

        Console.WriteLine("Successfully.");
    }
    else
    {
        Console.WriteLine("Please program run as admin!");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error : {ex.Message}");
}
````
