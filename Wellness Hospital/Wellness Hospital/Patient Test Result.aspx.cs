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
    public partial class Patient_Test_Result : System.Web.UI.Page
    {
        private OracleConnection conn = new OracleConnection("User Id=sandeep;Password=admin; Data Source=XE;");
        private OracleCommand cmd = null;
        private DataTable dt = new DataTable();
        private OracleDataAdapter adapter;
        private OracleDataReader reader;

        //Refreshing of the dataGrid

        protected void Page_Load(object sender, EventArgs e)
        {
            refresh();
            txtPTpatientname.ReadOnly = true;
            txtPTestname.ReadOnly = true;

        }

        private void refresh()
        {
            conn.Open();
            cmd = new OracleCommand("Select * from Patient_TestDetails", conn);
            adapter = new OracleDataAdapter(cmd);
            adapter.Fill(dt);
            GridViewPatientTest.DataSource = dt;
            GridViewPatientTest.DataBind();
            conn.Close();


        }
       
        //Clearing the texboxes of the text
        private void Clear()
        {
            txtPTid.Text = "";
            txtPTpatientid.Text = "";
            txtPTpatientname.Text = "";
            txtPTtestid.Text = "";
            txtPTestname.Text = "";
            txtPTremark.Text = "";
        }
        
        //Selecting of the data in the textbox
        protected void GridViewPatientTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gd = GridViewPatientTest.SelectedRow;
            txtPTid.Text = gd.Cells[1].Text;
            txtPTpatientid.Text = gd.Cells[2].Text;
            txtPTpatientname.Text = gd.Cells[3].Text;
            txtPTtestid.Text = gd.Cells[4].Text;
            txtPTestname.Text = gd.Cells[5].Text;
            txtPTremark.Text = gd.Cells[6].Text;
        }

        //Deleting of the data
        protected void GridViewPatientTest_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            try
            {
                conn.Open();
                cmd = new OracleCommand("Delete from Patient_TestDetails where ptestdetailsId ='" + txtPTid.Text + "'", conn);
                cmd.ExecuteNonQuery();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data Deleted')", true);
                conn.Close();
                refresh();
                Response.Redirect("Patient Test Result.aspx");
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No data to delete')", true);
            }

        }

        //Editing of the data

        protected void GridViewPatientTest_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                conn.Open();
                cmd = new OracleCommand("Update Patient_TestDetails set ptestdetailsId='" + txtPTid.Text + "',patientId='" + txtPTpatientid.Text + "',patientName='" + txtPTpatientname.Text + "', testId='" + txtPTtestid.Text + "',testName='" + txtPTestname.Text + "', testRemark='" + txtPTremark.Text + "'", conn);
                cmd.ExecuteNonQuery();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data updated successfully')", true);
                conn.Close();
                refresh();
                Response.Redirect("Patient Test Result.aspx");
            }

            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Update failed')", true);
            }

        }
        //inserting data into the database
        protected void btnPTsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                cmd = new OracleCommand("Insert into Patient_TestDetails (ptestdetailsId,patientId,patientName,testId,testName,testRemark) values ('" + txtPTid.Text + "','" + txtPTpatientid.Text + "','" + txtPTpatientname.Text + "','" + txtPTtestid.Text + "','" + txtPTestname.Text + "','" + txtPTremark.Text + "')", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data added successfully')", true);
                refresh();
                Clear();
                Response.Redirect("Patient Test Result.aspx");
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Insert data correctly')", true);
            }
        }

        protected void txtPTpatientid_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new OracleCommand("Select patientName from Patients_Details where patientId='" + txtPTpatientid.Text + "'", conn);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtPTpatientname.Text = reader["patientName"].ToString();
                reader.Close();
                conn.Close();

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('There is no data of patient id '" + txtPTpatientid.Text + "' in the patinet record')", true);
                txtPTpatientname.Text = "";
                txtPTpatientid.Text = "";
            }
        }

        protected void txtPTtestid_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new OracleCommand("Select testName from Tests_Details where testId='" + txtPTtestid.Text + "'", conn);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtPTestname.Text = reader["testName"].ToString();
                reader.Close();
                conn.Close();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('Test name of " + txtPTtestid.Text + " is not registered in test record.')", true);
                txtPTtestid.Text = "";
                txtPTestname.Text = "";
            }
        }
        //updating the data in database
        protected void btnPTupdate_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                cmd = new OracleCommand("Update Patient_TestDetails set patientId='" + txtPTpatientid.Text + "',patientName='" + txtPTpatientname.Text + "', testId='" + txtPTtestid.Text + "',testName='" + txtPTestname.Text + "', testRemark='" + txtPTremark.Text + "'" + " where ptestdetailsId=" + txtPTid.Text, conn);
                cmd.ExecuteNonQuery();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data updated successfully')", true);
                conn.Close();
                refresh();
                Response.Redirect("Patient Test Result.aspx");
            }

            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Update failed')", true);
            }
        }

        protected void btnPPcancle_Click(object sender, EventArgs e)
        {

                Clear();
        }

        //deleting the data from database
        protected void btnPTdelete_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                cmd = new OracleCommand("Delete from Patient_TestDetails where ptestdetailsId ='" + txtPTid.Text + "'", conn);
                cmd.ExecuteNonQuery();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data Deleted')", true);
                conn.Close();
                refresh();

                Response.Redirect("Patient Test Result.aspx");
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No data to delete')", true);
            }
        }

       

        protected void btnPTsearch1_Click(object sender, EventArgs e)
        {
            GridViewSearch1.Visible = true;

            //to display data on gridview
            DataTable dt = new DataTable();

            String con;
            con = "User Id = sandeep; Password=admin; Data source = XE";
            conn.ConnectionString = con;
            conn.Open();


            string query = "Select * from Patient_TestDetails where ptestdetailsId like '" + txtPTestsearch1.Text + "'";
            OracleCommand comd = new OracleCommand(query, conn);
            OracleDataAdapter adapter = new OracleDataAdapter(comd);
            adapter.Fill(dt);

            GridViewSearch1.DataSource = dt;
            GridViewSearch1.DataBind();

            conn.Close();
        }
    }


}
