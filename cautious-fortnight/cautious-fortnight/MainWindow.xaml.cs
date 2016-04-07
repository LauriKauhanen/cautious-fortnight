using System;
using System.Windows;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

using Microsoft.Win32;

namespace cautious_fortnight
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OCR ocrModel;
        Image<Bgr, Byte> image;
        Window resultWindow;
        Document doc;

        public MainWindow()
        {
            InitializeComponent();
            this.doc = new Document();
            this.ocrModel = new OCR();

            //Window resultWindow = new ResultWindow();
            //resultWindow.Owner = this;
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                ImagePanel.Source = BitmapSourceConvert.ToBitmapSource(new Image<Bgr, Byte>(openFileDialog.FileName));
        }

        private void ImagePanel_Initialized(object sender, EventArgs e)
        {
            Mat image = new Mat(100, 400, DepthType.Cv8U, 3);
            image.SetTo(new Bgr(255, 255, 255).MCvScalar);
            CvInvoke.PutText(image, "Hello, world", new System.Drawing.Point(10, 50), Emgu.CV.CvEnum.FontFace.HersheyPlain, 3.0, new Bgr(255.0, 0.0, 0.0).MCvScalar);

            ImagePanel.Source = BitmapSourceConvert.ToBitmapSource(image);
        }

        private void ImagePanel_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                //TODO: Check for image files
                image = new Image<Bgr, Byte>(files[0]);

                ImagePanel.Source = BitmapSourceConvert.ToBitmapSource(new Image<Bgr, Byte>(files[0]));

                TextBlock.Text = ocrModel.DetectText(image);

                //resultWindow.textBlock.Text = ocrModel.DetectText(image);
            }
        }
    }
}
