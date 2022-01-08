using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PubFuture.Models
{
    public class BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public DateTime? Create { get; set; }
        public DateTime? Change { get; set; }

        public BaseModel()
        {
            if (!Create.HasValue)
                Create = DateTime.Now;
            Change = DateTime.Now;
        }
    }
}
