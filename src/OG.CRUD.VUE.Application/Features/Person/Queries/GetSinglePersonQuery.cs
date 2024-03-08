using AutoMapper;
using FluentValidation;
using MediatR;
using OG.CRUD.VUE.Application.Common.DTOs;
using OG.CRUD.VUE.Application.Common.Exceptions;
using OG.CRUD.VUE.Application.Common.UnitOfWork;

namespace OG.CRUD.VUE.Application.Features.Person.Queries
{
    public class GetSinglePersonQuery(int id) : IRequest<PersonDTO>
    {
        public int Id { get; set; } = id;
    }

    internal class GetSinglePersonQueryHandler : IRequestHandler<GetSinglePersonQuery, PersonDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetSinglePersonQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PersonDTO> Handle(GetSinglePersonQuery request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.PersonRepository.GetSingle(request.Id);

            if (person is null)
            {
                throw new NotFoundException("Person", request.Id);
            }

            return _mapper.Map<PersonDTO>(person);
        }
    }

    internal class GetSinglePersonQueryValidator : AbstractValidator<GetSinglePersonQuery>
    {
        public GetSinglePersonQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Property {Id} cannot be empty")
                .NotNull().WithMessage("Property {Id} cannot be null")
                .NotEqual(0).WithMessage("Property {Id} cannot be 0");
        }
    }
}
