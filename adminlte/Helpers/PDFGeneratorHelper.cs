using iTextSharp.text;
using iTextSharp.text.pdf;
using Rotativa;
using Rotativa.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace adminlte.Helpers
{
    public class PDFGeneratorHelper : IPDFGeneratorHelper
    {
        private bool _isPartialView;
        private List<string> _copiesNames;
        private string _viewName;
        private List<byte[]> _pdf;
        private string _fileName;
        private bool _cd;
        private ControllerContext _context;

        public IPDFGeneratorHelper GeneratePDFByteArray()
        {
            _pdf = new List<byte[]>();
            foreach (var item in _copiesNames)
            {
                var viewObject = new PartialViewAsPdf(_viewName, item)
                {
                    PageSize = Size.A3,
                    PageOrientation = Orientation.Landscape,
                    PageMargins = { Left = 0, Right = 0 },
                };

                _pdf.Add(viewObject.BuildFile(_context));
            }
            return this;
        }

        public FileStreamResult GetCombinedResult()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (Document document = new Document())
                {
                    using (PdfCopy copy = new PdfCopy(document, ms))
                    {
                        document.Open();

                        for (int i = 0; i < _pdf.Count; ++i)
                        {
                            iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(_pdf[i]);
                            // loop over the pages in that document
                            int n = reader.NumberOfPages;
                            for (int page = 0; page < n;)
                            {
                                copy.AddPage(copy.GetImportedPage(reader, ++page));
                            }
                        }
                    }
                }
             
                System.Net.Mime.ContentDisposition cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = _fileName,
                    Inline = _cd  // false = prompt the user for downloading;  true = browser to try to show the file inline
                };

                _context.HttpContext.Response.ContentType = "application/pdf";
                _context.HttpContext.Response.AddHeader("content-disposition", cd.ToString());
                _context.HttpContext.Response.Buffer = true;
                _context.HttpContext.Response.Clear();
                _context.HttpContext.Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
                _context.HttpContext.Response.OutputStream.Flush();
                _context.HttpContext.Response.End();

            }
            return new FileStreamResult(_context.HttpContext.Response.OutputStream, "application/pdf");
        }

        public IPDFGeneratorHelper IsPartialView(bool isPartialView)
        {
            _isPartialView = isPartialView;
            return this;
        }

        public IPDFGeneratorHelper SetContentDisposition(bool inline)
        {
            _cd = inline;
            return this;
        }

        public IPDFGeneratorHelper setFileName(string fileName)
        {
            _fileName = fileName;
            return this;
        }

        public IPDFGeneratorHelper SetControlerContext(ControllerContext context)
        {
            _context = context;
            return this;
        }

        public IPDFGeneratorHelper SetCopiesName(List<string> CopiesName)
        {
            _copiesNames = CopiesName;
            return this;
        }

        public IPDFGeneratorHelper SetViewName(string viewName)
        {
            _viewName = viewName;
            return this;
        }
    }
}