"use strict";
// this file is client-side javascript.
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
// new instance of signarlR connection. And it builds it. creates connection.


//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;


connection.on("ReceiveMessage", function (user, message) {

    //var isSender = true; //default
    //console.log(chat.Username);

    var CurrentUser = document.getElementById("userInput").value;

    var isSender = user === CurrentUser;
    // bool isSender determine bubble type

    var bubble = document.createElement("div"); // Create the text bubble container

    if (isSender) {
        bubble.classList.add("sender-bubble");
    } else {
        bubble.classList.add("receiver-bubble");
    }

    var messagePara = document.createElement("p"); // Paragraph for the message
    messagePara.style.cssText = "font-size: 20px; color: black;";
    messagePara.textContent = message; // Use chat.Content instead of message
    bubble.appendChild(messagePara);

    var timestampPara = document.createElement("p"); // Paragraph for the timestamp and sender
    timestampPara.style.cssText = "margin-left: 80%; margin-right: auto; margin-bottom: -10px; font-size: 16px; color: black; font-weight: lighter;";

    var today = new Date(); // Use chat.Timestamp
    var timestamp = today.toLocaleTimeString();

    var userNode = document.createTextNode(user);
    var timestampNode = document.createTextNode(timestamp);

    timestampPara.appendChild(userNode); // Append user text node
    timestampPara.appendChild(document.createElement("br")); // Line break
    timestampPara.appendChild(timestampNode); // Append timestamp text node

    bubble.appendChild(timestampPara);

    document.getElementById("messagesList").appendChild(bubble);
            
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.

    // log message.
});

document.addEventListener("input", function (e) {
    if (e.target && e.target.classList.contains("auto-expand")) {
      e.target.style.height = "auto";
      e.target.style.height = e.target.scrollHeight + "px";
    }
  });

  document.addEventListener("DOMContentLoaded", function () {
    const changeFormatButton = document.getElementById("changeFormatButton");
    const messageInput = document.getElementById("messageInput");

    changeFormatButton.addEventListener("click", function () {
        if (messageInput.classList.contains("text-style-large")) {
            messageInput.classList.remove("text-style-large");
        } else {
            messageInput.classList.add("text-style-large");
        }
    });
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
    var today = new Date();
    var timestamp = today.toLocaleTimeString();

    // Assume you have a way to determine whether the message is from the sender or receiver
    var isSender = true; // Change this based on your authentication logic


    connection.invoke("SendMessage", user, message).catch(function (err) {

        console.log(`Invoking SendMessage: user=${user}, message=${message}, timestamp=${timestamp}`);
        connection.invoke("SendMessage", user, message, timestamp).catch(function (err) {
            console.error(err.toString());
        });


        return console.error(err.toString());

        // we need to log error to text file.
        // more free marks :)

    });
    event.preventDefault();
});