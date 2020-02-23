using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCProject.Models.Entity_Framework;

namespace MVCProject.ViewModels
{
    public class PersonelFormViewModel
    {
        public IEnumerable<Departman> Departmanlar { get;set;}
        public Personel Personel { get; set; }
    }
}