# StockChat
Test chat app en .net core con SignalR

Created in Visual Studio 2019 with .NET Core 3.1, SignlaR, and .Net Identiy.

Una vez importado abierta la solucion, correr 
Update-Database desde la consola de visual studio para que cree la base de datos local.

Once the solution was opended in Visual Studio, run the command
Update-Database from the package manager console to create the local database.

This was an excercise to:

● Allow registered users to log in and talk with other users in a chatroom.

● Allow users to post messages as commands into the chatroom with the following format
/stock=stock_code

● Create a decoupled bot that will call an API using the stock_code as a parameter
(https://stooq.com/q/l/?s=aapl.us&f=sd2t2ohlcv&h&e=csv, here aapl.us is the
stock_code)

● The bot should parse the received CSV file and then it should send a message back into
the chatroom using a message broker like RabbitMQ. The message will be a stock quote
using the following format: “APPL.US quote is $93.42 per share”. The post owner will be
the bot.

● Have the chat messages ordered by their timestamps and show only the last 50
messages.

[2020-08-12]

Added API for getting quote.

Added swagner https://localhost:44371/swagger/ for testing the API.
