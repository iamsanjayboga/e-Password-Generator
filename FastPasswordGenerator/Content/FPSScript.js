////function MD5CopyPassword() {
////    const elem = document.createElement('textarea');
////    var text = document.getElementById("GeneratedHashString").innerText;
////    const myArray = text.split(":");

////    elem.value = myArray[1];
////    document.body.appendChild(elem);
////    elem.select();
////    document.execCommand('copy');
////    document.body.removeChild(elem);

////}

////function CopyPassword() {

    
////    var copyText = document.getElementById("NewPasswordTextArea");

   
////    copyText.select();

////    copyText.setSelectionRange(0, 99999); /* For mobile devices */

   

////    document.execCommand("copy");

////}
function MD5CopyPassword() { const e = document.createElement("textarea"); const t = document.getElementById("GeneratedHashString").innerText.split(":"); e.value = t[1], document.body.appendChild(e), e.select(), document.execCommand("copy"), document.body.removeChild(e) }
function CopyPassword() { var e = document.getElementById("NewPasswordTextArea"); e.select(), e.setSelectionRange(0, 99999), document.execCommand("copy") }
function SHA1CopyPassword() { const e = document.createElement("textarea"); const t = document.getElementById("GeneratedHashString").innerText.split(":"); e.value = t[1], document.body.appendChild(e), e.select(), document.execCommand("copy"), document.body.removeChild(e) }