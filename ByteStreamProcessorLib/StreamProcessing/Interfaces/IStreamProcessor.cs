using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteStreamProcessorLib.StreamProcessing.Interfaces
{
    public interface IStreamProcessor
    {
        Task<IEnumerable<byte[]>> ProcessStreamAsync(Stream inputStream);
    }
}
