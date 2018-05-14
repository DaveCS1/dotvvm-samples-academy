using System;
using System.ComponentModel.DataAnnotations;

namespace DotvvmAcademy.Content.Lessons.ValidationDataContext.samples
{
    public class CustomerDetailViewModel
    {
        [Required]
        public string City { get; set; }
        [Required]
        public string ZIP { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        // add the SubscriptionFrom property
        // add the SubscriptionTo property
    }
}