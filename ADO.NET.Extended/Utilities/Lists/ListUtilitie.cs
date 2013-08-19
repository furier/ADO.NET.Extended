#region Using statements

using System.Collections.Generic;
using System.Linq;
using ADO.NET.Extended.Connection.Database.Implementation;
using ADO.NET.Extended.Connection.Database.Interface;

#endregion

namespace ADO.NET.Extended.Utilities.Lists
{
    /// <summary>
    ///     List utilitie.
    /// </summary>
    public static class ListUtilitie
    {
        /// <summary>
        ///     A List extension method that splits a list into smaller lists.
        /// </summary>
        /// <param name="source">       The source to act on. </param>
        /// <param name="splitSize">    Size of the split. </param>
        /// <returns>
        ///     .
        /// </returns>
        public static List<List<object>> Split(this List<object> source, int splitSize)
        {
            return source
                    .Select((x, i) => new {Index = i, Value = x})
                    .GroupBy(x => x.Index / splitSize)
                    .Select(x => x.Select(v => v.Value).ToList())
                    .ToList();
        }

        /// <summary>
        ///     An ICollection extension method that splits a Collection into smaller lists.
        /// </summary>
        /// <remarks>
        ///     SASTRU, 24.07.2013.
        /// </remarks>
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="source">       The source to act on. </param>
        /// <param name="splitSize">    Size of the split. </param>
        /// <returns>
        ///     A list of.
        /// </returns>
        public static ICollection<List<T>> Split<T>(this ICollection<T> source, int splitSize)
        {
            return source
                    .Select((x, i) => new {Index = i, Value = x})
                    .GroupBy(x => x.Index / splitSize)
                    .Select(x => x.Select(v => v.Value).ToList())
                    .ToList();
        }

        /// <summary>
        ///     An ICollection extension method that determine if two Collections are equal.
        /// </summary>
        /// <remarks>
        ///     SASTRU, 24.07.2013.
        /// </remarks>
        /// <param name="collectionA">  The collection a to act on. </param>
        /// <param name="collectionB">  The collection b. </param>
        /// <returns>
        ///     true if equal, false if not.
        /// </returns>
        public static bool AreEqual(this ICollection<object> collectionA, ICollection<object> collectionB)
        {
            var aEnumerator = collectionA.GetEnumerator();
            var bEnumerator = collectionB.GetEnumerator();
            while((aEnumerator.MoveNext()) && (bEnumerator.MoveNext()))
            {
                if(aEnumerator.Current != null && bEnumerator.Current != null && aEnumerator.Current.Equals(bEnumerator.Current)) continue;
                return false;
            }
            return true;
        }

        public static bool AreEqual(this ICollection<ICommand> collectionA, ICollection<ICommand> collectionB)
        {
            return collectionA.Cast<object>().ToList().AreEqual(collectionB.Cast<object>().ToList());
        }

        public static bool AreEqual(this ICollection<ScriptBundle> collectionA, ICollection<ScriptBundle> collectionB)
        {
            return collectionA.Cast<object>().ToList().AreEqual(collectionB.Cast<object>().ToList());
        }
    }
}