using System;
using System.Collections.Generic;
using System.Text;
using Domain.StoreContext.ValueObjects;
using Xunit;
using FluentAssertions;

namespace Tests
{

    public class DocumentTests
    {
        private readonly Document _validDocument;

        private readonly Document _invalidDocument;

        public DocumentTests()
        {
            _invalidDocument = new Document("123");
            _validDocument = new Document("36202315083");
        }

        [Fact]
        public void Constructor_ShouldReturnNotification_WhenDocumentIsInvalid()
        {

            _invalidDocument.IsValid.Should().BeFalse();
            _invalidDocument.Notifications.Count.Should().Be(1);
        }

        [Fact]
        public void Constructor_ShouldHaveNoReturn_whenDocumentIsValid()
        {

            _validDocument.IsValid.Should().BeTrue();
            _validDocument.Notifications.Count.Should().Be(0);
        }
    }
}
