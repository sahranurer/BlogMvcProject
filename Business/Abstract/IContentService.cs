using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContentService
    {
        void Add(Content content);
        void Delete(Content content);
        void Update(Content content);
        List<Content> GetContents(string p);
        List<Content> GetContents();
        List<Content> GetContentsByWriter(int id);
        Content GetById(int id);
        List<Content> GetListByHeadingId(int id);
    }
}
