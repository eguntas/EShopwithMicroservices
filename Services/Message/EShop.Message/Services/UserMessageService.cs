using AutoMapper;
using EShop.Message.DAL.Context;
using EShop.Message.DAL.Entities;
using EShop.Message.Dtos;
using Microsoft.EntityFrameworkCore;

namespace EShop.Message.Services
{
    public class UserMessageService : IUserMessageService
    {
        private readonly MessageContext _context;
        private readonly IMapper _mapper;

        public UserMessageService(MessageContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            var message = _mapper.Map<UserMessage>(createMessageDto);
            await _context.UserMessages.AddAsync(message);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMessageAsync(int id)
        {
            var value = await _context.UserMessages.FindAsync(id);
            _context.UserMessages.Remove(value);
            await _context.SaveChangesAsync();

        }

        public async Task<List<ResultMessageDto>> GetAllMessageAsync()
        {
           var values = await _context.UserMessages.ToListAsync();
            return _mapper.Map<List<ResultMessageDto>>(values);
        }

        public async Task<GetByIdMessageDto> GetByIdMessageAsync(int id)
        {
            var values = await _context.UserMessages.FindAsync(id);
            return _mapper.Map<GetByIdMessageDto>(values);
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id)
        {
            var values = await _context.UserMessages.Where(x => x.ReceiverId == id).ToListAsync();
            return _mapper.Map<List<ResultInboxMessageDto>>(values);
        }

        public async Task<List<ResultSandboxMessageDto>> GetSandboxMessageAsync(string id)
        {
            var values = await _context.UserMessages.Where(x => x.SenderId == id).ToListAsync();
            return _mapper.Map<List<ResultSandboxMessageDto>>(values);
        }

        public async Task<int> GetTotalMessageCountAsync()
        {
            return await _context.UserMessages.CountAsync();
        }

        public async Task UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            var values = _mapper.Map<UserMessage>(updateMessageDto);
            _context.UserMessages.Update(values);
            await _context.SaveChangesAsync();

        }
    }
}
