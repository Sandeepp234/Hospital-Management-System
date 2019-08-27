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
    public partial class Shedule : System.Web.UI.Page
    {
        
        private OracleConnection conn = new OracleConnection("User Id=sandeep;Password=admin; Data Source=XE;");
        private OracleCommand cmd = null;
        private DataTable dt = new DataTable();
        private OracleDataAdapter adapter;
        private OracleDataReader reader;

        protected void Page_Load(object sender, EventArgs e)
        {
            refresh();
            txtSdoctorname.ReadOnly = true;
            txtSpatientname.ReadOnly = true;
        }

        public void refresh()
        {
            conn.Open();
            cmd = new OracleCommand("Select * from Schedule_Details", conn);
            adapter = new OracleDataAdapter(cmd);
            adapter.Fill(dt);
            GridViewSchedule.DataSource = dt;
            GridViewSchedule.DataBind();
            conn.Close();


        }

        //Clearing the texboxes of the text
        private void Clear()
        {
            txtsheduleid.Text = "";
            txtSdoctorid.Text = "";
            txtSdoctorname.Text = "";
            txtSpatientid.Text = "";
            txtSpatientname.Text = "";
            txtStime.Text = "";
            txtSdate.Text = "";
        }

        protected void GridViewSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gd = GridViewSchedule.SelectedRow;
            txtsheduleid.Text = gd.Cells[1].Text;
            txtSdoctorid.Text = gd.Cells[2].Text;
            txtSdoctorname.Text = gd.Cells[3].Text;
            txtSpatientid.Text = gd.Cells[4].Text;
            txtSpatientname.Text = gd.Cells[5].Text;
            txtStime.Text = gd.Cells[6].Text;
            txtSdate.Text = gd.Cells[7].Text;

        }

        protected void GridViewSchedule_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                conn.Open();
                cmd = new OracleCommand("Update Schedule_Details set scheduleId='" + txtsheduleid.Text + "',doctorId='" + txtSdoctorid.Text + "',doctorName='" + txtSdoctorname.Text + "', patientId='" + txtSpatientid.Text + "',patientName='" + txtSpatientname.Text + "', scheduleTime='" + txtStime.Text + "', scheduleDate ='" +txtSdate+"'", conn);
                cmd.ExecuteNonQuery();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data updated successfully')", true);
                conn.Close();
                refresh();
                Response.Redirect("Shedule.aspx");
            }

            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Update failed')", true);
            }

        }



        protected void btnSsubmit_Click(object sender, EventArgs e)
        {

            try
            {
                conn.Open();
                cmd = new OracleCommand("Insert into Schedule_Details (scheduleId,doctorId,doctorName,patientId,patientName,scheduleTime,scheduleDate) values ('" + txtsheduleid.Text + "','" + txtSdoctorid.Text + "','" + txtSdoctorname.Text + "','" + txtSpatientid.Text + "','" + txtSpatientname.Text + "','" + txtStime.Text + "','"+ txtSdate.Text + "')", conn);
            
                cmd.ExecuteNonQuery();
                conn.Close();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data added successfully')", true);
                refresh();
                Clear();
                Response.Redirect("Shedule.aspx");
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Insert data correctly')", true);
            }


        }

        protected void txtSdoctorid_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new OracleCommand("Select doctorName from Doctor_Details where doctorId='" + txtSdoctorid.Text + "'", conn);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtSdoctorname.Text = reader["doctorName"].ToString();
                reader.Close();
                conn.Close();

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('There is no data of doctor id '" + txtSdoctorid.Text + "' in the doctor record')", true);
                txtSdoctorname.Text = "";
                txtSdoctorid.Text = "";
            }

        }

        protected void txtSpatientid_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new OracleCommand("Select patientName from Patients_Details where patientId='" + txtSpatientid.Text + "'", conn);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtSpatientname.Text = reader["patientName"].ToString();
                reader.Close();
                conn.Close();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('Patient name of " + txtSpatientname.Text + " is not registered in patient record.')", true);
                txtSpatientid.Text = "";
                txtSpatientname.Text = "";
            }
        }

        protected void btnSupdate_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                cmd = new OracleCommand("Update Schedule_Details set doctorId='" + txtSdoctorid.Text + "',doctorName='" + txtSdoctorname.Text + "', patientId='" + txtSpatientid.Text + "',patientName='" + txtSpatientname.Text + "', scheduleTime='" + txtStime.Text + "', scheduleDate ='" + txtSdate.Text + "'"+ " where scheduleId= " + txtsheduleid.Text, conn);
                cmd.ExecuteNonQuery();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data updated successfully')", true);
                conn.Close();
                refresh();
                Response.Redirect(" Shedule.aspx");
            }

            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Update failed')", true);
            }
        }

        protected void btnSdelete_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                cmd = new OracleCommand("Delete from Schedule_Details where scheduleId ='" + txtsheduleid.Text + "'", conn);
                cmd.ExecuteNonQuery();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data Deleted')", true);
                conn.Close();
                refresh();
                Response.Redirect("Shedule.aspx");
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No data to delete')", true);
            }


        }

        protected void btnSsearch_Click(object sender, EventArgs e)
        {
            GridViewSearch.Visible = true;

            //to display data on gridview
            DataTable dt = new DataTable();

            String con;
            con = "User Id = sandeep; Password=admin; Data source = XE";
            conn.ConnectionString = con;
            conn.Open();


            string query = "Select * from Schedule_Details where scheduleId like '" + txtSsearch.Text + "'";
            OracleCommand comd = new OracleCommand(query, conn);
            OracleDataAdapter adapter = new OracleDataAdapter(comd);
            adapter.Fill(dt);

            GridViewSearch.DataSource = dt;
            GridViewSearch.DataBind();

            conn.Close();
        }
        /*
       protected void btnSsearch_Click(object sender, EventArgs e)
       {
           GridViewSearch.Visible = true;

           //to display data on gridview
           DataTable dt = new DataTable();

        String con;
           con = "User Id = sandeep; Password=admin; Data source = XE";
           conn.ConnectionString = con;
           conn.Open();


           string query = "Select * from Schedule_Details where scheduleId like '" + txtsheduleid.Text + "'";
           OracleCommand comd = new OracleCommand(query, conn);
           OracleDataAdapter adapter = new OracleDataAdapter(comd);
           adapter.Fill(dt);

           GridViewSearch.DataSource = dt;
           GridViewSearch.DataBind();

           conn.Close();

       }
       */
    }
}