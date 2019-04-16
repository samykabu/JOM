using System;
using System.Windows.Forms;
using System.Xml;

namespace JomDBForm
{
    public partial class ParseXML_and_FillTables : Form
    {
        private JOMSQLDBEntities ent;
        public ParseXML_and_FillTables()
        {
            InitializeComponent();
            ent = new JOMSQLDBEntities();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(@"D:\Development\Projects\Personal Projects\JOM\V1.01 Assets\SortedData.xml");
            XmlNodeList Zones = xdoc.SelectNodes("//Zone");
            foreach (XmlNode node in Zones)
            {
                System.Diagnostics.Debug.WriteLine(node.Attributes["ZoneID"].Value);
                Zone nZone = Zone.CreateZone(node.Attributes["ZoneID"].Value, Guid.NewGuid());
                nZone.ArName = node.Attributes["ZoneName"].Value;
                nZone.EnName = node.Attributes["ZoneName"].Value;
                nZone.PolyData = node.SelectSingleNode("ZoneSurface").OuterXml;
                nZone.TranslateX = double.Parse(node.SelectSingleNode("TranslateFactor/X").InnerText);
                nZone.TranslateY = double.Parse(node.SelectSingleNode("TranslateFactor/Y").InnerText);
                nZone.ZoomFactor = double.Parse(node.SelectSingleNode("ZoomFactor").InnerText);
                nZone.FillColorR = int.Parse(node.SelectSingleNode("FillColor/R").InnerText);
                nZone.FillColorG = int.Parse(node.SelectSingleNode("FillColor/R").InnerText);
                nZone.FillColorB = int.Parse(node.SelectSingleNode("FillColor/R").InnerText);
                System.Diagnostics.Debug.WriteLine(nZone.ZoomFactor.ToString());

                ent.AddToZone(nZone);

                XmlNodeList nRegions = node.SelectNodes("Regions/Region");
                foreach (XmlNode nRegion in nRegions)
                {
                    string pData = nRegion.SelectSingleNode("RegionSurface").OuterXml;
                    JomDBForm.Region newRegion = JomDBForm.Region.CreateRegion(nRegion.Attributes["RegionID"].Value, pData, nZone.ID,
                                                                               Guid.NewGuid());
                    newRegion.ArName = nRegion.Attributes["RegionName"].Value;
                    newRegion.EnName = nRegion.Attributes["RegionName"].Value;
                    newRegion.FillColorR = int.Parse(node.SelectSingleNode("FillColor/R").InnerText);
                    newRegion.FillColorG = int.Parse(node.SelectSingleNode("FillColor/R").InnerText);
                    newRegion.FillColorB = int.Parse(node.SelectSingleNode("FillColor/R").InnerText);
                    newRegion.TranslateX = double.Parse(node.SelectSingleNode("TranslateFactor/X").InnerText);
                    newRegion.TranslateY = double.Parse(node.SelectSingleNode("TranslateFactor/Y").InnerText);
                    newRegion.ZoomFactor = double.Parse(nRegion.SelectSingleNode("ZoomFactor").InnerXml);
                    newRegion.OwnerZone = nZone;
                    ent.AddToRegion(newRegion);
                }
            }
            int recordCount = ent.SaveChanges();
            if (recordCount > 0)
                MessageBox.Show("Saved def");
        }
    }
}
