using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalsLabExer
{
    public partial class FrmClubRegistration : Form
    {
        private ClubRegistrationQuery clubRegistrationQuery;
        private int ID, Age;
        private int count = 0;
        private string FirstName, MiddleName, LastName, Gender, Program;
        private long StudentID;

        public FrmClubRegistration()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, EventArgs e)
        {
            ID = RegistrationID();
            StudentID = Convert.ToInt64(txtStudID.Text);
            FirstName = txtFirstName.Text;
            MiddleName = txtMiddleName.Text;
            LastName = txtLastName.Text;
            Age = Convert.ToInt32(txtAge.Text);
            Gender = cbGender.Text;
            Program = cbProgram.Text;
            clubRegistrationQuery.RegisterStudent(ID, StudentID, FirstName, MiddleName, LastName, Age, Gender, Program);
        }
            
        private void Update_Click(object sender, EventArgs e)
        {
            FrmUpdateMember upd = new FrmUpdateMember();
            upd.Show();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            RefreshListofClubMembers();
        }
        private void FrmClubRegistration_Load(object sender, EventArgs e)
        {       
            clubRegistrationQuery = new ClubRegistrationQuery();
            RefreshListofClubMembers();
        }
        public int RegistrationID()
        {
            return count++;
        }

        public void RefreshListofClubMembers()
        {
            clubRegistrationQuery.DisplayList();
            dataGridView1.DataSource = clubRegistrationQuery.bindingSource;
        }
    }
}
