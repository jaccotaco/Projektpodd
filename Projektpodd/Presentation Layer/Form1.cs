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
        public object SelectedItem { get; set; }
        public string beskrivning { get; set; }
        public string feed { get; set; }


        public Form1()
        {
            InitializeComponent();
            if (File.Exists("ListBoxItems.xml"))
            {
                using (StreamReader sr = new StreamReader("ListBoxItems.xml"))
                {
                    while (sr.Peek() != -1)
                    {
                        lstKategorier.Items.Add(sr.ReadLine());
                    }
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            



        }

        public void btnLaggTillPodd_Click(object sender, EventArgs e)
        {
            /*
            string url = podd;
            var reader = XmlReader.Create(url);
            reader.ReadToDescendant("item");
            do
            {
                reader.ReadStartElement("item");
                var title = reader.ReadElementContentAsString();
                Console.WriteLine(title);
            } while (reader.ReadToNextSibling("item"));

            
            try
                { 
            string url = podd;
            var reader = XmlReader.Create(url);
            reader.ReadToDescendant("item");
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                reader.Close();
                

                foreach (SyndicationItem item in feed.Items)
                {
                    string avsnitt = 
                    listPodd.Items.Add(avsnitt);
                } 
            }
            catch (Exception)
            {
                MessageBox.Show("Inte en giltig URL");
            }

            
            try
            {
                string url = podd;
                XmlReader reader = XmlReader.Create(url);
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                reader.Close();
                foreach (SyndicationItem item in feed.Items)
                {
                    string avsnitt = item.Summary.Text;
                    lstBeskrivning.Items.Add(avsnitt);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Inte en giltig URL");
            }

            */
            try
            {

                string url = podd;
                XmlReader reader = XmlReader.Create(url);
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                reader.Close();

                var hej = feed.Title.Text;
                listPodd.Items.Add(hej);
                
            }
            catch (Exception)
            {
                MessageBox.Show("Inte en giltig URL");
            }
            

        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            podd = textBox1.Text;


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void nyKategori_Click(object sender, EventArgs e)
        {
            lstKategorier.Items.Add(txtBoxKategorier.Text);
            using (StreamWriter sw = new StreamWriter("ListBoxItems.xml", true))
            {
                sw.WriteLine(txtBoxKategorier.Text);
                
            }
            this.txtBoxKategorier.Clear();
            string[] lineOfContents = File.ReadAllLines("ListBoxItems.xml");
            foreach (var line in lineOfContents)
            {
                string[] tokens = line.Split(',');
                comboBox2.Items.Add(tokens[0]);
            }
            

        }

        private void lstKategorier_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curItem = lstKategorier.SelectedItems.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*
            var selected_items = lstKategorier.SelectedItems.Cast<ListViewItem>();
            File.WriteAllLines("ListBoxItems.txt", selected_items.Select(lvi => lvi.Text));
            foreach (var lvi in selected_items) lstKategorier.Items.Remove(lvi);
            */

            foreach (var lvi in lstKategorier.SelectedItems.Cast<ListViewItem>()) lstKategorier.Items.Remove(lvi);
            File.WriteAllLines("ListBoxItems.xml", lstKategorier.Items.Cast<ListViewItem>().Select(lvi => lvi.Text + "," + lvi.SubItems[0].Text));
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}

