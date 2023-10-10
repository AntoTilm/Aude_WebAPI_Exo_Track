using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TB_NET_2023_APIMusique.BLL.Interfaces;
using TB_NET_2023_APIMusique.DTOs;
using TB_NET_2023_APIMusique.Mappers;

namespace TB_NET_2023_APIMusique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly ITrackService _TrackService;
        public TrackController(ITrackService trackService)
        {
            _TrackService = trackService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TrackDTO>))]
        public IActionResult GetAll()
        {
            IEnumerable<TrackDTO> result = _TrackService.GetAll().Select(t => t.ToDTO());
            return Ok(result);
        }

        [HttpGet("{trackId}")]
        [ProducesResponseType(200, Type = typeof(TrackFullDTO))]
        [ProducesResponseType(404, Type = typeof(string))]
        public IActionResult GetById([FromRoute]int trackId)
        {
            TrackFullDTO? result = _TrackService.GetById(trackId)?.ToFullDTO();

            if (result is null)
            {
                return NotFound("Track not found");
            }

            return Ok(result);
        }

    }
}
