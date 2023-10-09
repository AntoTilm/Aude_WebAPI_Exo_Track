using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TB_NET_2023_APIMusique.BLL.CustomExceptions;
using TB_NET_2023_APIMusique.BLL.Interfaces;
using TB_NET_2023_APIMusique.DTOs;
using TB_NET_2023_APIMusique.Mappers;

namespace TB_NET_2023_APIMusique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _ArtistService;

        public ArtistController(IArtistService artistService)
        {
            _ArtistService = artistService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ArtistDTO>))]
        public IActionResult GetAll()
        {
            IEnumerable<ArtistDTO> result = _ArtistService.GetAll().Select(a => a.ToDTO());
            return Ok(result);
        }

        [HttpGet("{artistId}")]
        [ProducesResponseType(404, Type = typeof(string))]
        [ProducesResponseType(200, Type = typeof(ArtistDTO))]
        public IActionResult GetById([FromRoute] int artistId)
        {
            ArtistDTO? artistDTO = _ArtistService.GetById(artistId)?.ToDTO();
            if (artistDTO is null)
            {
                return NotFound("Artist not found");
            }

            return Ok(artistDTO);

        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ArtistDTO))]
        public IActionResult Insert([FromBody] ArtistDataDTO artist)
        {
            ArtistDTO result = _ArtistService.Insert(artist.ToModel()).ToDTO();
            return CreatedAtAction(nameof(GetById), new { artistId = result.Id }, result);

        }

        [HttpDelete("{artistId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404, Type=typeof(string))]
        [ProducesResponseType(409, Type=typeof(string))] //Conflict
        [ProducesResponseType(400)]
        public IActionResult Delete([FromRoute]int artistId)
        {
            bool deleted;
            try
            {
                deleted = _ArtistService.Delete(artistId);
            }
            catch (AlreadySingingException ex)
            {
                return Conflict(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return deleted ? NoContent() : NotFound("Artist not found");
        }

        [HttpPut("{artistId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404, Type = typeof(string))]
        public IActionResult Update([FromRoute]int artistId, [FromBody]ArtistDataDTO artist)
        {
            bool updated;
            try
            {
                updated = _ArtistService.Update(artistId, artist.ToModel());

            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message); 
            }

            return updated ? NoContent() : NotFound("Artist Not Found");
        }
       
    }
}
