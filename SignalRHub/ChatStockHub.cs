using Microsoft.AspNetCore.SignalR;
using StockChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockChat.SignalRHub
{
    public class ChatStockHub : Hub
    {
        public async Task SendMessage(Message message) =>
            await Clients.All.SendAsync("receiveMessage", message);

        

    }
}
