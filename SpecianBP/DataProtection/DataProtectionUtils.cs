using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SpecianBP.DataProtection
{
    public static class DataProtectionUtils
    {
        /// <summary>
        /// Using reflection inspects the class, returning all grants in a flat structure
        /// </summary>
        /// <typeparam name="T">Type that holds the grants</typeparam>
        /// <returns></returns>
        public static Dictionary<string, IGrant> GetAllGrantsFlat<T>()
        {
            return typeof(T).GetFlatStructureFromNestedGrants(new HashSet<string>(), 1);
        }

        private static Dictionary<string, IGrant> GetFlatStructureFromNestedGrants(this Type root, HashSet<string> usedIds, int depth)
        {
            if (depth > 10)
            {
                throw new Exception("Maximum depth of the grant structure deep traversing (10) has been execessed");
            }
            var module = new Dictionary<string, IGrant>();
            var nestedTypes = root.GetNestedTypes(BindingFlags.Public);
            foreach (var nestedType in nestedTypes)
            {

                var newDict = nestedType.GetFlatStructureFromNestedGrants(usedIds, depth + 1);
                module = new[] { module, newDict }.SelectMany(dict => dict)
                    .ToDictionary(pair => pair.Key, pair => pair.Value);
            }
            root.LoadGrants(module, usedIds, grant => grant, true);
            return module;
        }

        private static void LoadGrants<T>(this Type root, Dictionary<string, T> output, HashSet<string> usedIds, Func<IGrant, T> transformer, bool useIdOfTheGrantAsDictionaryKey)
        {
            // grants
            var fields = root.GetFields(BindingFlags.Static | BindingFlags.Public);
            foreach (var fieldInfo in fields)
            {
                if (fieldInfo.GetValue(null) is IGrant value)
                {
                    var id = value.Id;
                    if (id != null)
                    {
                        if (usedIds.Contains(id.ToLower()))
                        {
                            throw new Exception($"There is duplicated Grant Code '{id}' in the grants");
                        }
                        usedIds.Add(id.ToLower());
                        output.Add(useIdOfTheGrantAsDictionaryKey ? value.Id : fieldInfo.Name, transformer(value));
                    }
                }
            }
        }
    }
}
