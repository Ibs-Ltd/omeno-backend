using Asp.Omeno.Service.Common.Constants;
using System;

namespace Asp.Omeno.Service.Application.Exceptions
{
    public class InternalValidationSignleException : Exception
    {
        public InternalValidationSignleException(string errors) : base(errors)
        {

        }
    }
}
