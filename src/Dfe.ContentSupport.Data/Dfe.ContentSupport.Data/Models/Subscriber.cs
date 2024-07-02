using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfe.ContentSupport.Data.Models
{
    public class Subscriber
    {
        [Key] // This attribute specifies that the property is the primary key
        public int ID { get; set; } // Primary key

        [MaxLength(255)]
        public required string EmailAddress { get; set; }

        public bool IsSubscribed { get; set; } = true;
    }
}

