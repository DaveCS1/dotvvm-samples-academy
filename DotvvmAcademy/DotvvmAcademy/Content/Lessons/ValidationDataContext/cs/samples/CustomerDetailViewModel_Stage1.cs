using System.ComponentModel.DataAnnotations;

namespace DotvvmAcademy.Tutorial.ViewModels
{
    public class CustomerDetailViewModel
    {
        //p�idjte atribut Required 
        public string City { get; set; }
        //p�idjte atribut Required 
        public string ZIP { get; set; }
        //p�idjte atribut EmailAddress
        public string Email { get; set; }
    }
}