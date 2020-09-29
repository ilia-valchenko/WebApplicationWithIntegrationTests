using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplicationWithIntegrationTests.Domain.Entities;

namespace WebApplicationWithIntegrationTests.Services.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetAsync();

        Task<Person> GetAsync(Guid id);
    }
}