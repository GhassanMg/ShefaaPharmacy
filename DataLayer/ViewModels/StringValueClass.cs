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
