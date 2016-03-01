using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.IO;
using WTS.WorkSuite.Library.IO.Cryptography;

namespace WorkSuite.Library.IO.Cryptography.Tests
{
    [TestClass]
    public class FileHelperExtensions_will
    {
        [TestMethod]
        public void get_byte_array_for_a_valid_stream()
        {
            var stub = new byte[] { 0x20, 0x20, 0x20 };

            var md5_value = new FileHelper().GetMD5Value(stub);

            Assert.AreEqual("628631f07321b22d8c176c200c855e1b", md5_value);
        }
    }
}
