<%@ Page Title="Strong Random Password Generator" ValidateRequest="false" Language="C#" Debug="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PasswordsGenerator.aspx.cs" Inherits="FastPasswordGenerator.PasswordsGenerator" 
    MetaKeywords="Fast Password Generator,Password Generator, Online Password Generator, Random Password Generator, Secure Password Generator, Create Password, Generate Password" 
    MetaDescription="Fast password generator is one-stop solution to create strong password which are impossible to hack or crack." %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <div class="row">
            <div class="col-lg-1">
                <%--<img src="Content/images/passwordgenerator.png" alt="Fast Passwords Generator"/> --%>
                <img src="Content/images/FastPasswordGenerator.webp" width="64" height="64" alt="Fast Passwords Generator" />
                
            </div>
            <div class="col-lg-11">
                <asp:Label ID="FastPasswordsGenerator" runat="server" Text="Fast Passwords Generator" CssClass="fontsize"></asp:Label>
            </div>
        </div>
        <br />
        <div class="row toppadding">
            <div class="col-lg-3">
                <asp:Label ID="PasswordType" runat="server" Text="Password Type:"></asp:Label>
            </div>
            <div class="col-lg-9">
                <asp:DropDownList CssClass="widthsize" ID="PasswordTypeDropDown" runat="server" OnSelectedIndexChanged="PassWordLenght" AutoPostBack="true">
                    <asp:ListItem Text="Weak" Value="Weak" />
                    <asp:ListItem Text="Strong" Value="Strong" />
                    <asp:ListItem Text="Extreme Strong" Value="Extreme Strong" />
                </asp:DropDownList>
            </div>
        </div>

        <div class="row toppadding">
            <div class="col-lg-3">
                <asp:Label ID="PasswordLength" runat="server" Text="Password Length:"></asp:Label>
            </div>
            <div class="col-lg-9">
                <asp:DropDownList CssClass="widthsize" ID="PasswordLengthDropDown" runat="server">
                </asp:DropDownList>
            </div>
        </div>

        <div class="row toppadding">
            <div class="col-lg-3">
                <asp:Label ID="IncludeSymbols" runat="server" Text="Include Symbols:"></asp:Label>
            </div>
            <div class="col-lg-9">
                <asp:CheckBox ID="IncludeSymbolsCB" runat="server" Checked="true" />
                <asp:Label ID="eg1" runat="server" Text="( e.g. @#$% )"></asp:Label>
            </div>

        </div>

        <%--<div class="row toppadding">
            <div class="col-lg-3">
                <asp:Label ID="BeginLetter" runat="server" Text="Begin With Character(Letter):"></asp:Label>
            </div>
            <div class="col-lg-9">
                <asp:CheckBox ID="BeginLetterCB" runat="server" Checked="true" />
                <asp:Label ID="eg2" runat="server" Text="( don't begin with a number or symbol )"></asp:Label>
            </div>

        </div>--%>

        <div class="row toppadding">
            <div class="col-lg-3">
                <asp:Label ID="IncludeNumbers" runat="server" Text="Include Numbers:"></asp:Label>
            </div>
            <div class="col-lg-9">
                <asp:CheckBox ID="IncludeNumbersCB" runat="server" Checked="true" />
                <asp:Label ID="eg7" runat="server" Text="( e.g. 123456 )"></asp:Label>
            </div>

        </div>

        <div class="row toppadding">
            <div class="col-lg-3">
                <asp:Label ID="ILC" runat="server" Text="Include Lowercase Characters:"></asp:Label>
            </div>
            <div class="col-lg-9">
                <asp:CheckBox ID="ILCCB" runat="server" Checked="true" />
                <asp:Label ID="eg3" runat="server" Text="( e.g. abcdefgh )"></asp:Label>
            </div>

        </div>

        <div class="row toppadding">
            <div class="col-lg-3">
                <asp:Label ID="IUC" runat="server" Text="Include Uppercase Characters:"></asp:Label>
            </div>
            <div class="col-lg-9">
                <asp:CheckBox ID="IUCCB" runat="server" Checked="true" />
                <asp:Label ID="eg4" runat="server" Text="( e.g. ABCDEFGH )"></asp:Label>
            </div>

        </div>



        <%--<div class="row toppadding">
            <div class="col-lg-3">
                <asp:Label ID="ESC" runat="server" Text="Exclude Similar Characters:"></asp:Label>
            </div>
            <div class="col-lg-9">
                <asp:CheckBox ID="ESCCB" runat="server" Checked="true" />
                <asp:Label ID="eg5" runat="server" Text="( e.g. i, l, 1, L, o, 0, O )"></asp:Label>
            </div>

        </div>--%>

        <div class="row toppadding">
            <div class="col-lg-3">
                <asp:Label ID="ETS" runat="server" Text="Easy to say:"></asp:Label>
            </div>
            <div class="col-lg-9">
                <asp:CheckBox ID="ETSCB" runat="server" Checked="false" OnCheckedChanged="DisableNumberSymbols" AutoPostBack="true" />
                <asp:Label ID="eg8" runat="server" Text="( e.g. Exclude numbers and symbols)"></asp:Label>
            </div>

        </div>

        <div class="row toppadding">
            <div class="col-lg-3">
                <asp:Label ID="EAC" runat="server" Text="Easy to read:"></asp:Label>
            </div>
            <div class="col-lg-9">
                <asp:CheckBox ID="EACCB" runat="server" Checked="false" />
                <asp:Label ID="eg6" runat="server" Text="( e.g. Exclude ambiguous characters like l, 1, O, and 0 )"></asp:Label>
                <%--{ } [ ] ( ) / \ ~ , ; : .--%>
            </div>

        </div>

        <div class="row toppadding">
            <div class="col-lg-3">
                <asp:Label ID="PasswordQuantity" runat="server" Text="Password Quantity:"></asp:Label>
            </div>
            <div class="col-lg-9">
                <asp:DropDownList CssClass="widthsize" ID="PasswordQuantityDropDown" runat="server">
                    <asp:ListItem Text="1" Value="1" />
                    <asp:ListItem Text="2" Value="2" />
                    <asp:ListItem Text="3" Value="3" />
                    <asp:ListItem Text="4" Value="4" />
                    <asp:ListItem Text="5" Value="5" />
                </asp:DropDownList>
            </div>
        </div>

        <div class="row buttonpadding">
            <div class="col-lg-3">
            </div>
            <div class="col-lg-9">
                <asp:Button CssClass="button button5" ID="GeneratePassword" runat="server" Text="Generate Password" OnClick="Generate_encypted_password" />
                <asp:Button CssClass="button button5" ClientIDMode="Static" ID="Copy" runat="server" Text="Copy" OnClick="copypassowrd" OnClientClick="CopyPassword()" />
                <%--<button class="button button5" onclick="CopyPassword()" id="copybtn">Copy</button>--%>
            </div>
        </div>

        <div class="row toppadding">
            <div class="col-lg-3">
                <asp:Label ID="NewPassword" runat="server" Text="Your New Passwords:"></asp:Label>
            </div>
            <div class="col-lg-9">
             
                <asp:TextBox ID="NewPasswordTextArea" runat="server" Width="315px" Height="120px" TextMode="MultiLine" ClientID="C1" 
                    ClientIDMode="Static" Text='<%# Eval("tAnnotation").ToString() %>'             
                    CssClass="textpassword"></asp:TextBox>
            </div>
        </div>

        <div class="row toppadding">
            <div class="col-lg-3">
            </div>
            <div class="col-lg-9">
                <asp:Label ID="ErrorMsg" runat="server" Text="" CssClass="alert"></asp:Label>
            </div>
        </div>

        <div class="row toppadding">

            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                <a href="PasswordsGenerator.aspx" class="button3">Password Generator</a>
                <a href="something" rel="noopener noreferrer" target="_blank" class="button3">Advanced Encryption Standard (AES)</a>
                <a href="something" rel="noopener noreferrer" target="_blank" class="button3">Rivest-Shamir-Adleman (RSA)</a>
                <a href="something" rel="noopener noreferrer" target="_blank" class="button3">Twofish</a>
                <a href="something" rel="noopener noreferrer" target="_blank" class="button3">Blowfish</a>
                <a href="something" rel="noopener noreferrer" target="_blank" class="button3">Data Encryption Standard (DES)</a>

                
                <a href="md5-hash-generator.aspx" class="button3">MD5</a>
                <a href="sha1-generator.aspx" class="button3">SHA-1</a>
                <a href="sha256-generator.aspx" class="button3">SHA-256</a>
                <a href="sha512-generator.aspx" class="button3">SHA-512</a>
            </div>
            <div class="col-lg-1"></div>

        </div>



    </div>

    <div class="row toppadding">
        <p class="textalign"><b>To keep your online accounts safe and prevent your passwords from being compromised using malicious code, brute force, or dictionary attacks, you should be aware of the following:</b></p>
        <p class="textalign">
            1. Never use the same password, security question, or answer for numerous essential accounts. 
           
            <br />
            <br />
            2. Create a password with at least 16 characters that includes a number, an uppercase letter, a lowercase letter, and a special symbol.
           
            <br />
            <br />
            3. Never use the names of your family, friends, or pets as passwords.
           
            <br />
            <br />
            4. Avoid using postcodes, house numbers, phone numbers, birthdates, ID card numbers, social security numbers, and other personal information in your passwords.
           
            <br />
            <br />
            5. Avoid using dictionary words in your passwords. 
            <br />
            &nbsp &nbsp Strong password examples include: <b>ePYHc~dS*)8$+V-' , qzRtC{6rXN3N\RgL , zbfUMZPE6`FC%)sZ. </b>
            <br />
            &nbsp &nbsp Weak passwords examples include: <b>qwert12345, Gbt3fC79ZmMEFUFJ, 1234567890, 987654321. </b>
            <br />
            <br />
            6. Do not use two or more similar passwords with the majority of their characters the same, such as ilovefreshflowersMac and ilovefreshflowersDropBox, because if one of these passwords is stolen, all of these passwords are stolen. 
            <br />
            <br />
            7. Do not use passwords that can be duplicated but cannot be changed, such as your fingerprints. 
            <br />
            <br />
            8. Do not let your web browsers (FireFox, Chrome, Safari, Opera, Internet Explorer, and Microsoft Edge) to keep your passwords, as all passwords saved in web browsers can be easily disclosed. 
            <br />
            <br />
            9. Do not log in to sensitive accounts on other people's computers or when using a public Wi-Fi hotspot, Tor, a free VPN, or a web proxy.
            <br />
            <br />
            10. Do not transfer sensitive information online using unencrypted connections (e.g., HTTP or FTP), as communications in these connections can be sniffed with little effort. When possible, employ encrypted connections such as HTTPS, SFTP, FTPS, SMTPS, and IPSec.
            <br />
            <br />
            11. When you're on the road, you can encrypt your Internet connections before they leave your laptop, tablet, phone, or router. For example, you can connect to a private VPN using protocols such as WireGuard (or IKEv2, OpenVPN, SSTP, or L2TP over IPSec) on your own server (home computer, dedicated server, or VPS). You can also create an encrypted SSH tunnel between your machine and your own server and configure Chrome or FireFox to use socks proxy. Even if someone uses a packet sniffer to collect your data as it is transported between your device (e.g., laptop, iPhone, iPad) and your server, they won't be able to steal your data or passwords from the encrypted streaming data.
            <br />
            <br />
            12. Is my password secure? Perhaps you believe your passwords are extremely strong and tough to crack. However, if a hacker steals your username and the MD5 hash value of your password from a company's server and the hacker's rainbow table contains this MD5 hash, your password will be broken rapidly. 
            <br />
            <br />
            &nbsp &nbsp To test the strength of your passwords and see if they are in the popular rainbow tables, use an <a href="md5-hash-generator.aspx" rel="noopener noreferrer" target="_blank">MD5 hash generator to generate MD5 hashes</a>, then decode your passwords by submitting these hashes to an online MD5 decryption service. 
            <b>For example, if your password is "0123456789A," it may take a computer over a year to crack it using the brute-force method, but how long will it take to crack it if you decode it by submitting its MD5 hash (C8E7279CD035B23BB9C0F1F954DFF5B3) to an MD5 decryption website? You can run the test on your own.</b>
            <br />
            <br />
            13. It is suggested that you update your passwords every 10 weeks. 
            <br />
            <br />
            14. It is recommended that you remember a few master passwords, keep other passwords in a plain text file, and encrypt this file with 7-Zip, GPG, or disk encryption software like BitLocker, or manage your passwords with password management software.
            <br />
            <br />
            15. Encrypt and backup your passwords in many locations so that if you lose access to your computer or account, you can quickly recover your passwords.
            <br />
            <br />
            16. Whenever possible, enable two-factor authentication.
            <br />
            <br />
            17. Do not keep important passwords on the cloud. 
            <br />
            <br />
            18. Access key websites (e.g., Paypal) straight from bookmarks; otherwise, carefully examine its domain name; it's a good idea to check the popularity of a website with Alexa toolbar to confirm that it's not a phishing site before entering your password.
            <br />
            <br />
            19. Use a firewall and antivirus software to protect your computer, and use the firewall to prevent all incoming and unwanted outgoing connections. Only download software from reliable sites, and whenever feasible, validate the <a href="md5-hash-generator.aspx" rel="noopener noreferrer" target="_blank">MD5</a> / SHA1 / SHA256 checksum or GPG signature of the installation package.
            <br />
            <br />
            20. Keep your operating systems (e.g., Windows 7, Windows 10, Mac OS X, iOS, Linux) and Web browsers (e.g., FireFox, Chrome, IE, Microsoft Edge) and Web browsers (e.g., FireFox, Chrome, IE, Microsoft Edge) of your devices (e.g., Windows PC, Mac PC, iPhone, iPad, Android tablet) up to date by installing the latest security update.
            <br />
            <br />
            21. If you have essential files on your computer that others can access, check for hardware keyloggers (e.g. wireless keyboard sniffer), software keyloggers, and hidden cameras as needed.
            <br />
            <br />
            22. If you have WIFI routers in your home, it is feasible to learn the passwords you typed (at your neighbor's house) by detecting the gestures of your fingers and hands, because the WIFI signal they received changes when you move your fingers and hands. In such instances, you can type your passwords using an on-screen keyboard; however, it would be more safe if this virtual keyboard (or soft keyboard) changed layouts each time.
            <br />
            <br />
            23. When you leave your computer or phone, lock it.
            <br />
            <br />
            24. Encrypt the entire hard drive with VeraCrypt, FileVault, LUKS, or similar programs before storing essential files on it, and physically destroy the hard disk of your previous devices if required.
            <br />
            <br />
            25. Use a secret or incognito mode to visit vital websites, or use one Web browser to view important websites and another to access other sites. Alternatively, you can view unimportant websites and install new software within a virtual computer established with VMware, VirtualBox, or Parallels.
            <br />
            <br />
            26. Use at least three different email addresses: the first to receive emails from important sites and apps like Paypal and Amazon, the second to receive emails from unimportant sites and apps like Facebook, and the third (from a different email provider like Outlook or GMail) to receive your password-reset email if the first one (e.g. Yahoo Mail) is hacked.
            <br />
            <br />
            27. Use at least two different phone numbers; DO NOT reveal the phone number you use to receive text messages with verification codes to anyone.
            <br />
            <br />
            28. Do not click the link in an email or SMS message, and do not reset your passwords by clicking them, unless you are certain that the messages are genuine.
            <br />
            <br />
            29. Do not reveal your passwords in the email to anyone.
            <br />
            <br />
            30. It is conceivable that one of the software or Apps you downloaded or updated was modified by hackers; you can avoid this problem by not installing this software or App for the first time, unless it is published to remedy security flaws. Web-based programs, which are more secure and portable, can be used instead.
            <br />
            <br />
            31. When utilizing online paste tools and screen capture applications, be cautious not to allow them to send your credentials to the cloud.
            <br />
            <br />
            32. If you are a webmaster, instead of storing the users' passwords, security questions, and answers in plain text in the database, keep the salted (SHA1, SHA256, or SHA512)hash values of these strings. It is advised that each user generate a unique random salt string. Furthermore, it's a good idea to log the user's device information (e.g., OS version, screen resolution, etc.) and save the salted hash values of them, so that when he/she tries to login with the correct password but his/her device information DOESN'T match the previously saved one, this user can verify his/her identity by entering another verification code sent via SMS or email.
            <br />
            <br />
            33. If you are a software developer, you should publish the update package signed with a private key using GnuPG and validate its signature with the previously published public key. 
            <br />
            <br />
            34. To keep your online business safe, register your own domain name and set up an email account with this domain name; this way, you won't lose your email account and all of your contacts because you may host your mail server anywhere and your email account won't be disabled by the email provider. 
            <br />
            <br />
            35. If an online purchasing site only accepts credit cards for payment, you should utilize a virtual credit card instead.
            <br />
            <br />
            36. When you leave your computer, close your online browser; otherwise, cookies can be readily intercepted with a simple USB device, allowing you to avoid two-step verification and enter into your account with stolen cookies on other computers.
            <br />
            <br />
            37. Distrust and remove faulty SSL certificates from your Web browser; otherwise, you will be unable to ensure the confidentiality and integrity of HTTPS connections using these certificates.
            <br />
            <br />
            38. Encrypt the entire system partition; otherwise, deactivate the pagefile and hibernation features, as essential documents can be found in the pagefile.sys and hiberfil.sys files.
            <br />
            <br />
            40. If possible, utilize cloud-based software rather than installing it on your local device, as there are an increasing number of supply-chain attacks that can install malicious applications or updates on your device in order to steal your credentials and obtain access to top secret data.
            <br />
            <br />
            41. Every large corporation should create and use an intrusion detection system based on artificial intelligence ( including network behavior anomaly detection tools )
            <br />
            <br />
            42. Only allow whitelisted IP addresses to connect to or log into critical servers and workstations.
            <br />
            <br />

        </p>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="Content/FPSScript.js"></script>
</asp:Content>
