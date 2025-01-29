using Business.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Models;

namespace ThunderTasks.Controllers
{
    [ApiController]
    [Route("odata/[controller]")]
    public class BaseController<T> : ControllerBase where T : BaseDbModel
    {
        protected readonly IGenericRepository<T> _repository;

        public BaseController(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [EnableQuery]
        public virtual IActionResult GetAll()
        {
            try
            {
                return Ok(_repository.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public virtual async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var item = await _repository.GetByIdAsync(id);
                if (item == null)
                    return NotFound();

                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create([FromBody] T model)
        {
            try
            {
                if (model == null)
                    return BadRequest("Dados inválidos.");

                var created = await _repository.CreateAsync(model);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public virtual async Task<IActionResult> Update(Guid id, [FromBody] T model)
        {
            try
            {
                if (id != model.Id)
                    return BadRequest("IDs não coincidem.");

                var updated = await _repository.UpdateAsync(model);
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _repository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
