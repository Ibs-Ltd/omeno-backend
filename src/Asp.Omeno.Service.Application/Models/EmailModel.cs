using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.Omeno.Service.Application.Models
{
    public class EmailModel
    {
        public string Receiver { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public bool IsHtmlBody { get; set; }
    }
}
