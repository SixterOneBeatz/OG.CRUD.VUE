using AutoMapper;
using FluentValidation;
using MediatR;
using OG.CRUD.VUE.Application.Common.DTOs;
using OG.CRUD.VUE.Application.Common.UnitOfWork;
using OG.CRUD.VUE.Domain;

namespace OG.CRUD.VUE.Application.Features.Person.Commands
{
    public class AddPersonCommand(PersonDTO person) : IRequest<Unit>
    {
        public PersonDTO Person { get; set; } = person;
    }

    internal class AddPersonCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<AddPersonCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        public async Task<Unit> Handle(AddPersonCommand request, CancellationToken cancellationToken)
        {
            var person = _mapper.Map<PersonDOM>(request.Person);
            await _unitOfWork.PersonRepository.Add(person);

            _unitOfWork.Commit();

            return Unit.Value;
        }
    }

    internal class AddPersonCommandValidator : AbstractValidator<AddPersonCommand>
    {
        public AddPersonCommandValidator()
        {
            RuleFor(x => x.Person.FirstName)
                .NotEmpty().WithMessage("Property {FirstName} cannot be empty")
                .NotNull().WithMessage("Property {FirstName} cannot be null");

            RuleFor(x => x.Person.LastName)
                .NotEmpty().WithMessage("Property {LastName} cannot be empty")
                .NotNull().WithMessage("Property {LastName} cannot be null");

            RuleFor(x => x.Person.DoB)
                .NotEmpty().WithMessage("Property {DoB} cannot be empty")
                .NotNull().WithMessage("Property {DoB} cannot be null");
        }
    }
}
