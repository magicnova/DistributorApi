using System;
using System.ComponentModel;
using System.Reflection;

namespace Distributor.Domain.Common.ExtensionMethods
{
    public static class GetEnumDescription
    {
        public static string GetDesctiption(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attribute = (DescriptionAttribute) fieldInfo?.GetCustomAttribute(typeof(DescriptionAttribute));
            return attribute?.Description;
        }
        
    }
}