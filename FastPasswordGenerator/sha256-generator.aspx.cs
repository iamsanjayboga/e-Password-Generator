using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FastPasswordGenerator
{
    public partial class sha256_generator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (GeneratedHashString.Text == "")
                {
                    Copy.Visible = false;
                }
                else
                {
                    Copy.Visible = true;
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void copypassowrd(object sender, EventArgs e)
        {
            try
            {
                if (GeneratedHashString.Text != "")
                {
                    Copy.Text = "Copied!!";
                    Copy.BackColor = Color.Gray;
                }
                else
                {
                    //ErrorMsg.Text = "Please generate password to copy";
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void GenerateSHA256Hash(object sender, EventArgs e)
        {
            try
            {
                if (HashString.Text != "")
                {
                    string hash = CreateSHA256Hash(HashString.Text).ToUpper();
                    var input = hash;
                    var regex = new Regex(@".{50}");
                    string result = regex.Replace(input, "$&" + Environment.NewLine);
                    GeneratedHashString.Text = String.Concat("SHA-256: ", result);

                    //GeneratedHashString.Text = String.Concat("SHA-256: ", CreateSHA256Hash(HashString.Text).ToUpper());
                    GeneratedHashString.Font.Bold = true;


                    GeneratedHashString.Visible = true;
                    Copy.Visible = true;

                    HashString.BorderColor = System.Drawing.Color.Black;
                    Copy.Text = "Copy";
                    Color blue = Color.FromArgb(3, 133, 183);
                    Copy.BackColor = blue;
                    //ErrorMsg.Visible = false;
                }
                else
                {
                    //ErrorMsg.Text = "Please enter string to generate hash";
                    HashString.BorderColor = System.Drawing.Color.Red;
                    GeneratedHashString.Visible = false;
                    Copy.Visible = false;
                }

            }
            catch (Exception ex)
            {
                GeneratedHashString.Text = ex.Message;
            }
        }

        public string CreateSHA256Hash(string input)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}