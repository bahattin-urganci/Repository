using PawPos.Domain.Ticket;
using PawPos.Infrastructure.Attributes;
using PawPos.Model;
using PawPos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawPos.Service.Services.Tenants
{
    [Transient]
    public class TicketService : BaseService, ITicketService
    {
        private ITicketRepository _ticketRepository;
        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public async Task<List<Ticket>> AllAsync() => (await _ticketRepository.GetAllAsync()).ToList();

        public async Task<ActionResponse<Ticket>> Collect(CollectDTO collect)
        {
            var ticket = await _ticketRepository.GetAsync(x => x.Id == collect.TicketId);
            ticket.RemainingAmount -= collect.Amount;
            ticket.Closed = ticket.RemainingAmount == 0;
            await _ticketRepository.SaveAsync(ticket);
            var response = CreateResponse(ticket);

            return response;
            //TODO collection ile ilgili devam edecek işler var
        }

        public async Task<Ticket> FindOneAsync(string id) => await _ticketRepository.GetAsync(x => x.Id == id);

        public async Task<List<Ticket>> OpenTickets() => Map<List<Ticket>>(await _ticketRepository.OpenTickets());

        public Task RemoveAsync(Ticket data) => _ticketRepository.RemoveAsync(data);

        public async Task<ActionResponse<Ticket>> SaveAsync(Ticket data)
        {
            data.LastOrderDate = DateTime.Now;
            data.Number = "test";
            data.TotalAmount = data.Orders.Sum(x => x.OrderAmount);
            data.RemainingAmount = data.TotalAmount;
            var response = CreateResponse(data);
            response.Response.Id = await _ticketRepository.SaveAsync(data);
            return response;
        }
    }
}
