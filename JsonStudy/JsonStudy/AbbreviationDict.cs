using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace JsonStudy
{
    [DataContract]
    class AbbreviationDict
    {
        [DataMember(Name = "abbrs")]
        public Dictionary<string, string> Abbreviations { get; set; }
    }
}
