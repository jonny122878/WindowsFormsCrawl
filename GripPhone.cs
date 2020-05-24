//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Net;
//using System.IO;
//using Emgu.CV.UI;
//using Emgu.CV;
//using Emgu.Util;
//using Emgu.CV.OCR;
//using Emgu.CV.Structure;
//using Emgu.CV.CvEnum;
//using System.Drawing.Imaging;
//using System.Runtime.InteropServices;
//namespace 排路程
//{
//    public partial class GripPhone : Form
//    {
//        public enum crudeCellX
//        {
//            Brand =1,Order=2,Project=3,Addr=4,Price=5,
//            Form=6,AddForm=7,Plain=8,Floor=9,HouseOld=10,
//            Index = 11,Kind=12,Interface=13,Car=14,Web=15,
//            Building=16,Section =17,GroundPlain=18,KindB=19,Rent=20,Equipment=21,Community=22,DevidePrice =23

//        }

//        public enum crudeMeaningCellX
//        {
//            Brand = 0, Order = 1, Project = 2, Addr = 3, Price = 4,
//            Form = 5, AddForm = 6, Plain = 7, Floor = 8, HouseOld = 9,
//            Index = 10, Kind = 11, Interface = 12, Car = 13, Web = 14,
//            Building = 15, Section = 16, GroundPlain = 17, KindB = 18, Rent = 19,
//            Equipment = 20, Community = 21, DevidePrice = 22

//        }
//        public enum tinyCellX
//        {
//            Brand = 1, Order = 2, Project = 3, Addr = 4, Price = 5,
//            Form = 6, AddForm = 7, Plain = 8, Floor = 9, HouseOld = 10,
//            Index = 11, Kind = 12, Interface = 13, Car = 14, Web = 15,
//            PhoneA = 16, GripTime = 17, Name = 18, Toward = 19, Building = 20,
//            Common = 21, AppendBuilding = 22, GroundPlain = 23, PhoneB = 24, NowState = 25,
//            AuthorityPlain = 26, KindB = 27, Rent = 28, Equipment = 29, Community = 30,
//            DevidePrice = 31
//        }
//        public enum tinyMeaningCellX
//        {
//            Brand = 0, Order = 1, Project = 2, Addr = 3, Price = 4,
//            Form = 5, AddForm = 6, Plain = 7, Floor = 8, HouseOld = 9,
//            Index = 10, Kind = 11, Interface = 12, Car = 13, Web = 14,
//            PhoneA = 15, GripTime = 16, Name = 17, Toward = 18, Building = 19,
//            Common = 20, AppendBuilding = 21, GroundPlain = 22, PhoneB = 23, NowState = 24,
//            AuthorityPlain = 25, KindB = 26, Rent = 27, Equipment = 28, Community = 29,
//            DevidePrice = 30
//        }
//        public int StopTime;
//        public GripPhone()
//        {
//            InitializeComponent();
//        }
//        private void GripPhone_Load(object sender, EventArgs e)
//        {


//            webBrowser3.Navigate("https://business.591.com.tw/?type=1&kind=5");
//            webBrowser4.Navigate("https://business.591.com.tw/?type=6&kind=5");
//            webBrowser5.Navigate("https://business.591.com.tw/?type=2&kind=5");
            
//            webBrowser1.Navigate("https://sale.591.com.tw/?shType=host&regionid=1");
//            webBrowser2.Navigate("https://rent.591.com.tw/?kind=0&region=1&shType=host");
//            webBrowser6.Navigate("https://business.591.com.tw/?type=1&kind=6");
//            webBrowser7.Navigate("https://business.591.com.tw/?type=1&kind=12");
//            webBrowser8.Navigate("https://business.591.com.tw/?type=2&kind=6");
//            webBrowser9.Navigate("https://business.591.com.tw/?type=2&kind=12");
//            webBrowser10.Navigate("https://business.591.com.tw/?type=1&kind=7");
//            webBrowser11.Navigate("https://business.591.com.tw/?type=1&kind=11");
//            webBrowser12.Navigate("https://business.591.com.tw/?type=2&kind=7");
//            webBrowser13.Navigate("https://business.591.com.tw/?type=2&kind=11");
            

//        }
//        private void set_taipei_all_or_host()
//        {
//            if (radioButton2.Checked == true)
//            {
//                foreach (HtmlElement hte in webBrowser1.Document.All)
//                {

//                    if (hte.TagName == "DIV" &&
//                    hte.GetAttribute("data-id") == "list" &&
//                    hte.InnerText != null &&
//                    hte.InnerText.IndexOf("所有物件") != -1)
//                    {
//                        hte.InvokeMember("click");
//                        break;
//                    }
//                }
//            }
//            else if (radioButton3.Checked == true)
//            {
//                foreach (HtmlElement hte in webBrowser1.Document.All)
//                {
//                    if (hte.TagName == "DIV" &&
//                    hte.GetAttribute("data-id") == "host" &&
//                    hte.InnerText != null &&
//                    hte.InnerText.IndexOf("屋主刊登") != -1)
//                    {
//                        hte.InvokeMember("click");
//                        break;
//                    }
//                }
//            }
//                WebBrowser[] WebbrowserArr = { webBrowser2, webBrowser3, webBrowser4, webBrowser5, webBrowser6,
//                                           webBrowser7, webBrowser8, webBrowser9, webBrowser10, webBrowser11,
//                                           webBrowser12, webBrowser13};
//            //設定台北市屋主或仲介
//            for (int i = 0; i < 12; i++)
//            {
//                timer1.Enabled = true;
//                while (StopTime < 3)
//                {
//                    Application.DoEvents();
//                }
//                StopTime = 0;
//                timer1.Enabled = false;
//                while (!(WebbrowserArr[i].ReadyState == WebBrowserReadyState.Complete))
//                {
//                    Application.DoEvents();
//                }
//                if (radioButton3.Checked == true)
//                {
//                    foreach (HtmlElement hte in WebbrowserArr[i].Document.All)
//                    {
//                        if (hte.TagName == "LI" &&
//                            hte.GetAttribute("data-text") == "host" &&
//                            hte.InnerText != null &&
//                            hte.InnerText.IndexOf("屋主") != -1)
//                        {
//                            hte.InvokeMember("click");
//                            break;
//                        }
//                    }
//                }
//                else if (radioButton2.Checked == true)
//                {
//                    foreach (HtmlElement hte in WebbrowserArr[i].Document.All)
//                    {
//                        if (hte.TagName == "LI" &&
//                            hte.GetAttribute("data-text") == "list" &&
//                            hte.InnerText != null &&
//                            hte.InnerText.IndexOf("所有物件") != -1)
//                        {
//                            hte.InvokeMember("click");
//                            break;
//                        }
//                    }
//                }
//            }
//        }
//        private void set_new_taipei_all_or_host()
//        {
//            WebBrowser[] WebbrowserArr = { webBrowser2, webBrowser3, webBrowser4, webBrowser5, webBrowser6,
//                                           webBrowser7, webBrowser8, webBrowser9, webBrowser10, webBrowser11,
//                                           webBrowser12, webBrowser13};
//            foreach (HtmlElement hte in webBrowser1.Document.All)
//            {
//                if (hte.TagName == "DIV" &&
//                    hte.GetAttribute("classname") == "region-list-item" &&
//                    hte.InnerText != null &&
//                    hte.InnerText.IndexOf("新北市") != -1)
//                {
//                    hte.InvokeMember("click");
//                    break;
//                }
//            }

//            timer1.Enabled = true;
//            while (StopTime < 5)
//            {
//                Application.DoEvents();
//            }
//            StopTime = 0;
//            timer1.Enabled = false;
//            while (!(webBrowser1.ReadyState == WebBrowserReadyState.Complete))
//            {
//                Application.DoEvents();
//            }

//            if (radioButton2.Checked == true)
//            {
//                foreach (HtmlElement hte in webBrowser1.Document.All)
//                {

//                    if (hte.TagName == "DIV" &&
//                    hte.GetAttribute("data-id") == "list" &&
//                    hte.InnerText != null &&
//                    hte.InnerText.IndexOf("所有物件") != -1)
//                    {
//                        hte.InvokeMember("click");
//                        break;
//                    }
//                }
//            }
//            else if (radioButton3.Checked == true)
//            {
//                foreach (HtmlElement hte in webBrowser1.Document.All)
//                {
//                    if (hte.TagName == "DIV" &&
//                    hte.GetAttribute("data-id") == "host" &&
//                    hte.InnerText != null &&
//                    hte.InnerText.IndexOf("屋主刊登") != -1)
//                    {
//                        hte.InvokeMember("click");
//                        break;
//                    }
//                }
//            }


//            for (int i = 0; i < 12; i++)
//            {
//                foreach (HtmlElement hte in WebbrowserArr[i].Document.All)
//                {
//                    if (hte.TagName == "A" &&
//                        hte.GetAttribute("data-id") == "3" &&
//                        hte.InnerText != null &&
//                        hte.InnerText.IndexOf("新北市") != -1)
//                    {
//                        hte.InvokeMember("click");
//                        break;
//                    }
//                }
//                timer1.Enabled = true;
//                while (StopTime < 5)
//                {
//                    Application.DoEvents();
//                }
//                StopTime = 0;
//                timer1.Enabled = false;
//                while (!(WebbrowserArr[i].ReadyState == WebBrowserReadyState.Complete))
//                {
//                    Application.DoEvents();
//                }
//                if (radioButton3.Checked == true)
//                {
//                    foreach (HtmlElement hte in WebbrowserArr[i].Document.All)
//                    {
//                        if (hte.TagName == "LI" &&
//                            hte.GetAttribute("data-text") == "host" &&
//                            hte.InnerText != null &&
//                            hte.InnerText.IndexOf("屋主") != -1)
//                        {
//                            hte.InvokeMember("click");
//                            break;
//                        }
//                    }
//                }
//                else if (radioButton2.Checked == true)
//                {
//                    foreach (HtmlElement hte in WebbrowserArr[i].Document.All)
//                    {
//                        if (hte.TagName == "LI" &&
//                            hte.GetAttribute("data-text") == "list" &&
//                            hte.InnerText != null &&
//                            hte.InnerText.IndexOf("所有物件") != -1)
//                        {
//                            hte.InvokeMember("click");
//                            break;
//                        }
//                    }
//                }
//            }
//        }


//        private void button1_Click(object sender, EventArgs e)
//        {
//            label23.Text = "程式運行中";

//            string PicPath = System.IO.Directory.GetCurrentDirectory() + "\\圖片";
//            if (Directory.Exists(PicPath) == false)
//            {
//                Directory.CreateDirectory(PicPath);
//            }
//            PicPath = PicPath + "\\";
//            //檢查資料庫路徑與圖片路徑
//            set_taipei_all_or_host();

            


//            int[] PageArr = new int[13];
            
//            const int SHEET_INDEX = 1;
//            const int COLUMN_NUM = 17;
//            const int WEB_COLUMN = 15;

//            string Path = System.IO.Directory.GetCurrentDirectory() + "\\台北市.xlsx";
            
//            string[] TitleArr = new string[] { "品牌", "次序", "案名", "地址", "價格",
//                                               "格局", "加蓋格局", "坪數", "樓層", "屋齡",
//                                               "索引", "種類", "外觀", "車位", "網址",
//                                               "主建物","段建號" , "土地坪數","種類B",
//                                               "租金","設備","社區","單價" };
//            /*
//            Brand =1,Order=2,Project=3,Addr=4,Price=5,
//            Form=6,AddForm=7,Plain=8,Floor=9,HouseOld=10,
//            Index = 11,Kind=12,Interface=13,Car=14,Web=15,
//            Building=16,Section =17,GroundPlain=18,KindB=19,Rent=20,Equipment=21,Community=22,DevidePrice =23             
//             */
//            string[] SheetArr = new string[] { "中古屋出租", "店面出租", "店面頂讓", "店面出售", "辦公出租",
//                                               "住辦出租", "辦公出售","住辦出售", "廠房出租", "土地出租", "廠房出售", "土地出售" };


//            Storage[] StorageArr1 = {   new Storage(0,(int)crudeCellX.Brand,SHEET_INDEX),new Storage(0,(int)crudeCellX.Order,SHEET_INDEX),
//                                       new Storage(0,(int)crudeCellX.Project,SHEET_INDEX),new Storage(0,(int)crudeCellX.Addr,SHEET_INDEX),
//                                       new Storage(0,(int)crudeCellX.Price,SHEET_INDEX),new Storage(0,(int)crudeCellX.Form,SHEET_INDEX),
//                                       new Storage(0,(int)crudeCellX.AddForm,SHEET_INDEX),new Storage(0,(int)crudeCellX.Plain,SHEET_INDEX),
//                                       new Storage(0,(int)crudeCellX.Floor,SHEET_INDEX),new Storage(0,(int)crudeCellX.HouseOld,SHEET_INDEX),
//                                       new Storage(0,(int)crudeCellX.Index,SHEET_INDEX),new Storage(0,(int)crudeCellX.Kind,SHEET_INDEX),
//                                       new Storage(0,(int)crudeCellX.Interface,SHEET_INDEX),new Storage(0,(int)crudeCellX.Car,SHEET_INDEX),
//                                       new Storage(0,(int)crudeCellX.Web,SHEET_INDEX), new Storage(0,(int)crudeCellX.Building,SHEET_INDEX),
//                                       new Storage(0,(int)crudeCellX.Section,SHEET_INDEX),new Storage(0,(int)crudeCellX.GroundPlain,SHEET_INDEX),
//                                       new Storage(0,(int)crudeCellX.KindB,SHEET_INDEX),new Storage(0,(int)crudeCellX.Rent,SHEET_INDEX),
//                                       new Storage(0,(int)crudeCellX.Equipment,SHEET_INDEX),new Storage(0,(int)crudeCellX.Community,SHEET_INDEX),
//                                       new Storage(0,(int)crudeCellX.DevidePrice,SHEET_INDEX),
//                                       };

