
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace MovieBooking29
{
    public partial class Profile29 : System.Web.UI.Page
    {
        private string GetConnection29()
        {
            return ConfigurationManager.ConnectionStrings["MovieBookingConnection29"].ConnectionString;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID29"] == null)
            {
                Response.Redirect("Login29.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadProfile29();
            }
        }

        private void LoadProfile29()
        {
            using (SqlConnection con = new SqlConnection(GetConnection29()))
            {
                string query = "SELECT User_Name29, Email_ID29, City29, PhoneNo29 FROM Tbl_User29 WHERE User_ID29 = @UserID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserID", Session["UserID29"]);

                con.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        TxtName29.Text = dr["User_Name29"].ToString();
                        TxtEmail29.Text = dr["Email_ID29"].ToString();
                        TxtCity29.Text = dr["City29"].ToString();
                        TxtPhone29.Text = dr["PhoneNo29"].ToString();
                    }
                    else
                    {
                        Session.Clear();
                        Response.Redirect("Login29.aspx");
                    }
                }
            }
        }

        protected void BtnUpdate29_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            string name = TxtName29.Text.Trim();
            string email = TxtEmail29.Text.Trim();
            string city = TxtCity29.Text.Trim();
            string phone = TxtPhone29.Text.Trim();

            if (!Regex.IsMatch(phone, @"^[0-9]{10,15}$"))
            {
                LblMessage29.Text = "Enter a valid phone number.";
                return;
            }

            using (SqlConnection con = new SqlConnection(GetConnection29()))
            {
                con.Open();

                string checkQuery = "SELECT COUNT(*) FROM Tbl_User29 WHERE Email_ID29 = @Email AND User_ID29 <> @UserID";

                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@Email", email);
                checkCmd.Parameters.AddWithValue("@UserID", Session["UserID29"]);

                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count > 0)
                {
                    LblMessage29.Text = "This email is already registered.";
                    return;
                }

                string query = "UPDATE Tbl_User29 SET User_Name29 = @Name, Email_ID29 = @Email, City29 = @City, PhoneNo29 = @Phone WHERE User_ID29 = @UserID";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@City", city);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@UserID", Session["UserID29"]);

                cmd.ExecuteNonQuery();
            }

            Session["UserName29"] = name;

            LblMessage29.Text = "Profile updated successfully.";
        }
    }
}
