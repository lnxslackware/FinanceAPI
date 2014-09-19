(function() {
    document.write("")
    PUBNUB.subscribe({
        channel: "nakov-channel",
        callback: function (message) {
            // Received a message --> print it in the page
            document.getElementById('messagesArea').innerHTML += message + '\n';
        }
    });
})();