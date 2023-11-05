using ByteStreamProcessorLib.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteStreamProcessorLib.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdAsync(Guid userId);
        Task<User?> GetUserByIdAndDomainAsync(Guid userId, string domain);
        Task<IEnumerable<User?>> GetUsersByDomainAsync(string domain, int page, int pageSize);
        Task<IEnumerable<User?>> GetUsersByTagAndDomainAsync(string tagValue, string domain);
    }
}
