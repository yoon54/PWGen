  
using System;
namespace RandomPassword.Models
{
    public class Password
    {
        public string Value{get;set;}

        public Password()
        {
            string choices ="1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*()";
            Random r = new Random();
            for (int i=0; i<14;i++)
            {
                Value += choices[r.Next(choices.Length)];
            }
        }
    }
}