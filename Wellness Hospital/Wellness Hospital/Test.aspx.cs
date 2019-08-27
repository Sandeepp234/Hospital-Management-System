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
    public partial class Test : System.Web.UI.Page
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

            OracleCommand cmd = new OracleCommand("Select *  from Tests_Details", cn);
            OracleDataAdapter adp = new OracleDataAdapter(cmd);

            adp.Fill(dt);
            cn.Close();
            GridViewTest.DataSource = dt;
            GridViewTest.DataBind();


        }

        private void clear()
        {
            txtTid.Text = "";
            txtTname.Text = "";
            txtTinvestigated.Text = "";
            txtTdiagnosis.Text = "";
            txtTresult.Text = "";


        }

        protected void GridViewTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gd = GridViewTest.SelectedRow;

            txtTid.Text = gd.Cells[1].Text;
            txtTname.Text = gd.Cells[2].Text;
            txtTinvestigated.Text = gd.Cells[3].Text;
            txtTdiagnosis.Text = gd.Cells[4].Text;
            txtTresult.Text = gd.Cells[5].Text;


        }

        protected void GridViewTest_RowEditing(object sender, GridViewEditEventArgs e)
        {

            String con;
            con = "User Id = sandeep; Password = admin; Data Source = XE;";
            cn.ConnectionString = con;
            cn.Open();

            OracleCommand cmd = new OracleCommand("Update Tests_Details set testName = '" + txtTname.Text + "',  testInvestigated = '" + txtTinvestigated.Text + "', testDetails='" + txtTdiagnosis.Text + "', testRemark='" + txtTresult.Text + "'"+ " where testId = " + txtTid.Text , cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            display();
            clear();

        }

        protected void GridViewTest_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String con;
            con = "User ID = sandeep ; Password =  admin; Data Source  =XE;";
            cn.ConnectionString = con;
            cn.Open();

            GridViewRow gvr = GridViewTest.SelectedRow;
            OracleCommand cmd = new OracleCommand("delete from Tests_Details where testId = " + txtTid.Text, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            clear();
            display();


        }

        protected void btnTsubmit_Click(object sender, EventArgs e)
        {
            String con;
            con = "User ID = sandeep; Password = admin; Data Source=XE;";

            cn.ConnectionString = con;
            cn.Open();

            OracleCommand cmd = new OracleCommand("Insert into Tests_Details values('" + txtTid.Text + "', '" + txtTname.Text + "', '" + txtTinvestigated.Text + "','" + txtTdiagnosis.Text + "','" + txtTresult.Text + "')", cn);

            cmd.ExecuteNonQuery();
            clear();
            cn.Close();

            Response.Write("Data Save Successfully");

            display();
        }

        protected void btnTcancel_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void btnTupdate_Click(object sender, EventArgs e)
        {

            String con;
            con = "User Id = sandeep; Password = admin; Data Source = XE;";
            cn.ConnectionString = con;
            cn.Open();

            OracleCommand cmd = new OracleCommand("Update Tests_Details set testName = '" + txtTname.Text + "',  testInvestigated = '" + txtTinvestigated.Text + "', testDetails='" + txtTdiagnosis.Text + "', testRemark='" + txtTresult.Text + "'" + " where testId = " + txtTid.Text, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            display();
            clear();
        }

        protected void btnTdelete_Click(object sender, EventArgs e)
        {
            String con;
            con = "User ID = sandeep ; Password =  admin; Data Source  =XE;";
            cn.ConnectionString = con;
            cn.Open();

            GridViewRow gvr = GridViewTest.SelectedRow;
            OracleCommand cmd = new OracleCommand("delete from Tests_Details where testId = " + txtTid.Text, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            clear();
            display();

        }
    }
}