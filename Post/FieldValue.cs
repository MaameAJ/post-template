using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post
{
    public struct FieldValue
    {

        Field _templateField;
        string _value;

        public string Name
        {
            get { return _templateField.Name; }
        }

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public string Field
        {
            get { return _templateField.ToString(); }
        }

        public FieldValue(Field field, string value)
        {
            _templateField = field;
            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }

    }
}
