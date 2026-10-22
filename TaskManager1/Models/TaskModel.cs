using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace TaskManager1.Models
{
    public class TaskModel
    {
        [Key]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "SKU is required.")]
        [RegularExpression(@"^[a-zA-Z0-9-_]+$", ErrorMessage = "SKU must contain valid alphanumeric characters, hyphens, or underscores.")]
        public string SKUs { get; set; }

        [Required(ErrorMessage = "Employee name is required.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Employee Assigned must contain letters and spaces only.")]
        public string EmployeeAssigned { get; set; }

        [Required(ErrorMessage = "Please select a bin.")]
        [Range(1, 3, ErrorMessage = "Bin must be selected from the drop down.")]
        public int Bin { get; set; }

        public bool Status { get; set; }
    }
}   
