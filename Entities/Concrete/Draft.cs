using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Draft
    {
        [Key]
        public int DraftID { get; set; }
        [StringLength(50)]
        public string DraftReceiver { get; set; }
        [StringLength(50)]
        public string DraftSubject { get; set; }
        [StringLength(500)]
        public string DraftArea { get; set; }
        [StringLength(500)]
        public string DraftFile { get; set; }
    }
}
