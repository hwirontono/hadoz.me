using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace HadozViewModel
{
    public class ViewInformation
    {
        public bool ReturnStatus { get; set; }
        public List<string> ReturnMessage { get; set; }
        public Hashtable ValidationErrors { get; set; }
    }
}
