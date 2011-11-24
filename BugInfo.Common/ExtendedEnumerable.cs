

namespace FxLib.Algorithms
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Data;

    public static partial class ExtendedEnumerable
    {
        [DebuggerStepThrough]
        public static void SafeForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            if (items == null)
                return;
            items.ForEach(action);
        }

        [DebuggerStepThrough]
        public static T[] SafeSort<T>(this IEnumerable<T> items, Func<CompareCode<T>, CompareCode<T>> compareAction)
        {
            return SafeSort(items, compareAction(new CompareCode<T>()));
        }

        [DebuggerStepThrough]
        public static T UnSafeItem<T>(this T item, string ifNullMessage) where T : class
        {
            if (item == null)
                throw new ArgumentNullException(ifNullMessage);
            else
                return item;
        }

        [DebuggerStepThrough]
        public static T[] SafeSort<T>(this IEnumerable<T> items, CompareCode<T> compareCode)
        {
            T[] array = items.SafeToArray();
            int len = array.Length;
            if (len == 0)
                return array;


            Array.Sort<T>(array, (x, y) => compareCode.Compare(x, y));

            return array;
        }

        [DebuggerStepThrough]
        public static IEnumerable<T> SafeUniqueItems<T>(this IEnumerable<T> items, Func<CompareCode<T>, CompareCode<T>> compareAction)
        {
            CompareCode<T> comp = new CompareCode<T>();
            return SafeUniqueItems(items, compareAction(comp));
        }

        private static IEnumerable<T> SafeUniqueItems<T>(this IEnumerable<T> items, CompareCode<T> compareCode)
        {
            T[] sortedArray = items.SafeSort(compareCode);

            int len = sortedArray.Length;
            if (len == 0)
                return sortedArray;

            Stack<T> uniqueItems = new Stack<T>();

            uniqueItems.Push(sortedArray[0]);
            for (int i = 1; i < len; i++)
            {
                if (compareCode.Compare(uniqueItems.Peek(), sortedArray[i]) != 0)
                    uniqueItems.Push(sortedArray[i]);
            }

            return uniqueItems;
        }



        [DebuggerStepThrough]
        public static List<OutT> SafeConvertAllItems<InputT, OutT>(this IEnumerable<InputT> items, Converter<InputT, IEnumerable<OutT>> converter)
        {
            List<OutT> list = new List<OutT>();

            items.SafeForEach(n => list.AddRange(converter(n).SafeItem(()=>new OutT[] { })));
            return list;
        }

        public static T SafeItem<T>(this T item, Func<T> defaultAction) where T : class
        {
            if (item == null)
                return defaultAction();
            else
                return item;

        }

        private static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            var en = items.GetEnumerator();
            while (en.MoveNext())
                action(en.Current);
        }

        [DebuggerStepThrough]
        public static T SafeFind<T>(this IEnumerable<T> items, Predicate<T> predicate)
        {
            T item;
            if (items.SafeTryFind(predicate, out item))
                return item;
            else
                return default(T);
        }


        [DebuggerStepThrough]
        public static bool SafeTryFind<T>(this IEnumerable<T> items, Predicate<T> predicate, out T item)
        {
            item = default(T);
            if (items == null)
            {
                return false;
            }

            var en = items.GetEnumerator();
            while (en.MoveNext())
            {
                if (predicate(en.Current))
                {
                    item = en.Current;
                    return true;
                }
            }

            return false;
        }



        [DebuggerStepThrough]
        public static List<T> SafeFindAll<T>(this IEnumerable<T> items, Predicate<T> predicate)
        {
            if (items == null)
                return new List<T>();

            return items.FindAll(predicate);
        }

        private static List<T> FindAll<T>(this IEnumerable<T> items, Predicate<T> predicate)
        {
            if (items is List<T>)
                return ((List<T>)items).FindAll(predicate);

            if (items is T[])
                return new List<T>(Array.FindAll((T[])items, predicate));

            List<T> list = new List<T>();

            var en = items.GetEnumerator();

            while (en.MoveNext())
            {
                if (predicate(en.Current))
                    list.Add(en.Current);
            }

            return list;
        }

        [DebuggerStepThrough]
        public static int SafeCount<T>(this IEnumerable<T> items)
        {
            if (items == null)
                return 0;

            if (items is IList)
                return ((IList)items).Count;

            if (items is T[])
                return ((T[])items).Length;

            return items.Count(null);
        }

        [DebuggerStepThrough]
        public static int SafeCount<T>(this IEnumerable<T> items, Predicate<T> predicate)
        {
            if (items == null)
                return 0;
            else
                return items.Count(predicate);
        }

        private static int Count<T>(this IEnumerable<T> items, Predicate<T> predicate)
        {
            int count = 0;
            if (predicate == null)
            {
                if (items is IList)
                    return ((IList)items).Count;

                if (items is T[])
                    return ((T[])items).Length;


                var en = items.GetEnumerator();
                while (en.MoveNext())
                    count++;
                return count;
            }
            else
            {
                if (items is List<T>)
                    return ((List<T>)items).FindAll(predicate).Count;

                if (items is T[])
                    return Array.FindAll((T[])items, predicate).Length;

                var en = items.GetEnumerator();
                while (en.MoveNext())
                {
                    if (predicate(en.Current))
                        count++;
                }
                return count;
            }
        }

        [DebuggerStepThrough]
        public static List<OutT> SafeConvertAll<InputT, OutT>(this IEnumerable<InputT> items, Converter<InputT, OutT> converter)
        {
            if (items == null)
                return new List<OutT>();

            var items1 = items as List<InputT>;
            if (items1 != null)
                return items1.ConvertAll(n => converter(n));

            List<OutT> list = new List<OutT>(items.Count(null));
            var en = items.GetEnumerator();
            while (en.MoveNext())
            {
                list.Add(converter(en.Current));
            }

            return list;
        }


        [DebuggerStepThrough]
        public static T[] SafeToArray<T>(this IEnumerable<T> items)
        {
            if (items == null)
                return new T[] { };

            if (items is T[])
                return (T[])items;

            if (items is List<T>)
                return ((List<T>)items).ToArray();

            T[] rets = (T[])Array.CreateInstance(typeof(T), items.Count(null));
            int index = 0;
            var en = items.GetEnumerator();

            while (en.MoveNext())
            {
                rets[index++] = en.Current;
            }

            return rets;
        }

        [DebuggerStepThrough]
        public static IEnumerable<T> SafeToEnumerable<T>(this IEnumerable<T> items)
        {
            if (items == null)
                return new T[] { };
            else
                return items;
        }



        [DebuggerStepThrough]
        public static bool SafeExists<T>(this IEnumerable<T> items, Predicate<T> predicate)
        {
            T item;
            return items.SafeTryFind(predicate, out item);
        }

     
        

        public static bool SafeIsEqual<T>(this IEnumerable<T> source, IEnumerable<T> target)
        {
            return !(source.SafeExists(n => !target.SafeExists(m => Comparer<T>.Default.Compare(m, n) == 0))
                || target.SafeExists(n => !source.SafeExists(m => Comparer<T>.Default.Compare(m, n) == 0)));
        }


    }


}

