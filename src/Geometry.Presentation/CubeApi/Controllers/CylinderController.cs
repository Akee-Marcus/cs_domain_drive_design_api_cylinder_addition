using Microsoft.AspNetCore.Mvc;

namespace CubeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CylinderController : ControllerBase
    {
        private readonly CylinderService _service;
        public CylinderController(CylinderService service)
        {
            _service = service;
        }

        /// <summary>
        /// Creates a new Cylinder.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(double radius, double height)
        {
            var result = await _service.CreateAsync(radius, height);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        /// <summary>
        /// Reads a Cylinder by ID.
        /// </summary>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var cylinder = await _service.GetAsync(id);
            if (cylinder is null)
                return NotFound();

            return Ok(cylinder);
        }

        /// <summary>
        /// Updates an existing Cylinder.
        /// </summary>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, double radius, double height)
        {
            await _service.UpdateAsync(id, radius, height);
            return NoContent();
        }

        /// <summary>
        /// Deletes a Cylinder.
        /// </summary>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }

}
