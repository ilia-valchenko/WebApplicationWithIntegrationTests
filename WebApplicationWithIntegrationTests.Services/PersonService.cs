using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplicationWithIntegrationTests.Domain.Entities;
using WebApplicationWithIntegrationTests.Repositories.Interfaces;
using WebApplicationWithIntegrationTests.Services.Interfaces;

namespace WebApplicationWithIntegrationTests.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository repository;

        public PersonService(IPersonRepository personRepository)
        {
            repository = personRepository;
        }

        public async Task<IEnumerable<Person>> GetAsync()
        {
            return await repository.GetAsync();
        }

        public async Task<Person> GetAsync(Guid id)
        {
            return await repository.GetAsync(id);
        }
    }
}