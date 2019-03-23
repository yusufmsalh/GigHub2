/*
 * main problem : I don't want all functions to be
 * in global scope as it would be probable to have
 *  repeated names.
 * so we to use the IIFE -> Immediately Invoked Function Expression : that is :
 *  I want to declare a private function ,
 *  and Only Expose certain parts to be public
 *  using a return statment
 *
 * Concept 1:IIFE
 * -----------
 * function x() {}
 * var x = function x(){}, x() => call function
 * var x = function x(){}();=> Immediatly Invoked.
 *
 *
 * Concept 2 : nested functions in javascript
 * -----------
 *var Person = function ()
 * {
 *      var  PersonName = "Mosh";
        var sayHello = function SayHello()
         {
         Console.Log(PersonName);//accessible here
        }
   }
* we can do this in Js ,that is unlike C#
 *
 *Concept 3 : Exposing to global scope (Revealing Module pattern In Js)
 * -----------
 * var Person = function ()
 * {
 *      var  PersonName = "Mosh";  // private
        var sayHello = function() // private
         {
         Console.Log(PersonName);//accessible here
        }
        return { 
        SayHelloExposed :sayHello // add public members here 
        }
   }
   Person.SayHelloExposed();//Prints personName
 *
 *
 *
 * Concept : Services:
 * ---------------
 * Controller is responsible for handeling events raised by dom and Update Dom
 * till the part that is responsible for calling the server ,here comes the services
 */
// summary : we want to create something like a class ,that has private and public members 
//class <= variable hold all members and functions
// private members: all members within the inline function expression
//public : define public members within the return (Returned object).





function InitiateFollowing() {
    $("#btnFollowing").click(function (e) {
        debugger;
        $.post("/api/Following", { FolloweeId: $(e.target).attr("FolloweeId") })

            .done(function () {
                $('#btnFollowing').text('Following').removeClass('btn-default').addClass('btn-success');
            })
            .fail(function (parameters) {
                //$('#btnFollowing').text('Failed To Update').addClass('btn-danger');
                alert('something went wrong');
            })

    });
}