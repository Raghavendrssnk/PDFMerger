using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace adminlte.Helpers
{
    public interface IPDFGeneratorHelper
    {
        IPDFGeneratorHelper IsPartialView(bool isPartialView);

        IPDFGeneratorHelper SetCopiesName(List<string> CopiesName);

        IPDFGeneratorHelper SetViewName(string viewName);

        IPDFGeneratorHelper SetControlerContext(ControllerContext context);

        IPDFGeneratorHelper GeneratePDFByteArray();

        IPDFGeneratorHelper setFileName(string fileName);

        IPDFGeneratorHelper SetContentDisposition(bool isPartialView);

        FileStreamResult GetCombinedResult();
    }
}