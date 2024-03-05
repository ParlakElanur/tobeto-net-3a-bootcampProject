using Business.Abstracts;
using Business.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class ApplicationBusinessRules : BaseBusinessRules
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IApplicantService _applicantService;
        private readonly IBootcampService _bootcampService;
        private readonly IApplicationStateService _applicationStateService;
        public ApplicationBusinessRules(IApplicationRepository applicationRepository, IApplicantService applicantService, IBootcampService bootcampService, IApplicationStateService applicationStateService)
        {
            _applicationRepository = applicationRepository;
            _applicantService = applicantService;
            _bootcampService = bootcampService;
            _applicationStateService = applicationStateService;

        }
        public async Task CheckIfApplicationIdNotExists(int id)
        {
            var isExists = await _applicationRepository.GetAsync(a => a.Id == id);
            if (isExists is null)
                throw new BusinessException("ApplicationId does not exists");
        }
        private async Task CheckIfApplicantNotExists(int id)
        {
            var isExists = await _applicantService.GetById(id);
            if (isExists is null)
                throw new BusinessException("ApplicantId does not exists");
        }
        private async Task CheckIfBootcampNotExists(int id)
        {
            var isExists = await _bootcampService.GetById(id);
            if (isExists is null)
                throw new BusinessException("BootcampId does not exists");
        }
        private async Task CheckIfApplicationStateNotExists(int id)
        {
            var isExists = await _applicationStateService.GetById(id);
            if (isExists is null)
                throw new BusinessException("ApplicationStateId does not exists");
        }
        public async Task CheckApplicationNotExists(int applicantId, int bootcampId, int applicationStateId)
        {
            await CheckIfApplicantNotExists(applicantId);
            await CheckIfBootcampNotExists(bootcampId);
            await CheckIfApplicationStateNotExists(applicationStateId);

            // üçü beraber bir kotrol eklenecek!
        }
    }
}
