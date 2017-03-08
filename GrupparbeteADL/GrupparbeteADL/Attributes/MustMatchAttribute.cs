using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrupparbeteADL.Attributes
{
    public class MustMatchAttribute : ValidationAttribute
    {
        string password;

        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            return value.ToString().Equals(password);
                
        }

        public MustMatchAttribute(string password)
        {
            this.password = password;
        }

    }
}
