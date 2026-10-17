using System.ComponentModel.DataAnnotations;

namespace TaskManager1.Models
{
    public class TaskModel
    {
        [Key] 
        public int TaskId { get; set; }


        public string? SKUs { get; set; }
        public string? EmployeeAssigned { get; set; }
        public string? Bin { get; set; }
        public bool? Status { get; set; }
    }
}
