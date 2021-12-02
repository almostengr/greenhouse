using Almostengr.Greenhouse.Api.DataTransferObjects;

namespace Almostengr.Greenhouse.Api.Models
{
    public class Moisture : BaseModel
    {
        public int MoistureLevel { get; set; }
        public string SensorName { get; set; }

        public MoistureDto ToDto()
        {
            return new MoistureDto
            {
                MoistureId = Id,
                Created = Created,
                MoistureLevel = MoistureLevel,
                SensorName = SensorName
            };
        }

        public static Moisture FromDto(MoistureDto dto)
        {
            return new Moisture
            {
                Id = dto.MoistureId,
                Created = dto.Created,
                MoistureLevel = dto.MoistureLevel,
                SensorName = dto.SensorName
            };
        }
        
    }
}