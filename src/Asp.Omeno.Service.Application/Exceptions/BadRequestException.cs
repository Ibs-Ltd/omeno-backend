using System;

namespace Asp.Omeno.Service.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string msg) : base(msg)
        {

        }
    }
}
