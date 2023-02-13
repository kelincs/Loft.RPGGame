using AutoMapper;
using Loft.RPGGame.Application.Contracts.Request;
using Loft.RPGGame.Application.Contracts.Validations;
using Loft.RPGGame.Domain.Entities;
using Loft.RPGGame.Domain.Interfaces;
using Loft.RPGGame.Domain.Interfaces.Contracts;
using Loft.RPGGame.WebAPI.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Loft.RPGGame.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {

        private readonly ICharacterService _characterService;
        private readonly IOccupationFactory _occupationFactory;
        private readonly IMapper _mapper;

        public CharacterController(ICharacterService characterService, IOccupationFactory occupationFactory, IMapper mapper)
        {
            _characterService = characterService;
            _occupationFactory = occupationFactory;
            _mapper = mapper;
        }

        [HttpGet("GetAllCharacters")]
        public ActionResult<IList<ICharacterResult>> Get()
        {
            try
            {
                var result = _characterService.GetAllCharacters();

                return Ok(_mapper.Map<List<Character>, List<CharacterResult>>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }            
        }      

        [HttpGet("GetCharacterDetailById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICharacterDetailResult> GetDetailById(Guid id)
        {
            try
            {
                var result = _characterService.GetCharacterById(id);

                return result is null ? NotFound() : _mapper.Map<Character, CharacterDetailResult>(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddCharacter")]
        public ActionResult Post([FromBody] CharacterRequest input)
        {
            try
            {
                var characterRequestValidator = new CharacterRequestValidator();
                var resultValidation = characterRequestValidator.Validate(input);

                if (resultValidation.IsValid)
                {
                    var filledOccupation = _occupationFactory.CreateOccupation(input.OccupationType);
                    var character = new Character() { Name = input.Name, Occupation = filledOccupation };

                    _characterService.AddCharacter(character);

                    return Ok(input);
                }
                else
                {
                    return BadRequest(resultValidation.Errors);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
