using System;
using System.Configuration;
using System.Data.SqlClient;

namespace MoviePlex
{
    public partial class UserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the user is logged in by verifying the presence of the "Username" session variable
                if (Session["Username"] != null)
                {
                    string username = Session["Username"].ToString();

                    // Define your database connection string
                    string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Query to select user data by username
                        string query = "SELECT * FROM Users WHERE Username = @Username";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Username", username);

                            SqlDataReader reader = command.ExecuteReader();

                            if (reader.Read())
                            {
                                lblUserID.Text = reader["UserID"].ToString();
                                lblUsername.Text = reader["Username"].ToString();
                                lblFullName.Text = reader["FullName"].ToString();
                                lblAge.Text = reader["Age"].ToString();
                                txtEmail.Text = reader["Email"].ToString();
                                txtPhoneNumber.Text = reader["PhoneNumber"].ToString();
                            }
                            reader.Close();
                        }
                    }
                }
                else
                {
                    // Handle the case where the user is not logged in
                    Response.Redirect("LoginPage.aspx"); // Redirect to the login page or handle as needed
                }
            }
        }

        // Update button click event
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // Check if the user is logged in
            if (Session["Username"] != null)
            {
                string username = Session["Username"].ToString();
                string email = txtEmail.Text;
                string phoneNumber = txtPhoneNumber.Text;

                // Update user details in the database
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Query to update user details
                    string query = "UPDATE Users SET Email = @Email, PhoneNumber = @PhoneNumber WHERE Username = @Username";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("@Username", username);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Update successful
                            // You can provide feedback to the user, e.g., display a success message
                            Response.Write("Details updated successfully.");
                        }
                        else
                        {
                            // Update failed
                            // You can provide feedback to the user, e.g., display an error message
                            Response.Write("Details update failed.");
                        }
                    }
                }
            }
            else
            {
                // User is not logged in, handle accordingly
                Response.Redirect("LoginPage.aspx");
            }
        }

        // Logout button click event
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear the session
            Session.Clear();

            // Redirect to the login page
            Response.Redirect("LoginPage.aspx");
        }
    }
}
