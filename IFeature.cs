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
    public class HtmlResult
    {
        public bool Match { get; set; }
        public string Value { get; set; }
    }
    public interface IFeature
    {
        HtmlResult GripHtmlElement(HtmlElement element);
    }
}
