using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;

namespace MoviePlex
{
    public partial class Loginpage : Page
    {
        protected void SignUp_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;
            string fullName = FullNameTextBox.Text;
            string age = AgeTextBox.Text;
            string email = EmailTextBox.Text;
            string phoneNumber = PhoneNumberTextBox.Text;

            // Validate age (should be a number between 12 and 120)
            if (!int.TryParse(age, out int ageValue) || ageValue < 12 || ageValue > 120)
            {
                Response.Write("Invalid age. Please enter a number between 12 and 120.");
                return; // Stop further processing
            }

            // Validate password (alphanumeric with 8 to 15 characters)
            if (!IsPasswordValid(password))
            {
                Response.Write("Invalid password. Password should be alphanumeric with 8 to 15 characters.");
                return; // Stop further processing
            }

            // Validate phone number (Canadian format)
            if (!IsCanadianPhoneNumber(phoneNumber))
            {
                Response.Write("Invalid phone number. Please enter a Canadian format phone number.");
                return; // Stop further processing
            }

            // Validate email pattern
            if (!IsEmailValid(email))
            {
                Response.Write("Invalid email address. Please enter a valid email.");
                return; // Stop further processing
            }

            // Hash the password
            string hashedPassword = HashPassword(password); // Implement HashPassword method

            // Check if the username already exists in the database
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string checkUsernameQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                using (SqlCommand checkCommand = new SqlCommand(checkUsernameQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@Username", username);
                    int existingUserCount = (int)checkCommand.ExecuteScalar();

                    if (existingUserCount > 0)
                    {
                        // Username already exists, inform the user
                        // You can display an error message or handle it as needed
                        Response.Write("Username already exists. Please choose another username.");
                    }
                    else
                    {
                        // Username doesn't exist, proceed with user creation
                        string insertQuery = "INSERT INTO Users (Username, Password, FullName, Age, Email, PhoneNumber) " +
                            "VALUES (@Username, @Password, @FullName, @Age, @Email, @PhoneNumber)";

                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Username", username);
                            command.Parameters.AddWithValue("@Password", hashedPassword);
                            command.Parameters.AddWithValue("@FullName", fullName);
                            command.Parameters.AddWithValue("@Age", age);
                            command.Parameters.AddWithValue("@Email", email);
                            command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                Response.Write("User created successfully.");
                                // Optionally, you can redirect the user to a login page or perform any other necessary actions.
                            }
                            else
                            {
                                Response.Write("User creation failed.");
                            }
                        }
                    }
                }
            }
        }
        private bool IsPasswordValid(string password)
        {

            return System.Text.RegularExpressions.Regex.IsMatch(password, @"^[a-zA-Z0-9]{8,15}$");
        }

        // Validate Canadian phone number format
        private bool IsCanadianPhoneNumber(string phoneNumber)
        {

            return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"\+\d{1,3}-\d{3}-\d{3}-\d{4}");
        }
        // Validate email pattern
        private bool IsEmailValid(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(email, @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,7}\b");
        }


        // Implement the HashPassword function here
        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
        protected void SignIn_Click(object sender, EventArgs e)
        {


            string signInIdentifier = SignInIdentifier.Text; // This can be either username or email
            string password = SignInPassword.Text;

            // Validate the user's credentials against the database
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT Username, Password FROM Users WHERE (Username = @SignInIdentifier OR Email = @SignInIdentifier)";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@SignInIdentifier", signInIdentifier);

                    // Retrieve the hashed password and username from the database
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string hashedPasswordFromDatabase = reader["Password"].ToString();
                        string username = reader["Username"].ToString();

                        // Hash the provided password for comparison
                        string hashedPasswordToCheck = HashPassword(password);

                        // Compare hashedPasswordToCheck with hashedPasswordFromDatabase
                        if (hashedPasswordToCheck == hashedPasswordFromDatabase)
                        {
                            // Successful login
                            // Store the username in a session
                            Session["Username"] = username;

                            // You can redirect to the user's profile or dashboard.
                            Response.Write("Successful login.");
                            Response.Redirect("BookingPage.aspx");
                        }
                        else
                        {
                            // Invalid credentials
                            // You can display an error message to the user or handle the failure in another way.
                            Response.Write("Invalid credentials. Please try again.");
                        }
                    }
                    else
                    {
                        // Username or email not found in the database
                        Response.Write("User not found.");
                    }
                }
            }
        }


    }
}