using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Heading
    {
        public int HeadingId { get; set; }
        public string HeadingName { get; set; }
        public DateTime HeadingDate { get; set; }
        //relationship specification
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public ICollection<Content> Contents { get; set; }

        //relationship specification
        public int WriterId { get; set; }
        public virtual  Writer Writer { get; set; }

    }
}
