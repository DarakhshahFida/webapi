using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaskManagementSystem.Domain.Enums
{
    // JSON serialization as strings
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Priority
    {
        //override the default enum-to-string conversion for serialization.
        [EnumMember(Value = "Low")]
        Low,

        [EnumMember(Value = "Medium")]
        Medium,

        [EnumMember(Value = "High")]
        High
    }
}
