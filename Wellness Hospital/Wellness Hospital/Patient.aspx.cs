using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wellness_Hospital
{
    public partial class Patient : System.Web.UI.Page
    {
        private OracleConnection cn = new OracleConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            display();

        }

        public void display()
        {
            DataTable dt = new DataTable();
            String con;
            con = "User Id = sandeep; Password=admin; Data source = XE";
            cn.ConnectionString = con;
            cn.Open();

            //to display data from department table

            OracleCommand cmd = new OracleCommand("Select *  from Patients_Details", cn);
            OracleDataAdapter adp = new OracleDataAdapter(cmd);

            adp.Fill(dt);
            cn.Close();
            GridViewPatient.DataSource = dt;
            GridViewPatient.DataBind();


        }

        private void clear()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtContact.Text = "";
            txtEmail.Text = "";
            txtDbo.Text = "";
            dropdownGender.Text = "";


        }

        protected void GridViewPatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gd = GridViewPatient.SelectedRow;

            txtId.Text = gd.Cells[1].Text;
            txtName.Text = gd.Cells[2].Text;
            txtAddress.Text = gd.Cells[3].Text;
            txtContact.Text = gd.Cells[4].Text;
            txtEmail.Text = gd.Cells[5].Text;
            txtDbo.Text = gd.Cells[6].Text;
            dropdownGender.Text = gd.Cells[7].Text;

        }

        protected void GridViewPatient_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String con;
            con = "User ID = sandeep ; Password =  admin; Data Source  =XE;";
            cn.ConnectionString = con;
            cn.Open();

            GridViewRow gvr = GridViewPatient.SelectedRow;
            OracleCommand cmd = new OracleCommand("delete from Patients_Details where patientId = '" + txtId.Text+"'", cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            clear();
            display();


        }

        protected void GridViewPatient_RowEditing(object sender, GridViewEditEventArgs e)
        {
            String con;
            con = "User Id = sandeep; Password = admin; Data Source = XE;";
            cn.ConnectionString = con;
            cn.Open();

            OracleCommand cmd = new OracleCommand("Update Patients_Details set  patientName = '" + txtName.Text + "', patientAddress = '" + txtAddress.Text + "', patientContact='" + txtContact.Text + "', patientEmail='" + txtEmail.Text + "', patientDoB='" + txtDbo.Text + "', patientGender='" + dropdownGender.Text + "'" + " where patientId = " + txtId.Text, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            display();
            clear();


        }

        protected void btnPsubmit_Click(object sender, EventArgs e)
        {
            String con;
            con = "User ID = sandeep; Password = admin; Data Source=XE;";

            cn.ConnectionString = con;
            cn.Open();

            OracleCommand cmd = new OracleCommand("Insert into Patients_Details values('" + txtId.Text + "', '" + txtName.Text + "', '" + txtAddress.Text + "','" + txtContact.Text + "','" + txtEmail.Text + "', '" + txtDbo.Text+"','" + dropdownGender.Text+"')", cn);

            cmd.ExecuteNonQuery();
            clear();
            cn.Close();

            Response.Write("Data Save Successfully");

            display();
        }

        protected void btnPupdate_Click(object sender, EventArgs e)
        {
            String con;
            con = "User Id = sandeep; Password = admin; Data Source = XE;";
            cn.ConnectionString = con;
            cn.Open();

            OracleCommand cmd = new OracleCommand("Update Patients_Details set  patientName = '" + txtName.Text + "', patientAddress = '" + txtAddress.Text + "', patientContact='" + txtContact.Text + "', patientEmail='" + txtEmail.Text + "', patientDoB='" + txtDbo.Text + "', patientGender='" + dropdownGender.Text + "'"+ " where patientId = " + txtId.Text, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            display();
            clear();

        }

        protected void btnPcancle_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void btnPdelete_Click(object sender, EventArgs e)
        {

            String con;
            con = "User ID = sandeep ; Password =  admin; Data Source  =XE;";
            cn.ConnectionString = con;
            cn.Open();

            GridViewRow gvr = GridViewPatient.SelectedRow;
            OracleCommand cmd = new OracleCommand("delete from Patients_Details where patientId = '" + txtId.Text + "'", cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            clear();
            display();
        }
    }
}