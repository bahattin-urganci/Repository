using PawPos.Domain;
using PawPos.Infrastructure.Attributes;
using PawPos.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PawPos.MongoRepository.Tenants
{
    [Transient]
    public class SectionRepository: MongoRepository<Section>,ISectionRepository
    {
    }
}
