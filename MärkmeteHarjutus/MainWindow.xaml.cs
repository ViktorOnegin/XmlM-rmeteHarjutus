using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.IO;
using System.Xml.XPath;


namespace MärkmeteHarjutus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("Märkmed.xml"))
            {
                MessageBox.Show("Fail on juba olemas");
            }
            else
            {

                MessageBox.Show("Fail on loodud");

                XmlTextWriter märkmeteFail = new XmlTextWriter("Märkmed.xml", System.Text.Encoding.UTF8);
                märkmeteFail.Formatting = Formatting.Indented;
                märkmeteFail.WriteStartElement("Märkmik");
                märkmeteFail.WriteStartElement("Märge");
                märkmeteFail.WriteStartElement("Pealkiri");
                märkmeteFail.WriteString("pealkiri");
                märkmeteFail.WriteEndElement();
                märkmeteFail.WriteStartElement("Sisu");
                märkmeteFail.WriteString("sisu");
                märkmeteFail.WriteEndElement();
                märkmeteFail.WriteEndElement();
                märkmeteFail.WriteEndElement();
                märkmeteFail.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!File.Exists("Märkmed.xml"))
            {
                MessageBox.Show("Fail puudub");
            }
            else 
            {
                string xmlfilepath = @"D:\programs\Visual Studio 2017\XML Märkmed\MärkmeteHarjutus\MärkmeteHarjutus\bin\Debug\Märkmed.xml";
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlfilepath);

                XmlNode node1 = doc.SelectSingleNode("/Märkmik/Märge/Pealkiri");
                node1.InnerText = TextBox1.Text;
                XmlNode node2 = doc.SelectSingleNode("/Märkmik/Märge/Sisu");
                node2.InnerText = TextBox2.Text;

                XmlNode node3 = doc.SelectSingleNode("/Märkmik/Märge/Pealkiri");
                TextBox3.Text = node3.InnerText;
                XmlNode node4 = doc.SelectSingleNode("/Märkmik/Märge/Sisu");
                TextBox4.Text = node4.InnerText;

                doc.Save("Märkmed.xml");


                MessageBox.Show("Märge Lisatud");
                //TextBox4.Text = File.ReadAllText("Märkmed.xml");

                TextBox1.Clear();
                TextBox2.Clear();
                
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string xmlfilepath = @"D:\programs\Visual Studio 2017\XML Märkmed\MärkmeteHarjutus\MärkmeteHarjutus\bin\Debug\Märkmed.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlfilepath);

            XmlNode node1 = doc.SelectSingleNode("/Märkmik/Märge/Pealkiri");

            if (node1 != null)
            {
                XmlNode parent1 = node1.ParentNode;
                parent1.RemoveChild(node1);
                string newXML = doc.OuterXml;
                TextBox3.Clear();
                doc.Save("Märkmed.xml");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string xmlfilepath = @"D:\programs\Visual Studio 2017\XML Märkmed\MärkmeteHarjutus\MärkmeteHarjutus\bin\Debug\Märkmed.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlfilepath);

            XmlNode node2 = doc.SelectSingleNode("/Märkmik/Märge/Sisu");

            if (node2 != null)
            {
                XmlNode parent2 = node2.ParentNode;
                parent2.RemoveChild(node2);
                string newXML = doc.OuterXml;
                TextBox4.Clear();
                doc.Save("Märkmed.xml");
            }
        }
    }
}
