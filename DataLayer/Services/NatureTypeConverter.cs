using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace DataLayer.Services
{
    public class NatureTypeConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext
                context, Type destinationType)
        {
            if (ReferenceEquals(destinationType, typeof(string)))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context,
                CultureInfo culture, object value, Type destinationType)
        {
            if (ReferenceEquals(destinationType, typeof(string)))
            {
                FieldInfo fi = value.GetType().GetField(value.ToString());
                DescriptionAttribute[] attr = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attr.Length > 0)
                {
                    return attr[0].Description;
                }
                else
                {
                    return value.ToString();
                }
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
