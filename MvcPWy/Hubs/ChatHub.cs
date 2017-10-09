using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace MvcPWy.Hubs
{
    public class ChatHub : Hub
    {
        //Decalre static class and store the user list
        public static class Users
        {
            public static Dictionary<string, string> ConnectionIds = new Dictionary<string, string>();
        }

        //Send message to all the Users
        public void Send(string message)
        {
            var user = Users.ConnectionIds.Where(u => u.Key == Context.ConnectionId).FirstOrDefault();
            Clients.All.show(user.Value + " Speak: " + message);
        }

        //Send message to somebody
        public void SendOne(string id, string message)
        {
            var from = Users.ConnectionIds.Where(u => u.Key == Context.ConnectionId).FirstOrDefault();
            //var to = Users.ConnectionIds.Where(u => u.Key == id).FirstOrDefault();

            Clients.Client(id).show("<span style='color:red'>" + from.Value + " Speak to you secretly: " + message + "</span>");
        }

        //new user access to the ChatRoom
        public void userConnected(string name)
        {
            //add new user to the chat hub
            Users.ConnectionIds.Add(Context.ConnectionId, name);

            //send to all the users the userlist
            Clients.All.getList(Users.ConnectionIds.Select(u => new { id = u.Key, name = u.Value }).ToList());

            //Inform all the users that there is a new user.
            Clients.Others.show(" Welcome " + name + " enter the chat room");
        }

        //when the users offline, it ask for reconnection
        public override Task OnDisconnected(bool stopCalled)
        {
            Clients.Others.removeList(Context.ConnectionId);
            Users.ConnectionIds.Remove(Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }
    }
}

/*using System;
using System.Web;
using Microsoft.AspNet.SignalR;
namespace MvcPWy.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
        }
    }
}*/