using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using WTS.WorkSuite.Library.IO;

namespace WorkSuite.Library.IO.Tests
{
    [TestClass]
    public class FileHelper_will
    {
        [TestMethod]
        public void get_byte_array_for_a_valid_stream()
        {
            var stub = new byte[] { 0x20, 0x20, 0x20 };

            var stream = new MemoryStream(stub);

            var data = FileHelper.get_file_as_byte_array_from_stream(stream);

            Assert.AreEqual(stub[0], data[0]);
            Assert.AreEqual(stub[1], data[1]);
            Assert.AreEqual(stub[2], data[2]);
        }


        [TestInitialize]
        public void before_each_test()
        {
            //input_stream = MockRepository.GenerateMock<Stream>();

            //input_stream.Stub(m => m.CanWrite).Return(true);

            //input_stream.Expect(m => m.Write(Arg<byte[]>.Is.Anything, Arg<int>.Is.Anything, Arg<int>.Is.Anything))
            //            .Callback((byte[] bytes, int offs, int c) => true);
        }
    }
}
