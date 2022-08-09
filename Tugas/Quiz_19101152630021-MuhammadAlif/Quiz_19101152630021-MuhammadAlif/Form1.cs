using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Quiz_19101152630021_MuhammadAlif
{
    public partial class Form1 : Form
    {
        Bitmap objBitmap;
        Bitmap objBitmap1;

        public Form1()
        {
            InitializeComponent();
        }

        // load
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                objBitmap = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = objBitmap;
            }
        }

        // grayscale
        private void button2_Click(object sender, EventArgs e)
        {
            // Add header(column)
            listView1.Clear();
            listView1.Columns.Add("[x,y]", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai R", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai G", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai B", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai xg", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai wb", 200, HorizontalAlignment.Center);

            objBitmap1 = new Bitmap(objBitmap);
            for (int x = 0; x < objBitmap.Width; x++)
                for (int y = 0; y < objBitmap1.Height; y++)
                {
                    ListViewItem item = new ListViewItem();

                    Color w = objBitmap.GetPixel(x, y);
                    int r = w.R;
                    int g = w.G;
                    int b = w.B;
                    int xg = (int)((r + g + b) / 3);
                    Color wb = Color.FromArgb(xg, xg, xg);
                    objBitmap1.SetPixel(x, y, wb);

                    item.SubItems[0].Text = "[" + y.ToString() + "," + x.ToString() + "]";
                    item.SubItems.Add(r.ToString());
                    item.SubItems.Add(g.ToString());
                    item.SubItems.Add(b.ToString());
                    item.SubItems.Add(xg.ToString());
                    item.SubItems.Add(wb.ToString());
                    listView1.Items.Add(item);
                }
            pictureBox2.Image = objBitmap1;
        }

        // bw
        private void button3_Click(object sender, EventArgs e)
        {
            // Add header(column)
            listView1.Clear();
            listView1.Columns.Add("[x,y]", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai R", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai G", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai B", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai xg", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai wb", 200, HorizontalAlignment.Center);

            objBitmap1 = new Bitmap(objBitmap);
            for (int x = 0; x < objBitmap.Width; x++)
                for (int y = 0; y < objBitmap1.Height; y++)
                {
                    ListViewItem item = new ListViewItem();

                    Color w = objBitmap.GetPixel(x, y);
                    int r = w.R;
                    int g = w.G;
                    int b = w.B;
                    int xg = (int)((r + g + b) / 3);
                    int xbw = 0;
                    if (xg >= 128) xbw = 255;
                    Color wb = Color.FromArgb(xbw, xbw, xbw);
                    objBitmap1.SetPixel(x, y, wb);

                    item.SubItems[0].Text = "[" + y.ToString() + "," + x.ToString() + "]";
                    item.SubItems.Add(r.ToString());
                    item.SubItems.Add(g.ToString());
                    item.SubItems.Add(b.ToString());
                    item.SubItems.Add(xg.ToString());
                    item.SubItems.Add(wb.ToString());
                    listView1.Items.Add(item);
                }
            pictureBox2.Image = objBitmap1;
        }

        // terang
        private void button4_Click(object sender, EventArgs e)
        {
            // Add header(column)
            listView1.Clear();
            listView1.Columns.Add("[x,y]", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai xg", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai wb", 200, HorizontalAlignment.Center);

            objBitmap1 = new Bitmap(objBitmap);
            int a = 50;     // masukkan 
            for (int x = 0; x < objBitmap.Width; x++)
                for (int y = 0; y < objBitmap.Height; y++)
                {
                    ListViewItem item = new ListViewItem();

                    // proses
                    Color w = objBitmap.GetPixel(x, y);
                    int xg = w.R;
                    int xb = xg + a;
                    if (xb < 0) xb = 0;
                    if (xb > 255) xb = 255;
                    Color wb = Color.FromArgb(xb, xb, xb);
                    objBitmap1.SetPixel(x, y, wb);

                    // output
                    item.SubItems[0].Text = "[" + y.ToString() + "," + x.ToString() + "]";
                    item.SubItems.Add(xg.ToString());
                    item.SubItems.Add(wb.ToString());
                    listView1.Items.Add(item);
                }
            pictureBox2.Image = objBitmap1;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.GridLines = true;// Whether the grid lines are displayed
            listView1.FullRowSelect = true;// Whether to select the entire line

            listView1.View = View.Details;// Set display mode
            listView1.Scrollable = true;// Whether to show the scroll bar automatically
            listView1.MultiSelect = false;// Is it possible to select multiple lines
        }

        // low pass
        private void button5_Click(object sender, EventArgs e)
        {
            // Add header(column)
            listView1.Clear();
            listView1.Columns.Add("[x,y]", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai X1", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai X2", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai X3", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai X4", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai X5", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai X6", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai X7", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai X8", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai X9", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai xg", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai wb", 200, HorizontalAlignment.Center);

            objBitmap1 = new Bitmap(objBitmap);
            for (int x = 1; x < objBitmap.Width - 1; x++)
                for (int y = 1; y < objBitmap.Height - 1; y++)
                {
                    ListViewItem item = new ListViewItem();

                    // proses
                    Color w1 = objBitmap1.GetPixel(x - 1, y - 1);
                    Color w2 = objBitmap1.GetPixel(x - 1, y);
                    Color w3 = objBitmap1.GetPixel(x - 1, y + 1);
                    Color w4 = objBitmap1.GetPixel(x, y - 1);
                    Color w5 = objBitmap1.GetPixel(x, y);
                    Color w6 = objBitmap1.GetPixel(x, y + 1);
                    Color w7 = objBitmap1.GetPixel(x + 1, y - 1);
                    Color w8 = objBitmap1.GetPixel(x + 1, y);
                    Color w9 = objBitmap1.GetPixel(x + 1, y + 1);
                    int x1 = w1.R;
                    int x2 = w2.R;
                    int x3 = w3.R;
                    int x4 = w4.R;
                    int x5 = w5.R;
                    int x6 = w6.R;
                    int x7 = w7.R;
                    int x8 = w8.R;
                    int x9 = w9.R;
                    int xb = (int)((x1 + x2 + x3 + x4 + x5 + x6 +
                    x7 + x8 + x9) / 9);
                    if (xb < 0) xb = 0;
                    if (xb > 255) xb = 255;
                    Color wb = Color.FromArgb(xb, xb, xb);
                    objBitmap1.SetPixel(x, y, wb);

                    // output
                    item.SubItems[0].Text = "[" + y.ToString() + "," + x.ToString() + "]";
                    item.SubItems.Add(x1.ToString());
                    item.SubItems.Add(x2.ToString());
                    item.SubItems.Add(x3.ToString());
                    item.SubItems.Add(x4.ToString());
                    item.SubItems.Add(x5.ToString());
                    item.SubItems.Add(x6.ToString());
                    item.SubItems.Add(x7.ToString());
                    item.SubItems.Add(x8.ToString());
                    item.SubItems.Add(x9.ToString());
                    item.SubItems.Add(xb.ToString());
                    item.SubItems.Add(wb.ToString());
                    listView1.Items.Add(item);
                }
            pictureBox2.Image = objBitmap1;
        }

        // high pass
        private void button6_Click(object sender, EventArgs e)
        {
            // Add header(column)
            listView1.Clear();
            listView1.Columns.Add("[x,y]", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai X1", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai X2", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai X3", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai X4", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai X5", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai X6", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai X7", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai X8", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai X9", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai xg", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai wb", 200, HorizontalAlignment.Center);

            float[] a = new float[10];
            a[1] = (float)-1;
            a[2] = (float)-0.5;
            a[3] = (float)0;
            a[4] = (float)-0.5;
            a[5] = (float)1;
            a[6] = (float)0.5;
            a[7] = (float)0;
            a[8] = (float)0.5;
            a[9] = (float)1;
            objBitmap1 = new Bitmap(objBitmap);
            for (int x = 1; x < objBitmap.Width - 1; x++)
                for (int y = 1; y < objBitmap.Height - 1; y++)
                {
                    ListViewItem item = new ListViewItem();

                    // proses
                    Color w1 = objBitmap.GetPixel(x - 1, y - 1);
                    Color w2 = objBitmap.GetPixel(x - 1, y);
                    Color w3 = objBitmap.GetPixel(x - 1, y + 1);
                    Color w4 = objBitmap.GetPixel(x, y - 1);
                    Color w5 = objBitmap.GetPixel(x, y);
                    Color w6 = objBitmap.GetPixel(x, y + 1);
                    Color w7 = objBitmap.GetPixel(x + 1, y - 1);
                    Color w8 = objBitmap.GetPixel(x + 1, y);
                    Color w9 = objBitmap.GetPixel(x + 1, y + 1);
                    int x1 = w1.R;
                    int x2 = w2.R;
                    int x3 = w3.R;
                    int x4 = w4.R;
                    int x5 = w5.R;
                    int x6 = w6.R;
                    int x7 = w7.R;
                    int x8 = w8.R;
                    int x9 = w9.R;
                    int xb = (int)(a[1] * x1 + a[2] * x2 + a[3] * x3);
                    xb = (int)(xb + a[4] * x4 + a[5] * x5 + a[6] * x6);
                    xb = (int)(xb + a[7] * x7 + a[8] * x8 + a[9] * x9);
                    if (xb < 0) xb = 0;
                    if (xb > 255) xb = 255;
                    Color wb = Color.FromArgb(xb, xb, xb);
                    objBitmap1.SetPixel(x, y, wb);

                    // output
                    item.SubItems[0].Text = "[" + y.ToString() + "," + x.ToString() + "]";
                    item.SubItems.Add(x1.ToString());
                    item.SubItems.Add(x2.ToString());
                    item.SubItems.Add(x3.ToString());
                    item.SubItems.Add(x4.ToString());
                    item.SubItems.Add(x5.ToString());
                    item.SubItems.Add(x6.ToString());
                    item.SubItems.Add(x7.ToString());
                    item.SubItems.Add(x8.ToString());
                    item.SubItems.Add(x9.ToString());
                    item.SubItems.Add(xb.ToString());
                    item.SubItems.Add(wb.ToString());
                    listView1.Items.Add(item);
                }
            pictureBox2.Image = objBitmap1;
        }
    }
}
