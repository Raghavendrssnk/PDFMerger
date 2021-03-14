﻿using adminlte.Helpers;
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

namespace adminlte.Controllers
{
    public class ExamplesController : Controller
    {
        private IPDFGeneratorHelper _iPDFGeneratorHelper;

        public ExamplesController()
        {
            _iPDFGeneratorHelper = new PDFGeneratorHelper();
        }

        public ActionResult GeneratePDF()
        {
            return _iPDFGeneratorHelper.IsPartialView(true)
                                       .SetViewName("_InvoicePDF")
                                       .SetCopiesName(new List<string>() { "Original", "UserCopy-1", "UserCopy-2" })
                                       .setFileName("TestLabe")
                                       .SetControlerContext(ControllerContext)
                                       .SetContentDisposition(true)
                                       .GeneratePDFByteArray()
                                       .GetCombinedResult();
        }

        //public ActionResult GeneratePDFOld()
        //{
        //    var Original = new PartialViewAsPdf("_InvoicePDF", "Original")
        //    {
        //        //FileName = "TestView.pdf",
        //        PageSize = Size.A3,
        //        PageOrientation = Orientation.Landscape,
        //        PageMargins = { Left = 0, Right = 0 },
        //        //ContentDisposition = ContentDisposition.Inline
        //    };

        //    var UserCopy1 = new PartialViewAsPdf("_InvoicePDF", "UserCopy-1")
        //    {
        //        //FileName = "TestView.pdf",
        //        PageSize = Size.A3,
        //        PageOrientation = Orientation.Landscape,
        //        PageMargins = { Left = 0, Right = 0 },
        //        //ContentDisposition = ContentDisposition.Inline
        //    };

        //    var UserCopy2 = new PartialViewAsPdf("_InvoicePDF", "UserCopy-2")
        //    {
        //        //FileName = "TestView.pdf",
        //        PageSize = Size.A3,
        //        PageOrientation = Orientation.Landscape,
        //        PageMargins = { Left = 0, Right = 0 },
        //        //ContentDisposition = ContentDisposition.Inline
        //    };

        //    var originalBytes = Original.BuildFile(ControllerContext);
        //    var userCopy1Bytes = UserCopy1.BuildFile(ControllerContext);
        //    var userCopy2Bytes = UserCopy2.BuildFile(ControllerContext);

        //    var byteList = new List<byte[]>() { originalBytes, userCopy1Bytes, userCopy2Bytes };
        //    var result = CombinePDFDocuments(byteList, "labTest.pdf", true);

        //    return result;
        //}

        //public FileStreamResult CombinePDFDocuments(List<byte[]> pdf, string fileName, bool contentDisposition)
        //{
        //    byte[] mergedPdf = null;
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        using (Document document = new Document())
        //        {
        //            using (PdfCopy copy = new PdfCopy(document, ms))
        //            {
        //                document.Open();

        //                for (int i = 0; i < pdf.Count; ++i)
        //                {
        //                    iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(pdf[i]);
        //                    // loop over the pages in that document
        //                    int n = reader.NumberOfPages;
        //                    for (int page = 0; page < n;)
        //                    {
        //                        copy.AddPage(copy.GetImportedPage(reader, ++page));
        //                    }
        //                }
        //            }
        //        }
        //        mergedPdf = ms.ToArray();
        //        // convert to donwloadable...

        //        System.Net.Mime.ContentDisposition cd = new System.Net.Mime.ContentDisposition
        //        {
        //            FileName = fileName,
        //            Inline = contentDisposition  // false = prompt the user for downloading;  true = browser to try to show the file inline
        //        };

        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", cd.ToString());
        //        Response.Buffer = true;
        //        Response.Clear();
        //        Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
        //        Response.OutputStream.Flush();
        //        Response.End();

        //    }
        //    return new FileStreamResult(Response.OutputStream, "application/pdf");
        //}

        // GET: Examples
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Page404()
        {
            return View();
        }

        public ActionResult Page500()
        {
            return View();
        }

        public ActionResult Blank()
        {
            return View();
        }

        public ActionResult InvoicePrint()
        {
            return View();
        }

        public ActionResult Invoice()
        {
            return View();
        }

        public ActionResult Lockscreen()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Pace()
        {
            return View();
        }

        public ActionResult PageProfile()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}