using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.ViewModels
{
    public class StringValueClass
    {
        public StringValueClass(string s)
        {
            _value = s;
        }
        public string Value { get { return _value; } set { _value = value; } }
        string _value;
    }
}
