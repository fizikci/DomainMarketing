namespace Epp.Reflection
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Linq;
    using System.Reflection;
    using System.Web.UI;
    using System.Windows;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// Refelction extensions
    /// </summary>
    internal static class ReflectionExtensions
    {
        /// <summary>
        /// Gets all custom referenced assemblies recursivelly
        /// </summary>
        /// <param name="assembly">Assembly in the top of hierarchy</param>
        /// <returns>All custom assemblies recursivelly referenced by the top assembly</returns>
        public static List<Assembly> GetCustomReferencedAssemblies(this Assembly assembly)
        {
            return assembly.GetAllReferencedAssemblies(GetPrimaryExcluding().ToList()).Distinct().ToList();
        }

        /// <summary>
        /// Gets all custom referenced assemblies recursivelly from current AppDomain
        /// </summary>
        /// <returns>All custom assemblies recursivelly referenced by the current AppDomain</returns>
        public static List<Assembly> GetDomainReferencedAssemblies()
        {
            return AppDomain
                .CurrentDomain
                .GetAssemblies()
                .SelectMany(assembly => assembly.GetCustomReferencedAssemblies())
                .Distinct().ToList();
        }

        /// <summary>
        /// Gets referenced assemblies recursivelly
        /// </summary>
        /// <param name="assembly">Assembly in the top of hierarchy</param>
        /// <param name="excluding">Exceptional assemblies</param>
        /// <returns>All assemblies recursivelly referenced by the top assembly</returns>
        private static IEnumerable<Assembly> GetAllReferencedAssemblies(this Assembly assembly, List<Assembly> excluding)
        {
            yield return assembly;
            var refAssemblies = assembly
                .GetReferencedAssemblies()
                .Select(asm =>
                {
                    try
                    {
                        var asm2 = Assembly.Load(asm);
                        return asm2;
                    }
                    catch
                    {
                        return null;
                    }
                })
                .Where(asm => asm != null && !excluding.Contains(asm))
                .SelectMany(asm => asm.GetAllReferencedAssemblies(excluding.Concat(Enumerable.Repeat(assembly, 1)).ToList())).ToList();

            foreach (var refAsm in refAssemblies)
            {
                yield return refAsm;
            }
        }

        /// <summary>
        /// Gets primary excluding assemblies
        /// </summary>
        /// <returns>Sequence of primary excluding assemblies</returns>
        private static IEnumerable<Assembly> GetPrimaryExcluding()
        {
            yield return typeof(object).Assembly;
            yield return typeof(HashSet<>).Assembly;
            yield return typeof(Uri).Assembly;
            yield return typeof(DataTable).Assembly;
            yield return typeof(XElement).Assembly;
            yield return typeof(XmlWriter).Assembly;
            yield return typeof(DependencyObject).Assembly;
            yield return typeof(Page).Assembly;
            yield return typeof(ConfigurationElement).Assembly;
        }
    }
}
