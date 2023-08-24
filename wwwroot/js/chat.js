"use strict";
// this file is client-side javascript.
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
// new instance of signarlR connection. And it builds it. creates connection.
// Its the chathub we mapped in Program.cs


//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;


connection.on("ReceiveMessage", function (user, message) { // this is where we tell UI how to respond to ReceiveMessage event
    // on event receive message
    // each sent message is received by receiver aswell as sender.
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
    messagePara.className = "content";

    var timestampPara = document.createElement("p"); // Paragraph for the timestamp and sender
    timestampPara.style.cssText = "margin-left: 80%; margin-right: auto; margin-bottom: -10px; font-size: 16px; color: black; font-weight: lighter;";
    timestampPara.className = "content";

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


$(document).ready(function() {
    $("#slider").on("input", function() {
        $('.content, #userInput, #messagesList, #messageInput').css("font-size", $(this).val() + ".5px");
    });
}); // Slide to change font size


const messageInputContainer = document.getElementById('messageInputContainer');
const chatContainer = document.querySelector('.chat-container');

chatContainer.addEventListener('scroll', () => {
  if (chatContainer.scrollTop + chatContainer.clientHeight >= chatContainer.scrollHeight) {
    messageInputContainer.style.position = 'fixed';
  } else {
    messageInputContainer.style.position = 'relative';
  }
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