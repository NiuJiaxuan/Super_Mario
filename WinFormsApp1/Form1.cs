using System.Xml;
using System.Text;
using System.Windows.Forms;


namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Users\\JokeMaker\\source\\repos\\Sprint1\\MyFirstGame\\bin\\Debug\\net6.0\\MarioLevel1.xml");
            XmlNode item = doc.CreateElement("Item");
            XmlNode objectType = doc.CreateElement("ObjectType");
            XmlNode objectName = doc.CreateElement("ObjectName");
            XmlNode position = doc.CreateElement("Position");
            XmlNode blockItem = doc.CreateElement("BlockItem");
            //objectType.InnerText = 
            item.AppendChild(objectType);
            item.AppendChild(objectName);
            item.AppendChild(position);
            item.AppendChild(blockItem);
        }
    }
}