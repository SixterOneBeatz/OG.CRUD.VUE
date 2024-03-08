using AutoMapper;
using MediatR;
using OG.CRUD.VUE.Application.Common.DTOs;
using OG.CRUD.VUE.Application.Common.UnitOfWork;

namespace OG.CRUD.VUE.Application.Features.Person.Queries
{
    public class GetPersonsQuery : IRequest<List<PersonDTO>> { }

    internal class GetPersonsQueryHandler : IRequestHandler<GetPersonsQuery, List<PersonDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPersonsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<PersonDTO>> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
        {
            var persons = await _unitOfWork.PersonRepository.GetAll();

            var result = _mapper.Map<List<PersonDTO>>(persons);

            return result;
        }
    }
}
