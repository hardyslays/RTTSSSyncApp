using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using RTTSSyncApp.Models;
using static RTTSSyncApp.Models.Configuration;

namespace RTTSSyncApp.ViewModels
{
    public class HomeViewModel
    {
        public DocTypeInfo[] docTypeInfos { get; set; }
        public FileValidationResult validationResult { get; set; }
        public RTTSFieldValues[] fieldValues { get; set; }
        public HomeViewModel(DocTypeInfo[] docTypeInfos)
        {
            this.docTypeInfos = docTypeInfos;
        }
    }
}