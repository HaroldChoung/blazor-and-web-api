using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Model.Models
{
    public class BaseResponseModel
    {
        public Boolean Success { get; set; }
        public String Message { get; set; }

        public object Data { get; set; }
    }
}
