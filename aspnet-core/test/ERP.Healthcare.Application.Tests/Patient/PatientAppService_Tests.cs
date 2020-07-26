using ERP.Healthcare.Patients;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ERP.Healthcare.Patient
{
    public class PatientAppService_Tests : HealthcareApplicationTestBase
    {
        private readonly IPatientAppService _PatientAppService;

        public PatientAppService_Tests()
        {
            _PatientAppService = GetRequiredService<IPatientAppService>();
        }

        [Fact]
        public async Task Should_Get_All_Patients_Without_Any_Filter()
        {
            var result = await _PatientAppService.GetListAsync(new GetPatientListDto());

            result.TotalCount.ShouldBeGreaterThanOrEqualTo(2);
            result.Items.ShouldContain(Patient => Patient.Name == "George Orwell");
            result.Items.ShouldContain(Patient => Patient.Name == "Douglas Adams");
        }

        [Fact]
        public async Task Should_Get_Filtered_Patients()
        {
            var result = await _PatientAppService.GetListAsync(
                new GetPatientListDto { Filter = "George" });

            result.TotalCount.ShouldBeGreaterThanOrEqualTo(1);
            result.Items.ShouldContain(Patient => Patient.Name == "George Orwell");
            result.Items.ShouldNotContain(Patient => Patient.Name == "Douglas Adams");
        }

        [Fact]
        public async Task Should_Create_A_New_Patient()
        {
            var PatientDto = await _PatientAppService.CreateAsync(
                new CreatePatientDto
                {
                    Name = "Edward Bellamy",
                    BirthDate = new DateTime(1850, 05, 22),
                    ShortDescription = "Edward Bellamy was an American Patient..."
                }
            );

            PatientDto.Id.ShouldNotBe(0);
            PatientDto.Name.ShouldBe("Edward Bellamy");
        }

        [Fact]
        public async Task Should_Not_Allow_To_Create_Duplicate_Patient()
        {
            await Assert.ThrowsAsync<PatientAlreadyExistsException>(async () =>
            {
                await _PatientAppService.CreateAsync(
                    new CreatePatientDto
                    {
                        Name = "Douglas Adams",
                        BirthDate = DateTime.Now,
                        ShortDescription = "..."
                    }
                );
            });
        }

        //TODO: Test other methods...
    }
}
