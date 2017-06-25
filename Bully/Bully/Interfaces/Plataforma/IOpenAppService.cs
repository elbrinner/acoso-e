using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bully.Interfaces.Plataforma
{
    public interface IOpenAppService
    {
        Task<bool> Launch(string stringUri);
    }
}
