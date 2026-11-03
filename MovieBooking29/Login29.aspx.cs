
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace MovieBooking29
{
    public partial class Login29 : System.Web.UI.Page
    {
        protected void BtnLogin29_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            string email = TxtEmail29.Text.Trim();
            string password = TxtPassword29.Text;

            string cs = ConfigurationManager.ConnectionStrings["MovieBookingConnection29"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT User_ID29, User_Name29, User_password29 FROM Tbl_User29 WHERE Email_ID29 = @Email";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", email);

                con.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        string storedPassword = dr["User_password29"].ToString();
                        string[] parts = storedPassword.Split(':');

                        if (parts.Length == 2)
                        {
                            byte[] salt = Convert.FromBase64String(parts[0]);
                            byte[] storedHash = Convert.FromBase64String(parts[1]);

                            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
                            {
                                byte[] enteredHash = pbkdf2.GetBytes(32);

                                if (CompareHashes29(enteredHash, storedHash))
                                {
                                    Session["UserID29"] = dr["User_ID29"];
                                    Session["UserName29"] = dr["User_Name29"].ToString();

                                    Response.Redirect("Default29.aspx");
                                    return;
                                }
                            }
                        }
                    }
                }
            }

            LblMessage29.Text = "Invalid email or password.";
        }

        private bool CompareHashes29(byte[] first, byte[] second)
        {
            if (first.Length != second.Length)
                return false;

            int difference = 0;

            for (int i = 0; i < first.Length; i++)
            {
                difference |= first[i] ^ second[i];
            }

            return difference == 0;
        }
    }
}
