using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cautious_fortnight
{
    public class DocumentModel
    {
        #region fields

        private string _document;
        private string _filePath;
        private Image<Bgr, Byte> _image;
        private string _result;
        private string _extension;

        private string[] allowedExtensions = { ".png", ".jpeg", ".jfif", ".jpg", ".JPG", ".JPE", ".tiff" };
        #endregion

        #region properties

        public string Document
        {
            get { return _document; }
            set
            {
                try
                {
                    if (allowedExtensions.Contains(Path.GetExtension(value)) && Path.GetDirectoryName(value) != null)
                    {
                        _document = value;
                        _filePath = Path.GetFullPath(value);
                        _extension = Path.GetExtension(value);
                        _image = new Image<Bgr, Byte>(value);
                    }
                    else
                    {
                        throw new System.Exception("Invalid file extension.");
                    }
                }
                catch (Exception e)
                {

                    throw e;
                }

            }
        }

        public Image<Bgr, Byte> Image
        {
            get { return _image; }
        }

        public string Result
        {
            get { return _result; }
            set {
                _result = value;
            }
        }
        #endregion
    }
}
