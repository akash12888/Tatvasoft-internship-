
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
    public class ThemeController : ControllerBase
    {
        private readonly ITheme _themeRepository;

        public ThemeController(ITheme themeRepository)
        {
            _themeRepository = themeRepository;

        }
        [HttpPost("CreateTheme")]
        public async Task<IActionResult> CreateTheme([FromBody] Themedto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mission = await _themeRepository.CreateTheme(model);

            return Ok(mission);
        }

        [HttpGet("GetThemes")]
        public async Task<IActionResult> GetThemeWithDetails()
        {
            var themeWithDetails = await _themeRepository.GetThemesWithDetails();
            return Ok(themeWithDetails);
        }


        [HttpGet("GetThemeById/{ThemeId}")]
        public async Task<IActionResult> GetThemeWithDetailsById(int ThemeId)
        {
            var themeWithDetails = await _themeRepository.GetThemesDetailsById(ThemeId);
            return Ok(themeWithDetails);
        }

        [HttpDelete("DeleteThemeById/{id}")]
        public async Task<IActionResult> DeleteTheme(int id)
        {
            var result = await _themeRepository.DeleteTheme(id);

            if (result == "Theme not found")
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPut("UpdateThemeById/{id}")]
        public async Task<IActionResult> UpdateTheme(int id, [FromBody] Themedto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _themeRepository.UpdateTheme(id, model);

            if (result == "Theme not found")
            {
                return NotFound(result);
            }

            return Ok(result);
        }

    }
}