//            Storage[] StorageArr2 = {   new Storage(0,(int)crudeCellX.Brand,SHEET_INDEX),new Storage(0,(int)crudeCellX.Order,SHEET_INDEX),
//                                       new Storage(0,(int)crudeCellX.Project,SHEET_INDEX),new Storage(0,(int)crudeCellX.Addr,SHEET_INDEX),
//                                       new Storage(0,(int)crudeCellX.Price,SHEET_INDEX),new Storage(0,(int)crudeCellX.Form,SHEET_INDEX),
//                                       new Storage(0,(int)crudeCellX.AddForm,SHEET_INDEX),new Storage(0,(int)crudeCellX.Plain,SHEET_INDEX),
//                                       new Storage(0,(int)crudeCellX.Floor,SHEET_INDEX),new Storage(0,(int)crudeCellX.HouseOld,SHEET_INDEX),
//                                       new Storage(0,(int)crudeCellX.Index,SHEET_INDEX),new Storage(0,(int)crudeCellX.Kind,SHEET_INDEX),
//                                       new Storage(0,(int)crudeCellX.Interface,SHEET_INDEX),new Storage(0,(int)crudeCellX.Car,SHEET_INDEX),
//                                       new Storage(0,(int)crudeCellX.Web,SHEET_INDEX), new Storage(0,(int)crudeCellX.Building,SHEET_INDEX),
//                                       new Storage(0,(int)crudeCellX.Section,SHEET_INDEX),new Storage(0,(int)crudeCellX.GroundPlain,SHEET_INDEX),
//                                       new Storage(0,(int)crudeCellX.KindB,SHEET_INDEX),new Storage(0,(int)crudeCellX.Rent,SHEET_INDEX),
//                                       new Storage(0,(int)crudeCellX.Equipment,SHEET_INDEX),new Storage(0,(int)crudeCellX.Community,SHEET_INDEX),
//                                       new Storage(0,(int)crudeCellX.DevidePrice,SHEET_INDEX),
//                                       };

            
            
//            webForInterface[] webForInterface1 = { new sale591(webBrowser1, label22, false, false), new rent591(webBrowser2, label21, false, false) };
//            webForInterface1[0].add_after_process(new clickTag("SPAN,,,,,下一頁,,,", 500, true));
//            webForInterface1[1].add_after_process(new clickTag("SPAN,,,,,下一頁,,,", 500, true));
            
//            for (int i = 0; i < 2; i++)
//            {
//                if (i==0)
//                {
//                    webForInterface1[i].running(StorageArr1);                    
//                }
//                else if (i==1)
//                {
//                    webForInterface1[i].running(StorageArr2);                    
//                }
                
//                //清除粗抓地址
//                //InputExcel1.write_data(StorageArr2);

//            }
            
//            WebBrowser[] WebBrowserArr =  { webBrowser1,webBrowser2,webBrowser3,webBrowser4, webBrowser5 , webBrowser6, webBrowser7,
//                                            webBrowser8,webBrowser9, webBrowser10 , webBrowser11, webBrowser12,webBrowser13};

//            stuff_data[] StuffDataArr = { running_store_rent, running_toplet, running_shop_sale, running_office_rent, running_live_office_rent,
//                                          running_office_sale,running_live_office_sale,running_factory_rent,running_ground_rent,running_factory_sale,
//                                          running_ground_sale };



//            InputExcel InputExcel1 = new InputExcel(Path, true, true, "中古屋出售");
//            string[] Column = new string[] {  "品牌", "次序", "案名", "地址A", "價格",
//                                              "格局", "加蓋格局", "坪數", "樓層", "屋齡",
//                                              "索引", "種類", "外觀", "車位", "網址",
//                                              "電話A", "抓取時間", "姓名","朝向","主建物",
//                                              "共用部分","附屬建物","土地坪數","電話B","現況",
//                                              "權狀坪數","種類B","租金","設備","社區",
//                                              "單價" };
//            InputExcel1.write_title(Column, 1);
            
//            for (int iSheet = 0; iSheet < SheetArr.Length; iSheet++)
//            {
//                InputExcel1.append_sheet(SheetArr[iSheet]);
//                InputExcel1.write_title(Column, iSheet + 2);
//            }
            
//            Storage[] StorageArr = {   new Storage(0,(int)crudeCellX.Brand,SHEET_INDEX),new Storage(0,(int)crudeCellX.Order,SHEET_INDEX),
//                                       new Storage(0,(int)crudeCellX.Project,SHEET_INDEX),new Storage(0,(int)crudeCellX.Addr,SHEET_INDEX),
//                                       new Storage(0,(int)crudeCellX.Price,SHEET_INDEX),new Storage(0,(int)crudeCellX.Form,SHEET_INDEX),
//                                       new Storage(0,(int)crudeCellX.AddForm,SHEET_INDEX),new Storage(0,(int)crudeCellX.Plain,SHEET_INDEX),
//                                       new Storage(0,(int)crudeCellX.Floor,SHEET_INDEX),new Storage(0,(int)crudeCellX.HouseOld,SHEET_INDEX),
//                                       new Storage(0,(int)crudeCellX.Index,SHEET_INDEX),new Storage(0,(int)crudeCellX.Kind,SHEET_INDEX),
//                                       new Storage(0,(int)crudeCellX.Interface,SHEET_INDEX),new Storage(0,(int)crudeCellX.Car,SHEET_INDEX),
//                                       new Storage(0,(int)crudeCellX.Web,SHEET_INDEX), new Storage(0,(int)crudeCellX.Building,SHEET_INDEX),
//                                       new Storage(0,(int)crudeCellX.Section,SHEET_INDEX),new Storage(0,(int)crudeCellX.GroundPlain,SHEET_INDEX),
//                                       new Storage(0,(int)crudeCellX.KindB,SHEET_INDEX),new Storage(0,(int)crudeCellX.Rent,SHEET_INDEX),
//                                       new Storage(0,(int)crudeCellX.Equipment,SHEET_INDEX),new Storage(0,(int)crudeCellX.Community,SHEET_INDEX),
//                                       new Storage(0,(int)crudeCellX.DevidePrice,SHEET_INDEX),
//                                       };



            
//            Storage[] StorageTinyArr = {   new Storage(0,(int)tinyCellX.Brand,SHEET_INDEX),new Storage(0,(int)tinyCellX.Order,SHEET_INDEX),
//                                               new Storage(0,(int)tinyCellX.Project,SHEET_INDEX),new Storage(0,(int)tinyCellX.Addr,SHEET_INDEX),
//                                               new Storage(0,(int)tinyCellX.Price,SHEET_INDEX),new Storage(0,(int)tinyCellX.Form,SHEET_INDEX),
//                                               new Storage(0,(int)tinyCellX.AddForm,SHEET_INDEX),new Storage(0,(int)tinyCellX.Plain,SHEET_INDEX),
//                                               new Storage(0,(int)tinyCellX.Floor,SHEET_INDEX),new Storage(0,(int)tinyCellX.HouseOld,SHEET_INDEX),
//                                               new Storage(0,(int)tinyCellX.Index,SHEET_INDEX),new Storage(0,(int)tinyCellX.Kind,SHEET_INDEX),
//                                               new Storage(0,(int)tinyCellX.Interface,SHEET_INDEX),new Storage(0,(int)tinyCellX.Car,SHEET_INDEX),
//                                               new Storage(0,(int)tinyCellX.Web,SHEET_INDEX), new Storage(0,(int)tinyCellX.PhoneA,SHEET_INDEX),
//                                               new Storage(0,(int)tinyCellX.GripTime,SHEET_INDEX),new Storage(0,(int)tinyCellX.Name,SHEET_INDEX),
//                                               new Storage(0,(int)tinyCellX.Toward,SHEET_INDEX),new Storage(0,(int)tinyCellX.Building,SHEET_INDEX),
//                                               new Storage(0,(int)tinyCellX.Common,SHEET_INDEX),new Storage(0,(int)tinyCellX.AppendBuilding,SHEET_INDEX),
//                                               new Storage(0,(int)tinyCellX.GroundPlain,SHEET_INDEX),new Storage(0,(int)tinyCellX.PhoneB,SHEET_INDEX),
//                                               new Storage(0,(int)tinyCellX.NowState,SHEET_INDEX),new Storage(0,(int)tinyCellX.AuthorityPlain,SHEET_INDEX),
//                                               new Storage(0,(int)tinyCellX.KindB,SHEET_INDEX),new Storage(0,(int)tinyCellX.Rent,SHEET_INDEX),
//                                               new Storage(0,(int)tinyCellX.Equipment,SHEET_INDEX),new Storage(0,(int)tinyCellX.Community,SHEET_INDEX),
//                                               new Storage(0,(int)tinyCellX.DevidePrice,SHEET_INDEX),
//                                       };

//            for (int i = 0;i < 13;i++)
//            //for (int i = 2; i < 5; i++)
//            {
//                //粗抓寫入
//                if (i !=0 && i!=1)
//                {
//                    NewWeb NewWeb = new NewWeb(WebBrowserArr[i], get_page_shop);
//                    pageFilter pageFilter1 = new pageFilter(NewWeb.get_page(), 30, get_page_shop_format);
//                    PageArr[i] = pageFilter1.rtn_page_rlt();
//                    NewWeb.running(WebBrowserArr[i], StorageArr, whole_head, data_head, StuffDataArr[i-2], data_end, click_sale_rent, PageArr[i], true);
//                }
               
//                //InputExcel1.write_data(StorageArr);
                
//                //細抓寫入
                
//                string[] ColumnValue = new string[31];

             

//                storage_stuff[] storage_stuff1 = {  house_sale_stuff_storage,house_rent_stuff_storage,
//                                                    store_rent_stuff_storage, store_tolpet_stuff_storage, store_sale_stuff_storage,
//                                                    rent_unite_stuff_storage, rent_unite_stuff_storage,sale_unite_stuff_storage,
//                                                    sale_unite_stuff_storage,rent_unite_stuff_storage,rent_unite_stuff_storage,
//                                                    sale_unite_stuff_storage,sale_unite_stuff_storage };
//                //public NewNewWeb(WebBrowser webBrowser1,hteFilter hteFilter1, dataFilter dataFilter1, next_page data_head, next_page data_end, next_page whole_grip,next_page next_page1)
//                //出售
//                NewNewWeb NewNewWeb = new NewNewWeb(WebBrowserArr[i], get_page_shop, get_page_shop_format, tiny_whole_and_data_head, tiny_data_end, tiny_whole_and_data_head, click_sale_rent);

//                if (i == 0)
//                {
//                     NewNewWeb = new NewNewWeb(WebBrowserArr[i], get_page_shop, get_page_shop_format, house_sale_whole_head, house_sale_data_end, house_sale_whole_head, click_sale_rent);
//                }
//                else if (i== 1)
//                {
//                     NewNewWeb = new NewNewWeb(WebBrowserArr[i], get_page_shop, get_page_shop_format, house_rent_whole_head, house_rent_data_end, house_rent_whole_head, click_sale_rent);
//                }
//                else if (i == 3)
//                {
//                    NewNewWeb = new NewNewWeb(WebBrowserArr[i], get_page_shop, get_page_shop_format, tolpet_whole_data_head, tolpet_data_end, tolpet_whole_data_head, click_sale_rent);
//                }
//                else if (i == 2 || i == 5 || i == 6 || i == 9 || i == 10)//出租
//                {
//                    NewNewWeb = new NewNewWeb(WebBrowserArr[i], get_page_shop, get_page_shop_format, rent_whole_data_head, rent_data_end, rent_whole_data_head, click_sale_rent);
//                }
                

//                //掛載填入小函數
//                if (i ==0 || i==4 ||i==7 || i == 8 || i==11 || i==12)//中古屋出售.店面出售
//                {
//                    NewNewWeb.add_stuff_data_process(sale_phone);
//                    NewNewWeb.add_stuff_data_process(sale_phone_fixed);

//                    NewNewWeb.add_stuff_data_process(sale_name);
//                    NewNewWeb.add_stuff_data_process(sale_addr);
//                    NewNewWeb.add_stuff_data_process(sale_index);                                       
//                    NewNewWeb.add_stuff_data_process(sale_toward);
//                    NewNewWeb.add_stuff_data_process(sale_building_group);
//                    NewNewWeb.add_stuff_data_process(sale_floor);
//                    NewNewWeb.add_stuff_data_process(sale_houseold);
//                    //

//                    NewNewWeb.add_stuff_data_process(sale_commuity);
//                    NewNewWeb.add_stuff_data_process(sale_plain);
//                    NewNewWeb.add_stuff_data_process(sale_ground_plain);
                    
//                    NewNewWeb.add_stuff_data_process(sale_now_state);
//                    NewNewWeb.add_stuff_data_process(sale_kind_a);
//                    //sale_phone_fixed

//                    NewNewWeb.add_stuff_data_process(building_sale_addr);
//                    NewNewWeb.add_stuff_data_process(building_sale_plain);
//                    NewNewWeb.add_stuff_data_process(building_sale_name);


//                }

//                else if (i ==1 || i==2 || i == 5 || i == 6 || i==9 || i== 10)//中古屋出租.店面出租
//                {

//                    NewNewWeb.add_stuff_data_process(grip_phone_fixed);
//                    NewNewWeb.add_stuff_data_process(grip_phone_mobile);

//                    NewNewWeb.add_stuff_data_process(grip_addr);
//                    NewNewWeb.add_stuff_data_process(grip_index);
//                    NewNewWeb.add_stuff_data_process(grip_name_rent);
                    
//                    NewNewWeb.add_stuff_data_process(rent_group);
//                    NewNewWeb.add_stuff_data_process(rent_car);
//                }
//                else if (i == 3)//頂讓
//                {

//                    NewNewWeb.add_stuff_data_process(tolpet_grip_phone);

