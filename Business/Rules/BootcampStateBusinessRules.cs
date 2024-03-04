using Business.CrossCuttingConcerns.Rules;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class BootcampStateBusinessRules : BaseBusinessRules
    {
        private readonly IBootcampStateRepository _bootcampStateRepository;
        public BootcampStateBusinessRules(IBootcampStateRepository bootcampStateRepository)
        {
            _bootcampStateRepository = bootcampStateRepository;
        }
    }
}
