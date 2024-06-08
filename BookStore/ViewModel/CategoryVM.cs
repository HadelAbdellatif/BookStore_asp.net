using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModel
{
    public class CategoryVM
    {

        public int Id { get; set; }

        [Required(ErrorMessage ="Name is Require")]
        [MaxLength(30)]
        public string Name { get; set; } = null!;
    }
}
