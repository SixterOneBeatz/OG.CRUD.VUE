using FluentValidation;
using MediatR;
using OG.CRUD.VUE.Application.Common.UnitOfWork;

namespace OG.CRUD.VUE.Application.Features.Person.Commands
{
    public class DeletePersonCommand(int id) : IRequest<Unit>
    {
        public int Id { get; set; } = id;
    }

    internal class DeletePersonCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeletePersonCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.PersonRepository.Delete(request.Id);

            _unitOfWork.Commit();

            return Unit.Value;
        }
    }

    internal class DeletePersonCommandValidator : AbstractValidator<DeletePersonCommand>
    {
        public DeletePersonCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Property {Id} cannot be empty")
                .NotNull().WithMessage("Property {Id} cannot be null")
                .LessThan(1).WithMessage("Property {Id} cannot be less than 1");
        }
    }
}
