using System;
using System.Collections.Generic;
using System.Reflection;

namespace UrlBuilder.Helpers
{
    /// <summary>
    /// Some simple utility methods for generic object operations.
    /// </summary>
    public class ReflectionHelpers
    {
        /// <summary>
        /// Enumerate through an object's properties and perform user defined action
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="callback"></param>
        public static void ObjectEnumerate(object obj, Action<PropertyInfo> callback)
        {
            foreach (var prop in obj.GetType().GetProperties())
            {
                callback(prop);
            }
        }
        
        /// <summary>
        /// Map any object to any type of list using a user defined callback.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="callback"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> MapObject<T>(object obj, Func<PropertyInfo, T> callback)
        {
            var list = new List<T>();
            
            ObjectEnumerate(obj, prop =>
            {
                list.Add(callback(prop)); 
            });

            return list;
        }
    }
}