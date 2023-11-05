using ByteStreamProcessorLib.Data.Models;
using ByteStreamProcessorLib.Data.Repositories.Interfaces;
using ByteStreamProcessorLib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteStreamProcessorLib.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User?> GetUserByIdAndDomainAsync(Guid userId, string domain)
        {
            return _userRepository.GetUserByIdAndDomainAsync(userId, domain);
        }

        public Task<IEnumerable<User?>> GetUsersByDomainAsync(string domain, int pageNumber, int pageSize)
        {
            return _userRepository.GetUsersByDomainAsync(domain, pageNumber, pageSize);
        }

        public Task<IEnumerable<User?>> GetUsersByTagAndDomainAsync(string tagValue, string domain)
        {
            return _userRepository.GetUsersByTagAndDomainAsync(tagValue, domain);
        }
    }
}
