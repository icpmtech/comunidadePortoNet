$("#contactForm").validator().on("submit", function (event) {
    if (event.isDefaultPrevented()) {
        // handle the invalid form...
        formError();
        submitMSG(false, "Por favor preenche o formulario correctamente?");
    } else {
        // everything looks good!
        event.preventDefault();
        submitForm();
    }
});


function submitForm(){
    // Initiate Variables With Form Content
    var name = $("#name").val();
    var email = $("#email").val();
    var msg_subject = $("#msg_subject").val();
    var message = $("#message").val();


    $.ajax({
        type: "POST",
        url: "api/SuggestionViewModels",
        data: $("#contactForm").serialize(),
        success : function(text){

                formSuccess();

        },error: function (x, y, z) {



            formError();

                            var response = null;
                            var errors = [];
                            var errorsString = "";
                            //WE IGNORE MODEL STATE EXTRACTION IF THERE WAS SOME OTHER UNEXPECTED ERROR (I.E. NOT A VALIDATION ERROR)
                            if (x.status == 400) {//SINCE WE ARE RETURNING BAD REQUEST STATUS FROM OUR WEB API, SO WE CHECK IF STATUS CODE IS 400
                                try {
                                    response = JSON.parse(x.responseText);
                                }
                                catch (e) { //this is not sending us a ModelState, else we would get a good responseText JSON to parse)
                                }
                            }
                            if (response != null) {
                                var modelState = response.ModelState;
                                for (var key in modelState) {
                                    if (modelState.hasOwnProperty(key)) {
                                        for (var i = 0; i < modelState[key].length; i++) {
                                            errorsString = (errorsString == "" ? "" : errorsString + "<br/>") + modelState[key][i];
                                            errors.push(modelState[key][i]);
                                        }
                                    }
                                }

                            }
                            //DISPLAY THE LIST OF ERROR MESSAGES
                            if (errorsString != "") {
                                submitMSG(false, errorsString);
                            }
                        }
    });
}

function formSuccess(){
    $("#contactForm")[0].reset();
    submitMSG(true, "<p>Mensagem enviada com sucesso!</p>")
}

function formError(){
    $("#contactForm").removeClass().addClass('shake animated').one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function(){
        $(this).removeClass();
    });
}

function submitMSG(valid, msg){
    if(valid){
        var msgClasses = "h3 text-center tada animated text-success";
    } else {
        var msgClasses = "h3 text-center text-danger";
    }
    $("#msgSubmit").removeClass().addClass(msgClasses).html(msg);
}