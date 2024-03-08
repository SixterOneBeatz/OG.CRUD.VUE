using AutoMapper;
using FluentValidation;
using MediatR;
using OG.CRUD.VUE.Application.Common.DTOs;
using OG.CRUD.VUE.Application.Common.Exceptions;
using OG.CRUD.VUE.Application.Common.UnitOfWork;
using OG.CRUD.VUE.Domain;

namespace OG.CRUD.VUE.Application.Features.Person.Commands
{
    public class UpdatePersonCommand(PersonDTO person) : IRequest<Unit>
    {
        public PersonDTO Person { get; set; } = person;
    }

    internal class UpdatePersonCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdatePersonCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.PersonRepository.GetSingle(request.Person.Id);

            if (person is null)
            {
                throw new NotFoundException("Person", request.Person.Id);
            }

            person = _mapper.Map<PersonDOM>(request.Person);
            await _unitOfWork.PersonRepository.Update(person);

            _unitOfWork.Commit();

            return Unit.Value;
        }
    }

    internal class UpdatePersonCommandValidator : AbstractValidator<UpdatePersonCommand>
    {
        public UpdatePersonCommandValidator()
        {
            RuleFor(x => x.Person.Id)
                .NotEmpty().WithMessage("Property {Id} cannot be empty")
                .NotNull().WithMessage("Property {Id} cannot be null")
                .LessThan(1).WithMessage("Property {Id} cannot be less than 1");

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
