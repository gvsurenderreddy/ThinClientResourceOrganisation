using System.IO;

namespace WTS.WorkSuite.Library.IO
{
    public class FileHelper
    {
        public static byte[] get_file_as_byte_array_from_stream(Stream inputStream)
        {
            var contentLength = (int)inputStream.Length;
            var br = new BinaryReader(inputStream);
            br.BaseStream.Position = 0;
            var filebytearray = br.ReadBytes(contentLength);
            return filebytearray;
        }
    }
}
