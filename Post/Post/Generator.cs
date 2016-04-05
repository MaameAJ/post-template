using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post
{
    public class Generator
    {
        Template _postTemplate;

        private FieldValueCollection _fieldValues;

        public Template PostTemplate
        {
            get { return _postTemplate; }
            set
            {
                //TODO remove all fieldValues that don't have a matching field
            }
        }

        public SeriesValues Series;

        public bool IsComplete
        {
            get 
            { 
                if(_fieldValues.Count == _postTemplate.FieldList.Count)
                {
                    return !_fieldValues.GetAssociatedFields().Except(_postTemplate.FieldList).Any();
                }

                return false;
            }
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<FieldValue> FieldValues
        {
            get { return _fieldValues.AsReadOnly(); }
        }

        public Generator(Template template)
        {
            _postTemplate = template;
        }

        public void SetFieldValue(Field field, string value)
        {
            if(_postTemplate.FieldList.Contains(field))
            {
                _fieldValues.Add(new FieldValue(field, value));
            }
        }

        public string GenerateContent()
        {
            if (IsComplete)
            {
                string content = _postTemplate.Format.Replace(_postTemplate.Series.TitleFormat, Series.Title).Replace(_postTemplate.Series.SummaryFormat, Series.Summary);

                foreach (FieldValue value in _fieldValues)
                {
                    content = content.Replace(value.Field, value.Value);
                }

                return content; 
            }

            throw new InvalidOperationException("Not all fields have been filled out.");
        }
    }
}
