using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace cautious_fortnight
{
    public class Document
    {
        public string name { get; set; }
        public string filepath { get; set; }
        public Image<Bgr, Byte> source { get; set; }
        public ImageSource source_WPF { get; set; }
        public string result { get; set; }

        public Document()
        {
            name = "default";
            filepath = "/";
        }
    }
}
