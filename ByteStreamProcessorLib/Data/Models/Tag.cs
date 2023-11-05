using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteStreamProcessorLib.Data.Models
{
    public class Tag
    {
        public Guid TagId { get; set; }

        [Required]
        public string Value { get; set; } = default!;

        [Required]
        public string Domain { get; set; } = default!;


        public List<User>? Users { get; set; }
    }
}
