using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro.DataSeed
{
    public interface IJulieProDbContextSeed
    {
        Task SeedAsync(int retry = 0);
    }
}
