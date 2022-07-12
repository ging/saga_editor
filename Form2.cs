using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFBatch
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = "Version " + Application.ProductVersion;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://forum.videohelp.com/threads/386028-FFmpeg-Batch-for-Windows");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://sourceforge.net/p/ffmpeg-batch/wiki/Changelog");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://sourceforge.net/p/ffmpeg-batch/wiki/FFmpeg%20Batch/");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (FFBatch_UPM.Properties.Settings.Default.app_lang == "es") MessageBox.Show("Aplicación para unir vídeos generados en los Platós SAGA de la Universidad Politécnica de Madrid.","Plató SAGA");
            if (FFBatch_UPM.Properties.Settings.Default.app_lang == "en") MessageBox.Show("Application to concatenate videos created with SAGA Studio from Polytechnics University of Madrid.", "SAGA Studio");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://innovacioneducativa.upm.es/saga/plato-saga");
        }
    }
}
