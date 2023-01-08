<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
    <%--CSS--%>
    <%--<link href="Styles/reset.css" rel="stylesheet" type="text/css" />--%>
    <link href="Styles/myStyle.css" rel="stylesheet" type="text/css" />
    <%--Scripts--%>
    <script src="jScripts/jquery-1.12.0.min.js" type="text/javascript"></script>
    <!--הקוד שמפעיל את תפריט הניווט-->
    <script src="jScripts/myScript.js"></script>


</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            

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
                <%--<p>--%>
                <img src="images/about.png" class="information" />
                <div class="sound"><a href="https://freemusicarchive.org/music/Scanglobe/fade-remix/undulation-remix">Scanglobe </a></div>
                <div class="telem"><a href="https://www.hit.ac.il/telem/overview">הפקולטה לטכנולוגיות למידה</a> </div>
                <%--</p>--%>
            </div>
            <div id="howToPlayDiv" class="popUp bounceInDown hide">
                <a class="closeHowToPlay">
                    <img src="images/exit.png" class="exit" />
                </a>

                <p>
                    <img src="images/howtoplay2.png" class="instructions" />
                </p>

            </div>



            <%--        כותרת המשחק:
        <asp:TextBox ID="myTopicTB" runat="server"></asp:TextBox>--%>
            <br />
            <br />
            <br />
            <br />

            <div class="bigSizeFont" style=" position:relative; right:10%;">מאגר המשחקים</div>
            <div class="ltr">
                <asp:Button class="CreatGameBTN" ID="CreatGame" runat="server" style=" position:relative; right:40%; top:-46px;" Text="יצירת משחק חדש" OnClick="CreatGame_Click" />
                <div style="font-size:23pt; font-weight:normal; position:relative; top:-88px; right:41.3%; width:10px;">+</div>
            </div>
            <div style="position: relative; right: 15%!important;">
<%--            <asp:ImageButton ID="ImageButton1" src="icons/plus.png" class="" runat="server" Style="position: relative; right:58%; top: -92px; opacity: 0.8;" OnClick="CreatGame_Click" Height="40" Width="40" />--%>
            <%--        שאלת המשחק:
        <asp:TextBox ID="myQuestionTB" runat="server"></asp:TextBox>--%>

            <%--        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/add.png" Height="104px" Width="111px" OnClick="ImageButton1_Click" />--%>
                            <asp:Label ID="noGames" runat="server" Style="font-size:24px; position:relative; right:400px; top:250px;" Text="אין משחקים במאגר, לחצו על יצירת משחק חדש  כדי ליצור אחד"></asp:Label>

            <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/Trees/XMLFile.xml" XPath="/gameRoot/game"></asp:XmlDataSource>
            <asp:GridView ID="GridView1" HorizontalAlign="Center" class="gridList" runat="server" AutoGenerateColumns="False" DataSourceID="XmlDataSource1" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnRowCommand="GridView1_RowCommand" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                <Columns>
                    <asp:TemplateField HeaderText=" &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;שם המשחק" ControlStyle-Width="200">
                        <ItemTemplate>
                            <asp:Label ID="myNameTxt" runat="server" style="padding-right:30px;" Text='<%#Server.UrlDecode(XPathBinder.Eval(Container.DataItem, "topic").ToString())%>'></asp:Label>
<%--                         style="padding-right:30px;"--%>
                        </ItemTemplate>

<ControlStyle Width="200px"></ControlStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="קוד המשחק">
                        <ItemTemplate>
                            <asp:Label ID="myIDTxt" style="padding-right:30px;" runat="server" Text='<%#XPathBinder.Eval(Container.DataItem, "@code").ToString()%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="עריכה">
                        <ItemTemplate>
                            <asp:ImageButton ID="EditBtn" runat="server" ImageUrl="~/images/edit2.png" CommandName="editRow" theItemId='<%#XPathBinder.Eval(Container.DataItem, "@code").ToString()%>' Height="45" Width="45" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="מחיקה">
                        <ItemTemplate>
                            <asp:ImageButton ID="DeleteBtn" runat="server" ImageUrl="~/images/delete2.png" CommandName="deleteRow" theItemId='<%#XPathBinder.Eval(Container.DataItem, "@code").ToString()%>' Height="45" Width="45" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="פרסום">
                        <ItemTemplate>
<%--                            <asp:Panel ID="Panel1" runat="server">--%>
                            <div class="tooltip3">
                                <asp:CheckBox ID="IsPublishedCB" class="checkboxresize" AutoPostBack="True" OnCheckedChanged="IsPublishedCB_CheckedChanged" runat="server" theItemId='<%#XPathBinder.Eval(Container.DataItem, "@code").ToString()%>' Checked='<%#Convert.ToBoolean(XPathBinder.Eval(Container.DataItem,"@ispublished"))%>'  />
<%--                            </asp:Panel>--%>
<%--                                <span class="tooltiptext3">Tooltip text </span>--%>
                                <asp:Label ID="myToolTip" CssClass="" runat="server" Text=""></asp:Label>
                                </div>
</div>

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#F2F2F2" Font-Bold="True" ForeColor="black"  Height="50" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>



            <%--  יצירת  משחק--%>
            <asp:Panel class="createPanel" ID="createPanel" runat="server">
                <div class="background0"></div>
                <div class="PopUpAll CreatGred">
                    <div class="createPanelBox">
                        <br />
                        <br />
                        <asp:Label ID="Label1" runat="server" font-size="14pt" Text="שם המשחק: "></asp:Label><br />
                        <asp:Label ID="Label2" runat="server" color="#7f7f7fc9" font-Italic="true" Font-Size="12pt" Text="שם המשחק יופיע בחלק הימני העליון של מסך המשחק "></asp:Label>
                        <br />
                        <br />
                        <asp:TextBox ID="myTopicTB" CharacterLimit="20" CharacterForLabel="QuestLbl" placeholder="לדוגמא: בעלי חיים" CssClass="CharacterCount" runat="server"></asp:TextBox>                       
                       
<%--                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>--%>
                        <br />
                        <asp:Label ID="QuestLbl" Style="position: absolute; right: 125px;" runat="server" Text="0/20"></asp:Label>
                        <br />
                        <br />
                        <asp:Button ID="Button1" class="disabledbtn" Width="6em" runat="server" OnClick="save_Click" Text="שמור" Enabled="True" />
                        <asp:Button ID="Button2" class="CancelBTN" Width="6em" runat="server" OnClick="cancel_Click" Text="ביטול" />
                    </div>
                </div>
                <br />
                <br />
                <br />
            </asp:Panel>





            <%--הגנה למחיקת משחק--%>
            <asp:Panel class="deletePanel" ID="deletePanel" runat="server">
                <div class="background1"></div>
                <div class="PopUpAll DelGred">
                    <div class="deletePanelBox">
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="Labeldelete" runat="server" font-size="20pt" Text="האם למחוק את המשחק"></asp:Label>
                        <asp:Label ID="Label3" runat="server" font-bold="true" font-size="20pt" Text=""></asp:Label><span id="questionmark">?</span>
                        <br />
                        <br />
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


            <br />
            <br />
        </div>
            </div>
    </form>
</body>
</html>
