using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using MediatR.Pipeline;

namespace kcs.Blog.Application.ValidationRequestPreProcessor
{
    //public class ValidationRequestPreProcessor<TRequest> : IRequestPreProcessor<TRequest>
    //{
    //    private readonly IEnumerable<IValidator<TRequest>> validators;

    //    public ValidationRequestPreProcessor(IEnumerable<IValidator<TRequest>> validators)
    //    {
    //        this.validators = validators;
    //    }

    //    public Task Process(TRequest request, CancellationToken cancellationToken)
    //    {
    //        var errors = new List<ValidationFailure>();
    //        foreach (var item in this.validators.ToList())
    //        {
    //            var error = item.Validate(request);
    //            if (error != null && !error.IsValid)
    //            {
    //                errors.AddRange(error.Errors);
    //            }
    //        }

    //        if (errors.Any())
    //        {
    //            var errorBuilder = new StringBuilder();
    //            var errorDetails = new List<string>();

    //            errorBuilder.AppendLine("Invalid request, reason: ");

    //            foreach (var error in errors)
    //            {
    //                errorBuilder.AppendLine(error.ErrorMessage);
    //                errorDetails.Add(error.ErrorMessage);
    //            }

    //            throw new ValidationException(string.Join(",", errorDetails));
    //        }

    //        return Task.CompletedTask;
    //    }
    //}
    //public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    //    where TRequest : IRequest<TResponse>
    //{
    //    private readonly IEnumerable<IValidator<TRequest>> _validators;

    //    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    //    {
    //        _validators = validators;
    //    }

    //    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    //    {
    //        if (_validators.Any())
    //        {
    //            var context = new ValidationContext<TRequest>(request);

    //            var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
    //            var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

    //            if (failures.Count != 0)
    //                throw new ValidationException(failures);
    //        }
    //        return await next();
    //    }
    //}
}