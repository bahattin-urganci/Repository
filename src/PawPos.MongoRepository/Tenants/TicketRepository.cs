using PawPos.Domain;
using PawPos.Domain.Ticket;
using PawPos.Infrastructure.Attributes;
using PawPos.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PawPos.MongoRepository.Tenants
{
    [Transient]
    public class TicketRepository:MongoRepository<Ticket>,ITicketRepository
    {
        public TicketRepository(IDatabaseFinder databaseFinder)
        {
            SetConnection(databaseFinder.GetDbSettings());
        }

        public Task<IEnumerable<Ticket>> OpenTickets() => FindAsync(x => !x.Closed);
    }
}
