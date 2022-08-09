﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Bitmap objBitmap;
        Bitmap objBitmap1;

        public Form1()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                objBitmap = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = objBitmap;
            }
        }

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
                for (int x = 0; x < objBitmap.Width; x++)
                for (int y = 0; y < objBitmap.Height; y++)
                {
                    ListViewItem item = new ListViewItem();
                    //listView1.Clear();
                    item.SubItems.Clear();
                    Color w = objBitmap.GetPixel(x, y);
                    int r = w.R;
                    int g = w.G;
                    int b = w.B;
                    int xg = (int)((r + g + b) / 3);
                    Color wb = Color.FromArgb(xg, xg, xg);
                    objBitmap.SetPixel(x, y, wb);
                    item.SubItems[0].Text = "[" + y.ToString() + "," + x.ToString() + "]";
                    item.SubItems.Add(r.ToString());
                    item.SubItems.Add(g.ToString());
                    item.SubItems.Add(b.ToString());
                    item.SubItems.Add(xg.ToString());
                    item.SubItems.Add(wb.ToString());
                    listView1.Items.Add(item);
                }
            pictureBox2.Image = objBitmap;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.GridLines = true;// Whether the grid lines are displayed
            listView1.FullRowSelect = true;// Whether to select the entire line

            listView1.View = View.Details;// Set display mode
            listView1.Scrollable = true;// Whether to show the scroll bar automatically
            listView1.MultiSelect = false;// Is it possible to select multiple lines
        }

        private void button3_Click(object sender, EventArgs e)
        {
            float[] a= new float[5];
            a[1] = (float)0.2;     // 1, 2
            a[2] = (float)0.2;     // 3, 2
            a[3] = (float)0.2;     // 2, 1
            a[4] = (float)0.2;     // 2, 3
            a[0] = (float)0.2;     // 2, 2
            
            objBitmap1 = new Bitmap(objBitmap);
            for (int x = 1; x < objBitmap.Width-1; x++)
            for (int y = 1; y < objBitmap.Height-1; y++)
            {

            Color w1 = objBitmap.GetPixel(x - 1, y);
            Color w2 = objBitmap.GetPixel(x + 1, y);
            Color w3 = objBitmap.GetPixel(x, y - 1);
            Color w4 = objBitmap.GetPixel(x, y + 1);
            Color w = objBitmap.GetPixel(x, y);
            int x1 = w1.R;
            int x2 = w2.R;
            int x3 = w3.R;
            int x4 = w4.R;
            int xg = w.R;
            int xb = (int)(a[0]*xg);
            xb=(int)(xb+a[1]*x1+a[2]*x2+a[3]*x3+a[4]*x4);
            if (xb < 0) xb = 0;
               if (xb > 255) xb = 255;
                Color wb = Color.FromArgb(xb, xb, xb);
                 objBitmap1.SetPixel(x, y, wb);
            }
            pictureBox2.Image = objBitmap1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            float[] a= new float[10];
            a[1]=(float)0.1;
            a[2]=(float)0.1;
            a[3]=(float)0.1;
            a[4]=(float)0.1;
            a[5]=(float)0.2;
            a[6]=(float)0.1;
            a[7]=(float)0.1;
            a[8]=(float)0.1;
            a[9]=(float)0.1;
            objBitmap1 = new Bitmap(objBitmap);
            for (int x = 1; x < objBitmap.Width-1; x++)
            for (int y = 1; y < objBitmap.Height-1; y++)
            {
            Color w1 = objBitmap.GetPixel(x-1, y-1);
            Color w2 = objBitmap.GetPixel(x-1, y);
            Color w3 = objBitmap.GetPixel(x-1, y+1);
            Color w4 = objBitmap.GetPixel(x, y-1);
            Color w5 = objBitmap.GetPixel(x, y);
            Color w6 = objBitmap.GetPixel(x, y+1);
            Color w7 = objBitmap.GetPixel(x+1, y-1);
            Color w8 = objBitmap.GetPixel(x+1, y);
            Color w9 = objBitmap.GetPixel(x+1, y+1);
            int x1 = w1.R;
            int x2 = w2.R;
            int x3 = w3.R;
            int x4 = w4.R;
            int x5 = w5.R;
            int x6 = w6.R;
            int x7 = w7.R;
            int x8 = w8.R;
            int x9 = w9.R;
            int xb = (int)(a[1]*x1+a[2]*x2+a[3]*x3);
            xb=(int)(xb+a[4]*x4+a[5]*x5+a[6]*x6);
            xb=(int)(xb+a[7]*x7+a[8]*x8+a[9]*x9);
            if (xb < 0) xb = 0;
            if (xb > 255) xb = 255;
            Color wb = Color.FromArgb(xb, xb, xb);
            objBitmap1.SetPixel(x, y, wb);
            }
            pictureBox2.Image = objBitmap1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            float[] a = new float[5];
            a[1] = (float)0.2;
            a[2] = (float)0.2;
            a[3] = (float)0.2;
            a[4] = (float)0.2;
            a[0] = (float)0.2;

            // Add header(column)
            listView1.Clear();
            listView1.Columns.Add("[x,y]", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai X1", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai X2", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai X3", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai X4", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai xg", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai wb", 200, HorizontalAlignment.Center);
            objBitmap1 = new Bitmap(objBitmap);
            for (int x = 1; x < objBitmap.Width - 1; x++)
                for (int y = 1; y < objBitmap.Height - 1; y++)
                {
                    ListViewItem item = new ListViewItem();
                    //listView1.Clear();
                    item.SubItems.Clear();
                    Color w1 = objBitmap.GetPixel(x - 1, y);
                    Color w2 = objBitmap.GetPixel(x + 1, y);
                    Color w3 = objBitmap.GetPixel(x, y - 1);
                    Color w4 = objBitmap.GetPixel(x, y + 1);
                    Color w = objBitmap.GetPixel(x, y);
                    int x1 = w1.R;
                    int x2 = w2.R;
                    int x3 = w3.R;
                    int x4 = w4.R;
                    int xg = w.R;
                    int xb = (int)(a[0] * xg);
                    xb = (int)(xb + a[1] * x1 + a[2] * x2 + a[3] * x3 + a[3] * x4);
                    if (xb < 0) xb = 0;
                    if (xb > 255) xb = 255;
                    Color wb = Color.FromArgb(xb, xb, xb);
                    objBitmap1.SetPixel(x, y, wb);
                    item.SubItems[0].Text = "[" + y.ToString() + "," + x.ToString() + "]";
                    item.SubItems.Add(x1.ToString());
                    item.SubItems.Add(x2.ToString());
                    item.SubItems.Add(x3.ToString());
                    item.SubItems.Add(x4.ToString());
                    item.SubItems.Add(xg.ToString());
                    item.SubItems.Add(wb.ToString());
                    listView1.Items.Add(item);
                }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            float[] a = new float[10];
            a[1] = (float)0.1;
            a[2] = (float)0.1;
            a[3] = (float)0.1;
            a[4] = (float)0.1;
            a[5] = (float)0.2;
            a[6] = (float)0.1;
            a[7] = (float)0.1;
            a[8] = (float)0.1;
            a[9] = (float)0.1;
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
            listView1.Columns.Add("Nilai xg", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai wb", 200, HorizontalAlignment.Center);
            objBitmap1 = new Bitmap(objBitmap);
            for (int x = 1; x < objBitmap.Width - 1; x++)
                for (int y = 1; y < objBitmap.Height - 1; y++)
                {
                    ListViewItem item = new ListViewItem();
                    //listView1.Clear();
                    item.SubItems.Clear();
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
                    item.SubItems[0].Text = "[" + y.ToString() + "," + x.ToString() + "]";
                    item.SubItems.Add(x1.ToString());
                    item.SubItems.Add(x2.ToString());
                    item.SubItems.Add(x3.ToString());
                    item.SubItems.Add(x4.ToString());
                    item.SubItems.Add(x5.ToString());
                    item.SubItems.Add(x6.ToString());
                    item.SubItems.Add(x7.ToString());
                    item.SubItems.Add(x8.ToString());
                    item.SubItems.Add(xb.ToString());
                    item.SubItems.Add(wb.ToString());
                    listView1.Items.Add(item);
                }
            pictureBox2.Image = objBitmap1;
        }

        ///////////////////////////////////////////////////////
        // 4 node a
        private void button8_Click(object sender, EventArgs e)
        {
            float[] a = new float[5];
            a[1] = (float)-0.5;     // 1, 2
            a[2] = (float)0.5;      // 3, 2
            a[3] = (float)-0.5;     // 2, 1
            a[4] = (float)0.5;      // 2, 3
            a[0] = (float)0;        // 2, 2

            objBitmap1 = new Bitmap(objBitmap);
            for (int x = 1; x < objBitmap.Width - 1; x++)
                for (int y = 1; y < objBitmap.Height - 1; y++)
                {

                    Color w1 = objBitmap.GetPixel(x - 1, y);
                    Color w2 = objBitmap.GetPixel(x + 1, y);
                    Color w3 = objBitmap.GetPixel(x, y - 1);
                    Color w4 = objBitmap.GetPixel(x, y + 1);
                    Color w = objBitmap.GetPixel(x, y);
                    int x1 = w1.R;
                    int x2 = w2.R;
                    int x3 = w3.R;
                    int x4 = w4.R;
                    int xg = w.R;
                    int xb = (int)(a[0] * xg);
                    xb = (int)(xb + a[1] * x1 + a[2] * x2 + a[3] * x3 + a[4] * x4);
                    if (xb < 0) xb = 0;
                    if (xb > 255) xb = 255;
                    Color wb = Color.FromArgb(xb, xb, xb);
                    objBitmap1.SetPixel(x, y, wb);
                }
            pictureBox2.Image = objBitmap1;
        }

        // 4 node b
        private void button9_Click(object sender, EventArgs e)
        {
            float[] a = new float[5];
            a[1] = (float)-0.5;     // 1, 2
            a[2] = (float)0.5;      // 3, 2
            a[3] = (float)-0.5;     // 2, 1
            a[4] = (float)0.5;      // 2, 3
            a[0] = (float)1;        // 2, 2

            objBitmap1 = new Bitmap(objBitmap);
            for (int x = 1; x < objBitmap.Width - 1; x++)
                for (int y = 1; y < objBitmap.Height - 1; y++)
                {

                    Color w1 = objBitmap.GetPixel(x - 1, y);
                    Color w2 = objBitmap.GetPixel(x + 1, y);
                    Color w3 = objBitmap.GetPixel(x, y - 1);
                    Color w4 = objBitmap.GetPixel(x, y + 1);
                    Color w = objBitmap.GetPixel(x, y);
                    int x1 = w1.R;
                    int x2 = w2.R;
                    int x3 = w3.R;
                    int x4 = w4.R;
                    int xg = w.R;
                    int xb = (int)(a[0] * xg);
                    xb = (int)(xb + a[1] * x1 + a[2] * x2 + a[3] * x3 + a[4] * x4);
                    if (xb < 0) xb = 0;
                    if (xb > 255) xb = 255;
                    Color wb = Color.FromArgb(xb, xb, xb);
                    objBitmap1.SetPixel(x, y, wb);
                }
            pictureBox2.Image = objBitmap1;
        }

        ///////////////////////////////////////////////////////
        // 8 node a
        private void button10_Click(object sender, EventArgs e)
        {
            float[] a = new float[10];
            a[1] = (float)-1;
            a[2] = (float)-0.5;
            a[3] = (float)0;
            a[4] = (float)-0.5;
            a[5] = (float)0;
            a[6] = (float)0.5;
            a[7] = (float)0;
            a[8] = (float)0.5;
            a[9] = (float)1;
            objBitmap1 = new Bitmap(objBitmap);
            for (int x = 1; x < objBitmap.Width - 1; x++)
                for (int y = 1; y < objBitmap.Height - 1; y++)
                {
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
                }
            pictureBox2.Image = objBitmap1;
        }

        // 8 node b
        private void button11_Click(object sender, EventArgs e)
        {
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
                }
            pictureBox2.Image = objBitmap1;
        }
    }
}
