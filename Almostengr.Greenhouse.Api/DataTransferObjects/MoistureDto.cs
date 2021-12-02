using System;

namespace Almostengr.Greenhouse.Api.DataTransferObjects
{
    public class MoistureDto
    {
        public int MoistureId { get; set; }
        public int MoistureLevel { get; set; }
        public DateTime Created { get; set; }
        public string SensorName { get; set; }
    }
}