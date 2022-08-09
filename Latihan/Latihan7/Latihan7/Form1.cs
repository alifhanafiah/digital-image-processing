using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Latihan7
{
    public partial class Form1 : Form
    {
        Bitmap objBitmap;
        Bitmap objBitmap1;

        public Form1()
        {
            InitializeComponent();
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
            objBitmap1 = new Bitmap(objBitmap);

            // grey scale
            for (int x = 0; x < objBitmap.Width; x++)
                for (int y = 0; y < objBitmap1.Height; y++)
                {
                    Color w = objBitmap.GetPixel(x, y);
                    int r = w.R;
                    int g = w.G;
                    int b = w.B;
                    int xg = (int)((r + g + b) / 3);
                    Color wb = Color.FromArgb(xg, xg, xg);
                    objBitmap1.SetPixel(x, y, wb);

                    // list view
                    ListViewItem item = new ListViewItem();
                    item.SubItems.Clear();

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

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.GridLines = true; // wether the grid lines are displayed
            listView1.FullRowSelect = true; // wether to select the entire
            listView1.View = View.Details; // set display mode
            listView1.Scrollable = true; // wether to show the scroll bar
            listView1.MultiSelect = false; // it is possible to select multi

            // add header (column)
            listView1.Columns.Add("[x,y]", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai R", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai G", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai B", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai xg", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai wb", 200, HorizontalAlignment.Center);
        }
    }
}
