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
    public partial class Department : System.Web.UI.Page
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

            OracleCommand cmd = new OracleCommand("Select *  from Department_Detais", cn);
            OracleDataAdapter adp = new OracleDataAdapter(cmd);

            adp.Fill(dt);
            cn.Close();
            GridViewDepartment.DataSource = dt;
            GridViewDepartment.DataBind();


        }


        private void clear()
        {
            txtDid.Text = "";
            txtDname.Text = "";
            txtDfloor.Text = "";
            txtDcontact.Text = "";
            txtDdepartmenthead.Text = "";


        }

        protected void btnDsubmit_Click(object sender, EventArgs e)
        {

            String con;
            con = "User ID = sandeep; Password = admin; Data Source=XE;";

            cn.ConnectionString = con;
            cn.Open();

            OracleCommand cmd = new OracleCommand("Insert into Department_Detais values('" + txtDid.Text + "', '" + txtDname.Text + "', '" + txtDdepartmenthead.Text + "','" + txtDcontact.Text + "','" + txtDfloor.Text + "')", cn);

            cmd.ExecuteNonQuery();
            clear();
            cn.Close();

            Response.Write("Data Save Successfully");

            display();

        }

        protected void GridViewDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gd = GridViewDepartment.SelectedRow;

            txtDid.Text = gd.Cells[1].Text;
            txtDname.Text = gd.Cells[2].Text;
            txtDdepartmenthead.Text = gd.Cells[3].Text;
            txtDcontact.Text = gd.Cells[4].Text;
            txtDfloor.Text = gd.Cells[5].Text;

        }

        protected void GridViewDepartment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String con;
            con = "User ID = sandeep ; Password =  admin; Data Source  =XE;";
            cn.ConnectionString = con;
            cn.Open();

            GridViewRow gvr = GridViewDepartment.SelectedRow;
            OracleCommand cmd = new OracleCommand("delete from Department_Detais where deptId = " + txtDid.Text, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            clear();
            display();

        }

        protected void GridViewDepartment_RowEditing(object sender, GridViewEditEventArgs e)
        {
            String con;
            con = "User Id = sandeep; Password = admin; Data Source = XE;";
            cn.ConnectionString = con;
            cn.Open();

            OracleCommand cmd = new OracleCommand("Update Department_Detais set  deptName = '" + txtDname.Text + "', deptHead = '" + txtDdepartmenthead.Text + "', deptContact='" + txtDcontact.Text + "', deptFloor='" + txtDfloor.Text + "'" + " where deptId = " + txtDid.Text, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            display();
            clear();



        }

        protected void btnDcancle_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void btnDupdate_Click(object sender, EventArgs e)
        {
            String con;
            con = "User Id = sandeep; Password = admin; Data Source = XE;";
            cn.ConnectionString = con;
            cn.Open();

            OracleCommand cmd = new OracleCommand("Update Department_Detais set  deptName = '" + txtDname.Text + "', deptHead = '" + txtDdepartmenthead.Text + "', deptContact='" + txtDcontact.Text + "', deptFloor='" + txtDfloor.Text + "'"+ " where deptId = " + txtDid.Text , cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            display();
            clear();

        }

        protected void btnDdelete_Click(object sender, EventArgs e)
        {

            String con;
            con = "User ID = sandeep ; Password =  admin; Data Source  =XE;";
            cn.ConnectionString = con;
            cn.Open();

            GridViewRow gvr = GridViewDepartment.SelectedRow;
            OracleCommand cmd = new OracleCommand("delete from Department_Detais where deptId = " + txtDid.Text, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            clear();
            display();
        }
    }
}