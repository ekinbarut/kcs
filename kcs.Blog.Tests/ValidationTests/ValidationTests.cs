using FluentAssertions;
using kcs.Blog.Abstraction.Command;
using kcs.Blog.Abstraction.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace kcs.Blog.Tests.ValidationTests
{
    public class ValidationTests
    {
        private CreateArticleCommandValidator createArticleCommandValidator { get; }
        private UpdateArticleCommandValidator updateArticleCommandValidator { get; }
        private AddReviewCommandValidator addReviewCommandValidator { get; }
        private UpdateReviewCommandValidator updateReviewCommandValidator { get; }
        private RemoveReviewCommandValidator removeReviewCommandValidator { get; }
        private DeleteArticleCommandValidator deleteArticleCommandValidator { get; }


        public ValidationTests()
        {
            createArticleCommandValidator = new CreateArticleCommandValidator();
            updateArticleCommandValidator = new UpdateArticleCommandValidator();
            addReviewCommandValidator = new AddReviewCommandValidator();
            updateReviewCommandValidator = new UpdateReviewCommandValidator();
            removeReviewCommandValidator = new RemoveReviewCommandValidator();
            deleteArticleCommandValidator = new DeleteArticleCommandValidator();
        }

        [Fact]
        public void CreateArticleCommandValidationShouldReturnFalse()
        {
            var request = new UpdateArticleCommand();

            updateArticleCommandValidator.Validate(request).IsValid.Should().BeFalse();
        }

        [Fact]
        public void UpdateArticleCommandValidationShouldReturnFalse()
        {
            var request = new CreateArticleCommand();

            createArticleCommandValidator.Validate(request).IsValid.Should().BeFalse();
        }
        [Fact]

        public void AddReviewCommandValidationShouldReturnFalse()
        {
            var request = new AddReviewCommand();

            addReviewCommandValidator.Validate(request).IsValid.Should().BeFalse();
        }

        [Fact]
        public void UpdateReviewCommandValidationShouldReturnFalse()
        {
            var request = new UpdateReviewCommand();

            updateReviewCommandValidator.Validate(request).IsValid.Should().BeFalse();
        }

        [Fact]
        public void RemoveReviewCommandValidationShouldReturnFalse()
        {
            var request = new RemoveReviewCommand();

            removeReviewCommandValidator.Validate(request).IsValid.Should().BeFalse();
        }

        [Fact]
        public void DeleteArticleCommandValidationShouldReturnFalse()
        {
            var request = new DeleteArticleCommand();

            deleteArticleCommandValidator.Validate(request).IsValid.Should().BeFalse();
        }

    }
}
