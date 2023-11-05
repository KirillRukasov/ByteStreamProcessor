using ByteStreamProcessorLib.StreamProcessing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteStreamProcessorLib.StreamProcessing
{
    public class MessageReader : IStreamProcessor
    {
        private readonly byte _delimiter;

        public MessageReader(byte delimiter)
        {
            _delimiter = delimiter;
        }

        public async Task<IEnumerable<byte[]>> ProcessStreamAsync(Stream inputStream)
        {
            if (inputStream == null) throw new ArgumentNullException(nameof(inputStream));
            if (!inputStream.CanRead) throw new InvalidOperationException("Stream cannot be read.");

            var messages = new List<byte[]>();
            var buffer = new List<byte>();
            var byteBuffer = new byte[1];
            int bytesRead;

            while ((bytesRead = await inputStream.ReadAsync(byteBuffer, 0, 1)) != 0)
            {
                byte readByte = byteBuffer[0];
                if (readByte != _delimiter)
                {
                    buffer.Add(readByte);
                }
                else if (buffer.Count > 0)
                {
                    messages.Add(buffer.ToArray());
                    buffer.Clear();
                }
            }

            if (buffer.Count > 0)
            {
                messages.Add(buffer.ToArray());
            }

            return messages;
        }
    }
}
