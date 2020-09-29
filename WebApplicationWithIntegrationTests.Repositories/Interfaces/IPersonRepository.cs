using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplicationWithIntegrationTests.Domain.Entities;

namespace WebApplicationWithIntegrationTests.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAsync();

        Task<Person> GetAsync(Guid id);
    }
}