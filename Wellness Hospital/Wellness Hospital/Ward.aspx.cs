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
    public partial class Ward : System.Web.UI.Page
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

            OracleCommand cmd = new OracleCommand("Select *  from Ward_Details", cn);
            OracleDataAdapter adp = new OracleDataAdapter(cmd);

            adp.Fill(dt);
            cn.Close();
            GridViewWard.DataSource = dt;
            GridViewWard.DataBind();
            

        }

        private void clear()
        {
            txtWId.Text = "";
            txtWname.Text = "";
            txtWfloor.Text = "";
            txtWcontact.Text = "";
            txtWwardhead.Text = "";
           

        }

        protected void btnWsubmit_Click1(object sender, EventArgs e)
        {
            String con;
            con = "User ID = sandeep; Password = admin; Data Source=XE;";

            cn.ConnectionString = con;
            cn.Open();

            OracleCommand cmd = new OracleCommand("Insert into Ward_Details values('" + txtWId.Text + "', '" + txtWname.Text + "', '" + txtWfloor.Text + "','" + txtWcontact.Text + "','" + txtWwardhead.Text + "')", cn);

            cmd.ExecuteNonQuery();
            clear();
            cn.Close();

            Response.Write("Data Save Successfully");

            display();
        }

        protected void GridViewWard_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gd = GridViewWard.SelectedRow;

            txtWId.Text = gd.Cells[1].Text;
            txtWname.Text = gd.Cells[2].Text;
            txtWfloor.Text = gd.Cells[3].Text;
            txtWcontact.Text = gd.Cells[4].Text;
            txtWwardhead.Text = gd.Cells[5].Text;
        }

        protected void GridViewWard_RowEditing(object sender, GridViewEditEventArgs e)
        {

            String con;
            con = "User Id = sandeep; Password = admin; Data Source = XE;";
            cn.ConnectionString = con;
            cn.Open();

            OracleCommand cmd = new OracleCommand("Update Ward_Details set  wardName = '" + txtWname.Text + "', wardFloor = '" + txtWfloor.Text + "', wardContact='" + txtWcontact.Text + "', wardHead='" + txtWwardhead.Text + "'"+ " where wardId = " + txtWId.Text , cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            display();
            clear();


        }

        protected void GridViewWard_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String con;
            con = "User ID = sandeep ; Password =  admin; Data Source  =XE;";
            cn.ConnectionString = con;
            cn.Open();

            GridViewRow gvr = GridViewWard.SelectedRow;
            OracleCommand cmd = new OracleCommand("delete from Ward_Details where wardId = " + txtWId.Text, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            clear();
            display();

        }

        protected void btnWcancel_Click(object sender, EventArgs e)
        {
            clear();

        }

        protected void btnWupdate_Click(object sender, EventArgs e)
        {
            String con;
            con = "User Id = sandeep; Password = admin; Data Source = XE;";
            cn.ConnectionString = con;
            cn.Open();

            OracleCommand cmd = new OracleCommand("Update Ward_Details set  wardName = '" + txtWname.Text + "', wardFloor = '" + txtWfloor.Text + "', wardContact='" + txtWcontact.Text + "', wardHead='" + txtWwardhead.Text + "'" + " where wardId = " + txtWId.Text, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            display();
            clear();
        }

        protected void btnWdelete_Click(object sender, EventArgs e)
        {
            String con;
            con = "User ID = sandeep ; Password =  admin; Data Source  =XE;";
            cn.ConnectionString = con;
            cn.Open();

            GridViewRow gvr = GridViewWard.SelectedRow;
            OracleCommand cmd = new OracleCommand("delete from Ward_Details where wardId = " + txtWId.Text, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            clear();
            display();
        }
    }
}