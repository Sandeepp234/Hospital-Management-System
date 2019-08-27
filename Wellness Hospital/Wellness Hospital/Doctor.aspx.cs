using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;



namespace Wellness_Hospital
{
    public partial class Doctor : System.Web.UI.Page
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

            OracleCommand cmd = new OracleCommand("Select *  from Doctor_Details", cn);
            OracleDataAdapter adp = new OracleDataAdapter(cmd);

            adp.Fill(dt);
            cn.Close();
            GridViewDoctor.DataSource = dt;
            GridViewDoctor.DataBind();
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gd = GridViewDoctor.SelectedRow;

            txtDdoctorid.Text = gd.Cells[1].Text;
            txtDdoctorname.Text = gd.Cells[2].Text;
            txtDdoctoraddress.Text = gd.Cells[3].Text;
            txtDdoctoremail.Text = gd.Cells[4].Text;
            txtDdoctorcontact.Text = gd.Cells[5].Text;
            txtDdoctorspecialist.Text = gd.Cells[6].Text;
            txtDdoctorlevel.Text = gd.Cells[7].Text;


        }

       

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            String con;
            con = "User ID = sandeep ; Password =  admin; Data Source  =XE;";
            cn.ConnectionString = con;
            cn.Open();

            GridViewRow gvr = GridViewDoctor.SelectedRow;
            OracleCommand cmd = new OracleCommand("delete from Doctor_Details where doctorId = " + txtDdoctorid.Text, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            clear();
            display();

        }

        protected void btnDoctorsubmit_Click(object sender, EventArgs e)
        {
            String con;
            con = "User ID = sandeep; Password = admin; Data Source=XE;";

            cn.ConnectionString = con;
            cn.Open();

            OracleCommand cmd = new OracleCommand("Insert into Doctor_Details values('" + txtDdoctorid.Text + "', '" + txtDdoctorname.Text + "', '" + txtDdoctoraddress.Text + "','" + txtDdoctoremail.Text + "','" + txtDdoctorcontact.Text + "', '" +txtDdoctorspecialist.Text +"','" +txtDdoctorlevel.Text+"')", cn);

            cmd.ExecuteNonQuery();
            clear();
            cn.Close();

            Response.Write("Data Save Successfully");

            display();

        }


        private void clear()
        {
            txtDdoctorid.Text = "";
            txtDdoctorname.Text = "";
            txtDdoctoraddress.Text = "";
            txtDdoctoremail.Text = "";
            txtDdoctorcontact.Text = "";
            txtDdoctorspecialist.Text = "";
            txtDdoctorlevel.Text = "";

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            String con;
            con = "User Id = sandeep; Password = admin; Data Source = XE;";
            cn.ConnectionString = con;
            cn.Open();

            OracleCommand cmd = new OracleCommand("Update Doctor_Details set  doctorName = '" + txtDdoctorname.Text + "', doctorAddress = '" + txtDdoctoraddress.Text + "', doctorEmail='" + txtDdoctoremail.Text + "', doctorContact='" + txtDdoctorcontact.Text + "', doctorSpecialist='" + txtDdoctorspecialist.Text + "', doctorLevel='" + txtDdoctorlevel.Text + "'" + " where doctorId = " + txtDdoctorid.Text, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            display();
            clear();
        }

        protected void btnDdoctorupdate_Click(object sender, EventArgs e)
        {
            String con;
            con = "User Id = sandeep; Password = admin; Data Source = XE;";
            cn.ConnectionString = con;
            cn.Open();

            OracleCommand cmd = new OracleCommand("Update Doctor_Details set  doctorName = '" + txtDdoctorname.Text + "', doctorAddress = '" + txtDdoctoraddress.Text + "', doctorEmail='" + txtDdoctoremail.Text + "', doctorContact='" + txtDdoctorcontact.Text + "', doctorSpecialist='" + txtDdoctorspecialist.Text + "', doctorLevel='" + txtDdoctorlevel.Text + "'" + " where doctorId = " + txtDdoctorid.Text, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            display();
            clear();
        }

        protected void btnDdoctorcancle_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void btnDdoctordelete_Click(object sender, EventArgs e)
        {
            String con;
            con = "User ID = sandeep ; Password =  admin; Data Source  =XE;";
            cn.ConnectionString = con;
            cn.Open();

            GridViewRow gvr = GridViewDoctor.SelectedRow;
            OracleCommand cmd = new OracleCommand("delete from Doctor_Details where doctorId = " + txtDdoctorid.Text, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            clear();
            display();
        }
    }
}