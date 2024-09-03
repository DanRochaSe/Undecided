using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

public class StringListConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
        return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
    }

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        if (value != null && value is string stringValue)
        {
            return new List<string>(stringValue.Split(','));
        }
        return base.ConvertFrom(context, culture, value);
    }

    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
        return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
        if (destinationType == typeof(string) && value is IList<string> listValue)
        {
            return string.Join(",", listValue);
        }
        return base.ConvertTo(context, culture, value, destinationType);
    }

    static StringListConverter()
    {
        TypeDescriptor.AddAttributes(typeof(List<string>), new TypeConverterAttribute(typeof(StringListConverter)));
    }
}

