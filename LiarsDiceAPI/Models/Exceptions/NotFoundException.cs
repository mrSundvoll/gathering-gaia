using System;
using System.Net;

namespace LiarsDiceAPI.Models.Exceptions
{
    public class NotFoundException : Exception
    {

        public NotFoundException(string messageContent) 
            : base(messageContent)
        {
        }
    }
}
