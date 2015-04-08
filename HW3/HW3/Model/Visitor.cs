using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3.Model
{
    [Serializable]
    public class Visitor
    {
        [Key]
        public string IP { get; set; }

    }
}
