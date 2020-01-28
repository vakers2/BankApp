using System;
using System.ComponentModel.DataAnnotations;

namespace ServerApp.Models
{
    public class Employee
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public DateTime Birthday { get; set; }        
        
        [Required]
        public bool Sex { get; set; }

        [Required]
        public string PassportSeries { get; set; }

        [Required]
        public string PassportNumber { get; set; }

        [Required]
        public string PassportGiver { get; set; }

        [Required]
        public DateTime PassportGiveDate { get; set; }

        [Required]
        public string IdentityNumber { get; set; }

        [Required]
        public string Birthplace { get; set; }

        [Required]
        public City City { get; set; }

        [Required]
        public string Address { get; set; }

        public string PhoneHome { get; set; }

        public string PhoneMobile { get; set; }

        public string Email { get; set; }

        public string Workplace { get; set; }

        public string WorkPosition { get; set; }

        [Required]
        public int FamilyPositionId { get; set; }

        [Required]
        public int CitizenshipId { get; set; }

        [Required]
        public int DisabilityId { get; set; }


        [Required]
        public bool Pensioner { get; set; }

        public int Income { get; set; }

        [Required]
        public bool Military { get; set; }


        public FamilyPosition FamilyPosition { get; set; }

        public Citizenship Citizenship { get; set; }

        public Disability Disability { get; set; }
    }
}
