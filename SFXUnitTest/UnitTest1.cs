using SF;
using SF.Model;
using System;
using System.Threading.Tasks;
using Xunit;

namespace SFXUnitTest
{
    public class UnitTest1
    {
        //I Admit i really struggled to think of some unit tests Sorry

        [Fact]
        public async Task ImportIncorrectKeyCheckAsync()
        {

            string APIKey = "j1zHbAwDsYNo4sR9FpIn";
            string URL = "https://api.transport.nsw.gov.au/v1/live/cameras";

            ImportCameraData import = new ImportCameraData(APIKey, URL);
            TrafficCameras trafficCameras = new TrafficCameras();
            trafficCameras = await import.GetTrafficCameraData();
            Assert.Null(trafficCameras.Features);
        }

        [Fact]
        public async Task ImportCorrectKeyCheckAsync()
        {
            string APIKey = "j1zHbAwDsYNo4sR9FpInRVzIX8698p9JxomI";
            string URL = "https://api.transport.nsw.gov.au/v1/live/cameras";

            ImportCameraData import = new ImportCameraData(APIKey, URL);
            TrafficCameras trafficCameras = new TrafficCameras();
            trafficCameras = await import.GetTrafficCameraData();
            Assert.NotNull(trafficCameras.Features);
        }


    }
}
