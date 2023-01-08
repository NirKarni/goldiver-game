<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<%--CSS--%><%--<link href="Styles/reset.css" rel="stylesheet" type="text/css" />--%>
    <link href="styles/myStyle.css" rel="stylesheet" />

   <%--Scripts--%>
    <!--jQuery library-->
    <script src="jScripts/jquery-1.12.0.min.js"></script>
    <!--הקוד שמפעיל את תפריט הניווט-->
    <script src="jScripts/myScript.js"></script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <header style="margin-top:-15px;">
            <!--קישור לדף עצמו כדי להתחיל את המשחק מחדש בלחיצה על הלוגו-->
            <div class="headsizetop">
                <a href="Gold_Diver.html" class="headsize">
                    <img src="images/diver logo.png" id="logo" />  <!--הלוגו של המשחק שלכם-->
                    <p class="headsize"> <img src="images/name logo.png" width="170" height="50" /> </p>
                </a>
            </div>
            <!--תפריט הניווט בראש העמוד-->
            <nav>
                <ul>
                    <li><a class="about">אודות</a></li>
                    <li><a class="howToPlay">איך משחקים?</a></li>
                    <li><a href="index.html" class="ToTheEditor">למשחק</a></li>
                </ul>
            </nav>
        </header>
    
        <div id="aboutDiv" style="z-index:999999;" class="popUp bounceInDown hide">
            <a class="closeAbout">
                <img src="images/exit.png" class="exit2" />
            </a>
            <%--<p>--%>
                <img src="images/about.png" class="information" />
                <div class="sound"><a href="https://freemusicarchive.org/music/Scanglobe/fade-remix/undulation-remix"> Scanglobe </a></div>
                <div class="telem"><a href="https://www.hit.ac.il/telem/overview">הפקולטה לטכנולוגיות למידה</a> </div>
            <%--</p>--%>
        </div>
        <div id="howToPlayDiv" style="z-index:999999;" class="popUp bounceInDown hide">
            <a class="closeHowToPlay">
                <img src="images/exit.png" class="exit" />
            </a>

            <p>
                <img src="images/howtoplay2.png" class="instructions" />
            </p>

        </div>

        <div id="formLogin">
            <form id="form2" runat="server" dir="rtl">
                <div id="frameLogin">
                    <div id="loginHead">
                        התחברות
                    </div>
                    <div>
                        <label for="UserNameTxt">
                        <strong>שם משתמש: </strong>
                  <br />
                        <asp:TextBox ID="UserNameTxt" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <br />
                    </label>
                    <label for="PasswordTxt">
                        <strong>סיסמא:</strong><br />
                        <asp:TextBox type="password" ID="PasswordTxt" runat="server"></asp:TextBox>
                        <br />
                    </label>
                    <br />
                    <asp:Button ID="loginBtn" runat="server" Text="כניסה" OnClick="Button1_Click" />
                    <br />
                    <asp:Label ID="labelFeedback" runat="server"></asp:Label>
                    <br />
                    </div>
                    <div id="loginImage">
                        <asp:Image ID="loginDivers" src="images/login%202%20divers.png" runat="server"  />
                        <asp:Image ID="loginFail" src="images/login%20fail.png" runat="server" Height="268" Width="155" />

                    </div>
                    </div>
                
            </form>
            </div>
</body>
</html>
