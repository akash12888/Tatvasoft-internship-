
using Authentication.Entities;
using Authentication.Model;
using Authentication.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionSkillController : ControllerBase
    {
        private readonly IMissionSkill _MissionSkillRepository;

        public MissionSkillController(IMissionSkill MissionSkillRepository)
        {
            _MissionSkillRepository = MissionSkillRepository;

        }
        [HttpPost("CreateSkill")]
        public async Task<IActionResult> CreateSkill([FromBody] MissionSkilldto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var skill = await _MissionSkillRepository.CreateSkill(model);

            return Ok(skill);
        }

        [HttpGet("GetSkill")]
        public async Task<IActionResult> GetSkillWithDetails()
        {
            var skillWithDetails = await _MissionSkillRepository.GetSkillWithDetails();
            return Ok(skillWithDetails);
        }


        [HttpGet("GetSkillById/{SkillId}")]
        public async Task<IActionResult> GetSkillWithDetailsById(int SkillId)
        {
            var skillWithDetails = await _MissionSkillRepository.GetSkillDetailsById(SkillId);
            return Ok(skillWithDetails);
        }

        [HttpDelete("DeleteSkillById/{id}")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            var result = await _MissionSkillRepository.DeleteSkill(id);

            if (result == "MissionSkill not found")
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPut("UpdateSkillById/{id}")]
        public async Task<IActionResult> UpdateTheme(int id, [FromBody] MissionSkilldto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _MissionSkillRepository.UpdateSkill(id, model);

            if (result == "MissionSkill not found")
            {
                return NotFound(result);
            }

            return Ok(result);
        }

    }
}
