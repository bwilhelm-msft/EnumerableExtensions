namespace EnumerableExtensions;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

public static class Extensions
{
    /// <summary>
    /// Determine whether the enumerable type is null or empty.
    /// </summary>
    /// <typeparam name="T">The item type of the enumerable</typeparam>
    /// <param name="enumerable">The enumerable</param>
    /// <returns><c>true</c> if the enumerable is null or empty; otherwise <c>false</c></returns>
    public static bool IsNullOrEmpty<T>(this IEnumerable<T>? enumerable)
    {
        return enumerable is null || !enumerable.GetEnumerator().MoveNext();
    }

    /// <summary>
    /// Determines whether the first enumerable instance has the same length as the second enumerable instance. The two instances do not need to have the same item type. An instance that is null or empty is considering to have a length of 0.
    /// </summary>
    /// <typeparam name="TFirst">The type of the first instance</typeparam>
    /// <typeparam name="TSecond">The type of the second instance</typeparam>
    /// <param name="first">The first enumerable instance</param>
    /// <param name="second">The second enumerable instance</param>
    /// <returns><c>true</c> if the two instance have the same length; otherwise <c>false</c>.</returns>
    public static bool HasSameLengthAs<TFirst, TSecond>(this IEnumerable<TFirst>? first, IEnumerable<TSecond>? second)
    {
        if (first is null)
        {
            return second.IsNullOrEmpty();
        }

        if (second is null)
        {
            return first.IsNullOrEmpty();
        }

        var firstEnumerator = first.GetEnumerator();
        var secondEnumerator = second.GetEnumerator();

        while (firstEnumerator.MoveNext())
        {
            if (!secondEnumerator.MoveNext())
            {
                return false;
            }
        }

        return !secondEnumerator.MoveNext();
    }
}
