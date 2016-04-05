using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post
{
    public struct SeriesFields //TODO figure out
    {
        string _title;
        string _summary;

        public string TitleFormat
        {
            get { return _title; }
            set { _title = value; }
        }

        public string SummaryFormat
        {
            get { return _summary; }
            set { _summary = value; }
        }

        public SeriesFields()
        {
            _title = "{SeriesTitle}";
            _summary = "{SeriesSummary}";
        }
    }
}
