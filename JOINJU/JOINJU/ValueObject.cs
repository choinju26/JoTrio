using System.Diagnostics;
using System.Collections;

namespace Common_ValueObject
{
    class ValueObject
    {
        private Hashtable vo = new Hashtable();
        public ValueObject()
        {

        }
        public void set(object title, object value)
        {
            vo[title] = value.ToString();
        }

        public string get(string title)
        {
            try
            {
                return string.Format("{0}", vo[title].ToString());
            }
            catch
            {
                return "";
            }
        }
        public string getString(string title)
        {
            try
            {
                return vo[title].ToString();
            }
            catch
            {
                return "";
            }
        }
        public int getInt(string title)
        {
            try
            {
                return int.Parse(vo[title].ToString());
            }
            catch
            {
                return 0;
            }
        }
        public double getDouble(string title)
        {
            try
            {
                return double.Parse(vo[title].ToString());
            }
            catch
            {
                return 0;
            }
        }
        override
        public string ToString()
        {
            string str = "";
            foreach (DictionaryEntry o in vo)
            {
                str += string.Format("{0} : {1}", o.Key, o.Value)+"\n";
                //Debug.Print(string.Format("{0} : {1}", o.Key, o.Value));
            }
            return str;
        }
        public bool isContainsKey(string title)
        {
            return vo.ContainsKey(title);
        }
    }
}
