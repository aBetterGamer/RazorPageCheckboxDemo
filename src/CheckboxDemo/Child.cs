using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CheckboxDemo
{
    public class Child
    {
        public Child() 
        {
            Parents = new HashSet<ParentChild>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public bool IsSelected { get; set; }

        public ICollection<ParentChild> Parents { get; set; }
    }
}
