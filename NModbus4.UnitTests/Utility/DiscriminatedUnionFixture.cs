﻿using System;
using Modbus.Utility;
using Xunit;

namespace Modbus.UnitTests.Utility;

public class DiscriminatedUnionFixture
{
    [Fact]
    public void DiscriminatedUnion_CreateA()
    {
        DiscriminatedUnion<string, string>? du = DiscriminatedUnion<string, string>.CreateA("foo");
        Assert.Equal(DiscriminatedUnionOption.A, du.Option);
        Assert.Equal("foo", du.A);
    }

    [Fact]
    public void DiscriminatedUnion_CreateB()
    {
        DiscriminatedUnion<string, string>? du = DiscriminatedUnion<string, string>.CreateB("foo");
        Assert.Equal(DiscriminatedUnionOption.B, du.Option);
        Assert.Equal("foo", du.B);
    }

    [Fact]
    public void DiscriminatedUnion_AllowNulls()
    {
        DiscriminatedUnion<object, object>? du = DiscriminatedUnion<object, object>.CreateB(null);
        Assert.Equal(DiscriminatedUnionOption.B, du.Option);
        Assert.Equal(null, du.B);
    }

    [Fact]
    public void AccessInvalidOption_A()
    {
        DiscriminatedUnion<string, string>? du = DiscriminatedUnion<string, string>.CreateB("foo");
        Assert.Throws<InvalidOperationException>(() => du.A.ToString());
    }

    [Fact]
    public void AccessInvalidOption_B()
    {
        DiscriminatedUnion<string, string>? du = DiscriminatedUnion<string, string>.CreateA("foo");
        Assert.Throws<InvalidOperationException>(() => du.B.ToString());
    }

    [Fact]
    public void DiscriminatedUnion_ToString()
    {
        DiscriminatedUnion<string, string>? du = DiscriminatedUnion<string, string>.CreateA("foo");
        Assert.Equal(du.ToString(), "foo");
    }
}