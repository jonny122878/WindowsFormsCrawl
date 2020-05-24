using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsCrawl
{
    public partial class Form1 : Form
    {
        public long sum;
        public Form1()
        {
            sum = 0;
            InitializeComponent();
        }
         
        private void Sum(long end)
        {
             
            for (long i =0;i< end;i++)
            {
                sum = sum + 1;
            }            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            //var firstTime = DateTime.Now.ToString();
            webBrowser2.Navigate("https://business.591.com.tw/?type=1&kind=5");
            webBrowser3.Navigate("https://business.591.com.tw/?type=6&kind=5");
            //webBrowser4.Navigate("https://business.591.com.tw/?type=2&kind=5");
            //webBrowser5.Navigate("https://business.591.com.tw/?type=1&kind=11");
            //webBrowser6.Navigate("https://business.591.com.tw/?type=2&kind=7");
            //webBrowser7.Navigate("https://business.591.com.tw/?type=2&kind=11");
            ////webBrowser1.Navigate("https://sale.591.com.tw/?shType=host&regionid=1");
            ////webBrowser2.Navigate("https://rent.591.com.tw/?kind=0&region=1&shType=host");
            ////webBrowser6.Navigate("https://business.591.com.tw/?type=1&kind=6");
            ////webBrowser7.Navigate("https://business.591.com.tw/?type=1&kind=12");
            ////webBrowser8.Navigate("https://business.591.com.tw/?type=2&kind=6");
            ////webBrowser9.Navigate("https://business.591.com.tw/?type=2&kind=12");
            ////webBrowser10.Navigate("https://business.591.com.tw/?type=1&kind=7");

            webBrowser2.ScriptErrorsSuppressed = true;//關閉彈出對話框
            webBrowser3.ScriptErrorsSuppressed = true;//關閉彈出對話框
            //webBrowser4.ScriptErrorsSuppressed = true;//關閉彈出對話框
            //webBrowser5.ScriptErrorsSuppressed = true;//關閉彈出對話框
            //webBrowser6.ScriptErrorsSuppressed = true;//關閉彈出對話框
            //webBrowser7.ScriptErrorsSuppressed = true;//關閉彈出對話框

            //var EndTime = DateTime.Now.ToString();
            //Console.WriteLine("test");

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void NotAsync()
        {
            Parallel.Invoke(
                () => { this.Sum(1000000000); },
                () => { this.Sum(1000000000); },
                () => { this.Sum(1000000000); }
               

                            );
        }

 
        private async void button1_Click(object sender, EventArgs e)
        {
            //    //this.Sum(1000000000);
            //    //this.Sum(1000000000);
            //    //this.Sum(1000000000);
            //    NotAsync();
            //    //    var firstTime = DateTime.Now.ToString();


            //    //    this.TestAsync();

            //    //    var EndTime = DateTime.Now.ToString();
            //        Console.WriteLine("test");

            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < 3; i++)
            {
                Thread t = new Thread(() => {
                    for (int j = 0; j < 3; j++)
                    {
                        this.Sum(1000000000);
                    }
                });
                threads.Add(t);
            }

  
            foreach (Thread t in threads) t.Start();




        }
        private async Task<long> SumAsync(long end)
        {
            var sum = 0;
            for (long i = 0; i < end; i++)
            {
                sum = sum + 1;
            }
            return sum;
        }
        private async void ClickAsync(HtmlElement hte) 
        {
            for (int i = 0; i < 200; i++)
            {
                hte.InvokeMember("click");
                Task.Delay(100);
            }
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            Feature feature = new Feature(
               m =>
               {
                   if (m.TagName == "I" && m.GetAttribute("classname") == "searchBtn")
                   {
                       return new HtmlResult() { Match = true, Value = "test" };

                   }
                   else
                   {
                       return new HtmlResult() { Match = false, Value = "test" };

                   }
               }


               );
            
            List<string> tests = new List<string>();

            foreach (HtmlElement hte in webBrowser2.Document.All)
            {

                var result = feature.GripHtmlElement(hte);
                if (result.Match == true)
                {
                    ClickAsync(hte);
                }

                
                
            }
            //List<Func<long, Task<long>>> funcs = new List<Func<long, Task<long>>>();
            //funcs.Add(this.SumAsync);
            //funcs.Add(this.SumAsync);
            //funcs.Add(this.SumAsync);
            //funcs.Add(this.SumAsync);
            //funcs.Add(this.SumAsync);
            //foreach (var item in funcs)
            //{
            //     long sum = await item.Invoke(1000000000);
            //    label1.Text = sum.ToString();
            //}
        }
    }
}
