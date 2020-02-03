using System;
using System.ComponentModel.DataAnnotations;

namespace ServerApp.Models
{
    public class Employee
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [RegularExpression(@"^[^0-9<>.,?;:'()!~%\-_@#/*""\s]+$", ErrorMessage = "Неверный формат данных")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [RegularExpression(@"^[^0-9<>.,?;:'()!~%_@#/*""\s]+$", ErrorMessage = "Неверный формат данных")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [RegularExpression(@"^[^0-9<>.,?;:'()!~%\-_@#/*""\s]+$", ErrorMessage = "Неверный формат данных")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public Sex Sex { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string PassportSeries { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string PassportNumber { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string PassportGiver { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public DateTime PassportGiveDate { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string IdentityNumber { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Birthplace { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Range(1, int.MaxValue, ErrorMessage = "Поле обязательно для заполнения")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Address { get; set; }

        public string PhoneHome { get; set; }

        public string PhoneMobile { get; set; }

        [EmailAddress(ErrorMessage = "Поле должно быть заполнено существующим электронным адресом")]
        public string Email { get; set; }

        public string Workplace { get; set; }

        public string WorkPosition { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Range(1, int.MaxValue, ErrorMessage = "Поле обязательно для заполнения")]
        public int FamilyPositionId { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Range(1, int.MaxValue, ErrorMessage = "Поле обязательно для заполнения")]
        public int CitizenshipId { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Range(1, int.MaxValue, ErrorMessage = "Поле обязательно для заполнения")]
        public int DisabilityId { get; set; }

        public bool Pensioner { get; set; }

        public int Income { get; set; }

        public bool Military { get; set; }

        public City City { get; set; }

        public FamilyPosition FamilyPosition { get; set; }

        public Citizenship Citizenship { get; set; }

        public Disability Disability { get; set; }
    }
}
