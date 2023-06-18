using System.ComponentModel;
using System.Reflection;

namespace sendchamp.sdk
{
    public static class EnumExtensionMethods
    {
        public static string GetDescription(this Enum GenericEnum)
        {
            Type type = GenericEnum.GetType();
            MemberInfo[] member = type.GetMember(GenericEnum.ToString());
            if (member != null && member.Length != 0)
            {
                object[] customAttributes = member[0].GetCustomAttributes(typeof(DescriptionAttribute), inherit: false);
                if (customAttributes != null && customAttributes.Count() > 0)
                {
                    return ((DescriptionAttribute)customAttributes.ElementAt(0)).Description;
                }
            }

            return GenericEnum.ToString();
        }
    }
}
