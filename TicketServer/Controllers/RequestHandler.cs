using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketServer.Utilities.Database;

namespace TicketServer.Controllers
{
    /// <summary>
    /// Takes a request string and returns a response string depending on the type of request.
    /// </summary>
    /// <param name="Listener"></param>
    internal class RequestHandler
    {
        public string Request { get; private set; }
        public string Response;

        public RequestHandler(string request)
        {
            Request = request;
            if (Request == "PING") { Response = "PONG"; return; } // Heartbeat

            var requestParts = Request.Split(':'); // beware, may change!

            switch (requestParts[0])
            {
                case "login":
                    Response = HandleLogin(requestParts[1]);
                    break;

                case "get_data":
                    Response = HandleGetData(requestParts[1]);
                    break;

                case "post_data":
                    Response = HandlePostData(requestParts[1]);
                    break;

                case "update_data":
                    Response = HandleUpdateData(requestParts[1]);
                    break;

                case "delete_data":
                    Response = HandleDeleteData(requestParts[1]);
                    break;

                case "dubug":
                    Response = HandleDebug(requestParts[1]);
                    break;

                default:
                    Response = "Invalid request";
                    break;
            }

        }

        //////////////// Request Handlers ////////////////

        private string HandleLogin(string request)
        {
            if (request.Split(new char[] { ',' }).Length != 2) return null;

            // Parse request
            string[] parts = request.Split(new char[] { ',' });
            string username = parts[0];
            string password = parts[1];

            // Verify user
            if (dbHandle.VerifyUser(username, password))
            {
                return "Success"; 
            }
            else
            {
                return "Fail";
            }
        }

        private string HandleGetData(string request)
        {
            throw new Exception("Not implemented");
        }

        private string HandlePostData(string request)
        {
            throw new Exception("Not implemented");
        }

        private string HandleUpdateData(string request)
        {
            throw new Exception("Not implemented");
        }

        private string HandleDeleteData(string request)
        {
            throw new Exception("Not implemented");
        }

        private string HandleDebug(string request)
        {
            throw new Exception("Not implemented");
        }

        public byte[] GetResponseBytes()
        {
            if (Response == null) return null;
            return Encoding.ASCII.GetBytes(Response);
        }
    }
}
