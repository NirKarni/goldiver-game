<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title></title>
    <meta name="description" content="" />
    <meta name="keywords" content="" />
    <meta name="author" content="" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=yes" />
    <meta http-equiv="X-UA-Compatible" content="IE=Edge" />
    <%--CSS--%><%--<link href="Styles/reset.css" rel="stylesheet" type="text/css" />--%>
    <link href="Styles/myStyle.css" rel="stylesheet" type="text/css" />
    <%--Scripts--%>
    <script src="jScripts/jquery-1.12.0.min.js" type="text/javascript"></script>
    <!--הקוד שמפעיל את תפריט הניווט-->
    <script src="jScripts/myScripts.js"></script>
</head>
<body>
    <header style="margin-top:-15px;">
        <!--קישור לדף עצמו כדי להתחיל את המשחק מחדש בלחיצה על הלוגו-->
        <div class="headsizetop">
            <a href="Gold_Diver.html" class="headsize">
                <img src="images/diver logo.png" id="logo" />
                <!--הלוגו של המשחק שלכם-->
                <p class="headsize">
                    <img src="images/name logo.png" width="170" height="50" />
                </p>
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

        <div id="aboutDiv" class="popUp bounceInDown hide">
            <a class="closeAbout">
                <img src="images/exit.png" class="exit2" />
            </a>
            
                <img src="images/about.png" class="information" />
                <div class="sound"><a href="https://freemusicarchive.org/music/Scanglobe/fade-remix/undulation-remix"> Scanglobe </a></div>
                <div class="telem"><a href="https://www.hit.ac.il/telem/overview">הפקולטה לטכנולוגיות למידה</a> </div>
            
        </div>
        <div id="howToPlayDiv" class="popUp bounceInDown hide">
            <a class="closeHowToPlay">
                <img src="images/exit.png" class="exit" />
            </a>

            <p>
                <img src="images/howtoplay2.png" class="instructions" />
            </p>

        </div>





    <form id="form1" runat="server">
        <div>
            <br /><br /><br />
