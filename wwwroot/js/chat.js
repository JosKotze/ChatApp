"use strict";
// this file is client-side javascript.
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
// new instance of signarlR connection. And it builds it. creates connection.


//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;


connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li"); // the actual message show in list form
    document.getElementById("messagesList").appendChild(li); // check in index.html

    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.

    li.textContent = `${user} says ${message}`; // format of message
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());

    // we need to log error to text file.
    // free marks :)

});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());

        // we need to log error to text file.
        // more free marks :)

    });
    event.preventDefault();
});