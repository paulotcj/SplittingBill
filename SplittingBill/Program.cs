using System;
using System.IO;

namespace SplittingBill
{
    public class Program
    {
        static string strInputFile;
        static string path;
        static string strFileOutput;
        static System.IO.StreamReader file;
        static System.IO.StreamWriter fileOutput;

        static void Main(string[] args)
        {
            string fileExists = CheckFilePath(args);

            if (String.Equals("File found", fileExists))
            {
                try {

                    InitializeVariables(args[0]);

                    ProcessFile();
                }
                catch(Exception e) { Console.WriteLine("SplittingBill error message: " +e.Message + "\n End of error."); }
                finally
                {
                    file.Close();
                    fileOutput.Close();
                }
            }



            Console.WriteLine("Press any key to finish.");
            Console.ReadKey();
        }




        //----------------------------------------------------------------------------
        /// <summary>
        /// Ensures the file informed is valid.
        /// </summary>
        /// <param name="args">The full file path of the source file should be informed at args[0]</param>
        public static string CheckFilePath(string[] args)
        {
            if (args.Length != 1)
            {
                string strReturn = "File not informed.";
                Console.WriteLine(strReturn);
                return strReturn;
            }
            else if (!File.Exists(args[0]))
            {
                string strReturn = "Invalid file or path.";
                Console.WriteLine(strReturn);
                return strReturn;
            }
            else
            {
                Console.WriteLine("File: " + args[0]);
                return "File found";
            }
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Initialize program's variables.
        /// </summary>
        /// <param name="args">String containing the full path of the source file</param>
        public static void InitializeVariables(string args)
        {
            strInputFile = args;
            path = Path.GetDirectoryName(strInputFile) + "\\";
            strFileOutput = path + Path.GetFileName(strInputFile) + ".out";


            file = new System.IO.StreamReader(strInputFile);
            fileOutput = new System.IO.StreamWriter(strFileOutput);
        }


        //----------------------------------------------------------------------------
        public static void ProcessFile()
        {
            //loop through each event
            //  guarantees that even files that do not terminate with 0 will finish the loop
            string line;
            //--------------------------------------------------
            while ((line = file.ReadLine()) != null && !line.Equals("0"))
            {

                //first line is the number of participants
                int accounts = int.Parse(line);

                Calculator calc = new Calculator(accounts);

                //----------------------------------------------
                //loop through accounts
                for (int i = 0; i < accounts; i++)
                {
                    if ((line = file.ReadLine()) != null)
                    {
                        int numReceipts = int.Parse(line);

                        //--------------------------------------
                        //loop through recepits
                        for (int j = 0; j < numReceipts; j++)
                        {
                            if ((line = file.ReadLine()) != null)
                            {
                                //in thise case we use the index 'i' (used one level above), because we are adding up to accounts
                                calc.AccountPay(i, decimal.Parse(line));
                            }

                        }
                        //--------------------------------------


                    }

                }
                //----------------------------------------------
                fileOutput.WriteLine(calc.ToString());
                Console.WriteLine(calc.ToString());
            }
            //--------------------------------------------------

        }
    }

}
