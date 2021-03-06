﻿using System.Collections.Generic;

namespace KoreanNewsDownloader.Extensions
{
    public static class IEnumerableExt
    {
        /// <summary>
        /// Wraps this object instance into an IEnumerable<T>
        /// consisting of a single item.
        /// </summary>
        /// <typeparam name="T"> Type of the object. </typeparam>
        /// <param name="item"> The instance that will be wrapped. </param>
        /// <returns> An IEnumerable<T> consisting of a single item. </returns>
        public static IEnumerable<T> Yield<T>(this T item)
        {
            yield return item;
        }
    }
}
