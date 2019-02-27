using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SpecianBP.Db
{
    public static class DataClassGenerator
    {
        /// <summary>
        /// Generates data from class where are nested classes representing sets with static fields representing entities.
        /// <code>
        /// public class Data 
        /// {
        ///   public class Countries
        ///   {
        ///      public static Country Cze = new Country(...);
        ///      public static Country Ger = new Country(...);
        ///   }
        /// }
        /// </code>
        /// </summary>
        public static IEnumerable<object> GetDataItems(Type dataHolderType)
        {
            var nestedTypes = dataHolderType.GetNestedTypes(BindingFlags.Public);
            foreach (var nestedType in nestedTypes)
            {
                var fields = nestedType.GetFields(BindingFlags.Static | BindingFlags.Public);
                foreach (var fieldInfo in fields)
                {
                    var value = fieldInfo.GetValue(null);
                    yield return value;
                }
            }
        }
    }
}
