namespace Munix.Miniflux
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;

    internal class EnumConverter<T>
        where T : struct
    {
        private readonly IDictionary<T, string> lookup;

        private readonly IDictionary<string, T> reverseLookup;

        public EnumConverter()
        {
            this.lookup = BuildLookup();
            this.reverseLookup = this.lookup.ToDictionary(x => x.Value, x => x.Key);
        }

        public static IDictionary<T, string> BuildLookup()
        {
            var data = (from T n in Enum.GetValues(typeof(T))
                        select new { Value = n, Name = GetEnumDescription(n) })
                        .Where(x => x.Name != null);
            return data.ToDictionary(x => x.Value, x => x.Name);
        }

        public T ToEnum(string value)
        {
            T result = default(T);

            if (!string.IsNullOrWhiteSpace(value))
            {
                bool found = this.reverseLookup.TryGetValue(value, out result);

                if (!found)
                {
                    throw new InvalidCastException($"Cannot convert value {value} to {typeof(T)}");
                }
            }

            return result;
        }

        public string ToString(T value)
        {
            string result = null;

            if (!value.Equals(default(T)))
            {
                bool found = this.lookup.TryGetValue(value, out result);

                if (!found)
                {
                    throw new InvalidCastException($"Cannot convert value {value} to Json");
                }
            }

            return result;
        }

        private static string GetEnumDescription(object value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return null;
        }
    }
}
