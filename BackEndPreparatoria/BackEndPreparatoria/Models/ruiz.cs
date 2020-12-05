namespace BackEndPreparatoria.Models
{   using System;
    using System.ComponentModel.DataAnnotations;
    public enum Places
    {
        Requisito1 = 10,
        Requisito2 = 20,
        Requisito3 = 30,
        Requisito4 = 40,
        Requisito5 = 50
    }
    public class ruiz
    {
        [Key]
        public int ruizID { get; set; }

        [Required]
        [Display(Name = "Nombre Completo")]
        [StringLength(24, ErrorMessage = "no cumple con los minimos o maximos caracteres requeridos", MinimumLength = 2)]
        public string Friendofruiz { get; set; }


        [Required]
        public Places Place { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = " {0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Cumpleaños")]
        public DateTime Birthdate { get; set; }
    }

   

  
   
}