<div class="EditTitle" style="position: relative; right:10%;">עריכת משחק <asp:Label ID="gameTopic"  runat="server"></asp:Label></div>&nbsp;&nbsp;
            <asp:Button CssClass="GoBackBTN" ID="goBack" style="position:relative; right:78%; top:-46px; z-index:2;" runat="server" OnClick="Button1_Click" Text="חזרה לדף הראשי" />
            <div style="position:relative; right:70%; top:-95px;">
                <asp:Image ID="myV" style="position:relative; top:10px; right:-5px; " runat="server" ImageUrl="~/images/Picture2.png" />
                <asp:Label ID="Vlabel" style="position:relative; font-weight:bold" runat="server" Text="ניתן לפרסם"></asp:Label>

            </div>
            <br />
            <br />
            <div class="greyround" style="position:relative; right:17%; top:-20px;"></div>
            <div class="gameNameAndQ" style="position:relative; right:27%; top:-95px; ">
            שם המשחק:
            <asp:TextBox ID="gameName" style="z-index:2; border-radius: 5px; " CharacterLimit="20" CharacterForLabel="nameLbl" CssClass="CharacterCount" runat="server" BorderStyle="Solid" Width="180"></asp:TextBox> 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; קטגוריה לזיהוי:
            <asp:TextBox ID="myQuestion" CharacterLimit="100" CharacterForLabel="questionLbl" style="border-radius: 5px;" CssClass="CharacterCount" runat="server" placeholder="לדוגמא: אילו חיות נמצאות בסכנת הכחדה?" BorderStyle="Solid" ToolTip="asdasd" Width="350"></asp:TextBox> 
            <br />
                </div>

            <div class="CharCount">
            <asp:Label ID="nameLbl" style="position:absolute; right:27.8%; top:180px;" runat="server" Text="0/20"></asp:Label>
            <asp:Label ID="questionLbl" style="position:absolute; right:53.4%;  top:180px;" runat="server" Text="0/100"></asp:Label>
            </div>

            <asp:Button ID="saveBTN" class="SaveEditBTN" runat="server" style="position:relative; right:83%; top:-70px;" Text="שמור" OnClick="saveBTN_Click1" />

            <div class="answerNumb" style="position:relative; right:40%;top:-50px; color:black;">
            כמות הפריטים לזיהוי:
            <asp:DropDownList ID="DropDownList1" style="border-radius: 5px;" runat="server" AutoPostBack="True" Height="35" Width="240">
                <asp:ListItem Value="1">8 נכונים, 12 לא נכונים</asp:ListItem>
                <asp:ListItem Value="2">10 נכונים, 15 לא נכונים</asp:ListItem>
                <asp:ListItem Value="3">14 נכונים, 21 לא נכונים</asp:ListItem>
            </asp:DropDownList>
                </div>
            <div class="greyround2" style="position:relative; right:40%"></div>
            <div class="addAnswer">
            <span style="position:relative; top:-56px; right:30%; font-size:21px;">הוספת פריט:</span>&nbsp;&nbsp;
            <asp:ImageButton ID="addPicture" class="addanswerdisable" Style="position:relative; top:-40px; right:31%;" runat="server" ImageUrl="~/icons/addPicture2.png" OnClick="addPicture_Click" Height="60" Width="70" />
            &nbsp;&nbsp;
            <asp:ImageButton ID="addText" runat="server" style="position:relative; top:-17px; right:28%;" ImageUrl="~/icons/addText2.png" OnClick="addText_Click" Height="85" Width="135" />
               <span style="position:relative; font-size:18px; left:7.0%; top:-25px;">תמונה</span> 
            <span style="position:relative; font-size:18px; right:2.0%; top:-25px;">טקסט</span>
            
            </div>

            <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/Trees/XMLFile.xml" XPath="/gameRoot/game/answer"></asp:XmlDataSource>
            <br />
            <div class="grid1" style="position:relative; right:21%"> <%--גרידוויו1--%>
            פריטים נכונים: <asp:Label ID="answerCountTrue" runat="server" Text="Label"></asp:Label> <br />
            <asp:GridView ID="GridView1" runat="server"  DataSourceID="XmlDataSource1" AutoGenerateColumns="False" Height="141px" OnRowCommand="GridView1_RowCommand" ShowHeader="False"  GridLines="Horizontal" BorderStyle="None">
                <Columns>
                    <asp:TemplateField HeaderText="answer" ShowHeader="False" ControlStyle-Width="320"><%--name--%>
                        <ItemTemplate>
                            <asp:Label ID="myAnswers" runat="server" Text='<%#Server.UrlDecode(XPathBinder.Eval(Container.DataItem, "@correct/..").ToString())%>'></asp:Label>
                            <div style="width:320px;"><asp:ImageButton ID="answerImage" style="width:40px; height:40px;" runat="server" Enabled="False" Height="30" Width="20" /></div>
                                <asp:HiddenField ID="HiddenField1" runat="server" value='<%#Server.UrlDecode(XPathBinder.Eval(Container.DataItem, "@type").ToString())%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                           <asp:ImageButton ID="PreviewBtn" CssClass="opacity" runat="server" tooltip="תצוגה מקדימה" ImageUrl="~/icons/preview2.png" CommandName="previewRow" theItemId='<%#XPathBinder.Eval(Container.DataItem, "@id").ToString()%>' Height="40" Width="40" /> <%--הוא לא מבין את ה-answer/@id--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                           <asp:ImageButton ID="EditBtn" CssClass="opacity" runat="server" ImageUrl="~/icons/EditB.png" CommandName="editRow" theItemId='<%#XPathBinder.Eval(Container.DataItem, "@id").ToString()%>' Height="40" Width="40" /> <%--הוא לא מבין את ה-answer/@id--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="DeleteBtn" CssClass="opacity" runat="server" ImageUrl="~/icons/deleteB.png" CommandName="deleteRow" theItemId='<%#XPathBinder.Eval(Container.DataItem, "@id").ToString()%>' Height="40" Width="40" /></> 
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
                </div>

            <asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile="~/Trees/XMLFile.xml" XPath="//game"></asp:XmlDataSource>
