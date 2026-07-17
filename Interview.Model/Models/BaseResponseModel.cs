using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Model.Models
{
    public class BaseResponseModel
    {
        public Boolean success { get; set; }
        public String message { get; set; }

        public object data { get; set; }
        public string ErrorMessage { get; set; }
    }
}
