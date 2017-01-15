using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigars.Database
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}
