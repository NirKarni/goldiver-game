using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;


public partial class Default2 : System.Web.UI.Page
{
    int mycontrolevar = 0;
    double myDeleteCount = 0;
    double myTextCount = 0;
    double myPicCount = 0;
    string imagesLibPath = "uploadedFiles/";
    string lastimage = "lastimage";
    string myGameCode;
    string lastimagename;
    XmlNode mytopicNode; //topic
    XmlNode myquestionNode; //question
    XmlNode myGameNode;
    string mySelected;
    int AllAnswersCount = 0;
    int CorrectAnswerCount = 0;
    int IncorrectAnswerCount = 0;
    int EditVar = 0;
    XmlDocument xmlDoc = new XmlDocument();
    int TrueAnswerCount;
    int FalseAnswerCount;


    protected void Page_Load(object sender, EventArgs e)
    {
        //if(IsPostBack && myDeleteCount == 1)
        //{
        //    deletePanel.Visible = true;
        //}

        ErrorLabel2.Text = "";
        ErrorLabel.Text = "";

        TrueAnswerCount = (xmlDoc.SelectNodes("//game[@code='" + myGameCode + "']/answer[@correct='true']").Count);
        FalseAnswerCount = (xmlDoc.SelectNodes("//game[@code='" + myGameCode + "']/answer[@correct='false']").Count);

        myGameCode = Session["gameCode"].ToString();
        xmlDoc.Load(Server.MapPath("Trees/XMLFile.xml"));
        myGameNode = xmlDoc.SelectSingleNode("//game[@code='" + myGameCode + "']");
        int myQ = Server.UrlDecode(xmlDoc.SelectSingleNode("//game[@code='" + myGameCode + "']/question").InnerXml).Length;

        int myName = Server.UrlDecode(xmlDoc.SelectSingleNode("//game[@code='" + myGameCode + "']/topic").InnerXml).Length;


        if ((DropDownList1.SelectedValue == "1" && TrueAnswerCount == 8 && FalseAnswerCount == 12) || (DropDownList1.SelectedValue == "2" && TrueAnswerCount == 10 && FalseAnswerCount == 15) || (DropDownList1.SelectedValue == "3" && TrueAnswerCount == 14 && FalseAnswerCount == 21) && myQ >=10 && myName >= 2)
        {
            myV.Visible = true;
            Vlabel.Visible = true;
        }
        else
        {
            myV.Visible = false;
            Vlabel.Visible = false;
        }

        foreach (GridViewRow row in GridView1.Rows)
        {
            string type = ((HiddenField)row.FindControl("HiddenField1")).Value;
            if (type == "text")
            {
                ((Label)row.FindControl("myAnswers")).Visible = true;
                ((ImageButton)row.FindControl("answerImage")).Visible = false;
            }
            else
            {
                string theId = ((ImageButton)row.FindControl("EditBtn")).Attributes["theItemId"];
                string ImageName = xmlDoc.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + theId + "']").Attributes["imagename"].Value;


                ((Label)row.FindControl("myAnswers")).Visible = false;
                ((ImageButton)row.FindControl("answerImage")).Visible = true;
                ((ImageButton)row.FindControl("answerImage")).ImageUrl = imagesLibPath + ImageName;

            }
        }

