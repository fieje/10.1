using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFindFourthDot()
        {
            string filePath = "test_dot.txt";
            File.WriteAllText(filePath, "This is a test .txt file. With some dots. Here is another dot. And this is the fourth dot.");

            Program.FindFourthDot(filePath, out int lineNumber, out int position);

            Assert.AreEqual(1, lineNumber);
            Assert.AreEqual(25, position);

            File.Delete(filePath);
        }

        [TestMethod]
        public void TestFindFourthDot_NotFound()
        {
            string filePath = "test_dot.txt";
            File.WriteAllText(filePath, "This is a test .txt file. With some dots. Here is another dot.");

            Program.FindFourthDot(filePath, out int lineNumber, out int position);

            Assert.AreEqual(1, lineNumber);
            Assert.AreEqual(16, position);

            File.Delete(filePath);
        }

        [TestMethod]
        public void TestFindFourthDot_FileNotFound()
        {
            string filePath = "non_existing_file.txt";

            Assert.ThrowsException<FileNotFoundException>(() => Program.FindFourthDot(filePath, out _, out _));
        }
    }
}
