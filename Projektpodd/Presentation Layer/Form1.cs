using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel.Syndication;
using System.Xml;
using System.IO;

namespace Projektpodd
{
    public partial class Form1 : Form
    {
        public string podd { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void btnLaggTillPodd_Click(object sender, EventArgs e)
        {
            try
            {
                string url = podd;
                XmlReader reader = XmlReader.Create(url);
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                reader.Close();
                foreach (SyndicationItem item in feed.Items)
                {
                    String subject = item.Title.Text;
                    String summary = item.Summary.Text;

                    string namn = item.Title.Text;

                    listPodd.Items.Add(namn);

                }
            } catch(Exception)
            {
                MessageBox.Show("Inte en giltig URL");
            }
            
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            podd = textBox1.Text;
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
