using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFightStick.Ioc
{
    public static class ReflectionUtils
    {
        public static void ForceLoadAssembliesBySchema(string schema)
        {
            var assemblies = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, schema);
            foreach (var assembly in assemblies)
            {
                try
                {
                    Assembly.LoadFrom(assembly);
                }
                catch
                {
                    throw;
                }
            }
        }

        public static IEnumerable<Type> GetTypes<T>(IEnumerable<Assembly> assemblies)
        {
            return assemblies?.SelectMany(a => a.GetTypes())
                .Where(t => typeof(T).IsAssignableFrom(t) && !t.IsInterface);
        }

        public static IEnumerable<T> CreateTypes<T>(IEnumerable<Type> types)
        {
            foreach (var type in types)
            {
                yield return (T)Activator.CreateInstance(type);
            }
        }
    }
}
