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
                    cmd.Parameters.AddWithValue("@Designation", selectedDesignation); // Add this line

                    cmd.ExecuteNonQuery();
                }
            }
        }


        protected void SignIn_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Determine if the identifier is numeric (EmployeeID) or not (EmployeeEmail)
                bool isNumeric = int.TryParse(SignInIdentifier.Text, out _);
                string identifierColumn = isNumeric ? "EmployeeID" : "EmployeeEmail";

                string selectQuery = $"SELECT EmployeeID, EmployeePassword, EmployeeDesignation FROM AdminTable WHERE ({identifierColumn} = @Identifier)";

                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Identifier", SignInIdentifier.Text);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Retrieve the stored password from the database
                            string storedPassword = reader["EmployeePassword"].ToString();

                            // Check if the entered password matches the stored password
                            if (SignInPassword.Text == storedPassword)
                            {
                                // Password is correct
                                string employeeDesignation = reader["EmployeeDesignation"].ToString();

                                // Redirect to the appropriate page based on the designation
                                if (employeeDesignation == "ShowManager" )
                                {
                                    Response.Redirect("AdminDashboard.aspx");
                                }
                                else if( employeeDesignation == "FoodAndBeveragesManager")
                                {
                                    Response.Redirect("FoodAdmin.aspx");
                                }
                            }
                            else
                            {
                                // Incorrect password
                                Response.Write("Incorrect password. Please try again.");
                            }
                        }
                        else
                        {
                            // No user found with the provided identifier
                            Response.Write("User not found. Please check your credentials.");
                        }
                    }
                }
            }
        }



    }
}
