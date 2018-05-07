using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace XML_Märkmed
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void UusMärkmik_Click(object sender, EventArgs e)
        {
            XmlTextWriter märkmed = new XmlTextWriter("D:\\programs\\Visual Studio 2017\\XML Märkmed\\XML Märkmed\\bin\\Debug\\Märkmed.xml" , Encoding.UTF8);
            märkmed.Formatting = Formatting.Indented;
            märkmed.WriteStartElement("Märkmik");
            märkmed.WriteStartElement("Uued Märkmed");
            märkmed.WriteStartElement("Pealkiri");
            märkmed.WriteString(textBox1.Text);
            märkmed.WriteEndElement();
            märkmed.WriteStartElement("Sisu");
            märkmed.WriteString(textBox2.Text);
            märkmed.WriteEndElement();
            märkmed.WriteEndElement();
            märkmed.WriteEndElement();
            märkmed.Close();
        }

        private void LisaMärkmed_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("D:\\programs\\Visual Studio 2017\\XML Märkmed\\XML Märkmed\\bin\\Debug\\Märkmed.xml");

            XmlNode märkmik = doc.CreateElement("Märkmik");
            XmlNode pealkiri2 = doc.CreateElement("Pealkiri");
            pealkiri2.InnerText = textBox3.Text;
            märkmik.AppendChild(pealkiri2);

            XmlNode sisu2 = doc.CreateElement("Sisu");
            sisu2.InnerText = textBox4.Text;
            märkmik.AppendChild(sisu2);
            doc.DocumentElement.AppendChild(märkmik);
            doc.Save("D:\\programs\\Visual Studio 2017\\XML Märkmed\\XML Märkmed\\bin\\Debug\\Märkmed.xml");
        }

        private void KustutaMärkmed_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("D:\\programs\\Visual Studio 2017\\XML Märkmed\\XML Märkmed\\bin\\Debug\\Märkmed.xml");

            foreach (XmlNode xmlNode in doc.SelectNodes("Märkmik/Uued Märkmed"))
                if (xmlNode.SelectSingleNode("Pealkiri").InnerText == textBox5.Text) xmlNode.ParentNode.RemoveChild(xmlNode);

            doc.Save("D:\\programs\\Visual Studio 2017\\XML Märkmed\\XML Märkmed\\bin\\Debug\\Märkmed.xml");
        }
    }
}
