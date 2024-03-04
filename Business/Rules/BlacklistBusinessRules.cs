using Business.CrossCuttingConcerns.Rules;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class BlacklistBusinessRules : BaseBusinessRules
    {
        private readonly IBlacklistRepository _blacklistRepository;
        public BlacklistBusinessRules(IBlacklistRepository blacklistRepository)
        {
            _blacklistRepository = blacklistRepository;
        }
    }
}
