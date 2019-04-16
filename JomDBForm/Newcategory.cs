using System;
using System.Linq;
using System.Windows.Forms;

namespace JomDBForm
{
    public partial class Newcategory : Form
    {
        private JOMSQLDBEntities ent;
        public Newcategory()
        {
            InitializeComponent();
        }

        private void Newcategory_Load(object sender, EventArgs e)
        {
            ent = new JOMSQLDBEntities();
            var sec = from c in ent.Sections select new { c.ArName, c.SectionID };
            comboBox1.DisplayMember = "ArName";
            comboBox1.ValueMember = "SectionID";
            comboBox1.DataSource = sec;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(comboBox1.SelectedValue.ToString());
            Category cf = Category.CreateCategory(Guid.NewGuid(), 0);
            cf.ArName = textBox1.Text;
            cf.EnName = textBox2.Text;
            //if (comboBox2.SelectedIndex >= 0)
            //{
            //    Guid catval = (Guid)comboBox2.SelectedValue;
            //    var ncat = from category in ent.Category where category.CategoryID == catval select category;
            //    cf.ParentCategory = ncat.First();
            //}

            Guid selval = (Guid)comboBox1.SelectedValue;
            var sec = from section in ent.Sections where section.SectionID == selval select section;
            cf.OwnerSection = sec.First();
            ent.AddToCategory(cf);
            if (ent.SaveChanges() > 0)
            {
                MessageBox.Show("Record Created");
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void FillCategories(object sender, EventArgs e)
        {
            Guid selval = (Guid)comboBox1.SelectedValue;
            var cat = from c in ent.Category where c.OwnerSection.SectionID == selval select new { c.ArName, c.CategoryID };
            comboBox2.DisplayMember = "ArName";
            comboBox2.ValueMember = "CategoryID";
            comboBox2.DataSource = cat;
            comboBox2.SelectedIndex = -1;
        }
    }
}
