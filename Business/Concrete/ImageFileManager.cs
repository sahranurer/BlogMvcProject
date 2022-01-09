using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _ımageFile;

        public ImageFileManager(IImageFileDal ımageFile)
        {
            _ımageFile = ımageFile;
        }

      

        public List<ImageFile> GetImageFiles()
        {
            return _ımageFile.List();
        }

        }
    }

