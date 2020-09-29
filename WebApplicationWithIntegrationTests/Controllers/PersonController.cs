using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationWithIntegrationTests.Services.Interfaces;

namespace WebApplicationWithIntegrationTests.Controllers
{
    public class PersonController : BaseController
    {
        private readonly IPersonService service;

        public PersonController(IPersonService personService)
        {
            service = personService;
        }

        // TODO: Add CancellationToken.
        [HttpGet]
        [Authorize(AuthenticationSchemes = "testAuthScheme")]
        public async Task<IActionResult> GetAsync()
        {
            var persons = await service.GetAsync();
            return Ok(persons);
        }

        // TODO: Add CancellationToken.
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = "tokenBasedAuthScheme")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var person = await service.GetAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }
    }
}