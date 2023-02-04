const express = require('express');
const app = express();
const http = require('http');
const server = http.createServer(app);
const { Server } = require("socket.io");
const { BinanceClient } = require("ccxws");
const markets = require("./appsettings.json").Markets;


const binance = new BinanceClient();
const market = {
  id: "BTCUSDT", // remote_id used by the exchange
  base: "BTC", // standardized base symbol for Bitcoin
  quote: "USDT", // standardized quote symbol for Tether
};

const io = new Server(server, {
  cors: {
    origin: "*",
    methods: ["GET"]
  }
});

io.on('connection', (socket) => {
  console.log('a user connected');
  binance.on("trade", trade => {
    socket.emit('trade', trade);
  });
  for (let m of markets) {    
    binance.subscribeTrades(m);
  }  
});


server.listen(3001, () => {
  console.log('listening on *:3001');
});