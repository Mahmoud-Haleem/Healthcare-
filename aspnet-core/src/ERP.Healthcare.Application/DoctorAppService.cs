using ERP.Healthcare.Doctors;
using ERP.Healthcare.Permissions;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;
using Volo.Abp.Threading;

namespace ERP.Healthcare
{
    public class DoctorAppService :
        CrudAppService<
            Doctor, //The Book entity
            DoctorDto, //Used to show books
            int, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateDoctorDto>, //Used to create/update a book
        IDoctorAppService //implement the IBookAppService
    {
        private readonly IRepository<Country, int> _countryRepository;
        private readonly IRepository<State, int> _stateRepository;
        private readonly IRepository<City, int> _cityRepository;
        private readonly IRepository<DoctorSpecialty, int> _doctorSpecialestRepository;
        private readonly IRepository<DoctorTitle, int> _doctorTitleRepository;
        private readonly IAsyncQueryableExecuter _asyncExecuter;

        public DoctorAppService(IRepository<Doctor, int> doctorRepository
            , IRepository<Country, int> countryRepository
            , IRepository<State, int> stateRepository
            , IRepository<City, int> cityRepository
            , IRepository<DoctorSpecialty, int> doctorSpecialestRepository
            , IRepository<DoctorTitle, int> doctorTitleRepository
            , IAsyncQueryableExecuter asyncExecuter
            )
            : base(doctorRepository)
        {
            _countryRepository = countryRepository;
            _stateRepository = stateRepository;
            _cityRepository = cityRepository;
            _doctorSpecialestRepository = doctorSpecialestRepository;
            _doctorTitleRepository = doctorTitleRepository;
            _asyncExecuter = asyncExecuter;

            GetPolicyName = HealthcarePermissions.Doctors.Default;
            GetListPolicyName = HealthcarePermissions.Doctors.Default;
            CreatePolicyName = HealthcarePermissions.Doctors.Create;
            UpdatePolicyName = HealthcarePermissions.Doctors.Edit;
            DeletePolicyName = HealthcarePermissions.Doctors.Delete;
        }

        protected override IQueryable<Doctor> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        { 
            return Repository.WithDetails(p => p.DoctorSpecialty, p => p.DoctorTitle, p => p.Address);
        }

        public async Task<LockupsDto> GetLockupsAsync(int countryId = 0, int stateId = 0)
        {
            var stateList = new List<State>();
            var cityList = new List<City>();

            var countryList = await _countryRepository.GetListAsync();
            
            if (countryId > 0)
            {
                var stateQuery = _stateRepository.Where(s => s.Country.Id == countryId);
                stateList = await _asyncExecuter.ToListAsync(stateQuery);

                var cityQuery = _cityRepository.Where(c => c.State.Id == stateId);
                cityList = await _asyncExecuter.ToListAsync(cityQuery);
            }

            var doctorSpecialestList = await _doctorSpecialestRepository.GetListAsync();
            var doctorTitleList = await _doctorTitleRepository.GetListAsync();

            var result = new LockupsDto
            {
                Country = ObjectMapper.Map<List<Country>, List<CountryDto>>(countryList),
                State = ObjectMapper.Map<List<State>, List<StateDto>>(stateList),
                City= ObjectMapper.Map<List<City>, List<CityDto>>(cityList),
                DoctorSpecialty = ObjectMapper.Map<List<DoctorSpecialty>, List<DoctorSpecialtyDto>>(doctorSpecialestList),
                DoctorTitle = ObjectMapper.Map<List<DoctorTitle>, List<DoctorTitleDto>>(doctorTitleList),
            };

            return result;
        }
    }
}
