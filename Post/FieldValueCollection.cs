using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post
{
    public class FieldValueCollection : ICollection<FieldValue>
    {

        private List<FieldValue> items;

        public int Count
        {
            get { return items.Count; }
        }

        public void Add(FieldValue field)
        {
            int existing = IndexOf(field);
            if(existing > -1)
            {
                RemoveAt(existing);
            }

            items.Add(field);
        }

        public void Clear()
        {
            items.Clear();
        }

        public bool Contains(FieldValue field)
        {
            return Contains(field.Name);
        }

        public bool Contains(string fieldName)
        {
            return IndexOf(fieldName) != -1;
        }

        public void CopyTo(FieldValue[] array, int index)
        {
            items.CopyTo(array, index);
        }

        public IEnumerator<FieldValue> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }

        public int IndexOf(string fieldName)
        {
            for (int i = 0; i < items.Count; i++)
            {
                FieldValue item = items[i];
                if (item.Name == fieldName)
                {
                    return i;
                }
            }

            return -1;
        }

        public int IndexOf(FieldValue field)
        {
            return IndexOf(field.Name);
        }

        public void Remove(FieldValue field)
        {
            items.Remove(field);
        }

        public void RemoveAt(int index)
        {
            items.RemoveAt(index);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<FieldValue> AsReadOnly()
        {
            return new System.Collections.ObjectModel.ReadOnlyCollection<FieldValue>(this.ToList<FieldValue>());
        }

        public List<Field> GetAssociatedFields()
        {
            List<Field> list = new List<Field>();
            foreach(FieldValue item in items)
            {
                list.Add(Field.Parse(item.Field));
            }

            return list;
        }
    }
}