//                    NewNewWeb.add_stuff_data_process(tolpet_index);
//                    NewNewWeb.add_stuff_data_process(tolpet_plain);
//                    NewNewWeb.add_stuff_data_process(tolpet_rent);
//                    NewNewWeb.add_stuff_data_process(tolpet_floor);
//                    NewNewWeb.add_stuff_data_process(tolpet_kind);
//                    NewNewWeb.add_stuff_data_process(tolpet_kind_b);
//                    NewNewWeb.add_stuff_data_process(tolpet_addr);
                    
//                    NewNewWeb.add_stuff_data_process(tolpet__name);

                    
//                }


//                //for (int iWeb = 0; iWeb <100; iWeb++)
//                int EndWebCount = StorageArr[(int)crudeMeaningCellX.Web].Content.Count;
//                if (i == 0)
//                {
//                    EndWebCount = StorageArr1[(int)crudeMeaningCellX.Web].Content.Count;
//                }
//                else if (i == 1)
//                {
//                    EndWebCount = StorageArr2[(int)crudeMeaningCellX.Web].Content.Count;
//                }
//                for (int iWeb=0; iWeb< EndWebCount; iWeb++)
//                {


//                        if (i == 0)
//                        {
//                            storage_stuff1[i](StorageTinyArr, StorageArr1, iWeb);
//                            NewNewWeb.set_url(StorageArr1[(int)crudeMeaningCellX.Web].Content[iWeb].ToString());
//                        }
//                        else if (i == 1)
//                        {
//                            storage_stuff1[i](StorageTinyArr, StorageArr2, iWeb);
//                            NewNewWeb.set_url(StorageArr2[(int)crudeMeaningCellX.Web].Content[iWeb].ToString());
//                        }
//                        else
//                        {
//                            storage_stuff1[i](StorageTinyArr, StorageArr, iWeb);
//                            NewNewWeb.set_url(StorageArr[(int)crudeMeaningCellX.Web].Content[iWeb].ToString());
//                        }

//                        NewNewWeb.ruuning(StorageTinyArr, null, 0, true);
//                        NewNewWeb.replenish_one_data(StorageTinyArr);
//                    //檢查沒有物件補位

//                        string TmpStr = "";

//                            if (File.Exists(PicPath + StorageTinyArr[(int)tinyMeaningCellX.Project].Content[iWeb].ToString() + StorageTinyArr[(int)tinyMeaningCellX.Index].Content[iWeb].ToString() + ".png") == true)
//                            {
//                                File.Delete(PicPath + StorageTinyArr[(int)tinyMeaningCellX.Project].Content[iWeb].ToString() + StorageTinyArr[(int)tinyMeaningCellX.Index].Content[iWeb].ToString() + ".png");
//                            }
//                        if (StorageTinyArr[(int)tinyMeaningCellX.PhoneB].Content[iWeb].ToString().IndexOf("http")!= -1)
//                        {
//                            save_phone_pic(PicPath, StorageTinyArr[(int)tinyMeaningCellX.Project].Content[iWeb].ToString() + StorageTinyArr[(int)tinyMeaningCellX.Index].Content[iWeb].ToString() + ".png", StorageTinyArr[(int)tinyMeaningCellX.PhoneB].Content[iWeb].ToString());
//                        }
                            

//                        if (File.Exists(PicPath + StorageTinyArr[(int)tinyMeaningCellX.Project].Content[iWeb].ToString() + StorageTinyArr[(int)tinyMeaningCellX.Index].Content[iWeb].ToString() + ".png") == true)
//                        {
//                            var image = new Bitmap(PicPath + StorageTinyArr[(int)tinyMeaningCellX.Project].Content[iWeb].ToString() + StorageTinyArr[(int)tinyMeaningCellX.Index].Content[iWeb].ToString() + ".png");
                            
//                            string TessPath = System.IO.Directory.GetCurrentDirectory() + "\\tessdata";
//                            var ocr = new Tesseract(TessPath, "eng", Tesseract.OcrEngineMode.OEM_DEFAULT);
//                            ocr.SetVariable("tessedit_char_whitelist", "0123456789-");

//                            using (Emgu.CV.Image<Bgr, Byte> img = new Image<Bgr, Byte>(image))
//                            {
//                                ocr.Recognize<Bgr>(img);
//                                TmpStr = ocr.GetText();
//                                TmpStr = TmpStr.Replace(" ", "");
//                                //TmpStr = TmpStr.Substring(0, 4) + TmpStr.Substring(6, 3) + TmpStr.Substring(11, 3);
//                                //MessageBox.Show(TmpStr, "RECOGNITION");
//                            }
//                            image.Dispose();
//                            ocr.Dispose();
//                        }
                        



//                        if (i != 0)
//                        {
//                            ColumnValue[0] = SheetArr[i - 1];
//                        }
//                        else
//                        {
//                            ColumnValue[0] = "中古屋出售";
//                        }

//                        for (int iIndex = 2; iIndex < 31; iIndex++)
//                        {
//                            if (iIndex == 23)
//                            {
//                                ColumnValue[iIndex] = TmpStr;
//                            }
//                            else
//                            {
//                                ColumnValue[iIndex] = StorageTinyArr[iIndex].Content[iWeb].ToString();
//                            }


//                        }

//                        dataBaseControl.insert_into_sql("台北市", Column, ColumnValue, 31);
                    


//                }
//                InputExcel1.write_data(StorageTinyArr);
//                NewNewWeb.clear_stuff_data_process();
//                //細抓初始化
//                for (int iClear = 0; iClear < 31; iClear++)
//                {
//                    StorageTinyArr[iClear].SheetIndex = StorageTinyArr[iClear].SheetIndex + 1;
//                    StorageTinyArr[iClear].Content.Clear();
//                }

//                //粗抓初始化
//                for (int k = 0; k < 23; k++)
//                {
//                    StorageArr[k].SheetIndex = StorageArr[k].SheetIndex + 1;
//                    StorageArr[k].Content.Clear();
//                }
//            }
































            

//            /*
//            //新北市
//            set_new_taipei_all_or_host();
//            Path = System.IO.Directory.GetCurrentDirectory() + "\\新北市.xlsx";
//            InputExcel InputExcel2 = new InputExcel(Path, true, true, "中古屋出售");

//            InputExcel2.write_title(Column, 1);
            
//            webForInterface[] webForInterface2 = { new sale591(webBrowser1, label22, false, true), new rent591(webBrowser2, label21, false, true) };
//            webForInterface2[0].add_after_process(new clickTag("SPAN,,,,,下一頁,,,", 500, true));
//            webForInterface2[1].add_after_process(new clickTag("SPAN,,,,,下一頁,,,", 500, true));
            
//            for (int i = 0; i < 2; i++)
//            {
//                if (i == 0)
//                {
//                    webForInterface2[i].running(StorageArr1);
//                }
//                else if (i == 1)
//                {
//                    webForInterface2[i].running(StorageArr2);
//                }

//                //清除粗抓地址
//                //InputExcel1.write_data(StorageArr2);

//            }
           
//            InputExcel2.write_title(Column, 1);

//            for (int iSheet = 0; iSheet < SheetArr.Length; iSheet++)
//            {
//                InputExcel2.append_sheet(SheetArr[iSheet]);
//                InputExcel2.write_title(Column, iSheet + 2);
//            }
            
            

//            for (int i = 0; i < 13; i++)
//            //for (int i = 2; i < 5; i++)
//            {
//                //粗抓寫入
//                if (i != 0 && i != 1)
//                {
//                    NewWeb NewWeb = new NewWeb(WebBrowserArr[i], get_page_shop);
//                    pageFilter pageFilter1 = new pageFilter(NewWeb.get_page(), 30, get_page_shop_format);
//                    PageArr[i] = pageFilter1.rtn_page_rlt();
//                    NewWeb.running(WebBrowserArr[i], StorageArr, whole_head, data_head, StuffDataArr[i - 2], data_end, click_sale_rent, PageArr[i], true);
//                }

//                //InputExcel1.write_data(StorageArr);

//                //細抓寫入

//                string[] ColumnValue = new string[31];



//                storage_stuff[] storage_stuff1 = {  house_sale_stuff_storage,house_rent_stuff_storage,
//                                                    store_rent_stuff_storage, store_tolpet_stuff_storage, store_sale_stuff_storage,
//                                                    rent_unite_stuff_storage, rent_unite_stuff_storage,sale_unite_stuff_storage,
//                                                    sale_unite_stuff_storage,rent_unite_stuff_storage,rent_unite_stuff_storage,
//                                                    sale_unite_stuff_storage,sale_unite_stuff_storage };
//                //public NewNewWeb(WebBrowser webBrowser1,hteFilter hteFilter1, dataFilter dataFilter1, next_page data_head, next_page data_end, next_page whole_grip,next_page next_page1)
//                //出售
//                NewNewWeb NewNewWeb = new NewNewWeb(WebBrowserArr[i], get_page_shop, get_page_shop_format, tiny_whole_and_data_head, tiny_data_end, tiny_whole_and_data_head, click_sale_rent);

//                if (i == 0)
//                {
//                    NewNewWeb = new NewNewWeb(WebBrowserArr[i], get_page_shop, get_page_shop_format, house_sale_whole_head, house_sale_data_end, house_sale_whole_head, click_sale_rent);
//                }
//                else if (i == 1)
//                {
//                    NewNewWeb = new NewNewWeb(WebBrowserArr[i], get_page_shop, get_page_shop_format, house_rent_whole_head, house_rent_data_end, house_rent_whole_head, click_sale_rent);
//                }
//                else if (i == 3)
//                {
//                    NewNewWeb = new NewNewWeb(WebBrowserArr[i], get_page_shop, get_page_shop_format, tolpet_whole_data_head, tolpet_data_end, tolpet_whole_data_head, click_sale_rent);
//                }
//                else if (i == 2 || i == 5 || i == 6 || i == 9 || i == 10)//出租
//                {
//                    NewNewWeb = new NewNewWeb(WebBrowserArr[i], get_page_shop, get_page_shop_format, rent_whole_data_head, rent_data_end, rent_whole_data_head, click_sale_rent);
//                }


//                //掛載填入小函數
//                if (i == 0 || i == 4 || i == 7 || i == 8 || i == 11 || i == 12)//中古屋出售.店面出售
//                {
//                    NewNewWeb.add_stuff_data_process(sale_phone);
//                    NewNewWeb.add_stuff_data_process(sale_phone_fixed);

//                    NewNewWeb.add_stuff_data_process(sale_name);
//                    NewNewWeb.add_stuff_data_process(sale_addr);
//                    NewNewWeb.add_stuff_data_process(sale_index);
//                    NewNewWeb.add_stuff_data_process(sale_toward);
//                    NewNewWeb.add_stuff_data_process(sale_building_group);
//                    NewNewWeb.add_stuff_data_process(sale_floor);
//                    NewNewWeb.add_stuff_data_process(sale_houseold);
//                    //

//                    NewNewWeb.add_stuff_data_process(sale_commuity);
//                    NewNewWeb.add_stuff_data_process(sale_plain);
//                    NewNewWeb.add_stuff_data_process(sale_ground_plain);

//                    NewNewWeb.add_stuff_data_process(sale_now_state);
//                    NewNewWeb.add_stuff_data_process(sale_kind_a);
//                    //sale_phone_fixed

//                    NewNewWeb.add_stuff_data_process(building_sale_addr);
//                    NewNewWeb.add_stuff_data_process(building_sale_plain);
//                    NewNewWeb.add_stuff_data_process(building_sale_name);


//                }

//                else if (i == 1 || i == 2 || i == 5 || i == 6 || i == 9 || i == 10)//中古屋出租.店面出租
//                {

//                    NewNewWeb.add_stuff_data_process(grip_phone_fixed);
//                    NewNewWeb.add_stuff_data_process(grip_phone_mobile);

//                    NewNewWeb.add_stuff_data_process(grip_addr);
//                    NewNewWeb.add_stuff_data_process(grip_index);
//                    NewNewWeb.add_stuff_data_process(grip_name_rent);

//                    NewNewWeb.add_stuff_data_process(rent_group);
//                    NewNewWeb.add_stuff_data_process(rent_car);
//                }
//                else if (i == 3)//頂讓
//                {
                    
//                    NewNewWeb.add_stuff_data_process(tolpet_grip_phone);
//                    NewNewWeb.add_stuff_data_process(tolpet_grip_fixed);
                    
//                    NewNewWeb.add_stuff_data_process(tolpet_index);
//                    NewNewWeb.add_stuff_data_process(tolpet_plain);
//                    NewNewWeb.add_stuff_data_process(tolpet_rent);
//                    NewNewWeb.add_stuff_data_process(tolpet_floor);
//                    NewNewWeb.add_stuff_data_process(tolpet_kind);
//                    NewNewWeb.add_stuff_data_process(tolpet_kind_b);
//                    NewNewWeb.add_stuff_data_process(tolpet_addr);

//                    NewNewWeb.add_stuff_data_process(tolpet__name);


//                }


//                //for (int iWeb = 0; iWeb < 3; iWeb++)
//                for (int iWeb=0; iWeb< StorageArr[(int)crudeMeaningCellX.Web].Content.Count;iWeb++)
//                {

//                    try
//                    {
//                        if (i == 0)
//                        {
//                            storage_stuff1[i](StorageTinyArr, StorageArr1, iWeb);
//                            NewNewWeb.set_url(StorageArr1[(int)crudeMeaningCellX.Web].Content[iWeb].ToString());
//                        }
//                        else if (i == 1)
//                        {
//                            storage_stuff1[i](StorageTinyArr, StorageArr2, iWeb);
//                            NewNewWeb.set_url(StorageArr2[(int)crudeMeaningCellX.Web].Content[iWeb].ToString());
//                        }
//                        else
//                        {
//                            storage_stuff1[i](StorageTinyArr, StorageArr, iWeb);
//                            NewNewWeb.set_url(StorageArr[(int)crudeMeaningCellX.Web].Content[iWeb].ToString());
//                        }

