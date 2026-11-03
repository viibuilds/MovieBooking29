
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace MovieBooking29
{
    public partial class Register29 : System.Web.UI.Page
    {
        protected void BtnRegister29_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            string name = TxtName29.Text.Trim();
            string email = TxtEmail29.Text.Trim();
            string password = TxtPassword29.Text;
            string city = TxtCity29.Text.Trim();
            string phone = TxtPhone29.Text.Trim();

            if (password.Length < 8)
            {
                LblMessage29.Text = "Password must contain at least 8 characters.";
                return;
            }

            if (!Regex.IsMatch(phone, @"^[0-9]{10,15}$"))
            {
                LblMessage29.Text = "Enter a valid phone number.";
                return;
            }

            byte[] salt = new byte[16];

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string passwordHash;

            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                byte[] hash = pbkdf2.GetBytes(32);
                passwordHash = Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);
            }

            string cs = ConfigurationManager.ConnectionStrings["MovieBookingConnection29"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                string checkQuery = "SELECT COUNT(*) FROM Tbl_User29 WHERE Email_ID29 = @Email";

                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@Email", email);

                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count > 0)
                {
                    LblMessage29.Text = "Email already registered.";
                    return;
                }

                string query = "INSERT INTO Tbl_User29 (User_Name29, Email_ID29, User_password29, City29, PhoneNo29) VALUES (@Name, @Email, @Password, @City, @Phone)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", passwordHash);
                cmd.Parameters.AddWithValue("@City", city);
                cmd.Parameters.AddWithValue("@Phone", phone);

                cmd.ExecuteNonQuery();
            }

            LblMessage29.Text = "Registration successful!";

            TxtName29.Text = "";
            TxtEmail29.Text = "";
            TxtPassword29.Text = "";
            TxtCity29.Text = "";
            TxtPhone29.Text = "";
        }
    }
}
