using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Content
    {
        public int ContentId { get; set; }
        public string ContentValue { get; set; }
        public DateTime ContentDate { get; set; }

        //relationship specification
        public int HeadingId { get; set; }
        public virtual Heading Heading { get; set; }

        //relationship spefication
        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }

    }
}
