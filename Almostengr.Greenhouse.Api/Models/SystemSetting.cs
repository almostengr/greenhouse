using System;
using Almostengr.Greenhouse.Api.Common;

namespace Almostengr.Greenhouse.Api.Models
{
    public class SystemSetting : BaseModel
    {
        public SettingKey Key { get; set; }
        public string Value { get; set; }
        public DateTime Modified { get; set; }
    }
}