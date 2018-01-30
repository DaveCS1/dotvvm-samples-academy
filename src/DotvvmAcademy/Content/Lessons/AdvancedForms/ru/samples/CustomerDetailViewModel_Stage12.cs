using System;
using System.Collections.Generic;

namespace DotvvmAcademy.Lessons.AdvancedForms.ViewModels
{
    public class CustomerDetailViewModel
    {
        public CustomerDetailViewModel()
        {
            Countries = new List<CountryInfo>();
            Countries.Add(new CountryInfo() { Id = 1, Name = "USA" });
            Countries.Add(new CountryInfo() { Id = 2, Name = "Canada" });
        }

        public CustomerInfo NewCustomer { get; set; }

        public List<CountryInfo> Countries { get; set; }
    }
}