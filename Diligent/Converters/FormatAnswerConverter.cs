using System;
using Xamarin.Forms;

namespace Diligent.Converters
{
	public class FormatAnswerConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter,
			System.Globalization.CultureInfo culture)
		{
            if (targetType != typeof(string))
            {
                throw new InvalidOperationException("The target must be a string");
            }

			string formatString = value as string;
                  
			if (string.IsNullOrEmpty(formatString))
            {
                return " - Missed answer";
            }

			return " - " + value;
		}

		public object ConvertBack(object value, Type targetType, object parameter,
			System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}