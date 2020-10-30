using System;

namespace LiarsDiceAPI.Models.Exceptions
{
    public class BadRequestException : Exception
    {

        public BadRequestException(string messageContent) 
            : base(messageContent)
        {
        }
    }
}