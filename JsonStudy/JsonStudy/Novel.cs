using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Runtime.Serialization;

namespace JsonStudy
{
    [DataContract(Name = "novel")]
    class Novel
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "author")]
        public string Author { get; set; }

        [DataMember(Name = "published")]
        public int Published { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", Title, Author, Published);
        }
    }
}