//                        NewNewWeb.ruuning(StorageTinyArr, null, 0, true);
//                        string TmpStr = "";
//                        try
//                        {
//                            if (File.Exists(textBox2.Text + StorageTinyArr[(int)tinyMeaningCellX.Project].Content[iWeb].ToString() + StorageTinyArr[(int)tinyMeaningCellX.Index].Content[iWeb].ToString() + ".png") == true)
//                            {
//                                File.Delete(textBox2.Text + StorageTinyArr[(int)tinyMeaningCellX.Project].Content[iWeb].ToString() + StorageTinyArr[(int)tinyMeaningCellX.Index].Content[iWeb].ToString() + ".png");
//                            }
//                            save_phone_pic(textBox2.Text, StorageTinyArr[(int)tinyMeaningCellX.Project].Content[iWeb].ToString() + StorageTinyArr[(int)tinyMeaningCellX.Index].Content[iWeb].ToString() + ".png", StorageTinyArr[(int)tinyMeaningCellX.PhoneB].Content[iWeb].ToString());
//                            var image = new Bitmap(textBox2.Text + StorageTinyArr[(int)tinyMeaningCellX.Project].Content[iWeb].ToString() + StorageTinyArr[(int)tinyMeaningCellX.Index].Content[iWeb].ToString() + ".png");

//                            string TessPath = System.IO.Directory.GetCurrentDirectory() + "\\tessdata";
//                            var ocr = new Tesseract(TessPath, "eng", Tesseract.OcrEngineMode.OEM_DEFAULT);
//                            ocr.SetVariable("tessedit_char_whitelist", "0123456789-");

//                            using (Emgu.CV.Image<Bgr, Byte> img = new Image<Bgr, Byte>(image))
//                            {
//                                try
//                                {
//                                    ocr.Recognize<Bgr>(img);
//                                    TmpStr = ocr.GetText();
//                                    TmpStr = TmpStr.Replace(" ", "");
//                                    //TmpStr = TmpStr.Substring(0, 4) + TmpStr.Substring(6, 3) + TmpStr.Substring(11, 3);
//                                    //MessageBox.Show(TmpStr, "RECOGNITION");
//                                }
//                                catch
//                                {
//                                    TmpStr = "0";
//                                }
//                            }
//                        }
//                        catch
//                        {
//                            TmpStr = "0";
//                        }
//                        if (i != 0)
//                        {
//                            ColumnValue[0] = SheetArr[i-1];
//                        }
//                        else
//                        {
//                            ColumnValue[0] = "中古屋出售";
//                        }
//                        ColumnValue[1] = "";
//                        for (int iIndex = 2; iIndex < 31; iIndex++)
//                        {
//                            if (iIndex == 23)
//                            {
//                                ColumnValue[iIndex] = TmpStr;
//                            }
//                            else
//                            {
//                                ColumnValue[iIndex] = StorageTinyArr[iIndex].Content[iWeb].ToString();
//                            }


//                        }

//                        dataBaseControl.insert_into_sql("新北市", Column, ColumnValue, 31);
//                    }


//                    catch
//                    {

//                    }


//                }
//                InputExcel2.write_data(StorageTinyArr);

//                NewNewWeb.clear_stuff_data_process();
//                //細抓初始化
//                for (int iClear = 0; iClear < 31; iClear++)
//                {
//                    StorageTinyArr[iClear].SheetIndex = StorageTinyArr[iClear].SheetIndex + 1;
//                    StorageTinyArr[iClear].Content.Clear();
//                }

//                //粗抓初始化
//                for (int k = 0; k < 23; k++)
//                {
//                    StorageArr[k].SheetIndex = StorageArr[k].SheetIndex + 1;
//                    StorageArr[k].Content.Clear();
//                }
//            }

//            */

//            label23.Text = "運行完畢";
//            //running(Storage[] StorageArr, next_page whole_grip, next_page data_head, stuff_data stuff_data1,
//            //next_page data_end, next_page whole_end, next_page next_page1,int Page, bool WhTest = false)

//        }
//        private void button2_Click_1(object sender, EventArgs e)
//        {
            

//        }
//        private void clear_storage(Storage[] Storage1)
//        {
//            for (int iClear=0; iClear< Storage1.Length; iClear++)
//            {
//                Storage1[iClear].Content.Clear();
//            }
//        }
//        private void tabPage1_Click(object sender, EventArgs e)
//        {

//        }


//        private void save_phone_pic(string Path, string FileName, string Url)
//        {
//            if (Url == "不填入")
//            {
//                return;
//            }
//            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(Url);
//            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();

//            System.IO.Stream dataStream = httpResponse.GetResponseStream();
//            byte[] buffer = new byte[8192];
//            string StdPic = Path + "\\" + "showPhone.png";
//            FileStream fs = new FileStream(StdPic,
//                FileMode.Create, FileAccess.Write);
//            int size = 0;
//            do
//            {
//                size = dataStream.Read(buffer, 0, buffer.Length);
//                if (size > 0)
//                    fs.Write(buffer, 0, size);
//            } while (size > 0);
//            fs.Dispose();
//            dataStream.Dispose();
//            httpResponse.Dispose();
//            fs.Close();
//            dataStream.Close();
//            httpResponse.Close();

//            pictureBox1.Load(StdPic);
//            string strPicFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".bmp";
//            try
//            {
//                pictureBox1.Image.Save(Path + FileName, System.Drawing.Imaging.ImageFormat.Bmp);
//            }
//            catch
//            {

//            }

//            pictureBox1.Dispose();
//        }



//        //storage_move_storage
//        //storage_move_storage
//        //storage_move_storage
//        //storage_move_storage
//        //storage_move_storage
//        private void store_sale_stuff_storage(Storage[] StorageTinyArr, Storage[] Storage1, int Index)
//        {
//            StorageTinyArr[(int)tinyMeaningCellX.Web].Content.Add(Storage1[(int)crudeMeaningCellX.Web].Content[Index].ToString());
//            StorageTinyArr[(int)tinyMeaningCellX.Project].Content.Add(Storage1[(int)crudeMeaningCellX.Project].Content[Index].ToString());
//            StorageTinyArr[(int)tinyMeaningCellX.Price].Content.Add(Storage1[(int)crudeMeaningCellX.Price].Content[Index].ToString());
//            //StorageTinyArr[(int)tinyMeaningCellX.Floor].Content.Add(Storage1[(int)crudeMeaningCellX.Floor].Content[Index].ToString());

//        }
//        private void store_tolpet_stuff_storage(Storage[] StorageTinyArr, Storage[] Storage1, int Index)
//        {
//            StorageTinyArr[(int)tinyMeaningCellX.Web].Content.Add(Storage1[(int)crudeMeaningCellX.Web].Content[Index].ToString());
//            StorageTinyArr[(int)tinyMeaningCellX.Project].Content.Add(Storage1[(int)crudeMeaningCellX.Project].Content[Index].ToString());            
//            StorageTinyArr[(int)tinyMeaningCellX.Price].Content.Add(Storage1[(int)crudeMeaningCellX.Price].Content[Index].ToString());
//        }
//        private void store_rent_stuff_storage(Storage[] StorageTinyArr, Storage[] Storage1, int Index)
//        {
//            StorageTinyArr[(int)tinyMeaningCellX.Web].Content.Add(Storage1[(int)crudeMeaningCellX.Web].Content[Index].ToString());
//            StorageTinyArr[(int)tinyMeaningCellX.Project].Content.Add(Storage1[(int)crudeMeaningCellX.Project].Content[Index].ToString());
//            StorageTinyArr[(int)tinyMeaningCellX.Rent].Content.Add(Storage1[(int)crudeMeaningCellX.Rent].Content[Index].ToString());
//            StorageTinyArr[(int)tinyMeaningCellX.Price].Content.Add(Storage1[(int)crudeMeaningCellX.Price].Content[Index].ToString());
//        }
        
//        private void rent_unite_stuff_storage(Storage[] StorageTinyArr, Storage[] Storage1, int Index)
//        {
//            StorageTinyArr[(int)tinyMeaningCellX.Web].Content.Add(Storage1[(int)crudeMeaningCellX.Web].Content[Index].ToString());
//            StorageTinyArr[(int)tinyMeaningCellX.Project].Content.Add(Storage1[(int)crudeMeaningCellX.Project].Content[Index].ToString());
//            StorageTinyArr[(int)tinyMeaningCellX.Rent].Content.Add(Storage1[(int)crudeMeaningCellX.Rent].Content[Index].ToString());
//        }
//        private void sale_unite_stuff_storage(Storage[] StorageTinyArr, Storage[] Storage1, int Index)
//        {
//            StorageTinyArr[(int)tinyMeaningCellX.Web].Content.Add(Storage1[(int)crudeMeaningCellX.Web].Content[Index].ToString());
//            StorageTinyArr[(int)tinyMeaningCellX.Project].Content.Add(Storage1[(int)crudeMeaningCellX.Project].Content[Index].ToString());
//            StorageTinyArr[(int)tinyMeaningCellX.Price].Content.Add(Storage1[(int)crudeMeaningCellX.Price].Content[Index].ToString());
//        }        

//        private void house_sale_stuff_storage(Storage[] StorageTinyArr, Storage[] Storage1, int Index)
//        {
//            StorageTinyArr[(int)tinyMeaningCellX.Web].Content.Add(Storage1[(int)crudeMeaningCellX.Web].Content[Index].ToString());
//            StorageTinyArr[(int)tinyMeaningCellX.Project].Content.Add(Storage1[(int)crudeMeaningCellX.Project].Content[Index].ToString());
//            StorageTinyArr[(int)tinyMeaningCellX.Form].Content.Add(Storage1[(int)crudeMeaningCellX.Form].Content[Index].ToString());
//            StorageTinyArr[(int)tinyMeaningCellX.Price].Content.Add(Storage1[(int)crudeMeaningCellX.Price].Content[Index].ToString());
//            //StorageTinyArr[(int)tinyMeaningCellX.HouseOld].Content.Add(Storage1[(int)crudeMeaningCellX.HouseOld].Content[Index].ToString());
//            StorageTinyArr[(int)tinyMeaningCellX.Kind].Content.Add(Storage1[(int)crudeMeaningCellX.Kind].Content[Index].ToString());
//        }
//        private void house_rent_stuff_storage(Storage[] StorageTinyArr, Storage[] Storage1, int Index)
//        {
//            StorageTinyArr[(int)tinyMeaningCellX.Web].Content.Add(Storage1[(int)crudeMeaningCellX.Web].Content[Index].ToString());
//            StorageTinyArr[(int)tinyMeaningCellX.Project].Content.Add(Storage1[(int)crudeMeaningCellX.Project].Content[Index].ToString());
//            //StorageTinyArr[(int)tinyMeaningCellX.Floor].Content.Add(Storage1[(int)crudeMeaningCellX.Floor].Content[Index].ToString());
//            StorageTinyArr[(int)tinyMeaningCellX.Form].Content.Add(Storage1[(int)crudeMeaningCellX.Form].Content[Index].ToString());
//            StorageTinyArr[(int)tinyMeaningCellX.Price].Content.Add(Storage1[(int)crudeMeaningCellX.Price].Content[Index].ToString());

//        }
//        //stuff to storage
//        //stuff to storage
//        //stuff to storage
//        //stuff to storage
//        //stuff to storage



//        //下一頁將資料進行轉換成有用的格式
//        public string get_page_rent_format(string Tgt)
//        {
//            string TmpTgt = Tgt;
//            TmpTgt = TmpTgt.Replace("共找到", "");
//            TmpTgt = TmpTgt.Replace("間房屋", "");
//            return TmpTgt;
//        }
//        public string get_page_shop_format(string Tgt)
//        {
//            string TmpTgt = Tgt;
//            TmpTgt = TmpTgt.Replace("共", "");
//            TmpTgt = TmpTgt.Replace("筆", "");
//            return TmpTgt;
//        }
//        //抓取下一頁目標的函數(代理傳送)

//        //<span class="TotalRecord">&nbsp;&nbsp;共 <span class="R">1558 </span>筆</span>
//        public string get_page_shop(HtmlElement hte)
//        {
//            //<div class="pull-left hasData">共找到<i>590</i>間房屋</div>        
//            if (hte.TagName == "SPAN" &&
//                hte.GetAttribute("classname") == "TotalRecord")
//            {
//                return hte.InnerText;
//            }
//            return "";
//        }


//        public string get_page_rent(HtmlElement hte)
//        {
//            //<div class="pull-left hasData">共找到<i>590</i>間房屋</div>        
//            if (hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "pull-left hasData")
//            {
//                return hte.InnerText;
//            }
//            return "";
//        }

//        public string get_page_sale(HtmlElement hte)
//        {
//            //<div class="pull-left hasData">共找到<i>590</i>間房屋</div>        
//            if (hte.TagName == "DIV" &&
//            hte.GetAttribute("classname") == "houseList-head-title pull-left")
//            {
//                return hte.InnerText;
//            }
//            return "";
//        }
//        //抓取完畢要換頁
//        public bool click_sale_rent(HtmlElement hte)
//        {
//            if (hte.TagName == "A" && 
//                hte.GetAttribute("classname") == "pageNext")
//            {
//                hte.InvokeMember("click");
//                return true;               
//            }
//            return false;
//        }
//        public bool click_new_taipei_city(HtmlElement hte)
//        {
//            if (hte.TagName == "A" &&
//                    hte.GetAttribute("classname") == "active" &&
//                    hte.GetAttribute("data-id") == "3")
//            {
//                hte.InvokeMember("click");
//                return true;
//            }
//            return false;
//        }
//        public bool click_house_man(HtmlElement hte)
//        {
//            if (hte.TagName == "UL" &&
//                   hte.GetAttribute("classname") == "listTips clearfix")
//            {
//                HtmlElementCollection hteCollection = hte.Children;
//                hteCollection[1].InvokeMember("click");
//                return true;
//            }
//            return false;
//        }
//        /*
        
             
//        */
//        //單筆結束
//        public bool tolpet_data_end(HtmlElement hte)
//        {
//            if (hte.TagName == "DIV" &&
//                hte.GetAttribute("id") == "tab")
//            {
//                return true;
//            }
//            return false;
//        }
//        public bool data_end(HtmlElement hte)
//        {
//            if (hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "price")
//            {
//                return true;
//            }
//            return false;
//        } 
//        public bool tiny_data_end(HtmlElement hte)
//        {
//            if (hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "copyright")
//            {
//                return true;
//            }
//            return false;
//        }
//        public bool house_sale_data_end(HtmlElement hte)
//        {
//            if (hte.TagName == "DIV" &&
//               (hte.GetAttribute("classname") == "copyright" || hte.GetAttribute("classname") == "footer-copyright"))
//            {
//                return true;
//            }
//            return false;
//        }
//        public bool house_rent_data_end(HtmlElement hte)
//        {
//            if (hte.TagName == "A" &&
//                hte.GetAttribute("id") == "leaveMSG")
//            {
//                return true;
//            }
//            return false;
//        }
//        /*    
//              if (WhAllHead == true &&
//                WhGrip == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "price")
//            {
//                WhGrip = false;
//            }

