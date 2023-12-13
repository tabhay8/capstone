using System;
using System.Data.SqlClient;
using System.Configuration;

namespace MoviePlex
{
    public partial class career : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Page load logic (if any)
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            // Get values from form controls
            string fullName = txtName.Text;
            string email = txtEmail.Text;
            string selectedJobTitle = ddlJobTitle.SelectedValue;
            int yearsOfExperience = Convert.ToInt32(txtExperience.Text);
            string coverLetter = txtCoverLetter.Text;

            // Save application data to the database
            SaveApplicationToDatabase(fullName, email, selectedJobTitle, yearsOfExperience, coverLetter);

            // You can add additional logic here, such as displaying a success message or redirecting to another page.
        }

        private void SaveApplicationToDatabase(string fullName, string email, string selectedJobTitle, int yearsOfExperience, string coverLetter)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Applications (FullName, Email, SelectedJobTitle, YearsOfExperience, CoverLetter, ApplicationDate) " +
                                   "VALUES (@FullName, @Email, @SelectedJobTitle, @YearsOfExperience, @CoverLetter, GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@SelectedJobTitle", selectedJobTitle);
                        cmd.Parameters.AddWithValue("@YearsOfExperience", yearsOfExperience);
                        cmd.Parameters.AddWithValue("@CoverLetter", coverLetter);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or display the exception message for debugging
                Response.Write($"Error: {ex.Message}");
            }
        }
    }
}