<%--            <br />--%>
            <div class="grid2" style="position:relative; right:35%"><%--class="grid2"--%>
            פריטים לא נכונים: <asp:Label ID="answerCountFalse" runat="server" Text="Label"></asp:Label> <br />
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="XmlDataSource2" OnRowCommand="GridView2_RowCommand" ShowHeader="False" GridLines="Horizontal" BorderStyle="None">
                <Columns>
                     <asp:TemplateField HeaderText="answer" ShowHeader="False"  ControlStyle-Width="320"><%--name--%>
                        <ItemTemplate>
                            <asp:Label ID="myAnswers" runat="server" Text='<%#Server.UrlDecode(XPathBinder.Eval(Container.DataItem, "@correct/..").ToString())%>'></asp:Label>
                           <div style="width:320px;"> <asp:ImageButton ID="answerImage" style="width:40px; height:40px;" runat="server" Enabled="False" /></div>
                            <asp:HiddenField ID="HiddenField1" runat="server" value='<%#Server.UrlDecode(XPathBinder.Eval(Container.DataItem, "@type").ToString())%>' />
                            </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                           <asp:ImageButton ID="PreviewBtn" CssClass="opacity" runat="server" ImageUrl="~/icons/preview2.png" CommandName="previewRow" theItemId='<%#XPathBinder.Eval(Container.DataItem, "@id").ToString()%>' Height="40" Width="40" /> 
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="EditBtn" CssClass="opacity" runat="server" ImageUrl="~/icons/EditB.png" CommandName="editRow" theItemId='<%#XPathBinder.Eval(Container.DataItem, "@id").ToString()%>' Height="40" Width="40" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="DeleteBtn" CssClass="opacity" runat="server" ImageUrl="~/icons/deleteB.png" CommandName="deleteRow" theItemId='<%#XPathBinder.Eval(Container.DataItem, "@id").ToString()%>' Height="40" Width="40" /></>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
                </div>


            <%--  הוספת מסיח טקסט --%>
            <asp:Panel class="createPanel" ID="textPanel" runat="server">
                <div class="background1"></div>
                <div class="PopUpAnswerText">
                    <%--CreatGred--%>
                    <div class="createPanelBox lesstop">
                        <br />
                        <br />
                        <br />

                        <asp:Label ID="Label1" class="editanswertitle" Style="position:relative; right:-50px;" runat="server" Text="עריכת פריט טקסט: "></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label6" style="position:relative; left:23%; top:-5px;" runat="server" Text="טקסט"></asp:Label>
                        <asp:TextBox ID="mytextAnswerTB" CharacterLimit="12" CharacterForLabel="textLbl" CssClass="CharacterCount" Style="position:relative; left:38%; top:20px;" runat="server"></asp:TextBox>

                        <asp:Label ID="textLbl" Style="position: relative; top:40px; left:105%" runat="server" Text="0/12"></asp:Label>

                  
                        <asp:RadioButtonList ID="RadioButtonList3"  RepeatDirection="Horizontal" Style=" left:25%; position: relative; top:50px;" runat="server" EnableViewState="False">
                            <asp:ListItem Value="true">הפריט נכון</asp:ListItem>
                            <asp:ListItem Value="false">הפריט לא נכון</asp:ListItem>
                        </asp:RadioButtonList>
                        <br />
                        <asp:Label ID="ErrorLabel" Style="position: relative; top: 30px; right: -50px; color: darkred;" runat="server" Text=""></asp:Label>
                        <br />
                        <div style="position: relative; top: 20px; right:-45px;">
                            <asp:Button ID="savetextanswer" class="SaveBTN" Style="position:relative; top:15px;" Width="6em" runat="server" OnClick="savetext_Click" Text="שמור" Enabled="True" />
                            <asp:Button ID="canceltextanswer" class="CancelBTN" Style="position:relative; top:15px;" Width="6em" runat="server" OnClick="canceltext_Click" Text="ביטול" />
                        </div>
                    </div>
                </div>
                <br />
                <br />
                <br />
            </asp:Panel>


            <%--  הוספת מסיח תמונה --%>
            <asp:Panel class="createPanel" ID="picturePanel" runat="server" ViewStateMode="Enabled">
                <div class="background1"></div>
                <div class="PopUpAnswerPicture">
                    <%--CreatGred--%>
                    <div class="createPanelBox">
                        <br />
                        
                        <asp:Label ID="Label2" class="editanswertitle" runat="server" Text="עריכת פריט תמונה: "></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label5" style="position:relative; left:5.2%; top:-28px;" runat="server" Text="טקסט"></asp:Label>
                        <asp:TextBox ID="myimageAnswerTB" style="position:relative; top:-7px; left:13%" CharacterLimit="20" CharacterForLabel="imageLbl" CssClass="CharacterCount" runat="server"></asp:TextBox>&nbsp;&nbsp; <div style="width:28px; height:28px; top:-8px;" class="tooltip"><div style="width:28px; height:28px;" class="tooltip2"><img style="position:relative; top:-7px; width:25px; height:35px; left:780%" src="icons/info_icon.png" /> <span class="tooltiptext"><span style="position:relative ; right:-13px;">עזרו ללומדים לדעת מה משמעות התמונה.<br /> הטקסט יופיע בתום המסך בלבד לטובת רפלקציה</span></span>     <span class="tooltiptext2"><span style="position:relative ; right:-13px;"></span></span></div></div>&nbsp;<span style="position:relative; top:-29px; left:40%; color:#2AC9DE;">אופציונאלי</span>
                        <br />
                        <asp:Label ID="imageLbl" Style="position: absolute; right: 16%; top:115px;" runat="server" Text="0/20"></asp:Label>
                        <br />
                        <asp:RadioButtonList ID="RadioButtonList1" RepeatDirection="Horizontal" Style=" right:13%; position: relative; top: 10px; padding-left:5px; " runat="server" EnableViewState="False">
                            <asp:ListItem Value="true">הפריט נכון</asp:ListItem>
                            <asp:ListItem Value="false">הפריט לא נכון</asp:ListItem>
                        </asp:RadioButtonList>
                        <br />
                        <asp:Label ID="ErrorLabel2" Style="position: relative; top: -7px; color: darkred; text-align:center" runat="server" Text="wow"></asp:Label>
                        <br />
                        <asp:Button ID="Button5" class="SaveBTN"  Style="position:relative; top:15px;" Width="6em" runat="server" OnClick="savepicture_Click" Text="שמור" />
                        <asp:Button ID="Button6" class="CancelBTN" Style="position:relative; top:15px;" Width="6em" runat="server" OnClick="cancelpicture_Click" Text="ביטול" />
                        <%--  הוספת תמונה--%>
                        <div class="uploadpic" style="width:30px;">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                            <br />
