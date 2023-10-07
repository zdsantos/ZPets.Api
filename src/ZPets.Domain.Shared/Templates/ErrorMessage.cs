﻿namespace ZPets.Domain.Shared.Templates
{
    public class ErrorMessage
    {
        public string Code { get; set; }
        public string Message { get; set; }

        public ErrorMessage(string code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}