//         */
//        //整體開始
//        public bool tolpet_whole_data_head(HtmlElement hte)
//        {
//            if (hte.TagName == "DIV" &&
//                hte.GetAttribute("id") == "main")
//            {
//                return true;
//            }
//            return false;
//        }



//        public bool rent_whole_data_head(HtmlElement hte)
//        {
//            if (hte.TagName == "A" &&
//                hte.InnerText == "首頁")
//            {
//                return true;
//            }
//            return false;
//        }
//        public bool rent_data_end(HtmlElement hte)
//        {
//            if (hte.TagName == "DIV" &&
//                hte.GetAttribute("id") == "footer")
//            {
//                return true;
//            }
//            return false;
//        }
//        public bool whole_head(HtmlElement hte)
//        {
//            if (hte.TagName == "DIV" &&
//                hte.GetAttribute("id") == "content")
//            {
//                return true;
//            }
//            return false;
//        }
//        public bool tiny_whole_and_data_head(HtmlElement hte)
//        {
//            if (hte.TagName == "DIV" &&
//                hte.GetAttribute("id") == "container")
//            {
//                return true;
//            }
//            return false;
//        }
//        public bool house_sale_whole_head(HtmlElement hte)
//        {
//            if (hte.TagName == "DIV" &&
//               hte.GetAttribute("id") == "container")
//            {
//                return true;
//            }
//            return false;
//        }
//        public bool house_rent_whole_head(HtmlElement hte)
//        {
//            if (hte.TagName == "DIV" &&
//               hte.GetAttribute("id") == "propNav")
//            {
//                return true;
//            }
//            return false;
//        }
//        /*
//         if (hte.TagName == "DIV" &&
//                   hte.GetAttribute("id") == "content")
//           {
//               WhAllHead = true;
//           }
//           */
//        //單筆開始
//        public bool data_head(HtmlElement hte)
//        {
//            if (hte.TagName == "DIV" &&
//               hte.GetAttribute("classname") == "imgSort")
//            {
//                return true;
//            }
//            return false;
//        }
//        public void store_tolpet_group(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "UL" &&
//                hte.GetAttribute("id") == "attr")
//            {
//                HtmlElementCollection hte1 = hte.Children;
//                for (int i = 0; i < hte1.Count; i++)
//                {
                   
//                    if (hte1[i].InnerText != null &&
//                        hte1[i].InnerText.IndexOf("租金：") != -1)
//                    {
//                        StorageArr[(int)tinyMeaningCellX.Rent].Content.Add(hte1[i].InnerText);
//                    }
//                    if (hte1[i].InnerText != null &&
//                        hte1[i].InnerText.IndexOf("坪數：") != -1)
//                    {
//                        StorageArr[(int)tinyMeaningCellX.Plain].Content.Add(hte1[i].InnerText);
//                    }
//                    if (hte1[i].InnerText != null &&
//                        hte1[i].InnerText.IndexOf("樓層：") != -1)
//                    {
//                        StorageArr[(int)tinyMeaningCellX.Floor].Content.Add(hte1[i].InnerText);
//                    }
//                    if (hte1[i].InnerText != null &&
//                        hte1[i].InnerText.IndexOf("店面類型：") != -1)
//                    {
//                        StorageArr[(int)tinyMeaningCellX.Kind].Content.Add(hte1[i].InnerText);
//                    }
//                    if (hte1[i].InnerText != null &&
//                        hte1[i].InnerText.IndexOf("店面類別：") != -1)
//                    {
//                        StorageArr[(int)tinyMeaningCellX.KindB].Content.Add(hte1[i].InnerText);
//                    }
//                    if (hte1[i].InnerText != null &&
//                        hte1[i].InnerText.IndexOf("地址：") != -1)
//                    {
//                        StorageArr[(int)tinyMeaningCellX.Addr].Content.Add(hte1[i].InnerText);
//                    }
//                }
//            }
//        }        
//        public void rent_car(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "LI" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("車 位") != -1)
//            {
//                StorageArr[(int)tinyMeaningCellX.Car].Content.Add(hte.InnerText);
//            }
//        }
//        public void building_sale_name(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "P" &&
//                hte.GetAttribute("classname") == "company stonefont")
//            {
//                StorageArr[(int)tinyMeaningCellX.Name].Content.Add(hte.InnerText);
//            }
//        }
//        public void building_sale_addr(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "P" &&
//                hte.GetAttribute("classname") == "address stonefont")
//            {
//                StorageArr[(int)tinyMeaningCellX.Addr].Content.Add(hte.InnerText);
//            }
//        }
//        public void building_sale_plain(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "P" &&
//                hte.GetAttribute("classname") == "pattern ellipsis stonefont")
//            {
//                StorageArr[(int)tinyMeaningCellX.Plain].Content.Add(hte.InnerText);
//            }
//        }
//        public void sale_ground_plain(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "info-floor-left" &&
//                hte.InnerText != null &&
//                (hte.InnerText.IndexOf("住宅") != -1 || hte.InnerText.IndexOf("商業") != -1 || hte.InnerText.IndexOf("工業") != -1
//                || hte.InnerText.IndexOf("建地") != -1|| hte.InnerText.IndexOf("農地") != -1|| hte.InnerText.IndexOf("林地") != -1
//                ||hte.InnerText.IndexOf("其他") != -1))
//            {
//                StorageArr[(int)tinyMeaningCellX.GroundPlain].Content.Add(hte.InnerText);
//            }
//        }
//        public void sale_plain(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "info-floor-left" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("權狀坪數") != -1)
//            {
//                StorageArr[(int)tinyMeaningCellX.Plain].Content.Add(hte.InnerText);
//            }
//        }
//        public void sale_commuity(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "info-addr-content" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("社區") != -1)
//            {
//                StorageArr[(int)tinyMeaningCellX.Community].Content.Add(hte.InnerText);
//            }
//        }
//        public void sale_addr(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "info-addr-content" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("地址") != -1)
//            {
//                StorageArr[(int)tinyMeaningCellX.Addr].Content.Add(hte.InnerText);
//            }
//        }
//        public void sale_name(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "SPAN" &&
//                hte.GetAttribute("classname") == "info-span-name")
//            {
//                StorageArr[(int)tinyMeaningCellX.Name].Content.Add(hte.InnerText);
//            }
//        }
//        public void sale_phone_fixed(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "SPAN" &&
//                hte.GetAttribute("classname") == "info-three-span info-three-tel")
//            {
//                StorageArr[(int)tinyMeaningCellX.PhoneB].Content.Add(hte.InnerText);
//            }
//        }
//        public void sale_phone(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "SPAN" &&
//                hte.GetAttribute("classname") == "info-host-word")
//            {
//                StorageArr[(int)tinyMeaningCellX.PhoneA].Content.Add(hte.InnerText);
//            }
//        }
//        public void sale_index(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "SPAN" &&
//                hte.GetAttribute("classname") == "breadList-last")
//            {
//                hte.InnerText = hte.InnerText.Replace("當前房屋（", "");
//                hte.InnerText = hte.InnerText.Replace("）", "");
//                StorageArr[(int)tinyMeaningCellX.Index].Content.Add(hte.InnerText);
//            }
//        }
//        public void sale_toward(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "info-addr-content" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("朝向") != -1)
//            {
//                StorageArr[(int)tinyMeaningCellX.Toward].Content.Add(hte.InnerText.Replace("\r\n\r\n", ""));
//            }
//        }
//        public void sale_floor(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "info-floor-left" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("樓層") != -1)
//            {
//                StorageArr[(int)tinyMeaningCellX.Floor].Content.Add(hte.InnerText);
//            }
//        }
//        public void sale_houseold(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "info-floor-left" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("屋齡") != -1)
//            {
//                StorageArr[(int)tinyMeaningCellX.HouseOld].Content.Add(hte.InnerText);
//            }
//        }
//        public void sale_now_state(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "info-addr-content" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("現況") != -1)
//            {
//                StorageArr[(int)tinyMeaningCellX.NowState].Content.Add(hte.InnerText);
//            }
//        }
//        public void sale_kind_a(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "info-addr-content" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("型態") != -1)
//            {
//                StorageArr[(int)tinyMeaningCellX.Kind].Content.Add(hte.InnerText);
//            }
//        }

//        /*
//        public void sale_kind(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "detail-house-item")
//            {
//                HtmlElementCollection elemColl = hte.Children;
//                if (elemColl[0].InnerText != null &&
//                    elemColl[0].InnerText.IndexOf("型態") != -1)
//                {
//                    StorageArr[(int)tinyColumnCellMeaning.Kind].Content.Add(elemColl[2].InnerText);
//                }
//            }
//        }
//        public void sale_house_old(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "info-floor-key" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("年") != -1)
//            {
//                StorageArr[(int)tinyColumnCellMeaning.HouseOld].Content.Add(hte.InnerText);
//            }
//        }
//        */


//        public void sale_car(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "detail-house-item" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("車位") != -1)
//            {
//                StorageArr[(int)tinyMeaningCellX.Car].Content.Add(hte.InnerText.Replace("車位\r\n： \r\n", ""));
//            }
//        }
//        public void ground_sale_grip_area(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//               WhDataHead == true &&
//               hte.TagName == "DIV" &&
//               hte.GetAttribute("classname") == "info-host-phone")
//            {
//                HtmlElementCollection HteChild = hte.Children;
//                StorageArr[(int)tinyMeaningCellX.Plain].Content.Add(HteChild[0].InnerText);
//            }
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "info-box-addr")
//            {
//                HtmlElementCollection HteChild = hte.Children;
//                StorageArr[(int)tinyMeaningCellX.NowState].Content.Add(HteChild[0].InnerText);
//                StorageArr[(int)tinyMeaningCellX.Kind].Content.Add(HteChild[1].InnerText);
//                StorageArr[(int)tinyMeaningCellX.Addr].Content.Add(HteChild[2].InnerText);
//            }
//        }
//        public void factory_sale_grip_area(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//               WhDataHead == true &&
//               hte.TagName == "DIV" &&
//               hte.GetAttribute("classname") == "info-host-phone")
//            {
//                HtmlElementCollection HteChild = hte.Children;
//                StorageArr[(int)tinyMeaningCellX.HouseOld].Content.Add(HteChild[1].InnerText);
//                StorageArr[(int)tinyMeaningCellX.Plain].Content.Add(HteChild[2].InnerText);
//            }
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "info-box-addr")
//            {
//                HtmlElementCollection HteChild = hte.Children;
//                StorageArr[(int)tinyMeaningCellX.NowState].Content.Add(HteChild[0].InnerText);
//                StorageArr[(int)tinyMeaningCellX.Kind].Content.Add(HteChild[1].InnerText);
//                StorageArr[(int)tinyMeaningCellX.Addr].Content.Add(HteChild[2].InnerText);
//            }
//        }


