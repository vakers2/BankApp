using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class CreditCard
    {
        public int Id { get; set; }

        public string CardNumber { get; set; }

        public int CardBalance { get; set; }

        public CreditCard()
        {
            CardNumber = RandomDigits(10);
        }

        private string RandomDigits(int length)
        {
            var random = new Random();
            var s = string.Empty;
            for (var i = 0; i < length; i++)
                s = string.Concat(s, random.Next(10).ToString());
            return s;
        }
    }
}
