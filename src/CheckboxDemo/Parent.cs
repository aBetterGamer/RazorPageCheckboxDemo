using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CheckboxDemo
{
    public class Parent
    {
        public Parent() 
        {
            Children = new HashSet<ParentChild>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public  ICollection<ParentChild> Children { get; set; }
    }
}
