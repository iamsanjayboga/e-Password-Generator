using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace FastPasswordGenerator
{
    public partial class PasswordsGenerator : System.Web.UI.Page
    {
        private static Random random = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    if (PasswordTypeDropDown.Text == "Weak")
                    {
                        ListItem[] weakitems = new ListItem[10];
                        weakitems[0] = new ListItem("6", "6");
                        weakitems[1] = new ListItem("7", "7");
                        weakitems[2] = new ListItem("8", "8");
                        weakitems[3] = new ListItem("9", "9");
                        weakitems[4] = new ListItem("10", "10");
                        weakitems[5] = new ListItem("11", "11");
                        weakitems[6] = new ListItem("12", "12");
                        weakitems[7] = new ListItem("13", "13");
                        weakitems[8] = new ListItem("14", "14");
                        weakitems[9] = new ListItem("15", "15");

                        PasswordLengthDropDown.Items.Clear();
                        PasswordLengthDropDown.Items.AddRange(weakitems);
                        PasswordLengthDropDown.DataBind();
                    }
                }




                //if (PasswordTypeDropDown.Text == "Weak")
                //{
                //    for (int i = 0; i < 10; i++)
                //    {
                //        weakitems[i] = new ListItem((i + 6).ToString(), (i + 1).ToString());
                //    }
                //    PasswordLengthDropDown.Items.Clear();
                //    PasswordLengthDropDown.Items.AddRange(weakitems);
                //    PasswordLengthDropDown.DataBind();

                //}
            }
            catch (Exception ex)
            {

            }
        }

        protected void PassWordLenght(object sender, EventArgs e)
        {
            try
            {
                ListItem[] weakitems = new ListItem[10];
                ListItem[] strongitems = new ListItem[113];
                ListItem[] Extremestrongitems = new ListItem[4];

                if (PasswordTypeDropDown.Text == "Weak")
                {
                    //for(int i = 0; i < 10; i++)
                    //{
                    //    weakitems[i] = new ListItem((i+6).ToString(), (i + 6).ToString());
                    //}
                    weakitems[0] = new ListItem("6", "6");
                    weakitems[1] = new ListItem("7", "7");
                    weakitems[2] = new ListItem("8", "8");
                    weakitems[3] = new ListItem("9", "9");
                    weakitems[4] = new ListItem("10", "10");
                    weakitems[5] = new ListItem("11", "11");
                    weakitems[6] = new ListItem("12", "12");
                    weakitems[7] = new ListItem("13", "13");
                    weakitems[8] = new ListItem("14", "14");
                    weakitems[9] = new ListItem("15", "15");

                    PasswordLengthDropDown.Items.Clear();
                    PasswordLengthDropDown.Items.AddRange(weakitems);
                    PasswordLengthDropDown.DataBind();

                }
                else if (PasswordTypeDropDown.Text == "Strong")
                {
                    for (int i = 0; i <= 112; i++)
                    {
                        strongitems[i] = new ListItem((i + 16).ToString(), (i + 16).ToString());
                    }
                    PasswordLengthDropDown.Items.Clear();
                    PasswordLengthDropDown.Items.AddRange(strongitems);
                    PasswordLengthDropDown.DataBind();

                }
                else if (PasswordTypeDropDown.Text == "Extreme Strong")
                {
                    Extremestrongitems[0] = new ListItem("256", "256");
                    Extremestrongitems[1] = new ListItem("512", "512");
                    Extremestrongitems[2] = new ListItem("1024", "1024");
                    Extremestrongitems[3] = new ListItem("2048", "2048");

                    PasswordLengthDropDown.Items.Clear();
                    PasswordLengthDropDown.Items.AddRange(Extremestrongitems);
                    PasswordLengthDropDown.DataBind();

                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void DisableNumberSymbols(object sender, EventArgs e)
        {
            try
            {
                if (ETSCB.Checked)
                {
                    IncludeSymbolsCB.Enabled = false;
                    IncludeSymbolsCB.Checked = false;
                    IncludeNumbersCB.Checked = false;
                    IncludeNumbersCB.Enabled = false;
                }
                else
                {
                    IncludeSymbolsCB.Enabled = true;
                    IncludeSymbolsCB.Checked = true;
                    IncludeNumbersCB.Checked = true;
                    IncludeNumbersCB.Enabled = true;
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
                if(NewPasswordTextArea.Text != "")
                {
                    Copy.Text = "Copied!!";
                    Copy.BackColor = Color.Gray;
                }
                else
                {
                    ErrorMsg.Text = "Please generate password to copy";
                }

                
               
            }
            catch(Exception ex)
            {

            }            
        }
        public static string RandomString(int length,string IncludeSymbolsCB, string ETSCB, string IncludeNumbersCB, string ILCCB, string IUCCB, string EACCB)
        {
            string passwordtogenerate = string.Empty;

            try
            {
                if (IncludeSymbolsCB == "True" && ETSCB == "False" && IncludeNumbersCB == "False" && ILCCB == "False" && IUCCB == "False" && EACCB == "False")
                {
                    //only symbol
                    passwordtogenerate = "~!#$%^&*()_+{}|[]:?";

                }
                else if (IncludeSymbolsCB == "False" && ETSCB == "False" && IncludeNumbersCB == "True" && ILCCB == "False" && IUCCB == "False" && EACCB == "False")
                {
                    //only number
                    passwordtogenerate = "0123456789";
                }
                else if (IncludeSymbolsCB == "False" && ETSCB == "False" && IncludeNumbersCB == "False" && ILCCB == "True" && IUCCB == "False" && EACCB == "False")
                {
                    //only lower case password
                    passwordtogenerate = "abcdefghijklmnopqrstuvwxyz";
                }
                else if (IncludeSymbolsCB == "False" && ETSCB == "False" && IncludeNumbersCB == "False" && ILCCB == "False" && IUCCB == "True" && EACCB == "False")
                {
                    //only upper case password
                    passwordtogenerate = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                }
                else if (IncludeSymbolsCB == "False" && ETSCB == "True" && IncludeNumbersCB == "False" && ILCCB == "False" && IUCCB == "False" && EACCB == "False")
                {
                    //easy to say - only letters.......
                    passwordtogenerate = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                }
                else if (IncludeSymbolsCB == "False" && ETSCB == "False" && IncludeNumbersCB == "False" && ILCCB == "False" && IUCCB == "False" && EACCB == "True")
                {
                    //easy to read - Ambigoius 
                    passwordtogenerate = "~!#$%^&*()_+{}|[]:?34689abcdefghijkmnpqrtuvwxyABCDEFGHJKLMNPQRTUVWXY";
                }
                else if (IncludeSymbolsCB == "True" && ETSCB == "False" && IncludeNumbersCB == "True" && ILCCB == "False" && IUCCB == "False" && EACCB == "False")
                {
                    // starting 2 checkbox
                    passwordtogenerate = "~!#$%^&*()_+{}|[]:?0123456789";
                }
                else if (IncludeSymbolsCB == "True" && ETSCB == "False" && IncludeNumbersCB == "True" && ILCCB == "True" && IUCCB == "False" && EACCB == "False")
                {
                    // starting 3 checkbox
                    passwordtogenerate = "abcdefghijklmnopqrstuvwxyz~!#$%^&*()_+{}|[]:?0123456789";
                }
                else if (IncludeSymbolsCB == "True" && ETSCB == "False" && IncludeNumbersCB == "True" && ILCCB == "True" && IUCCB == "True" && EACCB == "False")
                {   
                    // starting 4 cb
                    passwordtogenerate = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz~!#$%^&*()_+{}|[]:?0123456789";
                }
                else if (IncludeSymbolsCB == "False" && ETSCB == "False" && IncludeNumbersCB == "True" && ILCCB == "True" && IUCCB == "True" && EACCB == "False")
                {
                    // 2 - 4
                    passwordtogenerate = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                }
                else if (IncludeSymbolsCB == "False" && ETSCB == "False" && IncludeNumbersCB == "False" && ILCCB == "True" && IUCCB == "True" && EACCB == "False")
                {
                    // 3 - 4
                    passwordtogenerate = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                }
                else if (IncludeSymbolsCB == "False" && ETSCB == "True" && IncludeNumbersCB == "False" && ILCCB == "True" && IUCCB == "True" && EACCB == "True")
                {
                    //last 4
                    passwordtogenerate = "abcdefghijkmnpqrtuvwxyABCDEFGHJKLMNPQRTUVWXY";
                }
                else if (IncludeSymbolsCB == "True" && ETSCB == "False" && IncludeNumbersCB == "True" && ILCCB == "True" && IUCCB == "True" && EACCB == "True")
                {
                    // exclude 5th
                    passwordtogenerate = "~!#$%^&*()_+{}|[]:?34689abcdefghijkmnpqrtuvwxyABCDEFGHJKLMNPQRTUVWXY";
                }
                else if (IncludeSymbolsCB == "True" && ETSCB == "False" && IncludeNumbersCB == "False" && ILCCB == "True" && IUCCB == "True" && EACCB == "False")
                {
                    // 1 - 4 exclude 2nd number
                    passwordtogenerate = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz~!#$%^&*()_+{}|[]:?";
                }
                else if (IncludeSymbolsCB == "True" && ETSCB == "False" && IncludeNumbersCB == "True" && ILCCB == "False" && IUCCB == "True" && EACCB == "False")
                {
                    // 1 - 4 exclude 3rd number
                    passwordtogenerate = "ABCDEFGHIJKLMNOPQRSTUVWXYZ~!#$%^&*()_+{}|[]:?0123456789";
                }
                else if (IncludeSymbolsCB == "True" && ETSCB == "False" && IncludeNumbersCB == "False" && ILCCB == "False" && IUCCB == "True" && EACCB == "False")
                {
                    // 1 - 4 exclude 2nd-3rd number
                    passwordtogenerate = "ABCDEFGHIJKLMNOPQRSTUVWXYZ~!#$%^&*()_+{}|[]:?";
                }
                else if (IncludeSymbolsCB == "True" && ETSCB == "False" && IncludeNumbersCB == "False" && ILCCB == "True" && IUCCB == "False" && EACCB == "False")
                {
                    // 1 - 4 exclude 2nd-3rd number
                    passwordtogenerate = "abcdefghijkmnpqrtuvwxy~!#$%^&*()_+{}|[]:?";
                }
                else if (IncludeSymbolsCB == "False" && ETSCB == "False" && IncludeNumbersCB == "True" && ILCCB == "False" && IUCCB == "True" && EACCB == "False")
                {
                    // Number + Caps
                    passwordtogenerate = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                }
                else if (IncludeSymbolsCB == "False" && ETSCB == "False" && IncludeNumbersCB == "True" && ILCCB == "True" && IUCCB == "False" && EACCB == "False")
                {
                    // Number + Caps
                    passwordtogenerate = "abcdefghijkmnpqrtuvwxy0123456789";
                }
                else if (IncludeSymbolsCB == "False" && ETSCB == "True" && IncludeNumbersCB == "False" && ILCCB == "True" && IUCCB == "True" && EACCB == "False")
                {
                    // Easy to say
                    passwordtogenerate = "ABCDEFGHIJKLMNOPQRSTUVWXYabcdefghijkmnpqrtuvwxy";
                }
                else if (IncludeSymbolsCB == "False" && ETSCB == "True" && IncludeNumbersCB == "False" && ILCCB == "False" && IUCCB == "True" && EACCB == "False")
                {
                    // Easy to say - Caps
                    passwordtogenerate = "ABCDEFGHIJKLMNOPQRSTUVWXY";
                }
                else if (IncludeSymbolsCB == "False" && ETSCB == "True" && IncludeNumbersCB == "False" && ILCCB == "True" && IUCCB == "False" && EACCB == "False")
                {
                    // Easy to say - lower
                    passwordtogenerate = "abcdefghijkmnpqrtuvwxy";
                }
                else if (IncludeSymbolsCB == "False" && ETSCB == "True" && IncludeNumbersCB == "False" && ILCCB == "False" && IUCCB == "False" && EACCB == "True")
                {
                    // Ambigous + Easy to say
                    passwordtogenerate = "abcdefghijkmnpqrtuvwxyABCDEFGHJKLMNPQRTUVWXY";
                }
                else
                {
                    // all scenarios
                    if(ETSCB == "True")
                    {
                        passwordtogenerate = "abcdefghijkmnpqrtuvwxyABCDEFGHJKLMNPQRTUVWXY";
                    }
                    else
                    {
                        passwordtogenerate = "~!#$%^&*()_+{}|[]:?34689abcdefghijkmnpqrtuvwxyABCDEFGHJKLMNPQRTUVWXY";
                    }
                    
                }
            }
            catch(Exception ex)
            {
                passwordtogenerate = "-NA-";
            }

            

            return new string(Enumerable.Repeat(passwordtogenerate, length)
                      .Select(s => s[random.Next(s.Length)]).ToArray());


        }

        public string EnryptString(string strEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;

        }

        protected void Generate_encypted_password(object sender, EventArgs e)
        {
            try
            {
                string GlobalQuantityPassword = string.Empty;
                string Passlength = PasswordLengthDropDown.SelectedValue;
                int len = Convert.ToInt32(Passlength);

                string IncludeSymbols = IncludeSymbolsCB.Checked.ToString();
                string ETS = ETSCB.Checked.ToString();
                string IncludeNumbers = IncludeNumbersCB.Checked.ToString();
                string ILC = ILCCB.Checked.ToString();
                string IUC = IUCCB.Checked.ToString();
                //string ESC = ESCCB.Checked.ToString();
                string EAC = EACCB.Checked.ToString();

                for(int i=1;i<= Convert.ToInt32(PasswordQuantityDropDown.Text); i++)
                {
                    string RandomChar = RandomString(len, IncludeSymbols, ETS, IncludeNumbers, ILC, IUC, EAC);
                    RandomChar = String.Concat(RandomChar, "@");
                    GlobalQuantityPassword = String.Concat(GlobalQuantityPassword,RandomChar);
                    GlobalQuantityPassword = GlobalQuantityPassword.Replace("@", System.Environment.NewLine);
                }

                

               
                ErrorMsg.Text = string.Empty;

                Copy.Text = "Copy";
                Color blue = Color.FromArgb(3, 133, 183);
                Copy.BackColor = blue;

                NewPasswordTextArea.Text = GlobalQuantityPassword;
            }
            catch(Exception ex)
            {
                ErrorMsg.Text = ex.Message;
            }
        }
    }
}