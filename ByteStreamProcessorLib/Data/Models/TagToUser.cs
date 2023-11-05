using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteStreamProcessorLib.Data.Models
{
    public class TagToUser
    {
        public Guid EntityId { get; set; }
        public Guid UserId { get; set; }
        public Guid TagId { get; set; }


        public User? User { get; set; }
        public List<Tag>? Tags { get; set; }
    }
}
