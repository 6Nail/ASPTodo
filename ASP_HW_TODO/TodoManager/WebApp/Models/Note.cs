using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Note
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Display(Name = "Дата создания")]
        public DateTime CreationDate { get; set; } = DateTime.Now;
        [Display(Name = "Выполнить до:")]
        public DateTime DeadlineTime { get; set; }
        [Display(Name = "Название")]
        public string Title { get; set; }
        [Display(Name = "Текст")]
        public string Body { get; set; }
        public IdentityUser User { get; set; }
        public string UserId { get; set; }
    }
}
