using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
namespace tabukelimeprogram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void yukle()
        {
            XmlDocument i = new XmlDocument();
            DataSet ds = new DataSet();
            //xml dosyamızı okumak için bir reader oluşturuyoruz.
            XmlReader xmlFile;
            xmlFile = XmlReader.Create(@"veri.xml", new XmlReaderSettings());
            //içeriği Dataset e aktarıyoruz.
            ds.ReadXml(xmlFile);
            //datagridviewin kaynağı olarak dataseti gösteriyoruz.
            dataGridView1.DataSource = ds.Tables[0];
            xmlFile.Close();
        }

       
        private void button1_Click_1(object sender, EventArgs e)
        {         
               

                XDocument x = XDocument.Load("veri.xml");

                x.Element("grup").Add(
                new XElement("kelimeler",
                new XAttribute("kelime", kelime.Text),
                new XAttribute("yasak1", yasak1.Text),
                new XAttribute("yasak2", yasak2.Text),
                new XAttribute("yasak3", yasak3.Text),
                new XAttribute("yasak4", yasak4.Text),
                new XAttribute("yasak5", yasak5.Text)
                ));

                x.Save(@"veri.xml");
                yukle();
                
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            yukle();
        }
    }
}
