using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static RTTSSyncApp.Models.Configuration;

namespace RTTSSyncApp.ViewModels
{
    public class FormViewModel
    {
        public DocTypeInfo selectDocType { get; set; }
        public HttpPostedFileBase file { get; set; }
    }
}