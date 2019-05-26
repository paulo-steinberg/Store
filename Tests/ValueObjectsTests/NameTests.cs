using System;
using System.Collections.Generic;
using System.Text;
using Domain.StoreContext.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Tests
{
    public class NameTests
    {
        [Fact]
        public void Constructor_WhenNameIsEmpty_ShouldBeFalse()
        {
            var name = new Name("", "");
            name.IsValid.Should().BeFalse();
        }

        [Fact]
        public void Constructor_WhenNameIsLessThanThreeChars_ShouldBeFalse()
        {
            var name = new Name("as", "as");
            name.IsValid.Should().BeFalse();
        }

        [Fact]
        public void Constructor_WhenNameIsMoreThanFortyChars_ShouldBeFalse()
        {
            var name = new Name("aasdasdasdasdasdasdasdasdasdsadasdasdasdasdasdasds", "ddasdsadasdasdasdasdsadasdasdasdasdasdsadsadasdsadsads");
            name.IsValid.Should().BeFalse();
        }
    }
}
