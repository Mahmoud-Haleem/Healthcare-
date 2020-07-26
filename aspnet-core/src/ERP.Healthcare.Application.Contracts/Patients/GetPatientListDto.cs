using Volo.Abp.Application.Dtos;

namespace ERP.Healthcare.Patients
{
    public class GetPatientListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}