using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post
{
    public struct SeriesValues
    {
        string _title;
        string _summary;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Summary
        {
            get { return _summary; }
            set { _summary = value; }
        }

        public SeriesValues(string title, string summary)
        {
            _title = title;
            _summary = summary;
        }
    }
}
