using System;
using System.Web.Mvc;

namespace Prueba.Clases
{
    public class SegconHelpers
    {
        public static string Url(HtmlHelper helper, string target, string text)
        {
            return String.Format("<label for='{0}'>{1}</label>", target, text);

        }
    }
}