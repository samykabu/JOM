using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace JomDBForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //private static string _sqlCeconnectionString =
        //"metadata=res://*/JOMSQLModel.csdl|res://*/JOMSQLModel.ssdl|res://*/JOMSQLModel.msl;provider=System.Data.SqlServerCe.3.5;provider connection string=\"Data Source=D:\\Development\\Projects\\Personal Projects\\JOM\\V1.01 Assets\\JOMSQLDB.sdf;Password=p7z6y1f9;Persist Security Info=false\";";



        //entityConnectionString: If your metadata(CSDL, SSDL and MSL, or in this case EDMX) files lie in the same place as application, you can use "."




        private void Form1_Load(object sender, EventArgs e)
        {
            //try
            //{

            //    JOMSQLDBEntities ent = new JOMSQLDBEntities();
            //    var cate = from ca in ent.Category select ca;
            //    foreach (var category in cate)
            //    {
            //        System.Diagnostics.Debug.WriteLine(category.ArName);
            //    }
            //    var sec = from section in ent.Sections select section;

            //    foreach (var secc in sec)
            //    {
            //        System.Diagnostics.Debug.WriteLine(secc.ArName);
            //    }
            //    Category cf = Category.CreateCategory(Guid.NewGuid());
            //    cf.Sections = sec.First();
            //    cf.ArName = "Arabic Name";
            //    cf.EnName = "English name";
            //    ent.AddToCategory(cf);
            //    int i = ent.SaveChanges();
            //}
            //catch (Exception ex)
            //{
            //    System.Diagnostics.Debug.WriteLine(ex.Message);
            //}

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Newcategory nc = new Newcategory();
            nc.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ParseXML_and_FillTables pxml = new ParseXML_and_FillTables();
            pxml.Show();
        }
    }
}
