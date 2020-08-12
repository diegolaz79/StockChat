class Message {
    constructor(username, text, msgDate) {
        this.userName = username;
        this.text = text;
        this.msgDate = msgDate;
    }
}

// userName is declared in razor page.
const username = userName;
const textInput = document.getElementById('messageText');
const msgDateInput = document.getElementById('msgDate');
const chat = document.getElementById('chat');
const messagesQueue = [];

document.getElementById('submitButton').addEventListener('click', () => {
    var msg = $("#messageText").val();
    if (msg.length == 0) {
        alert("Mensaje vacio!");
        return false;
    }
    //console.log("Send chat message..." + msg);
    
    
    var currentdate = new Date();
    /*msgDate.innerHTML =
        (currentdate.getMonth() + 1) + "/"
        + currentdate.getDate() + "/"
        + currentdate.getFullYear() + " "
        + currentdate.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', hour12: true })
        */
});

function clearInputField() {
    messagesQueue.push(textInput.value);
    textInput.value = "";
}

function sendMessage() {
    let text = messagesQueue.shift() || "";
    if (text.trim() === "") return;
    
    let msgDate = new Date();
    let message = new Message(username, text);
    sendMessageToHub(message);
}

function addMessageToChatQithQuote(message) {
    var msg = message.text;
    var msgText = "";
    let isCurrentUserMessage = message.userName === username;
    let container = document.createElement('div');
    container.className = isCurrentUserMessage ? "container darker" : "container";

    let sender = document.createElement('p');
    sender.className = "sender";
    sender.innerHTML = message.userName;
    let text = document.createElement('p');
    if (msgText.length > 0) {
        text.innerHTML = msgText;
    }
    else {
        text.innerHTML = message.text;
    }
    let msgDate = document.createElement('span');
    msgDate.className = isCurrentUserMessage ? "time-left" : "time-right";
    var currentdate = new Date();
    msgDate.innerHTML =
        (currentdate.getMonth() + 1) + "/"
        + currentdate.getDate() + "/"
        + currentdate.getFullYear() + " "
        + currentdate.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', hour12: true })

    container.appendChild(sender);
    container.appendChild(text);
    container.appendChild(msgDate);
    chat.appendChild(container);
}

function addMessageToChat(message) {
    var msg = message.text;
    var msgText = "";
    if (msg.includes("/stock")) {
        console.log("Check stock!");
        msg = msg.replace("/stock=", "");
        $.ajax({
            type: "GET",
            url: "/api/StockAPI/" + msg,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                message.text = data.responseText;
                addMessageToChatQithQuote(message);
            },
            failure: function (data) {
                message.text = data.responseText;
                addMessageToChatQithQuote(message);
            }, //End of AJAX failure function  
            error: function (data) {
                message.text = data.responseText;
                addMessageToChatQithQuote(message);
            } //End of AJAX error function  

            });
    }
    else {
        addMessageToChatQithQuote(message);
    }

    
    

   
}
