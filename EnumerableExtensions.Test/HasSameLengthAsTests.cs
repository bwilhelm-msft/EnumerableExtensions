namespace EnumerableExtensions.Test;

using System;
using System.Collections.Generic;

using Xunit;

public class HasSameLengthAsTests
{
    [Fact]
    public void When_BothAreNull_ReturnsTrue()
    {
        IEnumerable<object>? first = null;
        IEnumerable<object>? second = null;
        Assert.True(first.HasSameLengthAs(second));
    }

    [Fact]
    public void When_FirstIsNullAndSecondIsEmpty_ReturnsTrue()
    {
        IEnumerable<object>? first = null;
        IEnumerable<object>? second = Array.Empty<object>();
        Assert.True(first.HasSameLengthAs(second));
    }

    [Fact]
    public void When_FirstIsEmptyAndSecondIsNull_ReturnsTrue()
    {
        IEnumerable<object>? first = Array.Empty<object>();
        IEnumerable<object>? second = null;
        Assert.True(first.HasSameLengthAs(second));
    }

    [Fact]
    public void When_FirstIsNullAndSecondIsNonEmpty_ReturnsFalse()
    {
        IEnumerable<object>? first = null;
        IEnumerable<int>? second = new[] { 1 };
        Assert.False(first.HasSameLengthAs(second));
    }

    [Fact]
    public void When_SecondIsNullAndFirstIsNonEmpty_ReturnsFalse()
    {
        IEnumerable<int>? first = new[] { 1 };
        IEnumerable<object>? second = null;
        Assert.False(first.HasSameLengthAs(second));
    }

    [Fact]
    public void When_FirstIsEmptyAndSecondIsNonEmpty_ReturnsFalse()
    {
        IEnumerable<object>? first = Array.Empty<object>();
        IEnumerable<int>? second = new[] { 1 };
        Assert.False(first.HasSameLengthAs(second));
    }

    [Fact]
    public void When_SecondIsEmptyAndFirstIsNonEmpty_ReturnsFalse()
    {
        IEnumerable<int>? first = new[] { 1 };
        IEnumerable<object>? second = Array.Empty<object>();
        Assert.False(first.HasSameLengthAs(second));
    }

    [Fact]
    public void When_FirstAndSecondAreEmpty_ReturnsTrue()
    {
        IEnumerable<object>? first = Array.Empty<object>();
        IEnumerable<object>? second = Array.Empty<object>();
        Assert.True(first.HasSameLengthAs(second));
    }

    [Fact]
    public void When_FirstIsSingleAndSecondIsMultiple_ReturnsFalse()
    {
        IEnumerable<int>? first = new[] { 1 };
        IEnumerable<int>? second = new[] { 2, 3 };
        Assert.False(first.HasSameLengthAs(second));
    }

    [Fact]
    public void When_FirstIsMultipleAndSecondIsSingle_ReturnsFalse()
    {
        IEnumerable<int>? first = new[] { 1, 2 };
        IEnumerable<int>? second = new[] { 3 };
        Assert.False(first.HasSameLengthAs(second));
    }

    [Fact]
    public void When_FirstAndSecondAreSingle_ReturnsTrue()
    {
        IEnumerable<int>? first = new[] { 1 };
        IEnumerable<int>? second = new[] { 2 };
        Assert.True(first.HasSameLengthAs(second));
    }

    [Fact]
    public void When_FirstAndSecondAreMultipleButDifferent_ReturnsFalse()
    {
        IEnumerable<int>? first = new[] { 1, 2 };
        IEnumerable<int>? second = new[] { 3, 4, 5 };
        Assert.False(first.HasSameLengthAs(second));
    }

    [Fact]
    public void When_FirstAndSecondAreMultipleAndSame_ReturnsTrue()
    {
        IEnumerable<int>? first = new[] { 1, 2 };
        IEnumerable<int>? second = new[] { 3, 4 };
        Assert.True(first.HasSameLengthAs(second));
    }
}
