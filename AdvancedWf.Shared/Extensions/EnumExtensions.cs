using System;
using System.ComponentModel.DataAnnotations;
using System.Resources;

namespace AdvancedWf.Shared.Extensions
{
    /// <summary>
    /// Helper extension to convert enum value to localized text
    /// </summary>
    public static class EnumExtensions
    {

        /// <summary>
        /// Get Enum value as localized text
        /// </summary>
        /// <param name="enumValue">ref enum</param>
        /// <returns></returns>
        public static string GetDescription(this Enum enumValue)
        {
            var fi = enumValue.GetType().GetField(enumValue.ToString());

            var attributes =
                (DisplayAttribute[])fi.GetCustomAttributes(
                typeof(DisplayAttribute),
                false);

            if (attributes.Length > 0)
                return new ResourceManager(attributes[0].ResourceType).GetString(attributes[0].Name);
            return enumValue.ToString();
        }
    }
}