//        public void ground_rent_grip_area(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "UL" &&
//                hte.GetAttribute("classname") == "attr")
//            {
//                HtmlElementCollection HteChild = hte.Children;
//                if (HteChild.Count == 3)
//                {
//                    StorageArr[(int)tinyMeaningCellX.Plain].Content.Add(HteChild[0].InnerText);
//                    StorageArr[(int)tinyMeaningCellX.Kind].Content.Add(HteChild[1].InnerText);
//                    StorageArr[(int)tinyMeaningCellX.NowState].Content.Add(HteChild[2].InnerText);
//                }
//            }
//        }
//        public void factory_rent_grip_area(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "UL" &&
//                hte.GetAttribute("classname") == "attr")
//            {
//                HtmlElementCollection HteChild = hte.Children;
//                if (HteChild.Count == 3)
//                {
//                    StorageArr[(int)tinyMeaningCellX.Plain].Content.Add(HteChild[0].InnerText);
//                    StorageArr[(int)tinyMeaningCellX.NowState].Content.Add(HteChild[2].InnerText);                   
//                }
//            }
//        }
//        public void sale_living_office_grip_area(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "info-host-phone")
//            {
//                HtmlElementCollection HteChild = hte.Children;
//                StorageArr[(int)tinyMeaningCellX.Form].Content.Add(HteChild[0].InnerText);
//                StorageArr[(int)tinyMeaningCellX.HouseOld].Content.Add(HteChild[1].InnerText);
//                StorageArr[(int)tinyMeaningCellX.Plain].Content.Add(HteChild[2].InnerText);
//            }
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "info-box-addr")
//            {
//                HtmlElementCollection HteChild = hte.Children;
//                StorageArr[(int)tinyMeaningCellX.Community].Content.Add(HteChild[1].InnerText);
//                StorageArr[(int)tinyMeaningCellX.Addr].Content.Add(HteChild[2].InnerText);
//            }
//        }
//        public void sale_office_grip_area(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "info-host-phone")
//            {
//                HtmlElementCollection HteChild = hte.Children;
//                StorageArr[(int)tinyMeaningCellX.HouseOld].Content.Add(HteChild[1].InnerText);
//                StorageArr[(int)tinyMeaningCellX.Plain].Content.Add(HteChild[2].InnerText);
//            }
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "info-box-addr")
//            {
//                HtmlElementCollection HteChild = hte.Children;
//                StorageArr[(int)tinyMeaningCellX.Kind].Content.Add(HteChild[0].InnerText);
//                StorageArr[(int)tinyMeaningCellX.Community].Content.Add(HteChild[1].InnerText);
//                StorageArr[(int)tinyMeaningCellX.Addr].Content.Add(HteChild[2].InnerText);
//            }
//        }
//        public void rent_living_office_grip_area(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "UL" &&
//                hte.GetAttribute("classname") == "attr")
//            {
//                HtmlElementCollection HteChild = hte.Children;
//                if (HteChild.Count == 6)
//                {
//                    StorageArr[(int)tinyMeaningCellX.Form].Content.Add(HteChild[0].InnerText);
//                    StorageArr[(int)tinyMeaningCellX.Plain].Content.Add(HteChild[1].InnerText);
//                    StorageArr[(int)tinyMeaningCellX.Kind].Content.Add(HteChild[3].InnerText);
//                    StorageArr[(int)tinyMeaningCellX.NowState].Content.Add(HteChild[4].InnerText);
//                    StorageArr[(int)tinyMeaningCellX.Community].Content.Add(HteChild[5].InnerText);
//                }
//            }
//        }
//        public void rent_office_grip_area(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "UL" &&
//                hte.GetAttribute("classname") == "attr")
//            {
//                HtmlElementCollection HteChild = hte.Children;
//                if (HteChild.Count == 5)
//                {
//                    StorageArr[(int)tinyMeaningCellX.Plain].Content.Add(HteChild[0].InnerText);
//                    StorageArr[(int)tinyMeaningCellX.AuthorityPlain].Content.Add(HteChild[1].InnerText);
//                    StorageArr[(int)tinyMeaningCellX.Kind].Content.Add(HteChild[3].InnerText);
//                    StorageArr[(int)tinyMeaningCellX.NowState].Content.Add(HteChild[4].InnerText);
//                }
//            }
//        }
//        public void tolpet_grip_area(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("id") == "detailInfo")
//            {
//                HtmlElementCollection HteChild = hte.Children;
//                if (HteChild.Count == 9)
//                {
//                    StorageArr[(int)tinyMeaningCellX.Plain].Content.Add(HteChild[3].InnerText);
//                    StorageArr[(int)tinyMeaningCellX.Kind].Content.Add(HteChild[7].InnerText);
//                    StorageArr[(int)tinyMeaningCellX.KindB].Content.Add(HteChild[8].InnerText);
//                }
               
//            }
//        }

//        public void grip_tolpet_name(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "linkman")
//            {
//                StorageArr[(int)tinyMeaningCellX.Name].Content.Add(hte.InnerText);
//            }
//        }
//        public void grip_tolpet_index(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("id") == "propNav")
//            {
//                StorageArr[(int)tinyMeaningCellX.Index].Content.Add(hte.InnerText);
//            }
//        }
//        //public delegate void stuff_data(HtmlElement hte,Storage[] Storage,bool WholeGrip,bool DataGrip);
//        //共通部分
//        //地址抓取
//        //索引抓取
//        //姓名
//        //電話A
//        //電話B
        
//        public void grip_addr(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "SPAN" &&
//                hte.GetAttribute("classname") == "addr")
//            {
//                StorageArr[(int)tinyMeaningCellX.Addr].Content.Add(hte.InnerText);
//            }
//        }        
//        public void grip_index(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "I" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("（R") != -1)
//            {
//                StorageArr[(int)tinyMeaningCellX.Index].Content.Add(hte.InnerText);
//            }
//        }                
//        public void grip_name_rent(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "avatarRight")
//            {
//                HtmlElementCollection htechd = hte.Children;
//                HtmlElementCollection htechdchd = htechd[0].Children;
//                if (htechdchd.Count == 1)
//                {
//                    if (htechdchd[0].TagName == "I")
//                    {
//                        StorageArr[(int)tinyMeaningCellX.Name].Content.Add(htechdchd[0].InnerText);
//                    }                    
//                }
                
//            }
//        }        
//        public void grip_phone_fixed(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//               WhDataHead == true &&
//               hte.TagName == "INPUT" &&
//               hte.GetAttribute("id") == "hid_tel")
//            {
//                StorageArr[(int)tinyMeaningCellX.PhoneA].Content.Add(hte.GetAttribute("value"));
//            }
//        }
//        public void grip_phone_mobile(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "SPAN" &&
//                hte.GetAttribute("classname") == "num")
//            {
//                HtmlElementCollection htechd = hte.Children;
//                if(htechd.Count == 1)
//                {
//                    StorageArr[(int)tinyMeaningCellX.PhoneB].Content.Add(htechd[0].GetAttribute("src"));
//                }                
//            }
//        }

//        public void tolpet_grip_phone(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "EM" &&
//                hte.GetAttribute("classname") == "number")
//            {
//                HtmlElementCollection htechd = hte.Children;
                
//                if(htechd.Count > 1)
//                {
//                    HtmlElementCollection htechdchd = htechd[0].Children;
//                    if (htechdchd.Count == 1)
//                    {
//                        StorageArr[(int)tinyMeaningCellX.PhoneB].Content.Add(htechdchd[0].GetAttribute("src"));
//                    }
//                }
                
                
//            }
//        }
        
//        public void tolpet_grip_fixed(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "LI" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("固定電話") != -1)
//            {
//                HtmlElementCollection htechd = hte.Children;
//                if (htechd.Count ==2)
//                {
//                    HtmlElementCollection htechdchd = htechd[1].Children;
//                    StorageArr[(int)tinyMeaningCellX.PhoneB].Content.Add(htechdchd[0].GetAttribute("src"));
//                }
                
//            }
//        }




//        public void rent_group(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "UL" &&
//                hte.GetAttribute("classname") == "attr")
//            {
//                HtmlElementCollection hte1 = hte.Children;
//                for (int i = 0; i < hte1.Count; i++)
//                {

//                    if (hte1[i].InnerText != null &&
//                        hte1[i].InnerText.IndexOf("坪數 :") != -1 &&
//                        hte1[i].InnerText.IndexOf("權狀坪數 :") == -1)
//                    {
//                        StorageArr[(int)tinyMeaningCellX.Plain].Content.Add(hte1[i].InnerText);
//                    }
//                    if (hte1[i].InnerText != null &&
//                        hte1[i].InnerText.IndexOf("型態 :") != -1)
//                    {
//                        StorageArr[(int)tinyMeaningCellX.Kind].Content.Add(hte1[i].InnerText);
//                    }
//                    if (hte1[i].InnerText != null &&
//                        hte1[i].InnerText.IndexOf("權狀坪數 :") != -1)
//                    {
//                        StorageArr[(int)tinyMeaningCellX.AuthorityPlain].Content.Add(hte1[i].InnerText);
//                    }
//                    if (hte1[i].InnerText != null &&
//                        hte1[i].InnerText.IndexOf("現況 :") != -1)
//                    {
//                        StorageArr[(int)tinyMeaningCellX.NowState].Content.Add(hte1[i].InnerText);
//                    }
//                    if (hte1[i].InnerText != null &&
//                        hte1[i].InnerText.IndexOf("樓層 :") != -1)
//                    {
//                        StorageArr[(int)tinyMeaningCellX.Floor].Content.Add(hte1[i].InnerText);
//                    }
//                    if (hte1[i].InnerText != null &&
//                        hte1[i].InnerText.IndexOf("社區 :") != -1)
//                    {
//                        StorageArr[(int)tinyMeaningCellX.Community].Content.Add(hte1[i].InnerText);
//                    }
//                    if (hte1[i].InnerText != null &&
//                        hte1[i].InnerText.IndexOf("類別 :") != -1)
//                    {
//                        StorageArr[(int)tinyMeaningCellX.Kind].Content.Add(hte1[i].InnerText);
//                    }
//                    if (hte1[i].InnerText != null &&
//                        hte1[i].InnerText.IndexOf("面積 :") != -1)
//                    {
//                        StorageArr[(int)tinyMeaningCellX.GroundPlain].Content.Add(hte1[i].InnerText);
//                    }
//                }
//            }
//        }


        

//        public void grip_store_sale_name(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "info-host-name")
//            {
//                StorageArr[(int)tinyMeaningCellX.Name].Content.Add(hte.InnerText);
//            }
//        }
//        public void grip_store_sale_phone_a(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//               WhDataHead == true &&
//               hte.TagName == "SPAN" &&
//               hte.GetAttribute("classname") == "info-three-span info-three-tel")
//            {
//                StorageArr[(int)tinyMeaningCellX.PhoneA].Content.Add(hte.InnerText);
//            }
//        }
//        public void grip_store_sale_phone_b(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//               WhDataHead == true &&
//               hte.TagName == "DIV" &&
//               hte.GetAttribute("classname") == "info-host-phone")
//            {
//                StorageArr[(int)tinyMeaningCellX.PhoneB].Content.Add(hte.InnerText);
//            }
//        }
//        public void grip_store_sale_index(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "SPAN" &&
//                hte.GetAttribute("classname") == "breadList-last")
//            {
//                StorageArr[(int)tinyMeaningCellX.Index].Content.Add(hte.InnerText);
//            }
//        }
//        public void sale_building_group(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "detail-house-item")
//            {
//                HtmlElementCollection elemColl = hte.Children;
//                if (elemColl[0].InnerText != null &&
//                    elemColl[0].InnerText.IndexOf("主建物") != -1)
//                {
//                    StorageArr[(int)tinyMeaningCellX.Building].Content.Add(elemColl[2].InnerText);
//                }
//                else if (elemColl[0].InnerText != null &&
//                    elemColl[0].InnerText.IndexOf("共用部分") != -1)
//                {
//                    StorageArr[(int)tinyMeaningCellX.Common].Content.Add(elemColl[2].InnerText);
//                }
//                else if (elemColl[0].InnerText != null &&
//                    elemColl[0].InnerText.IndexOf("附屬建物") != -1)
//                {
//                    StorageArr[(int)tinyMeaningCellX.AppendBuilding].Content.Add(elemColl[2].InnerText);
//                }
//                else if (elemColl[0].InnerText != null &&
//                    elemColl[0].InnerText.IndexOf("土地坪數") != -1)
//                {
//                    StorageArr[(int)tinyMeaningCellX.GroundPlain].Content.Add(elemColl[2].InnerText);
//                }
//            }
//        }
//        public void store_sale_house_old(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "info-floor-left" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("屋齡") != -1)
//            {
//                HtmlElementCollection hte1 = hte.Children;

//                StorageArr[(int)tinyMeaningCellX.HouseOld].Content.Add(hte1[0].InnerText);
//            }

//        }
//        public void store_sale_authority_plain(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "info-floor-left" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("權狀坪數") != -1)
//            {
//                HtmlElementCollection hte1 = hte.Children;
//                StorageArr[(int)tinyMeaningCellX.AuthorityPlain].Content.Add(hte1[0].InnerText);
//            }

//        }
//        public void store_sale_form(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "info-floor-left" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("格局") != -1)
//            {
//                HtmlElementCollection hte1 = hte.Children;
//                StorageArr[(int)tinyMeaningCellX.AuthorityPlain].Content.Add(hte1[0].InnerText);
//            }

//        }        
//        public void store_sale_kind(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "info-addr-content" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("型態") != -1)
//            {
//                HtmlElementCollection hte1 = hte.Children;
//                StorageArr[(int)tinyMeaningCellX.Kind].Content.Add(hte1[1].InnerText);
//            }

//        }
//        public void store_sale_community(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "info-addr-content" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("社區") != -1)
//            {
//                HtmlElementCollection hte1 = hte.Children;
//                StorageArr[(int)tinyMeaningCellX.Community].Content.Add(hte1[1].InnerText);
//            }

//        }
//        public void store_addr(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "info-addr-content" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("地址") != -1)
//            {
//                HtmlElementCollection hte1 = hte.Children;
//                StorageArr[(int)tinyMeaningCellX.Addr].Content.Add(hte1[1].InnerText);
//            }

//        }
//        public void store_nowstate(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "info-addr-content" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("現況") != -1)
//            {
//                HtmlElementCollection hte1 = hte.Children;
//                StorageArr[(int)tinyMeaningCellX.Addr].Content.Add(hte1[1].InnerText);
//            }

//        }

        
//        public void tolpet__name(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "linkman")
//            {
//                StorageArr[(int)tinyMeaningCellX.Name].Content.Add(hte.InnerText);
//            }
//        }
//        public void tolpet_index(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("id") == "propNav")
//            {
//                StorageArr[(int)tinyMeaningCellX.Index].Content.Add(hte.InnerText);
//            }

//        }
//        public void tolpet_rent(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "LI" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("租金：") != -1)
//            {
//                StorageArr[(int)tinyMeaningCellX.Rent].Content.Add(hte.InnerText);
//            }

//        }
//        public void tolpet_plain(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "LI" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("坪數：") != -1)
//            {
//                StorageArr[(int)tinyMeaningCellX.Plain].Content.Add(hte.InnerText);
//            }

//        }
//        public void tolpet_floor(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "LI" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("樓層：") != -1)
//            {
//                StorageArr[(int)tinyMeaningCellX.Floor].Content.Add(hte.InnerText);
//            }

//        }
//        public void tolpet_kind(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "LI" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("店面類型：") != -1)
//            {
//                StorageArr[(int)tinyMeaningCellX.Kind].Content.Add(hte.InnerText);
//            }

//        }
//        public void tolpet_kind_b(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "LI" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("店面類別：") != -1)
//            {
//                StorageArr[(int)tinyMeaningCellX.KindB].Content.Add(hte.InnerText);
//            }

