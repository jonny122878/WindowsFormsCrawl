using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace WindowsFormsCrawl
{
    public class Feature : IFeature
    {
        private Func<HtmlElement, HtmlResult> _condition;

        public Feature(Func<HtmlElement, HtmlResult> condition)
        {
            _condition = condition;
        }

        public Func<HtmlElement, HtmlResult> Condition { get => _condition; set => _condition = value; }

        public HtmlResult GripHtmlElement(HtmlElement element)
        {
            return _condition(element);
            throw new NotImplementedException();
        }
    }
}
