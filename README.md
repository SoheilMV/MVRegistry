# MVRegistry
Easy to use registry

## using
````csharp
using MVRegistry;

            try
            {
                RegEdit reg = new RegEdit();
                if (reg.IsRunAsAdmin()) //program run as admin
                {
                    reg.HKEY = HKEY.CurrentUser; //Select HKEY_CURRENT_USER 
                    reg.Address = "Software"; //HKEY_CURRENT_USER\Software
                    if (!reg.Key.Exists("MV Soft")) //This path exist this key or not?
                    {
                        reg.Key.Create("MV Soft"); //If not, create this key
                    }
                    reg.Address = "Software\\MV Soft"; //path "HKEY_CURRENT_USER\Software\MV Soft" for create value

                    //Create the Binary value in the string
                    reg.Value.CreateBinary("Binary1", "1,2,3,4,5,6,7");

                    //Create the Binary value in the byte array
                    reg.Value.CreateBinary("Binary2", new byte[] { 1, 2, 3, 4, 5, 6, 7 });

                    //Create the DWord value in the Integer
                    reg.Value.CreateDWord("DWord", 14);

                    //Create the ExpandString value in the string
                    reg.Value.CreateExpandString("ExpandString", "Coded By Soheil MV");

                    //Create the MultiString value in the string array
                    reg.Value.CreateMultiString("MultiString", new string[] { "a", "b", "c", "d", "e", "f" });

                    //Create the QWord value in the Integer
                    reg.Value.CreateQWord("QWord", 14);

                    //Create the String value in the string
                    reg.Value.CreateString("String", "Coded By Soheil MV");

                    //Create the Unknown value in the Object
                    reg.Value.CreateUnknown("Unknown", new string[] { "U", "N", "K", "N", "O", "W", "N" });

                    MessageBox.Show("Successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please program run as admin", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch
            {
                MessageBox.Show("Error");
            }


````