<%--                            <img class="CoinPreview" src="images/coin.png" height="110" />--%>
                            <asp:ImageButton ID="Coin" class="CoinPreview" runat="server" Style="position:relative; top:-50px; right: 600%;" ImageUrl="~/Images/CoinBacground.png" OnClientClick="openFileUploader1(); return false;" Height="100" Width="100" />
                            <asp:ImageButton ID="ImageforUpload1" Style="z-index:100; right:193px; top:-15px;" CssClass="cropped picPreview" runat="server" ImageUrl="~/Images/text.png" OnClientClick="openFileUploader1(); return false;" Height="75" Width="75" />
                            <br />
                            
                            <%-- <asp:Button ID="Button7" runat="server" Text="Upload" OnClick="Upload" />--%>     <%--~/Images/coinText.png--%>           <%--coinEmpty --%>        
                            <asp:Label ID="Label3" runat="server"></asp:Label>
                            <%--<asp:Image ID="ImageAnswer" runat="server" Width="40" Height="40" />--%>
                        </div>

                    </div>
                </div>
                <br />
                <br />
                <br />
            </asp:Panel>


            <%--הגנה למחיקת מסיח--%>
            <asp:Panel class="deletePanel" ID="deletePanel" runat="server">
                <div class="background1"></div>
                <div class="PopUpprevie DelGred2">
                    <div class="deletePanelBox">
                        <br />
                        <br />
                        <asp:Label ID="Labeldelete" runat="server" Text="האם את/ה בטוח שתרצה למחוק את המסיח? "></asp:Label>
                        <br />
                        <br />

                        <asp:ImageButton ID="ImageButton1" Style="position:relative; z-index:101; right:70px; top:-16px;" CssClass="cropped" class="answerpreview" runat="server" ImageUrl="~/Images/bacground.png" Height="95" Width="95" Enabled="False" />
                        <asp:Image ID="Image1" style="position:relative; right:-45px; top:2px;" class="CoinPreview2" runat="server" ImageUrl="~/images/CoinBacground.png" />
                        <asp:Label ID="Label7" style="z-index:300; position:absolute; right:180px; top:130px;" runat="server"></asp:Label>
                        <br />
                        <br />
                 
                        <asp:Button ID="yes" class="SaveBTN" Width="6em" runat="server" OnClick="yes_Click" Text="מחק" />
                        <asp:Button ID="no" class="CancelBTN" Width="6em" runat="server" OnClick="no_Click" Text="חזור" />
                    </div>
                </div>
                <br />
                <br />
                <br />
            </asp:Panel>


                        <%--הצגת מסיח--%>
            <asp:Panel ID="previewPanel" runat="server">
                <div class="previewBackground"></div>
                <div class="previewmyPanel <%--DelGred--%>">
                    <div>
                        <br />
                        <asp:Label ID="Label4" runat="server" Text="תצוגה מקדימה: "></asp:Label>
                        <br />
                        <br />
                        <br />
<%--                       <asp:ImageButton ID="mycoin" class="CoinPreview2" runat="server" ImageUrl="~/Images/coin.png" Height="140" Width="140" />--%>
                        <div>
                        <asp:Image ID="answerpreview" Style="position:relative; z-index:101; right:3.5px;" CssClass="cropped" class="answerpreview" runat="server" ImageUrl="~/Images/bacground.png" Height="95" Width="95" Enabled="False" />
                                                                                                     <%-- coinEmpty--%>    
                        <asp:Image ID="mycoin" class="CoinPreview2" runat="server" ImageUrl="~/images/CoinBacground.png" />

                        <asp:Label ID="answerText" style="z-index:300; position:absolute; vertical-align: middle; right:100px; top:110px;" runat="server" Text=""></asp:Label>
                     </div>
<%--                        <asp:Image ID="imagetopreview" runat="server" ImageUrl="" Height="80" />--%>
                        <br />
                      
                        <br />
                        <asp:Button ID="Button3" style="position:relative; z-index:150;" class="SaveBTN" Width="6em" runat="server" OnClick="close_Click" Text="חזור" />
                    </div>
                </div>
                <br />
                <br />
                <br />
            </asp:Panel>



        </div>
    </form>
</body>
</html>
