using System.ComponentModel.DataAnnotations;

namespace DiaryApp.Models
{
    public class DiaryEntry
    {
        //use annotations such as [key] . this will uniquely identify record
        //u can define error messages in the models
        public int  Id { get; set; }// when You use Id.net Entity identifier automaticaly  knows that its a unique identifier
        [Required(ErrorMessage ="please enter a title")]// the field can not be null inside ur table
        //[StringLength(100, MinimumLength =3, ErrorMessage ="Title must be between 3 and 100")]
        public string Title { get; set; } = string.Empty;//title is not null but by defaul has an empty string
        [Required]
        public string Content { get; set; }= string.Empty;
        [Required]
        public DateTime Created { get; set; } = DateTime.Now;

    }
}
 //the class takes properties(column inside your table) 