using System.ComponentModel.DataAnnotations;

namespace TaskManager1.Models
{
    public class TaskModel
    {
        [Key] 
        public int TaskId { get; set; }


        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? IsComplete { get; set; }
    }
}
