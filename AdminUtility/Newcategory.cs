using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AdminUtility
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
            try
            {
                ent = new JOMSQLDBEntities();
            }
            catch (Exception ex)
            {
                
                throw ex ;
            }
            var sec = from c in ent.Sections select new { c.ArName, c.SectionID };
            SelectedSectionID.DisplayMember = "ArName";
            SelectedSectionID.ValueMember = "SectionID";
            SelectedSectionID.DataSource = sec;
            DataTypeCombo.SelectedIndex = 0;
        }

        private void SaveBtClick(object sender, EventArgs e)
        {
            if (DataTypeCombo.SelectedIndex < 0)
                DataTypeCombo.SelectedIndex = 0;
            System.Diagnostics.Debug.WriteLine(SelectedSectionID.SelectedValue.ToString());
            Category cf = Category.CreateCategory(Guid.NewGuid(), 0);
            cf.ArName = ArabicName.Text;
            cf.EnName = EnglishName.Text;            

            if (HeaderImg.Text.Trim().Length > 0)
                cf.HeaderImageFile = "/Images/" + HeaderImg.Text;
            Guid selval = (Guid)SelectedSectionID.SelectedValue;
            var sec = from section in ent.Sections where section.SectionID == selval select section;
            cf.Sections = sec.First();
            cf.DType = DataTypeCombo.SelectedIndex;
            ent.AddToCategory(cf);
            if (ent.SaveChanges() > 0)
            {
                MessageBox.Show("Record Created");
                ArabicName.Text = "";
                EnglishName.Text = "";
                DataTypeCombo.SelectedIndex = 0;
            }
        }

        private void FillCategories(object sender, EventArgs e)
        {
            Guid selval = (Guid)SelectedSectionID.SelectedValue;
            var cat = from c in ent.Category where c.Sections.SectionID == selval select c;
            Categories.DisplayMember = "ArName";
            Categories.ValueMember = "CategoryID";
            Categories.DataSource = cat;            
            Categories.SelectedIndex = -1;
        }

        private void CancelClick(object sender, EventArgs e)
        {
            if (EditBT.Text.ToLower()!="edit")
            {
                EditBT.Text = "Edit";
                Categories.Enabled = true;
                SelectedSectionID.Enabled = true;
                SaveBT.Enabled = true;
                ArabicName.Text = "";
                EnglishName.Text = "";
                HeaderImg.Text = "";
                DataTypeCombo.SelectedIndex = -1;
                Categories.SelectedIndex = -1;
            }
            else
            {
                this.Close();    
            }
            
        }

        private void EditCategoryClick(object sender, EventArgs e)
        {
            if(Categories.SelectedIndex>=0)
            {
                if (EditBT.Text.ToLower() == "edit")
                {
                    Category scat = (Category) Categories.Items[Categories.SelectedIndex];
                    ArabicName.Text = scat.ArName;
                    EnglishName.Text = scat.EnName;
                    HeaderImg.Text = scat.HeaderImageFile;
                    DataTypeCombo.SelectedIndex = scat.DType;
                    EditBT.Text = "Update";
                    Categories.Enabled = false;
                    SelectedSectionID.Enabled = false;
                    SaveBT.Enabled = false;
                }
                else
                {
                    Category scat = (Category)Categories.Items[Categories.SelectedIndex];
                    scat.ArName = ArabicName.Text;
                    scat.EnName = EnglishName.Text;
                    scat.HeaderImageFile = HeaderImg.Text;
                    scat.DType = DataTypeCombo.SelectedIndex;

                    if(ent.SaveChanges()>0)
                    {
                       

                        EditBT.Text = "Edit";
                        Categories.Enabled = true;
                        SelectedSectionID.Enabled = true;
                        SaveBT.Enabled = true;
                        ArabicName.Text = "";
                        EnglishName.Text = "";
                        HeaderImg.Text = "";
                        DataTypeCombo.SelectedIndex = -1;
                        Categories.SelectedIndex = -1;
                    }
                }
            }
        }

        private void DispalyFileSelection_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFileDialog = new OpenFileDialog();
            oFileDialog.Filter = "Image Files|*.PNG;*.GIF;*.JPG";
            oFileDialog.ShowDialog();
            HeaderImg.Text = Path.GetFileName(oFileDialog.FileName);
        }
    }
}
