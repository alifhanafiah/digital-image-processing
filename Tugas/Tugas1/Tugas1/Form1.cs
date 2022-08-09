﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Tugas1
{
    public partial class Form1 : Form
    {
        Image File;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                File = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = File;
                pictureBox2.Image = File;
                pictureBox3.Image = File;
                pictureBox4.Image = File;
                pictureBox5.Image = File;
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
