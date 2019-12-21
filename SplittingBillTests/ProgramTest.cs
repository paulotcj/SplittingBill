using Microsoft.VisualStudio.TestTools.UnitTesting;
using SplittingBill;
using System.IO;
using System.Reflection;

namespace SplittingBillTests
{
    [TestClass]
    public class ProgramTest
    {
        //------------------------------------------------------------
        [TestMethod]
        public void ProgramTest_FileNotInformed()
        {
            string[] args = new string[0];
            string result = Program.CheckFilePath(args);
            string expected = "File not informed.";

            Assert.AreEqual(expected, result);


        }


        //------------------------------------------------------------
        [TestMethod]
        public void ProgramTest_InvalidFilePath()
        {
            string[] args = new string[1];
            args[0] = @"x:\fakedir\kvcdwrty\input.txt";
            string result = Program.CheckFilePath(args);
            string expected = "Invalid file or path.";
            Assert.AreEqual(expected, result);
        }


        //------------------------------------------------------------
        [TestMethod]
        public void ProgramTest_FileFound()
        {
            string[] args = new string[1];
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = path.Substring(0, path.Length - 42) + "SplittingBill\\inputFiles\\input.txt";
            args[0] = path;
            string result = Program.CheckFilePath(args);
            string expected = "File found";
            Assert.AreEqual(expected, result);
        }





    }
}
