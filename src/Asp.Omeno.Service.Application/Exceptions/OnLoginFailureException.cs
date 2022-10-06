using System;

namespace Asp.Omeno.Service.Application.Exceptions
{
    public class OnLoginFailureException : Exception
    {
        public OnLoginFailureException() : base("Incorrect email or password!")
        {

        }
    }
}
