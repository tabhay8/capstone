using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoviePlex
{
    public partial class AdminLogin : Page
    {
        protected void SignUp_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; // Replace with your database connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO AdminTable (EmployeeName, EmployeeID, EmployeeEmail, EmployeePassword, EmployeeDesignation) VALUES (@Name, @ID, @Email, @Password, @Designation)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", EmployeeNameTextBox.Text);
                    cmd.Parameters.AddWithValue("@ID", EmployeeIDTextBox.Text);
                    cmd.Parameters.AddWithValue("@Email", EmployeeEmailTextBox.Text);
                    cmd.Parameters.AddWithValue("@Password", EmployeePasswordTextBox.Text);
                    string selectedDesignation = EmployeeDesignationRadioList.SelectedValue;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected void SignIn_Click(object sender, EventArgs e)
        {
            string connectionString = "Your_Connection_String"; // Replace with your database connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT EmployeeID, EmployeePassword, EmployeeDesignation FROM AdminTable WHERE (EmployeeID = @Identifier OR EmployeeEmail = @Identifier) AND EmployeePassword = @Password";
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Identifier", SignInIdentifier.Text);
                    cmd.Parameters.AddWithValue("@Password", SignInPassword.Text);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Retrieve the employee designation from the database
                            string employeeDesignation = reader["EmployeeDesignation"].ToString();

                            // Redirect to the appropriate page based on the designation
                            if (employeeDesignation == "ShowManager")
                            {
                                Response.Redirect("ShowManagerDashboard.aspx");
                            }
                            else if (employeeDesignation == "FoodAndBeveragesManager")
                            {
                                Response.Redirect("FoodManagerPage.aspx");
                            }
                            else
                            {
                                // Handle other designations or display an error message
                                // Example: Response.Redirect("ErrorPage.aspx");
                            }
                        }
                        else
                        {
                            // Display an error message or redirect to an error page
                            // Example: Response.Redirect("ErrorPage.aspx");
                        }
                    }
                }
            }
        }

    }
}
