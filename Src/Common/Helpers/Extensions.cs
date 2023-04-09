using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Common.Helpers
{
    public static class Extensions
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
        public static int ToInt(this Enum value)
        {

            return (int)(IConvertible)value;
        }
        public static IQueryable<T> Page<T>(this IQueryable<T> queryable, int CurrentPage, int PageSize)
        {
            if (CurrentPage == 0 && PageSize == 0)
            {
                return queryable;
            }
            else
            {
                return queryable.Skip((CurrentPage - 1) * PageSize).Take(PageSize);
            }
        }
        public static bool HasValue(this string value)
        {
            return !string.IsNullOrEmpty(value?.Trim());
        }
        public static string FirstCharToUpper(this string input) =>
        input switch
        {
            null => throw new ArgumentNullException(nameof(input)),
            "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
            _ => input.First().ToString().ToUpper() + input.Substring(1)
        };
        public static string TrimAndLower(this string str)
        {
            return str.Trim().ToLower();
        }
        public static bool IsValidPhone(string Phone)
        {
            try
            {
                if (string.IsNullOrEmpty(Phone))
                    return false;
                var r = new Regex(@"^\+[1-9]\d{1,14}$");
                return r.IsMatch(Phone);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }
}
