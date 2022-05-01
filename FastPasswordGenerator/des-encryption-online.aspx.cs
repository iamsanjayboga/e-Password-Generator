using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FastPasswordGenerator
{
    public partial class des_encryption_online : System.Web.UI.Page
    {
        AesCryptoServiceProvider crypt_provider;

        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        public byte[] plaintext;
        public byte[] encryptedtext;

        public static byte[] StoredEncyptedText;
        //static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("Sanjitha");
        public static string decryptedtext = string.Empty;
        public static string encryptedtext2 = string.Empty;
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

        protected void GenerateDESEncrypt(object sender, EventArgs e)
        {

            try
            {
                if (HashString.Text != "")
                {

                    //CREATING DYNAMIC HASH USING SHA1
                    //sha1_generator sha1 = new sha1_generator();
                    //string sha1text = sha1.CreateSHA1Hash(HashString.Text);
                    //bytes = ASCIIEncoding.ASCII.GetBytes(sha1text);
                    plaintext = ByteConverter.GetBytes(HashString.Text);
                    encryptedtext = RSA_Encryption(plaintext, RSA.ExportParameters(false), false);
                    //txtencrypt.Text = ByteConverter.GetString(encryptedtext);
                    StoredEncyptedText = encryptedtext;
                    //string hash = AES_Encryption(HashString.Text).ToUpper();
                    //var input = encryptedtext;
                    //var regex = new Regex(@".{40}");
                    //string result = regex.Replace(ByteConverter.GetString(encryptedtext), "$&" + Environment.NewLine);
                    GeneratedHashString.Text = String.Concat("AES Encrypted: ", ByteConverter.GetString(encryptedtext));
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

        protected void DES_Decryption(object sender, EventArgs e)
        {
            
            try
            {
                GeneratedHashString.Text = GeneratedHashString.Text.Replace("AES Encrypted: ", "");
                if (GeneratedHashString.Text != "")
                {

                    
                    //txtdecrypt.Text = ByteConverter.GetString(decryptedtex);

                    //GeneratedHashString.Text = GeneratedHashString.Text.Replace("\n", "").Replace("\r", "");
                    //HashString.Text = GeneratedHashString.Text;

                    //string hash = AES_Decryption(GeneratedHashString.Text).ToUpper();
                    //hash = ConvertHexToString(hash, System.Text.Encoding.Unicode);
                    byte[] decryptedtex = RSA_Decryption(StoredEncyptedText, RSA.ExportParameters(true), false);

                    //var input = ByteConverter.GetString(decryptedtex);
                    //var regex = new Regex(@".{40}");
                    //string result = regex.Replace(input, "$&" + Environment.NewLine);
                    GeneratedHashString.Text = String.Concat("AES Decrypted: ", ByteConverter.GetString(decryptedtex));
                    GeneratedHashString.Font.Bold = true;


                }
                else
                {

                }
            }
            catch(Exception ex)
            {

            }
        }


        static public byte[] RSA_Encryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    encryptedData = RSA.Encrypt(Data, DoOAEPPadding);
                }
                return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        static public byte[] RSA_Decryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    decryptedData = RSA.Decrypt(Data, DoOAEPPadding);
                }
                return decryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }


        public string AES_Encryption(string clearText)
        {
            crypt_provider = new AesCryptoServiceProvider();
            crypt_provider.BlockSize = 128;
            crypt_provider.KeySize = 256;
            crypt_provider.GenerateIV();
            crypt_provider.GenerateKey();
            crypt_provider.Mode = CipherMode.CBC;
            crypt_provider.Padding = PaddingMode.Zeros;

            try
            {
                ICryptoTransform transform = crypt_provider.CreateEncryptor();
                byte[] encrypted_byte = transform.TransformFinalBlock(ASCIIEncoding.ASCII.GetBytes(clearText),0,clearText.Length);

                string str = Convert.ToBase64String(encrypted_byte);
                return str;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string AES_Decryption(string clearText)
        {
            crypt_provider = new AesCryptoServiceProvider();
            crypt_provider.BlockSize = 128;
            crypt_provider.KeySize = 256;
            crypt_provider.GenerateIV();
            crypt_provider.GenerateKey();
            crypt_provider.Mode = CipherMode.CBC;
            crypt_provider.Padding = PaddingMode.Zeros;

            try
            {
                ICryptoTransform transform = crypt_provider.CreateDecryptor();
                byte[] enc_bytes = Convert.FromBase64String(clearText);
                byte[] decrypted_bytes = transform.TransformFinalBlock(enc_bytes,0,enc_bytes.Length);

                string str = ASCIIEncoding.ASCII.GetString(decrypted_bytes);
                return str;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        


        public static string AES_Encrypt(string clearText, string key)
        {
            try
            {
                if (string.IsNullOrEmpty(key))
                {
                    throw new Exception($"Encryption key is empty!");
                }
                byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    encryptor.Padding = PaddingMode.Zeros;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        clearText = Convert.ToBase64String(ms.ToArray());
                    }
                }
                return clearText;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string AES_Decrypt(string cipherText, string key)
        {
            try
            {
                if (string.IsNullOrEmpty(key))
                {
                    throw new Exception($"Encryption key is empty!");
                }
                cipherText = cipherText.Replace(" ", "+");
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    encryptor.Padding = PaddingMode.Zeros;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        cipherText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
                return cipherText;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //AES
        public static string EncryptString(string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = ASCIIEncoding.ASCII.GetBytes("b14ca5898a4e4133bbce2ea2315a1916");
                aes.IV = iv;
                aes.Padding = PaddingMode.Zeros;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        //AES
        public static string DecryptString(string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes("b14ca5898a4e4133bbce2ea2315a1916");
                aes.IV = iv;
                aes.Padding = PaddingMode.Zeros;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }


        public static string Encrypt(string originalString)
        {
            //byte[] bytes = ASCIIEncoding.ASCII.GetBytes("Sanjitha");
            //if (String.IsNullOrEmpty(originalString))
            //{
            //    throw new ArgumentNullException
            //           ("The string which needs to be encrypted can not be null.");
            //}
            //DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            //MemoryStream memoryStream = new MemoryStream();
            //CryptoStream cryptoStream = new CryptoStream(memoryStream,
            //    cryptoProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
            //StreamWriter writer = new StreamWriter(cryptoStream);
            //writer.Write(originalString);
            //writer.Flush();
            //cryptoStream.FlushFinalBlock();
            //writer.Flush();
            //return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);

            try
            {
                DES des = new DESCryptoServiceProvider();
                des.Mode = CipherMode.CBC;

                byte[] plaintext = Encoding.ASCII.GetBytes(originalString);

                byte[] key = Encoding.ASCII.GetBytes("Sanjitha");
                byte[] IV = Encoding.ASCII.GetBytes("init vec");

                des.Key = key;
                des.IV = IV;

                ICryptoTransform transform = des.CreateEncryptor(des.Key, des.IV);

                MemoryStream memStreamEncryptedData = new MemoryStream();

                memStreamEncryptedData.Write(plaintext, 0, plaintext.Length);

                CryptoStream encStream = new CryptoStream(memStreamEncryptedData, transform, CryptoStreamMode.Write);

                byte[] ciphertext = memStreamEncryptedData.ToArray();

                encryptedtext2 = Convert.ToBase64String(ciphertext);

                encStream.Close();

                return encryptedtext2;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public static string Decrypt(string cryptedString)
        {
            //byte[] bytes = ASCIIEncoding.ASCII.GetBytes("Sanjitha");
            //if (String.IsNullOrEmpty(cryptedString))
            //{
            //    throw new ArgumentNullException
            //       ("The string which needs to be decrypted can not be null.");
            //}
            //DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            //MemoryStream memoryStream = new MemoryStream
            //        (Convert.FromBase64String(cryptedString));
            //CryptoStream cryptoStream = new CryptoStream(memoryStream,
            //    cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
            //StreamReader reader = new StreamReader(cryptoStream);
            //return reader.ReadToEnd();
            try
            {
                DES des = new DESCryptoServiceProvider();
                des.Mode = CipherMode.CBC;
                byte[] ciphertext = Convert.FromBase64String(cryptedString);
                byte[] key = Encoding.ASCII.GetBytes("Sanjitha");
                byte[] IV = Encoding.ASCII.GetBytes("init vec");

                des.Key = key;
                des.IV = IV;

                ICryptoTransform transform = des.CreateDecryptor(des.Key, des.IV);

                MemoryStream memDecryptStream = new MemoryStream();
                memDecryptStream.Write(ciphertext, 0, ciphertext.Length);
                CryptoStream cs_decrypt = new CryptoStream(memDecryptStream, transform, CryptoStreamMode.Write);


                byte[] plaintext = memDecryptStream.ToArray();

                decryptedtext = Encoding.ASCII.GetString(plaintext);

                return decryptedtext;

                //cs_decrypt.Close();

                
            }
            catch(Exception ex)
            {
                return ex.Message;
            }

                      

        }

        public static string ConvertHexToString(String hexInput, System.Text.Encoding encoding)
        {
            int numberChars = hexInput.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexInput.Substring(i, 2), 16);
            }
            return encoding.GetString(bytes);
        }

    }
}