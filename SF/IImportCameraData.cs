using SF.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SF
{
    public interface IImportCameraData
    {
        Task<TrafficCameras> GetTrafficCameraData();
    }
}
