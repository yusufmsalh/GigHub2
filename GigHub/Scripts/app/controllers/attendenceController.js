var GigController = function (gigService) {
    var theButtonthatHasBeenClicked; // to be global across the Module
    var IntiateGigs = function (container) {
     //  $("#btnGoing").click(btnGoingClickHandler);
        // will only be called for elements in  dom 
        //means if the user requested for 'Load More'.
        //this event handeler won't be applied .
        //plus we will have a seperate handler for each element matching charctiera.
        //a more efficient way to use on method.
        $(container).on('click', "#btnGoing", btnGoingClickHandler);
        //this will create a single attendence handeler in memory.
        //if any further elements has been added to dom ,the click handler will still be called.

    };
        var btnGoingClickHandler = function (e) {
            var theButtonthatHasBeenClicked = $(e.target);
            var gigIDDDDD = theButtonthatHasBeenClicked.attr("gigId");
            gigService.AddAttendenceExposed(gigIDDDDD, doneMethod, failMethod)

        }
        var failMethod = function () {
            alert('something went wrong');
        }
        var doneMethod = function () {
            var text = (theButtonthatHasBeenClicked.text == "Going") ? "Going" : "Not Going"
            theButtonthatHasBeenClicked.toggleClass('btn-default').toggleClass('btn-success').text(text);
        }

    
    return {
        InitiateGigsExposed: IntiateGigs

    }
}(GigService);