using System;

using Emgu.CV;
using Emgu.CV.OCR;
using Emgu.CV.Structure;

using System.Drawing;

namespace cautious_fortnight
{
    class OCR
    {
        private Tesseract _ocr;

        public OCR()
        {
            InitializeOCR("", "eng", OcrEngineMode.TesseractCubeCombined);
        }

        private void InitializeOCR(String dataPath, String lang, OcrEngineMode mode)
        {
            try
            {
                if (_ocr != null) { _ocr.Dispose(); }
                _ocr = new Tesseract(dataPath, lang, mode);
            }
            catch (Exception e)
            {
                _ocr = null;
                throw e;
            }
        }

        public String DetectText(Image<Bgr, Byte> image)
        {
            Bgr drawColor = new Bgr(Color.DarkRed);
            try
            {
                using (Image<Gray, byte> gray = image.Convert<Gray, Byte>())
                {
                    _ocr.Recognize(gray);
                    Tesseract.Character[] characters = _ocr.GetCharacters();
                    foreach (Tesseract.Character c in characters)
                    {
                        image.Draw(c.Region, drawColor, 1);
                    }

                    String text = _ocr.GetText();
                    return text;
                }
            }
            catch (Exception e)
            {
                return null;
                throw e;
            }
        }

        protected void DisposeObject()
        {
            _ocr.Dispose();
        }


    }

}
