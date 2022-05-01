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
    public partial class md5_hash_generator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(GeneratedHashString.Text == "")
                {
                    Copy.Visible = false;
                }
                else
                {
                    Copy.Visible = true;
                }
            }
            catch(Exception ex)
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

        protected void GenerateMD5Hash(object sender, EventArgs e)
        {
            try
            {
                if(HashString.Text != "")
                {
                    GeneratedHashString.Text = String.Concat("MD5: ",CreateMD5Hash(HashString.Text));
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
            catch(Exception ex)
            {
                GeneratedHashString.Text = ex.Message;
            }
        }

        public string CreateMD5Hash(string input)
        {
            // Step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }

        protected void PasswordGeneratorURL(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("PasswordsGenerator.aspx");
            }
            catch(Exception ex)
            {

            }
        }
    }
}