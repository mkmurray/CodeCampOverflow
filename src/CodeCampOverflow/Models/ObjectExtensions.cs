using System;
using AutoMapper;

namespace CodeCampOverflow.Models
{
    public static class ObjectExtensions
    {
        public static object Map(this object source, Type destinationType)
        {
            if (destinationType.IsValueType && source == null)
            {
                return Activator.CreateInstance(destinationType);
            }
            return Mapper.DynamicMap(source, source.GetType(), destinationType);
        }

        public static T Map<T>(this object source)
        {
            return (T)source.Map(typeof(T));
        }
    }
}