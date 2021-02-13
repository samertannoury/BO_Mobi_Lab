var WarningBackColor = "#fcf8e3";
var WarningColor = "#9F6000";
var WarningBorderColor = "#faebcc";
var WarningBtnClass = "btn btn-warning";

var SuccessBackColor = "#4CAF50";
var SuccessColor = "#3c763d";
var SuccessBorderColor = "#d6e9c6";
var SuccessBtnClass = "btn btn-success";

var ErrorBackColor = "#FFBABA";
var ErrorColor = "#D8000C";
var ErrorBorderColor = "#ebccd1";
var ErrorBtnClass = "btn btn-danger";

var InfoBackColor = "#d9edf7";
var InfoColor = "#31708f";
var InfoBorderColor = "#bce8f1";
var InfoBtnClass = "btn btn-info";
function ShowErrorMsg(title, text, flag) {
    try {
        var backcolor =null;
        var color =null;
        var bordercolor = null;
        var cssClass = null;
    if (flag == "W") {
        //Warning
        backcolor = WarningBackColor;
        color = WarningColor;
        bordercolor = WarningBorderColor;
        cssClass = WarningBtnClass;
    } else if (flag == "S") {
        //Success
        backcolor = SuccessBackColor;
        color = SuccessColor;
        bordercolor = SuccessBorderColor;
        cssClass = SuccessBtnClass;
    } else if (flag == "E") {
        //Error
        backcolor = ErrorBackColor;
        color = ErrorColor;
        bordercolor = ErrorBorderColor;
        cssClass = ErrorBtnClass;
    } else if (flag == "I") {
        //Information
        backcolor = InfoBackColor;
        color = InfoColor;
        bordercolor = InfoBorderColor;
        cssClass = InfoBtnClass;
    }
    var dialogInstance1 = new BootstrapDialog({
        title: title,
        message: text,
        buttons: [{
            label: 'OK',
            hotkey: 13,
            cssClass: cssClass,
            action: function (dialog) {
                dialog.close();
            }
        }]
    });

    dialogInstance1.realize();
    dialogInstance1.getModalHeader().css('background-color', backcolor);
    dialogInstance1.getModalHeader().css('color', color);
    dialogInstance1.getModalHeader().css('border-color', bordercolor);
    dialogInstance1.open();
    } catch (E) { alert(E); }
}

function SessionTimedOut(Title, Message, ButtonLabel, URL) {

    var dialogInstance1 = new BootstrapDialog({
        title: Title,
        message: Message,
        buttons: [{
            label: ButtonLabel,
            hotkey: 13,
            cssClass: InfoBtnClass,
            action: function (dialog) {
                location.href = URL;
            }
        }],
        onhide: function (dialogRef) {
            location.href = URL;
        },
    });

    cssClass = InfoBtnClass;
    dialogInstance1.realize();
    dialogInstance1.getModalHeader().css('background-color', InfoBackColor);
    dialogInstance1.getModalHeader().css('color', InfoColor);
    dialogInstance1.getModalHeader().css('border-color', InfoBorderColor);
    dialogInstance1.open();
}


function SuccessAndRedirect(Title, Message, ButtonLabel, URL) {

    var dialogInstance1 = new BootstrapDialog({
        title: Title,
        message: Message,
        buttons: [{
            label: ButtonLabel,
            hotkey: 13,
            cssClass: SuccessBtnClass,
            action: function (dialog) {
                location.href = URL;
            }
        }],
        onhide: function (dialogRef) {
            location.href = URL;
        },
    });

    dialogInstance1.realize();
    dialogInstance1.getModalHeader().css('background-color', SuccessBackColor);
    dialogInstance1.getModalHeader().css('color', SuccessColor);
    dialogInstance1.getModalHeader().css('border-color', SuccessBorderColor);
    dialogInstance1.open();
}