using Business.CrossCuttingConcerns.Rules;
using DataAccess.Abstracts;
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
        public ApplicationBusinessRules(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }
    }
}
