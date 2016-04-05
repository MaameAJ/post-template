using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Post
{
    public class Template
    {
        protected string _format;
        protected List<Field> _fieldlist;

        public SeriesFields Series;
        public System.Collections.ObjectModel.ReadOnlyCollection<Field> FieldList
        {
            get { return _fieldlist.AsReadOnly(); }
        }

        public string Format
        {
            get { return _format; }
            set
            {
                _fieldlist = GetFieldsFromFormat(value);
                _format = value;
            }
        }

        public Template(string title, string summary, string format)
        {
            Series.Title = title;
            Series.Summary = summary;
            _format = format;
            _fieldlist = GetFieldsFromFormat(format);
        }

        protected virtual List<Field> GetFieldsFromFormat(string format)
        {
            Collection<Field> fields = new Collection<Field>();

            Regex regex = new Regex(@"(?<field>{[$#!]\w+})");

            MatchCollection matches = regex.Matches(format);
            
            foreach(Match match in matches)
            {
                fields.Add(Field.Parse(match.Groups["field"].Value));
            }

            return fields;
        }
    }
}