        foreach (GridViewRow row in GridView2.Rows)
        {
            string type = ((HiddenField)row.FindControl("HiddenField1")).Value;
            if (type == "text")
            {
                ((Label)row.FindControl("myAnswers")).Visible = true;
                ((ImageButton)row.FindControl("answerImage")).Visible = false;
            }
            else
            {
                string theId = ((ImageButton)row.FindControl("EditBtn")).Attributes["theItemId"];
                string ImageName = xmlDoc.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + theId + "']").Attributes["imagename"].Value;


                ((Label)row.FindControl("myAnswers")).Visible = false;
                ((ImageButton)row.FindControl("answerImage")).Visible = true;
                ((ImageButton)row.FindControl("answerImage")).ImageUrl = imagesLibPath + ImageName;
            }
        }





        TrueAnswerCount = (xmlDoc.SelectNodes("//game[@code='" + myGameCode + "']/answer[@correct='true']").Count);
        FalseAnswerCount = (xmlDoc.SelectNodes("//game[@code='" + myGameCode + "']/answer[@correct='false']").Count);

        if (IsPostBack)
        {
            xmlDoc.SelectSingleNode("//game[@code='" + myGameCode + "']/question").Attributes[0].Value = DropDownList1.SelectedValue;
            xmlDoc.Save(Server.MapPath("Trees/XMLFile.xml"));
        }

        //בדיקה של כמות התווים בשביל הצגה ראשונית
        int gamenamecount = gameName.Text.Length;
        nameLbl.Text = gamenamecount.ToString() + "/20";

        //בדיקה של כמות התווים בשביל הצגה ראשונית
        int questioncount = myQuestion.Text.Length;
        questionLbl.Text = questioncount.ToString() + "/100";

        //myQuestion.BorderColor = Color.FromArgb(255, 0, 176, 80);

        //רקע ירוק לtext box
        //not working
        //int myQuestionCount = myQuestion.Text.Length;
        //if (questionLbl.Text == "10/100")
        //{
        //    myQuestion.BorderColor = Color.FromArgb(255, 0, 176, 80);
        //}
        //else if (questionLbl.Text == "0/100")
        //{
        //    myQuestion.BorderColor = Color.FromArgb(255, 197, 90, 17);
        //}


        CorrectAnswerCount = (xmlDoc.SelectNodes("//game[@code='" + myGameCode + "']//answer[@correct='true']").Count);
        IncorrectAnswerCount = (xmlDoc.SelectNodes("//game[@code='" + myGameCode + "']//answer[@correct='false']").Count); ;

        if (DropDownList1.SelectedValue == "1")
        {
            answerCountTrue.Text = CorrectAnswerCount + "/8";
            answerCountFalse.Text = IncorrectAnswerCount + "/12";
            if (CorrectAnswerCount < 8)
            {
                answerCountTrue.Style.Add("color", "#C55A11");
            }
            else
            {
                answerCountTrue.Style.Add("color", "#00B050");
            }

            if (IncorrectAnswerCount < 12)
            {
                answerCountFalse.Style.Add("color", "#C55A11");
            }
            else
            {
                answerCountFalse.Style.Add("color", "#00B050");
            }

        }
        else if (DropDownList1.SelectedValue == "2")
        {
            answerCountTrue.Text = CorrectAnswerCount + "/10";
            answerCountFalse.Text = IncorrectAnswerCount + "/15";

            if (CorrectAnswerCount < 10)
            {
                answerCountTrue.Style.Add("color", "#C55A11");
            }
            else
            {
                answerCountTrue.Style.Add("color", "#00B050");
            }

            if (IncorrectAnswerCount < 15)
            {
                answerCountFalse.Style.Add("color", "#C55A11");
            }
            else
            {
                answerCountFalse.Style.Add("color", "#00B050");
            }
        }
        else
        {
            answerCountTrue.Text = CorrectAnswerCount + "/14";
            answerCountFalse.Text = IncorrectAnswerCount + "/21";

            if (CorrectAnswerCount < 14)
            {
                answerCountTrue.Style.Add("color", "#C55A11");
            }
            else
            {
                answerCountTrue.Style.Add("color", "#00B050");
            }

            if (IncorrectAnswerCount < 21)
            {
                answerCountFalse.Style.Add("color", "#C55A11");
            }
            else
            {
                answerCountFalse.Style.Add("color", "#00B050");
            }
        }


        AllAnswersCount = (xmlDoc.SelectNodes("//game[@code='" + myGameCode + "']//answer").Count);

        deletePanel.Visible = false;
        previewPanel.Visible = false;

        if (IsPostBack)
        {
            mySelected = DropDownList1.SelectedValue;
        }

        if (IsPostBack && myTextCount == 1)
        {
            textPanel.Visible = true;
        }

        if (IsPostBack && myPicCount == 1)
        {
            picturePanel.Visible = true;
        }

        if (!IsPostBack)
        {
            // פאנל יצירת מסיח טקסט
            textPanel.Visible = false;

            // פאנל יצירת מסיח תמונה
            picturePanel.Visible = false;

            // פאנל מחיקת פריט
            deletePanel.Visible = false;
        }

        //myGameCode = Session["gameCode"].ToString();
        //XmlDocument xmlDoc = new XmlDocument();
        //xmlDoc.Load(Server.MapPath("Trees/XMLFile.xml"));

        //myGameNode = xmlDoc.SelectSingleNode("//game[@code='" + myGameCode + "']/topic"); //topic
        //gameName.Text = Server.UrlDecode(myGameNode.InnerXml);
        //gameTopic.Text = Server.UrlDecode(myGameNode.InnerXml);
        //TrueAnswerCount = (xmlDoc.SelectNodes("//game[@code='" + myGameCode + "']/answer[@correct='true']").Count);

        //myQuestion.Text =  TrueAnswerCount.ToString();
        //if (IsPostBack &&  )

        if ((DropDownList1.SelectedValue == "1" && TrueAnswerCount == 8 && FalseAnswerCount == 12) || (DropDownList1.SelectedValue == "2" && TrueAnswerCount == 10 && FalseAnswerCount == 15) || (DropDownList1.SelectedValue == "3" && TrueAnswerCount == 14 && FalseAnswerCount == 21))
        {
            addPicture.Attributes.CssStyle.Add("cursor", "not-allowed");
            addPicture.Attributes.CssStyle.Add("opacity", "0.45");
            addText.Attributes.CssStyle.Add("cursor", "not-allowed");
            addText.Attributes.CssStyle.Add("opacity", "0.45");
        }
        else
        {
            addPicture.Attributes.CssStyle.Remove("cursor");
            addPicture.Attributes.CssStyle.Remove("opacity");
            addText.Attributes.CssStyle.Remove("cursor");
            addText.Attributes.CssStyle.Remove("opacity");
        }


        //מגבלה של הוספת פריטים 
        if ((DropDownList1.SelectedValue == "1" && TrueAnswerCount == 8 && FalseAnswerCount == 12) || (DropDownList1.SelectedValue == "2" && TrueAnswerCount == 10 && FalseAnswerCount == 15) || (DropDownList1.SelectedValue == "3" && TrueAnswerCount == 14 && FalseAnswerCount == 21))
        {
            addPicture.Enabled = false;
            addText.Enabled = false;
        }
        else
        {
            addPicture.Enabled = true;
            addText.Enabled = true;

            if (DropDownList1.SelectedValue == "1" && TrueAnswerCount == 8 && IsPostBack)
            {
                RadioButtonList3.Items[0].Enabled = false;
            }
            else if (DropDownList1.SelectedValue == "2" && TrueAnswerCount == 10 && IsPostBack)
            {
                RadioButtonList3.Items[0].Enabled = false;
            }
            else if (DropDownList1.SelectedValue == "3" && TrueAnswerCount == 14 && IsPostBack)
            {
                RadioButtonList3.Items[0].Enabled = false;
            }
            else if (DropDownList1.SelectedValue == "1" && FalseAnswerCount == 12 && IsPostBack)
            {
                RadioButtonList3.Items[1].Enabled = false;
            }
            else if (DropDownList1.SelectedValue == "2" && FalseAnswerCount == 15 && IsPostBack)
            {
                RadioButtonList3.Items[1].Enabled = false;
            }
            else if (DropDownList1.SelectedValue == "2" && FalseAnswerCount == 21 && IsPostBack)
            {
                RadioButtonList3.Items[1].Enabled = false;
            }


            if (DropDownList1.SelectedValue == "1" && TrueAnswerCount == 8 && IsPostBack)
            {
                RadioButtonList1.Items[0].Enabled = false;
            }
            else if (DropDownList1.SelectedValue == "2" && TrueAnswerCount == 10 && IsPostBack)
            {
                RadioButtonList1.Items[0].Enabled = false;
            }
            else if (DropDownList1.SelectedValue == "3" && TrueAnswerCount == 14 && IsPostBack)
            {
                RadioButtonList1.Items[0].Enabled = false;
            }
            else if (DropDownList1.SelectedValue == "1" && FalseAnswerCount == 12 && IsPostBack)
            {
                RadioButtonList1.Items[1].Enabled = false;
            }
            else if (DropDownList1.SelectedValue == "2" && FalseAnswerCount == 15 && IsPostBack)
            {
                RadioButtonList1.Items[1].Enabled = false;
            }
            else if (DropDownList1.SelectedValue == "2" && FalseAnswerCount == 21 && IsPostBack)
            {
                RadioButtonList1.Items[1].Enabled = false;
            }


        }






    }

    protected void Page_init(object sender, EventArgs e)
    {

        myGameCode = Session["gameCode"].ToString();
        xmlDoc.Load(Server.MapPath("Trees/XMLFile.xml"));
        myGameNode = xmlDoc.SelectSingleNode("//game[@code='" + myGameCode + "']");

        mySelected = xmlDoc.SelectSingleNode("//game[@code='" + myGameCode + "']/question").Attributes[0].Value;
        DropDownList1.SelectedValue = mySelected;

        mytopicNode = xmlDoc.SelectSingleNode("//game[@code='" + myGameCode + "']/topic"); //topic
        gameName.Text = Server.UrlDecode(mytopicNode.InnerXml);
        gameTopic.Text = '\u0022' + Server.UrlDecode(mytopicNode.InnerXml) + '\u0022';

        myquestionNode = xmlDoc.SelectSingleNode("//game[@code='" + myGameCode + "']/question");
        myQuestion.Text = Server.UrlDecode(myquestionNode.InnerXml);

        XmlDataSource1.XPath = "/gameRoot/game[@code=" + myGameCode + "]/answer[@correct='true']";
        XmlDataSource2.XPath = "/gameRoot/game[@code='" + myGameCode + "']/answer[@correct='false']";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void addPicture_Click(object sender, ImageClickEventArgs e)
    {
        picturePanel.Visible = true;
        myPicCount = 1;
    }

    protected void addText_Click(object sender, ImageClickEventArgs e)
    {
        textPanel.Visible = true;
        myTextCount = 1;
    }


    //----------------------פאנל הוספת מסיח טקסט--------------------------//
    protected void savetext_Click(object sender, EventArgs e)
    {
        EditVar = Convert.ToInt16(Session["EditSession"]);
        // פונקציית יצירת מסיח
        if (mytextAnswerTB.Text != "" && (RadioButtonList3.SelectedValue == "true" || RadioButtonList3.SelectedValue == "false"))
        {
            if (EditVar == 1)
            {
                EditTextAnswer();
                myTextCount = 0;
                Response.Redirect("Edit.aspx");
            }
            else
            {
                CreatNewTextAnswer();
                myTextCount = 0;
                Response.Redirect("Edit.aspx");
            }
        }
        else if (mytextAnswerTB.Text == "" && (RadioButtonList3.SelectedValue == "true" || RadioButtonList3.SelectedValue == "false"))
        {
            ErrorLabel.Text = "חסר טקסט";
            myTextCount = 1;
        }
        else if (mytextAnswerTB.Text != "" && RadioButtonList3.SelectedValue == "")
        {
            ErrorLabel.Text = "חסר סימון בנכונות המסיח";
            myTextCount = 1;
        }
        else
        {
            ErrorLabel.Text = "חסר סימון בנכונות המסיח וחסר טקסט";
            myTextCount = 1;
        }
        //Response.Redirect("Edit.aspx");
    }

    // כפתור ביטול
    protected void canceltext_Click(object sender, EventArgs e)
    {
        // העלמת הפאנל של מחיקת משחק
        textPanel.Visible = false;
        mytextAnswerTB.Text = "";
        EditVar = 0;
        Session["EditSession"] = EditVar;
    }



    //----------------------פאנל הוספת מסיח תמונה--------------------------//
    protected void savepicture_Click(object sender, EventArgs e)
    {
        EditVar = Convert.ToInt16(Session["EditSession"]);
        if ((RadioButtonList1.SelectedValue == "true" || RadioButtonList1.SelectedValue == "false") && FileUpload1.HasFile)// && ImageforUpload1.ImageUrl != "~/images/ImagePlaceholder.png") --> how to check if the url changed???
        {
            // פונקציית יצירת מסיח
            if (EditVar == 1)
            {
                EditPictureAnswer();
                myPicCount = 0;
                Response.Redirect("Edit.aspx");
            }
            else
            {
                CreatNewImageAnswer();
                myPicCount = 0;
                Response.Redirect("Edit.aspx");
            }
        }
        else if (RadioButtonList1.SelectedValue == "" && FileUpload1.HasFile)
        {
            //myimageAnswerTB.Text = "missing items";

            ErrorLabel2.Text = "חסר סימון בנכונות המסיח";
        }
        else if ((RadioButtonList1.SelectedValue == "true" || RadioButtonList1.SelectedValue == "false") && FileUpload1.HasFile == false)
        {
            ErrorLabel2.Text = "חסרה תמונה";
        }
        else
        {
            ErrorLabel2.Text = "חסרה תמונה וחסר סימון בנכונות המסיח";
        }
        //Response.Redirect("Edit.aspx");
    }


    // כפתור ביטול
    protected void cancelpicture_Click(object sender, EventArgs e)
    {
        // העלמת הפאנל של מחיקת משחק
        picturePanel.Visible = false;
        myimageAnswerTB.Text = "";
        EditVar = 0;
        Session["EditSession"] = EditVar;
    }

    protected void EditTextAnswer()
    {
        int theId = Convert.ToInt16(Session["AnswerID"]);

        XmlNode answertoedit = myGameNode.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + theId + "']");
        answertoedit.InnerXml = Server.UrlEncode(mytextAnswerTB.Text);
        answertoedit.Attributes["correct"].Value = RadioButtonList3.SelectedValue; ;
        //myGameNode.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + theId + "']").Attributes["correct"].Value = RadioButtonList3.SelectedValue;
        xmlDoc.Save(Server.MapPath("Trees/XMLFile.xml"));
        GridView1.DataBind();
        GridView2.DataBind();
        textPanel.Visible = false;
        EditVar = 0;
        Session["EditSession"] = EditVar;
    }

    protected void EditPictureAnswer()
    {
        int theId = Convert.ToInt16(Session["AnswerID"]);

        XmlNode answertoedit = myGameNode.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + theId + "']");


        if (answertoedit.InnerXml == "")
        {
            answertoedit.InnerXml = "";
        }
        else
        {
            answertoedit.InnerXml = Server.UrlEncode(myimageAnswerTB.Text);
        }
        answertoedit.Attributes["correct"].Value = RadioButtonList1.SelectedValue; ;
        xmlDoc.Save(Server.MapPath("Trees/XMLFile.xml"));

        GridView1.DataBind();
        GridView2.DataBind();

        Upload();
        string imageName = lastimagename; //.Substring(12)

        string filename = myGameNode.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + theId + "']").Attributes["imagename"].Value;
        string filePath = Server.MapPath(imagesLibPath + filename);
        System.IO.File.Delete(filePath);

        myGameNode.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + theId + "']").Attributes["imagename"].Value = imageName;

        picturePanel.Visible = false;
        EditVar = 0;
        Session["EditSession"] = EditVar;

    }

    protected void CreatNewTextAnswer()
    {

        // בדיקה האם קיימות תשובות במשחק

        AllAnswersCount = (xmlDoc.SelectNodes("//game[@code='" + myGameCode + "']//answer").Count);

        //איידי לשאלה חדשה
        string AnswersID = "1";

        // אם יש תשובות
        if (AllAnswersCount != 0)
        {
            int MaxID = Convert.ToInt16(xmlDoc.SelectSingleNode("//answer[not(@id < //game[@code='" + myGameCode + "']//answer/@id)]/@id").Value);

            MaxID++;
            AnswersID = MaxID.ToString();
        }

        XmlElement myAnswerNode = xmlDoc.CreateElement("answer");
        myAnswerNode.SetAttribute("id", AnswersID);

        if (RadioButtonList3.SelectedValue == "true")
        {
            myAnswerNode.SetAttribute("correct", "true");
        }
        else
        {
            myAnswerNode.SetAttribute("correct", "false");
        }
        myAnswerNode.InnerXml = Server.UrlEncode(mytextAnswerTB.Text);
        myAnswerNode.SetAttribute("type", "text");
        myAnswerNode.SetAttribute("imagename", "");


        //if (RadioButtonList3.SelectedValue == "true")
        //{
        //    xmlDoc.SelectSingleNode("//game[@code='" + myGameCode + "']/True").AppendChild(myAnswerNode);
        //}
        //else
        //{
        //    xmlDoc.SelectSingleNode("//game[@code='" + myGameCode + "']/False").AppendChild(myAnswerNode);
        //}

        mytextAnswerTB.Text = "";
        //RadioButtonList3.SelectedIndex = -1; //מנקה את הבחירה

        myGameNode.AppendChild(myAnswerNode);
        xmlDoc.Save(Server.MapPath("Trees/XMLFile.xml"));
        textPanel.Visible = false;
        XmlDataSource1.Save();
        XmlDataSource2.Save();
        GridView1.DataBind();
        GridView2.DataBind();
    }

    protected void CreatNewImageAnswer()
    {

        AllAnswersCount = (xmlDoc.SelectNodes("//game[@code='" + myGameCode + "']//answer").Count);

        //איידי לשאלה חדשה
        string AnswersID = "1";

        // אם יש תשובות
        if (AllAnswersCount != 0)
        {
            int MaxID = Convert.ToInt16(xmlDoc.SelectSingleNode("//answer[not(@id < //game[@code='" + myGameCode + "']//answer/@id)]/@id").Value);

            MaxID++;
            AnswersID = MaxID.ToString();
        }

        Upload();
        //string imagePath = ImageAnswer.ImageUrl;

        string imageName = lastimagename; //.Substring(12)

        // יצירת ענף תשובה 
        XmlElement myAnswerNode = xmlDoc.CreateElement("answer");
        myAnswerNode.SetAttribute("id", AnswersID);
        if (RadioButtonList1.SelectedValue == "true")
        {
            myAnswerNode.SetAttribute("correct", "true");
        }
        else
        {
            myAnswerNode.SetAttribute("correct", "false");
        }
        myAnswerNode.InnerXml = Server.UrlEncode(myimageAnswerTB.Text);
        myAnswerNode.SetAttribute("type", "picture");
        myAnswerNode.SetAttribute("imagename", imageName); ///////imageName/////// to continue from here beacause its not working

        xmlDoc.SelectSingleNode("//game[@code='" + myGameCode + "']").AppendChild(myAnswerNode);

        myimageAnswerTB.Text = "";

        picturePanel.Visible = false;
        // myGameNode.AppendChild(myAnswerNode);
        xmlDoc.Save(Server.MapPath("Trees/XMLFile.xml"));
        XmlDataSource1.Save();
        XmlDataSource2.Save();
        GridView1.DataBind();
        GridView2.DataBind();
    }

    protected void saveBTN_Click1(object sender, EventArgs e)
    {
        xmlDoc.Load(Server.MapPath("Trees/XMLFile.xml"));

        // לקיחת הערכים שהמשתמש הכניס בתיבות טקסט והכנסתם לעץ 
        xmlDoc.SelectNodes("//game[@code='" + myGameCode + "']").Item(0).ChildNodes[0].InnerXml = Server.UrlEncode(myQuestion.Text);
        xmlDoc.SelectNodes("//game[@code='" + myGameCode + "']").Item(0).ChildNodes[1].InnerXml = Server.UrlEncode(gameName.Text);

        myimageAnswerTB.Text = "";
        // RadioButtonList1.SelectedValue = ;

        // שמירת העץ החדש
        xmlDoc.Save(Server.MapPath("Trees/XMLFile.xml"));
        Response.Redirect("Edit.aspx");
    }

    protected void lastimagesave()
    {
        string fileType = FileUpload1.PostedFile.ContentType;
        if (fileType.Contains("image")) //בדיקה האם הקובץ שהוכנס הוא תמונה
        {
            //שמירת הנתיב המלא של הקובץ       
            string fileName = FileUpload1.PostedFile.FileName;
            // הסיומת של הקובץ       
            string endOfFileName = fileName.Substring(fileName.LastIndexOf("."));
            //מתן זמן לתמונה למניעת כפילות       
            string myTime = DateTime.Now.ToString("dd_MM_yy-HH_mm_ss_ffff");
            // חיבור השם החדש עם הזמן והסיומת של הקובץ       
            string imageNewName = "imageNewName" + myTime + endOfFileName;
            //שמירה של הקובץ לספרייה בשם החדש שלו        
            FileUpload1.PostedFile.SaveAs(Server.MapPath(imagesLibPath) + imageNewName);
            //הצגה של הקובץ החדש מהספרייה
            // ImageAnswer.ImageUrl = imagesLibPath + imageNewName;
            lastimagename = imageNewName;
        }
        else
        {
            Label3.Text = "הקובץ אינו תמונה ולכן לא ניתן להעלות אותו";
        }

    }

    protected void Upload()
    {
        string fileType = FileUpload1.PostedFile.ContentType;
        if (fileType.Contains("image")) //בדיקה האם הקובץ שהוכנס הוא תמונה
        {
            //שמירת הנתיב המלא של הקובץ       
            string fileName = FileUpload1.PostedFile.FileName;
            // הסיומת של הקובץ       
            string endOfFileName = fileName.Substring(fileName.LastIndexOf("."));
            //מתן זמן לתמונה למניעת כפילות       
            string myTime = DateTime.Now.ToString("dd_MM_yy-HH_mm_ss_ffff");
            // חיבור השם החדש עם הזמן והסיומת של הקובץ       
            string imageNewName = "imageNewName" + myTime + endOfFileName;


            // Bitmap המרת הקובץ שיתקבל למשתנה מסוג
            System.Drawing.Bitmap bmpPostedImage = new System.Drawing.Bitmap(FileUpload1.PostedFile.InputStream);

            //קריאה לפונקציה המקטינה את התמונה
            //אנו שולחים לה את התמונה שלנו בגירסאת הביטמאפ ואת האורך והרוחב שאנו רוצים לתמונה החדשה
            System.Drawing.Image objImage = FixedSize(bmpPostedImage, 80, 80);



            //שמירה של הקובץ לספרייה בשם החדש שלו        
            objImage.Save(Server.MapPath(imagesLibPath) + imageNewName);
            //הצגה של הקובץ החדש מהספרייה
            // ImageAnswer.ImageUrl = imagesLibPath + imageNewName;
            lastimagename = imageNewName;


        }
        else
        {
            Label3.Text = "הקובץ אינו תמונה ולכן לא ניתן להעלות אותו";
        }

    }

    static System.Drawing.Image FixedSize(System.Drawing.Image imgPhoto, int Width, int Height)
    {
        int sourceWidth = Convert.ToInt32(imgPhoto.Width);
        int sourceHeight = Convert.ToInt32(imgPhoto.Height);

        int sourceX = 0;
        int sourceY = 0;
        int destX = 0;
        int destY = 0;

        float nPercent = 0;
        float nPercentW = 0;
        float nPercentH = 0;

        nPercentW = ((float)Width / (float)sourceWidth);
        nPercentH = ((float)Height / (float)sourceHeight);
        if (nPercentH < nPercentW)
        {
            nPercent = nPercentH;
            destX = System.Convert.ToInt16((Width -
                          (sourceWidth * nPercent)) / 2);
        }
        else
        {
            nPercent = nPercentW;
            destY = System.Convert.ToInt16((Height -
                          (sourceHeight * nPercent)) / 2);
        }

        int destWidth = (int)(sourceWidth * nPercent);
        int destHeight = (int)(sourceHeight * nPercent);

        System.Drawing.Bitmap bmPhoto = new System.Drawing.Bitmap(Width, Height,
                          PixelFormat.Format24bppRgb);
        bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                         imgPhoto.VerticalResolution);

        System.Drawing.Graphics grPhoto = System.Drawing.Graphics.FromImage(bmPhoto);
        grPhoto.Clear(System.Drawing.Color.White);
        grPhoto.InterpolationMode =
                InterpolationMode.HighQualityBicubic;
        grPhoto.CompositingQuality = CompositingQuality.HighQuality;  //------------------------>
        grPhoto.SmoothingMode = SmoothingMode.HighQuality;
        grPhoto.PixelOffsetMode = PixelOffsetMode.HighQuality;
        grPhoto.CompositingMode = CompositingMode.SourceCopy;

        grPhoto.DrawImage(imgPhoto,
            new System.Drawing.Rectangle(destX, destY, destWidth, destHeight),
            new System.Drawing.Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
            System.Drawing.GraphicsUnit.Pixel);

        grPhoto.Dispose();
        return bmPhoto;
    }



    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ImageButton i = (ImageButton)e.CommandSource;
        string theId = i.Attributes["theItemId"];
        Session["AnswerID"] = theId;
        Labeldelete.Text = " למחוק את המסיח"+ "&nbsp;" + Server.UrlDecode(myGameNode.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + theId + "']").InnerXml) + "?";
        string AnswerType = xmlDoc.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + theId + "']").Attributes[2].Value;


        switch (e.CommandName)
        {
            //אם נלחץ על כפתור מחיקה יקרא לפונקציה של מחיקה                    
            case "deleteRow":
                deletePanel.Visible = true;
                answerText.Text = "";
                if (xmlDoc.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + theId + "']").Attributes["type"].Value == "picture")
                {
                    //answerpreview.Visible = true;
                    string filename = myGameNode.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + theId + "']").Attributes["imagename"].Value;
                    //string filePath = Server.MapPath(imagesLibPath + "imageNewName" + filename);
                    ImageButton1.ImageUrl = imagesLibPath + filename;
                    Label7.Text = "";
                }
                else
                {
                    ImageButton1.ImageUrl = ""; ///images/bacground.png
                    // answerpreview.Visible = false;
                    //להוסיף רקע ל-url
                    Label7.Text = Server.UrlDecode(xmlDoc.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + theId + "']").InnerXml);
                }
                break;

            case "previewRow":
                previewImage();
                previewPanel.Visible = true;
                break;

            //אם נלחץ על כפתור עריכה (העפרון) נעבור לעריכת המסיח                    
            case "editRow":
                EditVar = 1;
                Session["EditSession"] = EditVar;
                if (AnswerType == "picture")
                {
                    picturePanel.Visible = true;
                    if (xmlDoc.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + theId + "']").InnerXml == null)
                    {
                        myimageAnswerTB.Text = "";
                    }
                    else
                    {
                        myimageAnswerTB.Text = Server.UrlDecode(xmlDoc.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + theId + "']").InnerXml);

                    }
                    if (xmlDoc.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + theId + "']").Attributes[1].Value == "true")
                    {
                        RadioButtonList1.SelectedValue = "true";
                    }
                    else
                    {
                        RadioButtonList1.SelectedValue = "false";
                    }
                    string ImageName = xmlDoc.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + theId + "']").Attributes["imagename"].Value;
                    ImageforUpload1.ImageUrl = imagesLibPath + ImageName;
                }
                else if (AnswerType == "text")
                {
                    textPanel.Visible = true;
                    mytextAnswerTB.Text = Server.UrlDecode(xmlDoc.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + theId + "']").InnerXml);
                    if (xmlDoc.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + theId + "']").Attributes[1].Value == "true")
                    {
                        RadioButtonList3.SelectedValue = "true";
                    }
                    else
                    {
                        RadioButtonList3.SelectedValue = "false";
                    }
                }
                break;
        }

    }



    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ImageButton i = (ImageButton)e.CommandSource;
        string theId = i.Attributes["theItemId"];
        Session["AnswerID"] = theId;
        Labeldelete.Text = " למחוק את המסיח" + "&nbsp;" + Server.UrlDecode(myGameNode.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + theId + "']").InnerXml) + "?";
        string AnswerType = xmlDoc.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + theId + "']").Attributes[2].Value;

        switch (e.CommandName)
        {
            //אם נלחץ על כפתור מחיקה יקרא לפונקציה של מחיקה                    
            case "deleteRow":
                deletePanel.Visible = true;
                answerText.Text = "";
                if (xmlDoc.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + theId + "']").Attributes["type"].Value == "picture")
                {
                    //answerpreview.Visible = true;
                    string filename = myGameNode.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + theId + "']").Attributes["imagename"].Value;
                    //string filePath = Server.MapPath(imagesLibPath + "imageNewName" + filename);
                    ImageButton1.ImageUrl = imagesLibPath + filename;
                    Label7.Text = "";
                }
                else
                {
                    ImageButton1.ImageUrl = ""; ///images/bacground.png
                    // answerpreview.Visible = false;
                    //להוסיף רקע ל-url
                    Label7.Text = Server.UrlDecode(xmlDoc.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + theId + "']").InnerXml);
                }
                break;

            case "previewRow":
                previewImage();
                previewPanel.Visible = true;
                break;

            //אם נלחץ על כפתור עריכה (העפרון) נעבור לעריכת המסיח                   
            case "editRow":
                EditVar = 1;
                Session["EditSession"] = EditVar;
                if (AnswerType == "picture")
                {
                    picturePanel.Visible = true;      // need to work on how to preview the picture!!!!!
                    if (xmlDoc.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + theId + "']").InnerXml == null)
                    {
                        myimageAnswerTB.Text = "";
                    }
                    else
                    {
                        myimageAnswerTB.Text = Server.UrlDecode(xmlDoc.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + theId + "']").InnerXml);

                    }
                    if (xmlDoc.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + theId + "']").Attributes[1].Value == "true")
                    {
                        RadioButtonList1.SelectedValue = "true";
                    }
                    else
                    {
                        RadioButtonList1.SelectedValue = "false";
                    }
                    string ImageName = xmlDoc.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + theId + "']").Attributes["imagename"].Value;
                    ImageforUpload1.ImageUrl = imagesLibPath + ImageName;

                }
                else if (AnswerType == "text")
                {
                    textPanel.Visible = true;
                    mytextAnswerTB.Text = Server.UrlDecode(xmlDoc.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + theId + "']").InnerXml);
                    if (xmlDoc.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + theId + "']").Attributes[1].Value == "true")
                    {
                        RadioButtonList3.SelectedValue = "true";
                    }
                    else
                    {
                        RadioButtonList3.SelectedValue = "false";
                    }
                }
                break;
        }

    }


    // כפתור מחק
    protected void yes_Click(object sender, EventArgs e)
    {
        // פונקציית מחיקת משחק
        deleteRow();
        Response.Redirect("Edit.aspx");
    }

    // כפתור לא למחוק
    protected void no_Click(object sender, EventArgs e)
    {
        // העלמת הפאנל של מחיקת משחק
        deletePanel.Visible = false;
    }


    protected void deleteRow()
    {


        string answerCodeToDelete = Session["AnswerID"].ToString();
        XmlDocument Document = XmlDataSource1.GetXmlDocument();
        XmlNode node = Document.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + answerCodeToDelete + "']");

        if (Document.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + answerCodeToDelete + "']/@type").Value == "picture")
        {
            string filename = myGameNode.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + answerCodeToDelete + "']").Attributes["imagename"].Value;
            string filePath = Server.MapPath(imagesLibPath + filename);
            System.IO.File.Delete(filePath);
        }

        node.ParentNode.RemoveChild(node);

        XmlDataSource1.Save();
        XmlDataSource2.Save();
        GridView1.DataBind();
        GridView2.DataBind();
    }

    //הצגת המסיח
    protected void previewImage()
    {
        string theId = Session["AnswerID"].ToString();
        answerText.Text = "";
        if (xmlDoc.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + theId + "']").Attributes["type"].Value == "picture")
        {
            //answerpreview.Visible = true;
            string filename = myGameNode.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + theId + "']").Attributes["imagename"].Value;
            //string filePath = Server.MapPath(imagesLibPath + "imageNewName" + filename);
            answerpreview.ImageUrl = imagesLibPath + filename;
        }
        else
        {
            answerpreview.ImageUrl = ""; ///images/bacground.png
           // answerpreview.Visible = false;
            //להוסיף רקע ל-url
            answerText.Text = Server.UrlDecode(xmlDoc.SelectSingleNode("/gameRoot/game[@code='" + myGameCode + "']//answer[@id='" + theId + "']").InnerXml);
        }

    }

    //סגירת פאנל ההצגה
    protected void close_Click(object sender, EventArgs e)
    {
        previewPanel.Visible = false;
    }
}