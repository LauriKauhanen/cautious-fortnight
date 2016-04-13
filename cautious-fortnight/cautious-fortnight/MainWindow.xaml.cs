using System;
using System.Windows;
using System.ComponentModel;

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
        private OCR ocrModel;
        public DocumentModel doc { get; }
        private readonly BackgroundWorker worker = new BackgroundWorker();

        public MainWindow()
        {
            InitializeComponent();
            this.ocrModel = new OCR();
            this.doc = new DocumentModel();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }


        private void ImagePanel_Initialized(object sender, EventArgs e)
        {
            ImagePanel_RenderText("Drag and Drop image file here");
        }

        private void ImagePanel_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                doc.Document = files[0];

                worker.RunWorkerAsync();

                ImagePanel_RenderText("OCR in progress...");
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            doc.Result = ocrModel.DetectText(doc.Image);
        }

        private void worker_RunWorkerCompleted(object sender,
                                               RunWorkerCompletedEventArgs e)
        {
            ResultWindow result = new ResultWindow();
            result.Owner = this;
            result.Show();
            result.ResultTextBox.Text = doc.Result;

            ImagePanel.Source = BitmapSourceConvert.ToBitmapSource(doc.Image);
            this.Width = doc.Image.Width;
            this.Height = doc.Image.Height;
        }

        private void ImagePanel_RenderText(string text)
        {
            Mat image = new Mat(600, 1200, DepthType.Cv8U, 3);
            image.SetTo(new Bgr(255, 255, 255).MCvScalar);
            CvInvoke.PutText(image, text, new System.Drawing.Point(100, 250), Emgu.CV.CvEnum.FontFace.HersheyTriplex, 2.0, new Bgr(0.0, 0.0, 0.0).MCvScalar);

            ImagePanel.Source = BitmapSourceConvert.ToBitmapSource(image);
        }
    }
}
