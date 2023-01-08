$(document).ready(function () {
    $(".about").click(function () {
        $("#aboutDiv").toggle();
    });

    $(".howToPlay").click(function () {
        $("#howToPlayDiv").toggle();
    });

    $(".closeAbout").click(function () {
        $("#aboutDiv").hide();
        $("#gameIframe")[0].contentWindow.focus();
    });

    $(".closeHowToPlay").click(function () {
        $("#howToPlayDiv").hide();
        $("#gameIframe")[0].contentWindow.focus();
    });
});

//כאשר העמוד נטען
$(document).ready(function () {

        document.getElementById("Button1").disabled = true;
        document.getElementById("Button1").classList.add("disabledbtn");
        //console.log("ready!");

    //בהקלדה בתיבת הטקסט
    $(".CharacterCount").keyup(function () {
        checkCharacter($(this)); //קריאה לפונקציה שבודקת את מספר התווים
    });


    //בהעתקה של תוכן לתיבת הטקסט
    $(".CharacterCount").on("paste", function () {
        checkCharacter($(this));//קריאה לפונקציה שבודקת את מספר התווים
    });


    //פונקציה שמקבלת את תיבת הטקסט שבה מקלידים ובודקת את מספר התווים
    function checkCharacter(myTextBox) {

        //משתנה למספר התווים הנוכחי בתיבת הטקסט
        var countCurrentC = myTextBox.val().length;

        //משתנה המכיל את מספר התווים שמוגבל לתיבה זו
        var CharacterLimit = myTextBox.attr("CharacterLimit");

        //בדיקה האם ישנה חריגה במספר התווים
        if (countCurrentC > CharacterLimit) {

            //מחיקת התווים המיותרים בתיבה
            myTextBox.val(myTextBox.val().substring(0, CharacterLimit));
            //עדכון של מספר התווים הנוכחי
            countCurrentC = CharacterLimit;

        }



        //משתנה המקבל את שם הלייבל המקושר לאותה תיבת טקסט 
        var LableToShow = myTextBox.attr("CharacterForLabel");

        //הדפסה כמה תווים הוקלדו מתוך כמה
        $("#" + LableToShow).text(countCurrentC + "/" + CharacterLimit);


        //if ((Document.getElementById("myQuestion").text.length) > 9) {

        //        Document.getElementById("myQuestion").style.borderColor = "green";

        //    } else {
        //        Document.getElementById("myQuestion").style.borderColor = "red";
        //    }

        disablesavemewgame();

        //BorderColor();

    }

});


//function BorderColor() {
//    //var letterCount = document.getElementById("myQuestion").value;


//    if (letterCount.length < 10) {
//        document.getElementById("myQuestion").classList.remove("green");
//        document.getElementById("myQuestion").classList.add("red");
//    } else {
//        document.getElementById("myQuestion").classList.remove("red");
//        document.getElementById("myQuestion").classList.add("green");
//    }
//}

function disablesavemewgame() {
    var letterCount = document.getElementById("myTopicTB").value;

    if (letterCount.length < 2) {
        document.getElementById("Button1").disabled = true;
        document.getElementById("Button1").classList.remove("SaveBTN");
        document.getElementById("Button1").classList.add("disabledbtn");
    } else {
        document.getElementById("Button1").disabled = false;
        document.getElementById("Button1").classList.remove("disabledbtn");
        document.getElementById("Button1").classList.add("SaveBTN");
    }
}

//פעולה שמתרחשת בלחיצה על התמונה הראשונה ופותחת את חלון בחירת התמונה הראשונה
function openFileUploader1() {
    $('#FileUpload1').click();
}

//פעולה שמתרחשת בלחיצה על התמונה השניה ופותחת את חלון בחירת התמונה השניה
function openFileUploader2() {
    $('#FileUpload2').click();
}


$(document).ready(function () {

    //לאחר שלחצנו על התמונה שרצינו לבחור - תמונה מספר אחד
    $("#FileUpload1").change(function () {
        if (this.files && this.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#ImageforUpload1').attr('src', e.target.result);
            }
            reader.readAsDataURL(this.files[0]);
        }
    });
});