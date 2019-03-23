var GigService = function () {
    //handel calling the server here.
    var AddAttendence = function (gigId, doneMethod, failMethod) {
        $.post("/api/Attendece", { GigId: gigId, passedParam2: 1, passedParam3: "Hello Text" })
            .done(doneMethod)//passed from controller
            .fail(failMethod);//passed from controller
    }
    return { AddAttendenceExposed: AddAttendence };
}();