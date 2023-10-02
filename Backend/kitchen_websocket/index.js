// importing express library
const express = require('express');
// creating an instance of express
const app = express();
// importing http, socketio and cors libarires
const http = require("http");
const {Server} = require('socket.io');
const cors = require('cors');

app.use(cors());

const server = http.createServer(app);
const io = new Server(server, {
    cors: {
        origin: ["http://localhost:3000", "http://localhost:3001"],
        method: ["GET", "POST"],
    }
})

io.on("connection", (socket) => {
    socket.on("order_received", (data) => {
        console.log (data);
        socket.broadcast.emit("order_received", data);
    })
})

server.listen(8000, () => {
    console.log("server is running!");    
})
