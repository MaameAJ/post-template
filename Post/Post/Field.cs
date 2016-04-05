using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Post
{
    public struct Field
    {
        public enum Type { SINGLE, AREA, AUTO }

        string _name;
        Type _type;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Type TypeAttr
        {
            get { return _type; }
            set { _type = value; }
        }

        public Field(string name, Type type)
        {
            _name = name;
            _type = type;
        }

        private char TypeToSymbol()
        {
            switch(_type)
            {
                case Type.SINGLE:
                    return '!';
                case Type.AREA:
                    return '#';
                case Type.AUTO:
                    return '$';
                default:
                    throw new NotSupportedException("This type value is not currently supported.");
            }
        }

        public override string ToString()
        {
            return String.Format("{{{0}{1}}}", TypeToSymbol(), _name);
        }

        private static Type TypeFromSymbol(char symbol)
        {
             switch(symbol)
            {
                case '!':
                    return Type.SINGLE;
                case '#':
                    return Type.AREA;
                case '$':
                    return Type.AUTO;
                default:
                    throw new InvalidCastException(String.Format("{0} does not have a corresponding FieldType.", symbol));
            }
        }

        private static Type TypeFromSymbol(string symbol)
        {
            if(symbol.Length != 1)
            {
                throw new InvalidCastException(String.Format("{0} is not a valid symbol for a FieldType."));
            }
            else
            {
                return TypeFromSymbol(symbol[0]);
            }

        }

        public static Field Parse(string value)
        {
            if(value == null)
            {
                throw new ArgumentNullException("value cannot be null.");
            }
            else
            {
                try
                {

                    Regex regex = new Regex(@"{(?<type>[$#!])(?<name>\w+)}");

                    Match match = regex.Match(value);
                    Group typeMatch = match.Groups["type"];
                    Group nameMatch = match.Groups["name"];

                    if(match.Success && typeMatch.Success && nameMatch.Success)
                    {
                        Type type = TypeFromSymbol(typeMatch.Value);
                        string name = nameMatch.Value;
                        return new Field(name, type);
                    }
                    else
                    {
                        throw new FormatException(String.Format("{0} is not a valid format", value));
                    }

                    
                }
                catch (Exception ex)
                {
                    if(ex is IndexOutOfRangeException || ex is InvalidCastException)
                    {
                        throw new FormatException(String.Format("{0} is not a valid format", value), ex);
                    }
                    else
                    {
                        throw;
                    }
                }

            }
        }

        public static bool TryParse(string value, out Field result)
        {
            try
            {
                result = Parse(value);
                return true;
            }
            catch(Exception)
            {
                result = default(Field);
                return false;
            }
        }

        public override bool Equals(object obj)
        {
            if(obj.GetType() == GetType())
            {
                Field other = (Field)obj;
                return (other._name == _name && other._type == _type);
            }

            return false;
        }
    }
}
