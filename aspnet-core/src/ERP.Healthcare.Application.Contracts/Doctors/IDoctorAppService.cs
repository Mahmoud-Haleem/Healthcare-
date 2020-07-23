using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ERP.Healthcare.Doctors
{
    public interface IDoctorAppService :
        ICrudAppService< //Defines CRUD methods
            DoctorDto, //Used to show doctors
            int, //Primary key of the doctor entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateDoctorDto> //Used to create/update a doctor
    {

    }
}
