using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FastPasswordGenerator
{
    public partial class sha1_generator : System.Web.UI.Page
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

        protected void GenerateSHA1Hash(object sender, EventArgs e)
        {
            try
            {
                if (HashString.Text != "")
                {
                    GeneratedHashString.Text = String.Concat("SHA-1: ", CreateSHA1Hash(HashString.Text));
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

        public string CreateSHA1Hash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }


    }
}