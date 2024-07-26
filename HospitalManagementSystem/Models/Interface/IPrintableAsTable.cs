using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Models.Interface
{
    public interface IPrintableAsTable
    {
        string TableHeader { get; }
        string TableBody { get; }
    }
}
