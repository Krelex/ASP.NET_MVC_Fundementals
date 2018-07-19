using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projekt_7_2_vj.Models.Validacije
{
    public class modelValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value  is Artikl)
            {
                Artikl ar = (Artikl)value;
                if (ar.Kolicina > 300)
                {
                    if(ar.Cijena > 1000)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}