//        }
//        public void tolpet_addr(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "LI" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("地址：") != -1)
//            {
//                StorageArr[(int)tinyMeaningCellX.Addr].Content.Add(hte.InnerText);
//            }

//        }
//        /*public void store_sale_floor(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//{
//    if (WhAllHead == true &&
//        WhDataHead == true &&
//        hte.TagName == "DIV" &&
//        hte.GetAttribute("classname") == "info-floor-left" &&
//        hte.InnerText != null &&
//        hte.InnerText.IndexOf("樓層") != -1)
//    {
//        StorageArr[(int)tinyMeaningCellX.Floor].Content.Add(hte.InnerText);
//    }

//}*/






//        public void running_ground_sale(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "A" &&
//                hte.GetAttribute("href").IndexOf("sale") != -1)
//            {
//                StorageArr[(int)crudeMeaningCellX.Web].Content.Add(hte.GetAttribute("href"));
//                StorageArr[(int)crudeMeaningCellX.Project].Content.Add(hte.InnerText);
//            }
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "P" &&
//                hte.GetAttribute("classname") == "lightBox" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("類別") != -1 &&
//                hte.InnerText.IndexOf("坪") != -1)
//            {

//                string[] TmpStrArr = hte.InnerText.Split('|');
//                if (TmpStrArr.Length == 4)
//                {
//                    StorageArr[(int)crudeMeaningCellX.Kind].Content.Add(TmpStrArr[0]);
//                    StorageArr[(int)crudeMeaningCellX.KindB].Content.Add(TmpStrArr[1]);
//                    StorageArr[(int)crudeMeaningCellX.Plain].Content.Add(TmpStrArr[2]);
//                    StorageArr[(int)crudeMeaningCellX.DevidePrice].Content.Add(TmpStrArr[3]);
//                }

//            }
    
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "P" &&
//                hte.GetAttribute("classname") == "lightBox" &&
//                hte.InnerText != null &&
//                (hte.InnerText.IndexOf("段") != -1 || hte.InnerText.IndexOf("路") != -1 || hte.InnerText.IndexOf("街") != -1 || hte.InnerText.IndexOf("村") != -1))
//            {
//                HtmlElementCollection HteChild = hte.Children;

//                if (HteChild[0].InnerText.IndexOf("段") != -1 || HteChild[0].InnerText.IndexOf("路") != -1 || HteChild[0].InnerText.IndexOf("街") != -1 || hte.InnerText.IndexOf("村") != -1)
//                {
//                    StorageArr[(int)crudeMeaningCellX.Addr].Content.Add(HteChild[0].InnerText);
//                }
//                else
//                {
//                    StorageArr[(int)crudeMeaningCellX.Addr].Content.Add(HteChild[1].InnerText);
//                }

//            }
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "price")
//            {
//                StorageArr[(int)crudeMeaningCellX.Price].Content.Add(hte.InnerText);
//            }
//        }
//        public void running_factory_sale(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "A" &&
//                hte.GetAttribute("href").IndexOf("sale") != -1)
//            {
//                StorageArr[(int)crudeMeaningCellX.Web].Content.Add(hte.GetAttribute("href"));
//                StorageArr[(int)crudeMeaningCellX.Project].Content.Add(hte.InnerText);
//            }
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "P" &&
//                hte.GetAttribute("classname") == "lightBox" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("樓層") != -1 &&
//                hte.InnerText.IndexOf("坪") != -1)
//            {

//                string[] TmpStrArr = hte.InnerText.Split('|');
//                if (TmpStrArr.Length == 4)
//                {
//                    StorageArr[(int)crudeMeaningCellX.Kind].Content.Add(TmpStrArr[0]);
//                    StorageArr[(int)crudeMeaningCellX.Plain].Content.Add(TmpStrArr[1]);
//                    StorageArr[(int)crudeMeaningCellX.Floor].Content.Add(TmpStrArr[2]);
//                    StorageArr[(int)crudeMeaningCellX.DevidePrice].Content.Add(TmpStrArr[3]);
//                }

//            }
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "P" &&
//                hte.GetAttribute("classname") == "lightBox" &&
//                hte.InnerText != null &&
//                (hte.InnerText.IndexOf("段") != -1 || hte.InnerText.IndexOf("路") != -1 || hte.InnerText.IndexOf("街") != -1 || hte.InnerText.IndexOf("村") != -1))
//            {
//                HtmlElementCollection HteChild = hte.Children;

//                if (HteChild[0].InnerText.IndexOf("段") != -1 || HteChild[0].InnerText.IndexOf("路") != -1 || HteChild[0].InnerText.IndexOf("街") != -1 || hte.InnerText.IndexOf("村") != -1)
//                {
//                    StorageArr[(int)crudeMeaningCellX.Addr].Content.Add(HteChild[0].InnerText);
//                }
//                else
//                {
//                    StorageArr[(int)crudeMeaningCellX.Addr].Content.Add(HteChild[1].InnerText);
//                }

//            }
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "price")
//            {
//                StorageArr[(int)crudeMeaningCellX.Price].Content.Add(hte.InnerText);
//            }
//        }
//        public void running_ground_rent(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "A" &&
//                hte.GetAttribute("href").IndexOf("rent") != -1)
//            {
//                StorageArr[(int)crudeMeaningCellX.Web].Content.Add(hte.GetAttribute("href"));
//                StorageArr[(int)crudeMeaningCellX.Project].Content.Add(hte.InnerText);
//            }
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "P" &&
//                hte.GetAttribute("classname") == "lightBox" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("類別") != -1 &&
//                hte.InnerText.IndexOf("坪") != -1)
//            {

//                string[] TmpStrArr = hte.InnerText.Split('|');
//                if (TmpStrArr.Length == 3)
//                {
//                    StorageArr[(int)crudeMeaningCellX.Kind].Content.Add(TmpStrArr[0]);
//                    StorageArr[(int)crudeMeaningCellX.KindB].Content.Add(TmpStrArr[1]);
//                    StorageArr[(int)crudeMeaningCellX.Floor].Content.Add(TmpStrArr[2]);
//                }

//            }
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "P" &&
//                hte.GetAttribute("classname") == "lightBox" &&
//                hte.InnerText != null &&
//                (hte.InnerText.IndexOf("段") != -1 || hte.InnerText.IndexOf("路") != -1 || hte.InnerText.IndexOf("街") != -1 || hte.InnerText.IndexOf("村") != -1))
//            {
//                HtmlElementCollection HteChild = hte.Children;

//                if (HteChild[0].InnerText.IndexOf("段") != -1 || HteChild[0].InnerText.IndexOf("路") != -1 || HteChild[0].InnerText.IndexOf("街") != -1 || hte.InnerText.IndexOf("村") != -1)
//                {
//                    StorageArr[(int)crudeMeaningCellX.Addr].Content.Add(HteChild[0].InnerText);
//                }
//                else
//                {
//                    StorageArr[(int)crudeMeaningCellX.Addr].Content.Add(HteChild[1].InnerText);
//                }

//            }
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "price")
//            {
//                StorageArr[(int)crudeMeaningCellX.Rent].Content.Add(hte.InnerText);
//            }
//        }
//        public void running_factory_rent(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "A" &&
//                hte.GetAttribute("href").IndexOf("rent") != -1)
//            {
//                StorageArr[(int)crudeMeaningCellX.Web].Content.Add(hte.GetAttribute("href"));
//                StorageArr[(int)crudeMeaningCellX.Project].Content.Add(hte.InnerText);
//            }
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "P" &&
//                hte.GetAttribute("classname") == "lightBox" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("樓層") != -1 &&
//                hte.InnerText.IndexOf("坪") != -1)
//            {

//                string[] TmpStrArr = hte.InnerText.Split('|');
//                if (TmpStrArr.Length == 3)
//                {
//                    StorageArr[(int)crudeMeaningCellX.Kind].Content.Add(TmpStrArr[0]);
//                    StorageArr[(int)crudeMeaningCellX.Plain].Content.Add(TmpStrArr[1]);
//                    StorageArr[(int)crudeMeaningCellX.Floor].Content.Add(TmpStrArr[2]);
//                }               
//                else if (TmpStrArr.Length == 4)
//                {
//                    StorageArr[(int)crudeMeaningCellX.Kind].Content.Add(TmpStrArr[0]);
//                    StorageArr[(int)crudeMeaningCellX.Form].Content.Add(TmpStrArr[1]);
//                    StorageArr[(int)crudeMeaningCellX.Plain].Content.Add(TmpStrArr[2]);
//                    StorageArr[(int)crudeMeaningCellX.Floor].Content.Add(TmpStrArr[3]);
//                }
//            }

//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "P" &&
//                hte.GetAttribute("classname") == "lightBox" &&
//                hte.InnerText != null &&
//                (hte.InnerText.IndexOf("段") != -1 || hte.InnerText.IndexOf("路") != -1 || hte.InnerText.IndexOf("街") != -1 || hte.InnerText.IndexOf("村") != -1))
//            {
//                HtmlElementCollection HteChild = hte.Children;

//                if (HteChild[0].InnerText.IndexOf("段") != -1 || HteChild[0].InnerText.IndexOf("路") != -1 || HteChild[0].InnerText.IndexOf("街") != -1 || hte.InnerText.IndexOf("村") != -1)
//                {
//                    StorageArr[(int)crudeMeaningCellX.Addr].Content.Add(HteChild[0].InnerText);
//                }
//                else
//                {
//                    StorageArr[(int)crudeMeaningCellX.Addr].Content.Add(HteChild[1].InnerText);
//                }

//            }
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "price")
//            {
//                StorageArr[(int)crudeMeaningCellX.Rent].Content.Add(hte.InnerText);
//            }
//        }
//        public void running_live_office_sale(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {

//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "A" &&
//                hte.GetAttribute("href").IndexOf("sale") != -1)
//            {
//                StorageArr[(int)crudeMeaningCellX.Web].Content.Add(hte.GetAttribute("href"));
//                StorageArr[(int)crudeMeaningCellX.Project].Content.Add(hte.InnerText);
//            }
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "P" &&
//                hte.GetAttribute("classname") == "lightBox" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("樓層") != -1 &&
//                hte.InnerText.IndexOf("坪") != -1)
//            {

//                string[] TmpStrArr = hte.InnerText.Split('|');
//                if (TmpStrArr.Length ==5)
//                {
//                    StorageArr[(int)crudeMeaningCellX.Kind].Content.Add(TmpStrArr[0]);
//                    StorageArr[(int)crudeMeaningCellX.Form].Content.Add(TmpStrArr[1]);
//                    StorageArr[(int)crudeMeaningCellX.Plain].Content.Add(TmpStrArr[2]);
//                    StorageArr[(int)crudeMeaningCellX.Floor].Content.Add(TmpStrArr[3]);
//                    StorageArr[(int)crudeMeaningCellX.DevidePrice].Content.Add(TmpStrArr[4]);
//                }
                
//            }

//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "P" &&
//                hte.GetAttribute("classname") == "lightBox" &&
//                hte.InnerText != null &&
//                (hte.InnerText.IndexOf("段") != -1 || hte.InnerText.IndexOf("路") != -1 || hte.InnerText.IndexOf("街") != -1 || hte.InnerText.IndexOf("村") != -1))
//            {
//                HtmlElementCollection HteChild = hte.Children;

//                if (HteChild[0].InnerText.IndexOf("段") != -1 || HteChild[0].InnerText.IndexOf("路") != -1 || HteChild[0].InnerText.IndexOf("街") != -1 || hte.InnerText.IndexOf("村") != -1)
//                {
//                    StorageArr[(int)crudeMeaningCellX.Addr].Content.Add(HteChild[0].InnerText);
//                }
//                else
//                {
//                    StorageArr[(int)crudeMeaningCellX.Addr].Content.Add(HteChild[1].InnerText);
//                }

//            }
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "price")
//            {
//                StorageArr[(int)crudeMeaningCellX.Price].Content.Add(hte.InnerText);
//            }
//        }
//        public void running_office_sale(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {

//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "A" &&
//                hte.GetAttribute("href").IndexOf("sale") != -1)
//            {
//                StorageArr[(int)crudeMeaningCellX.Web].Content.Add(hte.GetAttribute("href"));
//                StorageArr[(int)crudeMeaningCellX.Project].Content.Add(hte.InnerText);
//            }
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "P" &&
//                hte.GetAttribute("classname") == "lightBox" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("樓層") != -1 &&
//                hte.InnerText.IndexOf("坪") != -1)
//            {

//                string[] TmpStrArr = hte.InnerText.Split('|');
//                if (TmpStrArr.Length ==4)
//                {
//                    StorageArr[(int)crudeMeaningCellX.Kind].Content.Add(TmpStrArr[0]);
//                    StorageArr[(int)crudeMeaningCellX.Plain].Content.Add(TmpStrArr[1]);
//                    StorageArr[(int)crudeMeaningCellX.Floor].Content.Add(TmpStrArr[2]);
//                    StorageArr[(int)crudeMeaningCellX.DevidePrice].Content.Add(TmpStrArr[3]);
//                }
                
//            }

//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "P" &&
//                hte.GetAttribute("classname") == "lightBox" &&
//                hte.InnerText != null &&
//                (hte.InnerText.IndexOf("段") != -1 || hte.InnerText.IndexOf("路") != -1 || hte.InnerText.IndexOf("街") != -1 || hte.InnerText.IndexOf("村") != -1))
//            {
//                HtmlElementCollection HteChild = hte.Children;

//                if (HteChild[0].InnerText.IndexOf("段") != -1 || HteChild[0].InnerText.IndexOf("路") != -1 || HteChild[0].InnerText.IndexOf("街") != -1 || hte.InnerText.IndexOf("村") != -1)
//                {
//                    StorageArr[(int)crudeMeaningCellX.Addr].Content.Add(HteChild[0].InnerText);
//                }
//                else
//                {
//                    StorageArr[(int)crudeMeaningCellX.Addr].Content.Add(HteChild[1].InnerText);
//                }

