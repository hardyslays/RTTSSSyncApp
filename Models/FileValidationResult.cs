using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RTTSSyncApp.Models
{
    public class FileValidationResult
    {
        public bool valid { get; set; }
        public string errMsg { get; set; }

        public FileValidationResult(bool valid, string errMsg)
        {
            this.valid = valid;
            this.errMsg = errMsg;
        }

    }
}