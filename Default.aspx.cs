using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Drawing;



public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // פאנל מחיקה
        deletePanel.Visible = false;

        // פאנל מחיקה
        createPanel.Visible = false;

        XmlDocument myDoc = XmlDataSource1.GetXmlDocument();
        int countgames = Convert.ToInt16(myDoc.SelectNodes("//game").Count);

        if (countgames == 0)
        {
            noGames.Visible = true;
        }
        else
        {
            noGames.Visible = false;
        }


        checkAllGamePublish();

    }


    // -----------------------------------------------------להוסיף שאלה ושם
    protected void checkAllGamePublish()
    {
        XmlDocument myDoc = XmlDataSource1.GetXmlDocument();
        foreach (GridViewRow row in GridView1.Rows)
        {
            //חיפוש הלייבל שבו מופיע ה ID של המשחק
            Label gameCodeLbl = (Label)row.FindControl("myIDTxt");
            //בעזרת האי-די של המשחק נוכל לבדוק האם עומד בתנאי הפרסום
            string GameCode = gameCodeLbl.Text;

            int distructorAmount = Convert.ToInt16(myDoc.SelectSingleNode("//game[@code='" + GameCode + "']/question").Attributes["distructorsamount"].Value);
            int counterQ = Convert.ToInt16(myDoc.SelectNodes("//game[@code='" + GameCode + "']//answer").Count);

            // אורך שם המשחק
            string myTopic = (myDoc.SelectSingleNode("//game[@code='" + GameCode + "']//topic").InnerXml).ToString();
            int myTopicLen = myTopic.Length;

            //אורך השאלה
            string myQuestion = (myDoc.SelectSingleNode("//game[@code='" + GameCode + "']//question").InnerXml).ToString();
            int myQuestionLen = myQuestion.Length;

            //חיפוש הצ'אק-בוקס על פי האי-די שלו
            CheckBox GameIsPublishCb = (CheckBox)row.FindControl("IsPublishedCB");
            Label mytooltip = (Label)row.FindControl("myToolTip");

            if ((counterQ == 25 && distructorAmount == 2 && myTopicLen >= 2 && myQuestionLen >= 10) || (counterQ == 20 && distructorAmount == 1 && myTopicLen >= 2 && myQuestionLen >= 10) || (counterQ == 35 && distructorAmount == 3 && myTopicLen >= 2 && myQuestionLen >= 10))
            {
                GameIsPublishCb.Enabled = true;
                mytooltip.CssClass = "";
            }
            else
            {
                GameIsPublishCb.Enabled = false;

                GameIsPublishCb.Attributes.CssStyle.Add("position", "relative");
                GameIsPublishCb.Attributes.CssStyle.Add("right", "10px");
                GameIsPublishCb.Attributes.CssStyle.Add("top", "2.5px");

                mytooltip.CssClass = "tooltiptext3";
                if ((myTopic == "" || myTopicLen <=1) && (myQuestion == "" || myQuestionLen <=9) && ((counterQ <= 24 && distructorAmount == 2) || (counterQ <= 19 && distructorAmount == 1) || (counterQ <= 34 && distructorAmount == 3)))
                {
                    mytooltip.Text = "שם המשחק, קטגוריה לזיהוי וכמות המסיחים לא לא עומדים בדרישות הפרסום";
                }
                else if ((myTopic == "" || myTopicLen <= 1) && (myQuestion == "" || myQuestionLen <= 9))
                {
                    mytooltip.Text = "שם המשחק והקטגוריה לזיהוי לא עומדים בדרישות הפרסום";
                }
                else if (((counterQ <= 24 && distructorAmount == 2) || (counterQ <= 19 && distructorAmount == 1) || (counterQ <= 34 && distructorAmount == 3)) && (myTopic == "" || myTopicLen <= 1))
                {
                    mytooltip.Text = "שם המשחק וכמות המסיחים לא עומדים בדרישות הפרסום";
                }
                else if (((counterQ <= 24 && distructorAmount == 2) || (counterQ <= 19 && distructorAmount == 1) || (counterQ <= 34 && distructorAmount == 3)) && (myQuestion == "" || myQuestionLen <= 9))
                {
                    mytooltip.Text = "קטגוריה לזיהוי וכמות המסיחים לא עומדים בדרישות הפרסום";
                }
                else if (((counterQ <= 24 && distructorAmount == 2) || (counterQ <= 19 && distructorAmount == 1) || (counterQ <= 34 && distructorAmount == 3)))
                {
                    mytooltip.Text = "כמות המסיחים לא עומדת בדרישות הפרסום";
                }
                else if ((myTopic == "" || myTopicLen <= 1))
                {
                    mytooltip.Text = "שם המשחק לא עומד בדרישות הפרסום";
                }
                else if ((myQuestion == "" || myQuestionLen <= 9))
                {
                    mytooltip.Text = "קטגוריה לזיהוי לא עומדת בדרישות הפרסום";
                }

               // mytooltip.Text = "WTF!!!";
                //tooltipdiv.Style = "hom_but_a";
                //tooltipdiv.Attributes("class") = "classToAdd";

                //אם מקודם המשחק היה מפורסם, אנחנו רוצים להחזיר אותו ללא מפורסם בעץ
                XmlNode IsPublish = myDoc.SelectSingleNode("/gameRoot/game[@code='" + GameCode + "']");
                IsPublish.Attributes["ispublished"].InnerXml = "False";
                XmlDataSource1.Save();

                //וגם לשנות את הפקד עצמו ללא לחוץ
                GameIsPublishCb.Checked = false;
            }

        }

    }


    protected void IsPublishedCB_CheckedChanged(object sender, EventArgs e)
    {
        XmlDocument xmlDoc = XmlDataSource1.GetXmlDocument();

        CheckBox myCheckBox = (CheckBox)sender;

        string theId = myCheckBox.Attributes["theItemId"];

        XmlNode theGame = xmlDoc.SelectSingleNode("/gameRoot/game[@code=" + theId + "]");
        
        //קבלת הערך החדש של התיבה לאחר הלחיצה
        bool NewPublished = myCheckBox.Checked;

        //עדכון של המאפיין בעץ
        theGame.Attributes["ispublished"].InnerText = NewPublished.ToString();

        XmlDataSource1.Save();
        GridView1.DataBind();
        checkAllGamePublish();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        XmlDocument xmlDoc = XmlDataSource1.GetXmlDocument();      
        ImageButton i = (ImageButton)e.CommandSource;
        string theId = i.Attributes["theItemId"];
        Session["gameCode"] = theId;
        string deletename = Server.UrlDecode(xmlDoc.SelectSingleNode("/gameRoot/game[@code=" + theId + "]/topic").InnerXml);

        switch (e.CommandName)
        {
            //אם נלחץ על כפתור מחיקה יקרא לפונקציה של מחיקה                    
            case "deleteRow":
                deletePanel.Visible = true;
                Label3.Text = deletename;
                break;

            //אם נלחץ על כפתור עריכה (העפרון) נעבור לדף עריכה                    
            case "editRow":

                Response.Redirect("Edit.aspx");
                break;
        }

    }
    protected void deleteRow()
    {

        string gameCodeToDelete = Session["gameCode"].ToString();
        XmlDocument Document = XmlDataSource1.GetXmlDocument();
        XmlNode node = Document.SelectSingleNode("/gameRoot/game[@code='" + gameCodeToDelete + "']");
        node.ParentNode.RemoveChild(node);

        XmlDataSource1.Save();
        GridView1.DataBind();
        Response.Redirect("Default.aspx");
    }

    // כפתור מחק
    protected void yes_Click(object sender, EventArgs e)
    {
        // פונקציית מחיקת משחק
        deleteRow();
    }

    // כפתור לא למחוק
    protected void no_Click(object sender, EventArgs e)
    {
        // העלמת הפאנל של מחיקת משחק
        deletePanel.Visible = false;
    }




    //לחיצה על יצירת משחחק
    protected void CreatGame_Click(object sender, EventArgs e)
    {
        createPanel.Visible = true;
    }

    // כפתור יצירת משחק
    protected void save_Click(object sender, EventArgs e)
    {
        // פונקציית מחיקת משחק
        //if ((myTopicTB.Text.Length) > 2)
        //{
            CreatNewGame();
        //}
        //else
        // {

        // }

    }

    // כפתור ביטול
    protected void cancel_Click(object sender, EventArgs e)
    {
        // העלמת הפאנל של מחיקת משחק
        deletePanel.Visible = false;
    }

    protected void CreatNewGame()
    {
        XmlDocument xmlDoc = XmlDataSource1.GetXmlDocument();

        int countgames = Convert.ToInt16(xmlDoc.SelectNodes("//game").Count);
        int MaxCode;


        if (countgames == 0)
        {
            MaxCode = 100;
        }
        else
        {
            MaxCode = Convert.ToInt16(xmlDoc.SelectSingleNode("//game[not(@code < //game/@code)]/@code").Value);
            MaxCode++;
        }

        // יצירת ענף משחק     
        XmlElement myGameNode = xmlDoc.CreateElement("game");
        myGameNode.SetAttribute("code", MaxCode.ToString());
        myGameNode.SetAttribute("ispublished", "False");

        // יצירת ענף שאלה
        XmlElement myQuestionNode = xmlDoc.CreateElement("question");
        myQuestionNode.SetAttribute("distructorsamount", "2");
        myQuestionNode.InnerXml = "";  /*Server.UrlEncode(myQuestionTB.Text);-------------לקחת מתיבת טקסט------------*/
        myGameNode.AppendChild(myQuestionNode);

        // יצירת ענף כותרת המשחק
        XmlElement myTopicNode = xmlDoc.CreateElement("topic");
        myTopicNode.InnerXml = Server.UrlEncode(myTopicTB.Text);
        myGameNode.AppendChild(myTopicNode);

        // יצירת ענף תשובה ריקה
        //XmlElement myAnswerNode = xmlDoc.CreateElement("answer");
        //myAnswerNode.SetAttribute("correct", "");
        // myAnswerNode.SetAttribute("type", "");
        // myAnswerNode.SetAttribute("imagename", "");
        //myGameNode.AppendChild(myAnswerNode);

        // הוספת המשחק החדש ראשון ברשימה 
        XmlNode FirstGame = xmlDoc.SelectNodes("/gameRoot/game").Item(0);
        xmlDoc.SelectSingleNode("/gameRoot").InsertBefore(myGameNode, FirstGame);
        XmlDataSource1.Save();
        GridView1.DataBind();

        // איפוס תיבות הטקסט
        //myQuestionTB.Text = "";
        myTopicTB.Text = "";
        Response.Redirect("Default.aspx");
    }





}