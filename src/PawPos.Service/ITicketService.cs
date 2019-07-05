using PawPos.Domain.Ticket;
using PawPos.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PawPos.Service
{
    public interface ITicketService :IBaseService<Ticket>
    {
        Task<List<Ticket>> OpenTickets();
        Task<ActionResponse<Ticket>> Collect(CollectDTO collect);
    }
}
