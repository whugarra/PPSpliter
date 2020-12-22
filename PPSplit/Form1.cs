using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPSplit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PdfReader reader = new PdfReader(@".\PP.pdf");
            PdfDocument pdfDoc = new PdfDocument(reader);

            for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
            {
                var textEventListener = new LocationTextExtractionStrategy();
                string pdfString = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(i), textEventListener);
                Console.WriteLine(pdfString);
            }
            pdfDoc.Close();
        }
    }
}
