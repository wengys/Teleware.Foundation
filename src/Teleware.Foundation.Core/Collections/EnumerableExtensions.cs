using System;
using System.Collections.Generic;

namespace Teleware.Foundation.Collections
{
    /// <summary>
    /// IEnumerable 扩展
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// 对每个元素分别执行操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action">操作</param>
        public static void Each<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            var enumerator = source.GetEnumerator();
            int i = 0;
            while (enumerator.MoveNext())
            {
                i += 1;
                action(enumerator.Current, i);
            }
        }

        /// <summary>
        /// 对每个元素分别执行操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action">操作</param>
        public static void Each<T>(this IEnumerable<T> source, Action<T> action)
        {
            var enumerator = source.GetEnumerator();

            while (enumerator.MoveNext())
            {
                action(enumerator.Current);
            }
        }
    }
}