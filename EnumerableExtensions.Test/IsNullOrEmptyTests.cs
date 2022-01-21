namespace EnumerableExtensions.Test;

using System;
using System.Collections.Generic;

using Xunit;

public class IsNullOrEmptyTests
{
    [Fact]
    public void When_IsNull_ReturnsTrue()
    {
        IEnumerable<object>? enumerable = null;
        Assert.True(enumerable.IsNullOrEmpty());
    }

    [Fact]
    public void When_IsEmpty_ReturnsTrue()
    {
        IEnumerable<object> enumerable = Array.Empty<object>();
        Assert.True(enumerable.IsNullOrEmpty());
    }

    [Fact]
    public void When_HasSingleItem_ReturnsFalse()
    {
        IEnumerable<int> enumerable = new[] { 1 };
        Assert.False(enumerable.IsNullOrEmpty());
    }

    [Fact]
    public void When_HasMultipleItems_ReturnsFalse()
    {
        IEnumerable<int> enumerable = new[] { 1, 2, 3 };
        Assert.False(enumerable.IsNullOrEmpty());
    }
}