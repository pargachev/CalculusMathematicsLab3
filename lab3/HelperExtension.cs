using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace lab3
{
    public static class HelperExtension
    {

        public static double[] ToDoubleArray(this string stringDoubleArray)
        {
            string[] array = stringDoubleArray.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return array.Select(x => double.Parse(x, CultureInfo.InvariantCulture)).ToArray();
        }

        public static string ToFormatedString(this double[] array)
        {
            return string.Join(" ", array.Select(x => x.ToString("F3", CultureInfo.InvariantCulture)).ToArray());
        }
    }
}
