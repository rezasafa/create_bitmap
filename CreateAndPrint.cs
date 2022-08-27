using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int w = 303; int h = 303;
        Bitmap bmp;//= new Bitmap(w, h);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Title = "نام مکان";
            var ImageAddress = @"D:\desk\Nature HD Wallpapers\Nature HD Wallpapers 001.jpg";
            var dt = "1401/02/24";
            var Vadeh = "صبحانه";
            var Count = 1;
            var Pors = "پرس";
            var FoodName = "نون و پنیر خرما عسل";
            var EmployName = "رضا سلیمانی صفا";
            var Msg = "متن امروز";
            var Reg = DateTime.Now.ToLongDateString();
            var Resturant = "نام رستوران";

            bmp = new Bitmap(w, h);


            using (Graphics graph = Graphics.FromImage(bmp))
            {
                Rectangle ImageSize = new Rectangle(0, 0, w, h);
                graph.FillRectangle(Brushes.White, ImageSize);

                Pen blackPen = new Pen(Color.Black, 1);

                StringFormat format = new StringFormat(StringFormatFlags.DirectionRightToLeft);
                Font font = new Font("Tahoma", 10, FontStyle.Bold);

                CreateBox(graph,blackPen);

                float x1 = 1, y1 = 75.0F;
                float x2 = 303.0F, y2 = 75.0F;
                float x = 150.0F, y = 30.0F;
                CreateText(graph, Title, font, x, y, format);

                x1 = 180.0F; y1 = 5.0F;
                x2 = 110.0F; y2 = 65.0F;
                Image img;
                img = Image.FromFile(ImageAddress);

                graph.DrawImage(img, x1, y1, x2, y2);

                x = 150.0F; y = 30.0F;
                CreateText(graph, Title, font, x, y, format);

                x = 280.0F; y = 90.0F;
                CreateText(graph, dt, font, x, y, format);

                x = 150.0F; y = 90.0F;
                CreateText(graph, Vadeh, font, x, y, format);

                x1 = 1; y1 = 75.0F;
                x2 = 303.0F; y2 = 75.0F;
                graph.DrawLine(blackPen, x1, y1, x2, y2);

                x = 270.0F; y = 120.0F;
                CreateText(graph, Count.ToString(), font, x, y, format);

                x = 240.0F; y = 120.0F;
                CreateText(graph, Pors, font, x, y, format);

                x = 150.0F; y = 120.0F;
                CreateText(graph, FoodName, font, x, y, format);

                x = 210.0F; y = 170.0F;
                CreateText(graph, EmployName, font, x, y, format);

                x1 = 1; y1 = 210.0F;
                x2 = 303.0F; y2 = 210.0F;
                graph.DrawLine(blackPen, x1, y1, x2, y2);

                x = 300.0F; y = 230.0F;
                CreateText(graph, Msg, font, x, y, format);

                x = 170.0F; y = 260.0F;
                CreateText(graph, Reg, font, x, y, format);

                x = 295.0F; y = 260.0F;
                CreateText(graph, Resturant, font, x, y, format);

                blackPen.Dispose();

                

            }


            pictureBox1.Image = bmp;

            printDocument1.Print();
        }

        void CreateBox(Graphics graph,Pen pen)
        {
            Rectangle main = new Rectangle();
            main.X = 1;
            main.Y = 1;
            main.Width = 303; //302.362;
            main.Height = 303; // 302.362;
            graph.DrawRectangle(pen, main);
        }

        void CreateText(Graphics graph, string Text, Font font, float x, float y, StringFormat format)
        {
            graph.DrawString(Text, font, Brushes.Black, x, y, format);
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            
            //double cmToUnits = 100 / 2.54;
            e.Graphics.DrawImage(bmp, 0, 0, 303, 303);
            //e.Graphics.DrawImage(bmp, 0, 0, (float)(27 * cmToUnits), (float)(18 * cmToUnits));
        }
    }
}
