using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplicationWithIntegrationTests.Domain.Entities;
using WebApplicationWithIntegrationTests.Repositories.Interfaces;

namespace WebApplicationWithIntegrationTests.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public async Task<IEnumerable<Person>> GetAsync()
        {
            return await Task.Run(() => new[]
            {
                new Person("John", "Doe", 34),
                new Person("John", "Smith", 30)
            });
        }

        public async Task<Person> GetAsync(Guid id)
        {
            return await Task.Run(() => new Person("John", "Doe", 34));
        }
    }
}