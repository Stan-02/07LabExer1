using System;
using System.Data.SqlClient;
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
    public partial class FrmUpdateMember : Form
    {
        private ClubRegistrationQuery clubRegistrationQuery;
        private int Age;
        private string Program;
        private long StudentId;

        public FrmUpdateMember()
        {
            InitializeComponent();
        }

        private void FrmUpdateMember_Load(object sender, EventArgs e)
        {
            clubRegistrationQuery = new ClubRegistrationQuery();
            clubRegistrationQuery.DisplayID(cbID);
        }

        public void Fill()
        {
            string ClubDBConnectionString = @"Data Source=DESKTOP-VKHU5QN\SQLEXPRESS;Initial Catalog=ClubDB;Integrated Security=True";
            SqlConnection sqlConnect = new SqlConnection(ClubDBConnectionString);
            string getId = "SELECT * FROM ClubMembers";
            SqlCommand sqlCommand = new SqlCommand(getId, sqlConnect);
            sqlConnect.Open();
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();
            while (sqlReader.Read())
            {
                cbID.Items.Add(sqlReader["StudentId"]);
            }
            sqlConnect.Close();
        }
        public void cbFill()
        {
            clubRegistrationQuery.DisplayID(cbID);
        }
        public void TextFill()
        {
            LastNameTxt.Text = clubRegistrationQuery._LastName;
            FirstNameTxt.Text = clubRegistrationQuery._FirstName;
            MiddleNameTxt.Text = clubRegistrationQuery._MiddleName;
            AgeTxt.Text = clubRegistrationQuery._Age.ToString();
            cmbGender.Text = clubRegistrationQuery._Gender;
            cmbProgram.Text = clubRegistrationQuery._Program;
        }

        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            clubRegistrationQuery.DisplayText(cbID.Text);
            TextFill();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            StudentId = Convert.ToInt64(cbID.Text);
            Age = Convert.ToInt32(AgeTxt.Text);
            Program = cmbProgram.Text;
            clubRegistrationQuery.UpdateStudent(StudentId, Age, Program);
        }
    }
}
