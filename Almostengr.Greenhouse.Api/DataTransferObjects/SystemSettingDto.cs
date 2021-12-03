using Almostengr.Greenhouse.Api.Common;

namespace Almostengr.Greenhouse.Api.DataTransferObjects
{
    public class SystemSettingDto : BaseDto
    {
        public SettingKey Key { get; set; }
        public string Value { get; set; }
    }
}