//            }
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "price")
//            {
//                StorageArr[(int)crudeMeaningCellX.Price].Content.Add(hte.InnerText);
//            }
//        }
//        public void running_live_office_rent(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {

//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "A" &&
//                hte.GetAttribute("href").IndexOf("rent") != -1)
//            {
//                StorageArr[(int)crudeMeaningCellX.Web].Content.Add(hte.GetAttribute("href"));
//                StorageArr[(int)crudeMeaningCellX.Project].Content.Add(hte.InnerText);
//            }
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "P" &&
//                hte.GetAttribute("classname") == "lightBox" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("樓層") != -1 &&
//                hte.InnerText.IndexOf("坪") != -1)
//            {
                
//                string[] TmpStrArr = hte.InnerText.Split('|');
                
//                if (TmpStrArr.Length == 4)
//                {
//                    StorageArr[(int)crudeMeaningCellX.Kind].Content.Add(TmpStrArr[0]);
//                    StorageArr[(int)crudeMeaningCellX.Form].Content.Add(TmpStrArr[1]);
//                    StorageArr[(int)crudeMeaningCellX.Plain].Content.Add(TmpStrArr[2]);
//                    StorageArr[(int)crudeMeaningCellX.Floor].Content.Add(TmpStrArr[3]);
//                }
//            }

//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "P" &&
//                hte.GetAttribute("classname") == "lightBox" &&
//                hte.InnerText != null &&
//                (hte.InnerText.IndexOf("段") != -1 || hte.InnerText.IndexOf("路") != -1 || hte.InnerText.IndexOf("街") != -1 || hte.InnerText.IndexOf("村") != -1))
//            {
//                HtmlElementCollection HteChild = hte.Children;

//                if (HteChild[0].InnerText.IndexOf("段") != -1 || HteChild[0].InnerText.IndexOf("路") != -1 || HteChild[0].InnerText.IndexOf("街") != -1 || hte.InnerText.IndexOf("村") != -1)
//                {
//                    StorageArr[(int)crudeMeaningCellX.Addr].Content.Add(HteChild[0].InnerText);
//                }
//                else
//                {
//                    StorageArr[(int)crudeMeaningCellX.Addr].Content.Add(HteChild[1].InnerText);
//                }

//            }
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "price")
//            {
//                StorageArr[(int)crudeMeaningCellX.Rent].Content.Add(hte.InnerText);
//            }
//        }
//        public void running_office_rent(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
            
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "A" &&
//                hte.GetAttribute("href").IndexOf("rent") != -1)
//            {
//                StorageArr[(int)crudeMeaningCellX.Web].Content.Add(hte.GetAttribute("href"));
//                StorageArr[(int)crudeMeaningCellX.Project].Content.Add(hte.InnerText);
//            }
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "P" &&
//                hte.GetAttribute("classname") == "lightBox" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("樓層") != -1 &&
//                hte.InnerText.IndexOf("坪") != -1)
//            {

//                string[] TmpStrArr = hte.InnerText.Split('|');
//                if (TmpStrArr.Length == 3)
//                {
//                    StorageArr[(int)crudeMeaningCellX.Kind].Content.Add(TmpStrArr[0]);
//                    StorageArr[(int)crudeMeaningCellX.Plain].Content.Add(TmpStrArr[1]);
//                    StorageArr[(int)crudeMeaningCellX.Floor].Content.Add(TmpStrArr[2]);
//                }
//                else if (TmpStrArr.Length == 4)
//                {
//                    StorageArr[(int)crudeMeaningCellX.Kind].Content.Add(TmpStrArr[0]);
//                    StorageArr[(int)crudeMeaningCellX.Form].Content.Add(TmpStrArr[1]);
//                    StorageArr[(int)crudeMeaningCellX.Plain].Content.Add(TmpStrArr[2]);
//                    StorageArr[(int)crudeMeaningCellX.Floor].Content.Add(TmpStrArr[3]);
//                }
                
//            }
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "P" &&
//                hte.GetAttribute("classname") == "lightBox" &&
//                hte.InnerText != null &&
//                (hte.InnerText.IndexOf("段") != -1 || hte.InnerText.IndexOf("路") != -1 || hte.InnerText.IndexOf("街") != -1 || hte.InnerText.IndexOf("村") != -1))
//            {
//                HtmlElementCollection HteChild = hte.Children;

//                if (HteChild[0].InnerText.IndexOf("段") != -1 || HteChild[0].InnerText.IndexOf("路") != -1 || HteChild[0].InnerText.IndexOf("街") != -1 || hte.InnerText.IndexOf("村") != -1)
//                {
//                    StorageArr[(int)crudeMeaningCellX.Addr].Content.Add(HteChild[0].InnerText);
//                }
//                else
//                {
//                    StorageArr[(int)crudeMeaningCellX.Addr].Content.Add(HteChild[1].InnerText);
//                }

//            }
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "price")
//            {
//                StorageArr[(int)crudeMeaningCellX.Rent].Content.Add(hte.InnerText);
//            }
//        }
//        public void running_shop_sale(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
            
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "A" &&
//                hte.GetAttribute("href").IndexOf("sale") != -1)
//            {
//                StorageArr[(int)crudeMeaningCellX.Web].Content.Add(hte.GetAttribute("href"));
//                StorageArr[(int)crudeMeaningCellX.Project].Content.Add(hte.InnerText);
//            }
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "P" &&
//                hte.GetAttribute("classname") == "lightBox" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("樓層") != -1 &&
//                hte.InnerText.IndexOf("單價") != -1)
//            {

//                string[] TmpStrArr = hte.InnerText.Split('|');
//                if (TmpStrArr.Length == 4)
//                {
//                    StorageArr[(int)crudeMeaningCellX.Kind].Content.Add(TmpStrArr[0]);
//                    StorageArr[(int)crudeMeaningCellX.Plain].Content.Add(TmpStrArr[1]);
//                    StorageArr[(int)crudeMeaningCellX.Floor].Content.Add(TmpStrArr[2]);
//                    StorageArr[(int)crudeMeaningCellX.DevidePrice].Content.Add(TmpStrArr[3]);
//                }
//                else if (TmpStrArr.Length == 5)
//                {
//                    StorageArr[(int)crudeMeaningCellX.Kind].Content.Add(TmpStrArr[0]);
//                    StorageArr[(int)crudeMeaningCellX.Form].Content.Add(TmpStrArr[1]);
//                    StorageArr[(int)crudeMeaningCellX.Plain].Content.Add(TmpStrArr[2]);
//                    StorageArr[(int)crudeMeaningCellX.Floor].Content.Add(TmpStrArr[3]);
//                    StorageArr[(int)crudeMeaningCellX.DevidePrice].Content.Add(TmpStrArr[4]);
//                }
//            }

//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "P" &&
//                hte.GetAttribute("classname") == "lightBox" &&
//                hte.InnerText != null &&
//                (hte.InnerText.IndexOf("段") != -1 || hte.InnerText.IndexOf("路") != -1 || hte.InnerText.IndexOf("街") != -1))
//            {
//                HtmlElementCollection HteChild = hte.Children;
//                if (HteChild[0].InnerText.IndexOf("段") != -1 || HteChild[0].InnerText.IndexOf("路") != -1 || HteChild[0].InnerText.IndexOf("街") != -1)
//                {
//                    StorageArr[(int)crudeMeaningCellX.Addr].Content.Add(HteChild[0].InnerText);
//                }
//                else
//                {
//                    StorageArr[(int)crudeMeaningCellX.Addr].Content.Add(HteChild[1].InnerText);
//                }

//            }
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "price")
//            {
//                StorageArr[(int)crudeMeaningCellX.Price].Content.Add(hte.InnerText);
//            }
//        }
//        public void running_toplet(HtmlElement hte, Storage[] StorageArr, bool WhAllHead, bool WhDataHead)
//        {
            
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "A" &&
//                hte.GetAttribute("href").IndexOf("store") != -1)
//            {
//                StorageArr[(int)crudeMeaningCellX.Web].Content.Add(hte.GetAttribute("href"));
//                StorageArr[(int)crudeMeaningCellX.Project].Content.Add(hte.InnerText);
//            }
//            /*
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "P" &&
//                hte.GetAttribute("classname") == "lightBox" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("租金") != -1 &&
//                hte.InnerText.IndexOf("設備") != -1)
//            {

//                string[] TmpStrArr = hte.InnerText.Split('|');
//                if (TmpStrArr.Length == 5)
//                {
//                    StorageArr[(int)crudeMeaningCellX.Kind].Content.Add(TmpStrArr[0]);
//                    StorageArr[(int)crudeMeaningCellX.KindB].Content.Add(TmpStrArr[1]);
//                    StorageArr[(int)crudeMeaningCellX.Plain].Content.Add(TmpStrArr[2]);
//                    StorageArr[(int)crudeMeaningCellX.Rent].Content.Add(TmpStrArr[3]);
//                    StorageArr[(int)crudeMeaningCellX.Equipment].Content.Add(TmpStrArr[4]);
//                }
                
//            }
//            */
//            /*
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "P" &&
//                hte.GetAttribute("classname") == "lightBox" &&
//                hte.InnerText != null &&
//                (hte.InnerText.IndexOf("段") != -1 || hte.InnerText.IndexOf("路") != -1 || hte.InnerText.IndexOf("街") != -1 || hte.InnerText.IndexOf("村") != -1))
//            {
//                HtmlElementCollection HteChild = hte.Children;

//                if (HteChild[0].InnerText.IndexOf("段") != -1 || HteChild[0].InnerText.IndexOf("路") != -1 || HteChild[0].InnerText.IndexOf("街") != -1 || hte.InnerText.IndexOf("村") != -1)
//                {
//                    StorageArr[(int)crudeMeaningCellX.Addr].Content.Add(HteChild[0].InnerText);
//                }
//                else
//                {
//                    StorageArr[(int)crudeMeaningCellX.Addr].Content.Add(HteChild[1].InnerText);
//                }

//            }
//            */
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "price")
//            {
//                StorageArr[(int)crudeMeaningCellX.Price].Content.Add(hte.InnerText);
//            }
//        }        
//        public void running_store_rent(HtmlElement hte,Storage[] StorageArr, bool WhAllHead,bool WhDataHead)
//        {
            

//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "A" &&
//                hte.GetAttribute("href").IndexOf("rent") != -1)
//            {
//                StorageArr[(int)crudeMeaningCellX.Web].Content.Add(hte.GetAttribute("href"));
//                StorageArr[(int)crudeMeaningCellX.Project].Content.Add(hte.InnerText);
//            }

//            /*if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "P" &&
//                hte.GetAttribute("classname") == "lightBox" &&
//                hte.InnerText != null &&
//                hte.InnerText.IndexOf("坪") != -1 &&
//                hte.InnerText.IndexOf("樓層") != -1)
//            {

//                string[] TmpStrArr = hte.InnerText.Split('|');
//                if (TmpStrArr.Length == 3)
//                {
//                    StorageArr[(int)crudeMeaningCellX.Kind].Content.Add(TmpStrArr[0]);
//                    StorageArr[(int)crudeMeaningCellX.Plain].Content.Add(TmpStrArr[1]);
//                    StorageArr[(int)crudeMeaningCellX.Floor].Content.Add(TmpStrArr[2]);
//                }
//                else if (TmpStrArr.Length == 4)
//                {
//                    StorageArr[(int)crudeMeaningCellX.Kind].Content.Add(TmpStrArr[0]);
//                    StorageArr[(int)crudeMeaningCellX.Form].Content.Add(TmpStrArr[1]);
//                    StorageArr[(int)crudeMeaningCellX.Plain].Content.Add(TmpStrArr[2]);
//                    StorageArr[(int)crudeMeaningCellX.Floor].Content.Add(TmpStrArr[3]);
//                }
               
//            }*/
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "P" &&
//                hte.GetAttribute("classname") == "lightBox" &&
//                hte.InnerText != null &&
//                (hte.InnerText.IndexOf("段") != -1 || hte.InnerText.IndexOf("路") != -1 || hte.InnerText.IndexOf("街") != -1 || hte.InnerText.IndexOf("村") != -1))
//            {
//                HtmlElementCollection HteChild = hte.Children;
//                if (HteChild[0].InnerText.IndexOf("段") != -1 || HteChild[0].InnerText.IndexOf("路") != -1 || HteChild[0].InnerText.IndexOf("街") != -1 || hte.InnerText.IndexOf("村") != -1)
//                {
//                    StorageArr[(int)crudeMeaningCellX.Addr].Content.Add(HteChild[0].InnerText);
//                }
//                else
//                {
//                    StorageArr[(int)crudeMeaningCellX.Addr].Content.Add(HteChild[1].InnerText);
//                }
                

//            }
//            if (WhAllHead == true &&
//                WhDataHead == true &&
//                hte.TagName == "DIV" &&
//                hte.GetAttribute("classname") == "price")
//            {
//                StorageArr[(int)crudeMeaningCellX.Rent].Content.Add(hte.InnerText);
//            }
//        }
//        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
//        {

//        }

//        private void tabPage4_Click(object sender, EventArgs e)
//        {

//        }

//        private void webBrowser3_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
//        {

//        }

//        private void tabPage14_Click(object sender, EventArgs e)
//        {

//        }

//        private void button2_Click(object sender, EventArgs e)
//        {
//            Form Form3 = new Form3();
//            Form3.Show();
//        }
//        private void button4_Click(object sender, EventArgs e)
//        {
//            set_new_taipei_all_or_host();
//            //set_new_taipei_all_or_host();


//        }
//        private void radioButton2_CheckedChanged(object sender, EventArgs e)
//        {
//        }

//        private void radioButton3_CheckedChanged(object sender, EventArgs e)
//        {

//        }

//        private void radioButton1_CheckedChanged(object sender, EventArgs e)
//        {

//        }

//        private void timer1_Tick(object sender, EventArgs e)
//        {
//            StopTime = StopTime + 1;
//            /*

//            */
//        }

        
//    }
//}
