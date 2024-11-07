using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyDo.Shared.Models
{
    public class HoneyDoModel 
    {
        public int Id { get; set; } = 0; 
        [Required]
        public string Task { get; set; } = "";
        public string? Description { get; set; }
        public string? Image { get; set; } = "_content/HoneyDo.Shared/placeholder-image.jpg";
        [Required]
        public bool IsComplete { get; set; } = false;
        [Required]
        public DateTime DueDate { get; set; } = DateTime.Now.AddDays(1);
        public string? AssignedTo { get; set; } = "Nick";
        [Required]
        public string CreatedBy { get; set; } = "Beth";
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public HoneyDoModel Copy()
        {
            return (HoneyDoModel)this.MemberwiseClone();
        }
    }
}
