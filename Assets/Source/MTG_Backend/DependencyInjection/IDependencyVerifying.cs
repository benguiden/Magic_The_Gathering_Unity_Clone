using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace MTG.Backend
{

    [Serializable]
    public class MissingDependencyException : Exception
    {

        public MissingDependencyException()
        {
        }

        public MissingDependencyException(string message) : base(message)
        {
        }

        public MissingDependencyException(string message, Exception inner) : base(message, inner)
        {
        }

        protected MissingDependencyException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

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

            var properties = dependencyClassType
                .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(p => p.GetCustomAttributes(typeof(Dependency), true).Length > 0);

            var missingDependencies = new List<PropertyInfo>();

            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType != typeof(bool)
                    && !property.PropertyType.IsClass)
                {
                    throw new Exception("Property return type is not a bool or class type.");
                }

                object dependencyReturnValue = property.GetValue(dependency);

                if ((dependencyReturnValue == null)
                    || (dependencyReturnValue is bool value && !value))
                {
                    missingDependencies.Add(property);
                }
            }

            if (missingDependencies.Count <= 0)
                return true;

            if (throwException)
            {
                throw new MissingDependencyException();
            }

            return false;
        }

    }

    [AttributeUsage((AttributeTargets.Property), Inherited = true, AllowMultiple = false)]
    public class Dependency : Attribute
    {

    }

}
