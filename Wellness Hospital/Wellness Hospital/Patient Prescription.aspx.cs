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
    public partial class Patient_Prescription : System.Web.UI.Page
    {
        private OracleConnection conn = new OracleConnection("User Id=sandeep;Password=admin; Data Source=XE;");
        private OracleCommand cmd = null;
        private DataTable dt = new DataTable();
        private OracleDataAdapter adapter;
        private OracleDataReader reader;


        protected void Page_Load(object sender, EventArgs e)

        {
            refresh();
            txtPPdoctorName.ReadOnly = true;
            txtPPpatientname.ReadOnly = true;
            txtPPtestName.ReadOnly = true;

        }

        private void refresh()
        {
            conn.Open();
            cmd = new OracleCommand("Select * from Patient_Prescription", conn);
            adapter = new OracleDataAdapter(cmd);
            adapter.Fill(dt);
            GridViewPrescription.DataSource = dt;
            GridViewPrescription.DataBind();
            conn.Close();


        }

        // clearing the data from the textbox
        private void Clear()
        {

            txtPPid.Text = "";
            txtPPpatientid.Text = "";
            txtPPpatientname.Text = "";
            txtPPdoctorId.Text = "";
            txtPPdoctorName.Text = "";
            txtPPtestId.Text = "";
            txtPPtestName.Text = "";
            txtPPobservation.Text = "";
        }

        //Selecting the data in the textbox 

        protected void GridViewPrescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gd = GridViewPrescription.SelectedRow;
            txtPPid.Text = gd.Cells[1].Text;
            txtPPpatientid.Text = gd.Cells[2].Text;
            txtPPpatientname.Text = gd.Cells[3].Text;
            txtPPdoctorId.Text = gd.Cells[4].Text;
            txtPPdoctorName.Text = gd.Cells[5].Text;
            txtPPtestId.Text = gd.Cells[6].Text;
            txtPPtestName.Text = gd.Cells[7].Text;
            txtPPobservation.Text = gd.Cells[8].Text;
            txtgender.Text = gd.Cells[9].Text;
            txtPPage.Text = gd.Cells[10].Text;
            txtPPmedicine.Text = gd.Cells[11].Text;
            
           
        }

        protected void txtPPpatientid_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new OracleCommand("Select patientName from Patients_Details where patientId='" + txtPPpatientid.Text + "'", conn);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtPPpatientname.Text = reader["patientName"].ToString();
                reader.Close();
                conn.Close();

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('There is no data of patient id '" + txtPPpatientid.Text + "' in the patinet record')", true);
                txtPPpatientname.Text = "";
                txtPPpatientid.Text = "";
            }


        }

        protected void txtPPdoctorId_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new OracleCommand("Select doctorName from Doctor_Details where doctorId='" + txtPPdoctorId.Text + "'", conn);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtPPdoctorName.Text = reader["doctorName"].ToString();
                reader.Close();
                conn.Close();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('Doctor name of " + txtPPdoctorId.Text + " is not registered in doctor record.')", true);
                txtPPdoctorId.Text = "";
                txtPPdoctorName.Text = "";
            }



        }

        protected void txtPPtestId_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new OracleCommand("Select testName from Tests_Details where testId='" + txtPPtestId.Text + "'", conn);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtPPtestName.Text = reader["testName"].ToString();
                reader.Close();
                conn.Close();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('Test name of " + txtPPtestId.Text + " is not registered in test record.')", true);
                txtPPtestId.Text = "";
                txtPPtestName.Text = "";
            }
        }
        //Inserting the data from the database
        protected void btnPPsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                cmd = new OracleCommand("Insert into Patient_Prescription (prescriptionId,patientId,patientName,doctorId,doctorName,testId,testName,observation,patientGender,prescripedMedicine,appoitmentDate) values ('" + txtPPid.Text + "','" + txtPPpatientid.Text + "','" + txtPPpatientname.Text + "','" + txtPPdoctorId.Text + "','" + txtPPdoctorName.Text + "','" + txtPPtestId.Text + "','" +txtPPtestName.Text+"', '" +txtPPobservation.Text+"','" +txtgender.Text+"','" +txtPPmedicine.Text+"','"+txtPPdatee.Text+"')", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data added successfully')", true);
                refresh();
                Clear();
                Response.Redirect("Patient Prescription.aspx");
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Insert data correctly')", true);
            }
        }
        //Updating the data from the database
        protected void btnPPUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                cmd = new OracleCommand("Update Patient_Prescription set  patientId='" + txtPPpatientid.Text + "',patientName='" + txtPPpatientname.Text + "', doctorId='" + txtPPdoctorId.Text + "',doctorName='" + txtPPdoctorName.Text + "',testId='" + txtPPtestId.Text + "',testName='" + txtPPtestName.Text + "', observation='" + txtPPobservation.Text + "', patientGender ='" + txtgender.Text + "', prescripedMedicine ='" + txtPPmedicine.Text + "', appoitmentDate='" + txtPPdatee.Text + "'" + "  where prescriptionId= " + txtPPid.Text, conn);
                cmd.ExecuteNonQuery();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data updated successfully')", true);
                conn.Close();
                refresh();
                Response.Redirect("Patient Prescription.aspx");

            }

            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Update failed')", true);
            }
        }

        //Deletiing the data from the databse

        protected void btnPPdelete_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                cmd = new OracleCommand("Delete from Patient_Prescription where prescriptionId ='" + txtPPid.Text + "'", conn);
                cmd.ExecuteNonQuery();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data Deleted')", true);
                conn.Close();
                refresh();
                Response.Redirect("Patient Prescription.aspx");
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No data to delete')", true);
            }

        }
        //Clearing the data from the textbox
        protected void btnPPcancle_Click(object sender, EventArgs e)
        {
            Clear();
        }
        //Deleting of the database
        protected void GridViewPrescription_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                conn.Open();
                cmd = new OracleCommand("Delete from Patient_Prescription where prescriptionId ='" + txtPPid.Text + "'", conn);
                cmd.ExecuteNonQuery();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data Deleted')", true);
                conn.Close();
                refresh();
                Response.Redirect("Patient Prescription.aspx");
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No data to delete')", true);
            }

        }
        //Editing of the database
        protected void GridViewPrescription_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                conn.Open();
                cmd = new OracleCommand("Update Patient_Prescription set  patientId='" + txtPPpatientid.Text + "',patientName='" + txtPPpatientname.Text + "', doctorId='" + txtPPdoctorId.Text + "',doctorName='" + txtPPdoctorName.Text + "',testId='" + txtPPtestId.Text + "',testName='" + txtPPtestName.Text + "', observation='" + txtPPobservation.Text + "', patientGender ='" + txtgender.Text + "', prescripedMedicine ='" + txtPPmedicine.Text + "', appoitmentDate='" + txtPPdatee.Text + "'" + "  where prescriptionId= " + txtPPid.Text, conn);
                cmd.ExecuteNonQuery();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data updated successfully')", true);
                conn.Close();
                refresh();
                Response.Redirect("Patient Prescription.aspx");

            }

            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Update failed')", true);
            }
        }


     


        protected void searchbtn_Click(object sender, EventArgs e)
        {
            GridViewsearch.Visible = true;

            //to display data on gridview
            DataTable dt = new DataTable();

            String con;
            con = "User Id = sandeep; Password=admin; Data source = XE";
            conn.ConnectionString = con;
            conn.Open();


            string query = "Select * from Patient_Prescription where prescriptionId like '" + searchtxt.Text + "'";
            OracleCommand comd = new OracleCommand(query, conn);
            OracleDataAdapter adapter = new OracleDataAdapter(comd);
            adapter.Fill(dt);

            GridViewsearch.DataSource = dt;
            GridViewsearch.DataBind();

            conn.Close();
        }
    }
}