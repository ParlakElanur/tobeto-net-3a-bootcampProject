using AutoMapper;
using Business.Abstracts;
using Business.Requests.Blacklist;
using Business.Responses.Blacklist;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class BlacklistManager : IBlacklistService
    {
        private readonly IBlacklistRepository _blacklistRepository;
        private readonly IMapper _mapper;

        public BlacklistManager(IBlacklistRepository blacklistRepository, IMapper mapper)
        {
            _blacklistRepository = blacklistRepository;
            _mapper = mapper;
        }
        public async Task<IDataResult<GetByIdBlacklistResponse>> GetAsync(int id)
        {
            Blacklist blacklist = await _blacklistRepository.GetAsync(b => b.Id == id);
            GetByIdBlacklistResponse blacklistResponse = _mapper.Map<GetByIdBlacklistResponse>(blacklist);

            return new SuccessDataResult<GetByIdBlacklistResponse>(blacklistResponse, "Received successfully");
        }
        public async Task<IDataResult<CreateBlacklistResponse>> AddAsync(CreateBlacklistRequest request)
        {
            Blacklist blacklist = _mapper.Map<Blacklist>(request);
            blacklist.CreatedDate = DateTime.UtcNow;
            await _blacklistRepository.AddAsync(blacklist);

            CreateBlacklistResponse blacklistResponse = _mapper.Map<CreateBlacklistResponse>(blacklist);

            return new SuccessDataResult<CreateBlacklistResponse>(blacklistResponse, "Added successfully");
        }
        public async Task<IDataResult<UpdateBlacklistResponse>> UpdateAsync(UpdateBlacklistRequest request)
        {
            Blacklist blacklist = _mapper.Map<Blacklist>(request);
            blacklist.UpdatedDate = DateTime.UtcNow;
            await _blacklistRepository.UpdateAsync(blacklist);

            UpdateBlacklistResponse blacklistResponse = _mapper.Map<UpdateBlacklistResponse>(blacklist);

            return new SuccessDataResult<UpdateBlacklistResponse>(blacklistResponse, "Updated successfully");
        }
        public async Task<IResult> DeleteAsync(DeleteBlacklistRequest request)
        {
            Blacklist blacklist = await _blacklistRepository.GetAsync(b => b.Id == request.Id);
            blacklist.DeletedDate = DateTime.UtcNow;
            await _blacklistRepository.DeleteAsync(blacklist);

            return new SuccessResult("Deleted successfully");
        }
        public async Task<IDataResult<List<GetAllBlacklistResponse>>> GetAllAsync()
        {
            List<Blacklist> blacklists = await _blacklistRepository.GetAllAsync();
            List<GetAllBlacklistResponse> getAllBlacklists = _mapper.Map<List<GetAllBlacklistResponse>>(blacklists);

            return new SuccessDataResult<List<GetAllBlacklistResponse>>(getAllBlacklists, "Listed successfully");
        }
    }
}
