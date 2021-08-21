using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MTG.Backend
{

    [AttributeUsage((AttributeTargets.Property), Inherited = true, AllowMultiple = false)]
    public class Dependency : Attribute
    {

    }

    public static class DependencyVerifying
    {

        public static bool VerifyDependencies(IDependency dependency, bool throwException = true)
        {
            if (dependency == null)
            {
                if (throwException)
                    throw new ArgumentNullException(nameof(dependency));
                return false;
            }

            Type dependencyClassType = dependency.GetType();

            var properties =
                dependencyClassType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            var dependencyInterfaces = dependencyClassType.GetInterfaces().ToArray();

            dependencyInterfaces = dependencyInterfaces.Where(i => i.GetInterfaces().Contains(typeof(IDependency))).ToArray();

            var dependencyInterfaceProperties = dependencyInterfaces.SelectMany(i =>
                i.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)).ToArray();

            properties = properties.Where(property => dependencyInterfaceProperties.Any(dependencyProperty => dependencyProperty.Name.Equals(property.Name))).ToArray();

            var missingDependencies = properties.Where(p => IsMissingDependency(dependency, p)).ToArray();

            if (missingDependencies.Length <= 0)
                return true;

            if (throwException)
                throw new MissingDependencyException();

            return false;
        }

        private static bool IsMissingDependency(IDependency dependency, PropertyInfo property)
        {
            object dependencyReturnValue = property.GetValue(dependency);

            //Bool
            if (property.PropertyType == typeof(bool)) 
            {
                return !((bool) dependencyReturnValue);
            }
            
            //Class
            if (property.PropertyType.IsClass) 
            {
                return dependencyReturnValue == null;
            }
            
            //Array
            if (property.PropertyType.IsArray)
            {
                return dependencyReturnValue == null || ((object[]) dependencyReturnValue).Any(o => o == null);
            }
            
            //Generic Enumerable
            if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
            {
                return dependencyReturnValue == null || ((IEnumerable<object>) dependencyReturnValue).Any(o => o == null);
            }

            throw new NotImplementedException();
        }

    }

}
