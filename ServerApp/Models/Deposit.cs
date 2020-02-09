using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class Deposit
    {
        public int Id { get; set; }

        [Display(Name = "Номер договора")]
        public int ContractNumber { get; set; }

        [Display(Name = "Тип")]
        public DepositType Type { get; set; }
        public int CurrencyId { get; set; }
        
        [Display(Name = "Дата начала")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Дата конца")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Срок договора")]
        public int ContractTerm { get; set; }

        public float StartSum { get; set; }
        public float Sum { get; set; }

        [Display(Name = "Процент по вкладу")]
        public float Percent { get; set; }
        public string UserId { get; set; }

        public Employee User { get; set; }
        public Currency Currency { get; set; }
    }
}
