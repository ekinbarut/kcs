using FluentValidation;

namespace kcs.Blog.Abstraction.Validator
{
    public abstract class BaseValidator<T> : AbstractValidator<T>, IBaseValidator<T>
    {
        protected BaseValidator()
        {
            this.CascadeMode = CascadeMode.Continue;
        }
    }
}
