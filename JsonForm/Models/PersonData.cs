using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Windows.Markup;

namespace JsonForm.Models
{
    public class PersonData
    {
        [Required(ErrorMessage = "Поле обязательно к заполнению!")]
        [RegularExpression(@"^[A-Za-z]+([\'\-\ A-Za-z][A-Za-z\'\-]*)*|^[А-ЯЁа-яё]+([\'\-\ А-ЯЁа-яё][А-ЯЁа-яё\'\-]*)*", 
            ErrorMessage = "Можно вводить только русские ИЛИ латинские буквы! А также некоторые знаки (пробел, апостроф, тире)")]
        [Display(Name = "Введите фамилию")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Поле обязательно к заполнению!")]
        [Display(Name = "Введите имя")]
        [RegularExpression(@"^[A-Z]+([\'\-\ A-Za-z][A-Za-z\'\-]*)*|^[А-ЯЁ]+([\'\-\ А-ЯЁа-яё][А-ЯЁа-яё\'\-]*)*",
            ErrorMessage = "Можно вводить только русские ИЛИ латинские буквы! А также некоторые знаки (пробел, апостроф, тире). Имя должно начинаться с заглавной буквы!")]
        public string FirstName { get; set; }


        [Display(Name = "Введите отчество")]
        [RegularExpression(@"^[A-Za-z]+([\'\-\ A-Za-z][A-Za-z\'\-]*)*|^[А-ЯЁа-яё]+([\'\-\ А-ЯЁа-яё][А-ЯЁа-яё\'\-]*)*",
            ErrorMessage = "Можно вводить только русские ИЛИ латинские буквы! А также некоторые знаки (пробел, апостроф, тире)")]
        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Display(Name = "Введите дату рождения")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
    }
}
