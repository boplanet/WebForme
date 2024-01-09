using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebForme
{
    public partial class Registracija : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (IsUsernameAvailable(username))
            {
                if (SaveUserToDatabase(username, fullName, password))
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    lblMessage.Text = "Došlo je do problema prilikom registracije. Molimo pokušajte ponovno.";
                }
            }
            else
            {
                lblMessage.Text = "Korisničko ime već postoji. Molimo odaberite drugo korisničko ime.";
            }
        }

        private bool IsUsernameAvailable(string username)
        {
            return !CheckIfUsernameExistsInDatabase(username);
        }

        private bool CheckIfUsernameExistsInDatabase(string username)
        {

            string connectionString = "Data Source=RAZNO\\SQLEXPRESSPIN;Initial Catalog=WebFormsLabos;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        private bool SaveUserToDatabase(string username, string fullName, string password)
        {

            string connectionString = "Data Source=RAZNO\\SQLEXPRESSPIN;Initial Catalog=WebFormsLabos;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Users (Username, FullName, Password) VALUES (@Username, @FullName, @Password)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@FullName", fullName);
                    command.Parameters.AddWithValue("@Password", password);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}
