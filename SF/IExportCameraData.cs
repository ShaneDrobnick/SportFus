using SF.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SF
{
    interface IExportCameraData
    {
       public Task<bool> GenerateCSV();
    }
}
