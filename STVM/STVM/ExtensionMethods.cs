using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.IO;

namespace STVM
{
    static class ExtensionMethods
    {

        public static string ToDescription(this Enum en) //ext method
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(
                typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return en.ToString();
        }

        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source.IndexOf(toCheck, comp) >= 0;
        }

        /// <summary>
        /// Workaround for some weird cases where DateTime seems to transport some residual time zone information to SOAP request?!
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime CleanDate(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day);
        }

    }
}
