using PawPos.Domain;
using PawPos.Domain.Ticket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PawPos.Repository
{
    public interface ITicketRepository :IRepository<Ticket>
    {
        Task<IEnumerable<Ticket>> OpenTickets();
    }
}
