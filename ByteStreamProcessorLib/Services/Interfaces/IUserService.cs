using ByteStreamProcessorLib.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteStreamProcessorLib.Services.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetUserByIdAndDomainAsync(Guid userId, string domain);
        Task<IEnumerable<User?>> GetUsersByDomainAsync(string domain, int pageNumber, int pageSize);
        Task<IEnumerable<User?>> GetUsersByTagAndDomainAsync(string tagValue, string domain);
    }
}
