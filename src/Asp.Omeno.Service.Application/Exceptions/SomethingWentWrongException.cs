using System;

namespace Asp.Omeno.Service.Application.Exceptions
{
    public class SomethingWentWrongException : Exception
    {
        public SomethingWentWrongException() : base("Something went wrong")
        {
        }
    }
}
