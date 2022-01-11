using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Talent
    {
        [Key]
        public int SkillID { get; set; }
       
        [StringLength(250)]
        public string SkillName { get; set; }

        public string SkillDetails { get; set; }

        public byte SkillLevel { get; set; }
       
    }
}
