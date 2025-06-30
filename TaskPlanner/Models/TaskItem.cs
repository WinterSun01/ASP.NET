using System;
using System.ComponentModel.DataAnnotations;

namespace TaskPlanner.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите заголовок")]
        [StringLength(100)]
        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        [StringLength(500)]
        [Display(Name = "Описание")]
        public string? Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Срок выполнения")]
        public DateTime? DueDate { get; set; }

        [Display(Name = "Выполнено")]
        public bool IsCompleted { get; set; }
    }
}
