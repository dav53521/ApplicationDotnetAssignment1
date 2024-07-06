using ApplicationDotnetAssignment1.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Models
{
    public class Admin: IAdmin
    {
        public int Id { get; set; }
        public virtual LoginDetails LoginDetails { get; set; }
    }
}
