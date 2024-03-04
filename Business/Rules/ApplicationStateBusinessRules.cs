using Business.CrossCuttingConcerns.Rules;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class ApplicationStateBusinessRules : BaseBusinessRules
    {
        private readonly IApplicationStateRepository _applicationStateRepository;
        public ApplicationStateBusinessRules(IApplicationStateRepository applicationStateRepository)
        {
            _applicationStateRepository = applicationStateRepository;
        }
    }
}
