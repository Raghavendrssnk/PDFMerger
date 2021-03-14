using adminlte.Helpers;
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
                                       .SetFileName("TestLabe.pdf")
                                       .SetControlerContext(ControllerContext)
                                       .SetContentDisposition(true)
                                       .GeneratePDFByteArray()
                                       .GetCombinedResult();
        }

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