using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CheckboxDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly CheckboxDemoDbContext _dbContext;
        
        [Required]
        [BindProperty]
        public int? ParentId { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        [BindProperty]
        [Display(Name = "Parent Name")]
        public string ParentName { get; set; }

        [BindProperty]
        public List<SelectListItem> Children { get; set; }

        public IndexModel(ILogger<IndexModel> logger, CheckboxDemoDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task OnGetAsync()
        {
            var parent = await _dbContext.Parents
                              .Include(t => t.Children)
                              .ThenInclude(t => t.Child)
                              .FirstOrDefaultAsync();

            ParentName = parent?.Name;

            ParentId = parent?.Id;
            
            Children = parent?.Children
                .Select(s => new SelectListItem(s.Child.Name, s.Child.Id.ToString(), s.Child.IsSelected)).ToList();
        }

        public async Task OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // logging to see the information posted back and model-bound
                _logger.LogInformation("OnPost: ParentId = {ParentId}", ParentId);
                _logger.LogInformation("OnPost: ParentName = {ParentName}", ParentName);

                for (var i = 0; i < Children.Count; i++)
                {
                    _logger.LogInformation("OnPost: Child[{i}] = {Text} {Value} {Selected}", i, Children[i].Text,
                        Children[i].Value, Children[i].Selected);
                }

                // now lets save it
                var parent = await _dbContext.Parents
                    .Include(t => t.Children)
                    .ThenInclude(t => t.Child)
                    .FirstOrDefaultAsync(t => t.Id == ParentId);

                if (parent != null)
                {
                    parent.Name = ParentName;

                    // first clear them all out
                    foreach (var child in parent.Children)
                    {
                        child.Child.IsSelected = false;
                    }

                    foreach (var child in Children)
                    {
                        if (parent.Children.Any(t => t.ChildId == int.Parse(child.Value)))
                        {
                            // now check the ones that are checked
                            parent.Children.First(t => t.ChildId == int.Parse(child.Value)).Child.IsSelected =
                                child.Selected;
                        }
                    }

                    // save changes
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
