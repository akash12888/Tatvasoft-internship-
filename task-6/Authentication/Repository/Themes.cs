
using Authentication.Model;
using Microsoft.EntityFrameworkCore;
using Authentication.Entities;


namespace Authentication.Repository
{
    public class Theme : ITheme
    {
        private readonly AuthContext _authContext;

        public Theme(AuthContext authContext)
        {
            _authContext = authContext;
        }

        public async Task<List<ThemeViewMODEL>> GetThemesWithDetails()
        {
            try
            {
                var themesWithDetails = await _authContext.Themes
                    .Select(theme => new ThemeViewMODEL
                    {
                        ThemeId = theme.ThemeId,
                        ThemeName = theme.ThemeName,
                        CreatedDate = theme.CreatedDate.ToString(), 
                        ModifiedDate = theme.ModifiedDate.ToString() 
                    })
                    .ToListAsync();

                return themesWithDetails;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve themes with details", ex);
            }
        }

        public async Task<string> CreateTheme(Themedto model)
        {
            try
            {
                var theme = new Themedto
                {
                    ThemeId = model.ThemeId,
                    ThemeName = model.ThemeName,
                    CreatedDate = model.CreatedDate, 
                    ModifiedDate = model.ModifiedDate 

                };

                _authContext.Themes.Add(theme);
                await _authContext.SaveChangesAsync();

                return "Theme Created Successfully";
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create theme", ex);
            }
        }

        public async Task<ThemeViewMODEL> GetThemesDetailsById(int themeId)
        {
            try
            {
                var themeWithDetails = await _authContext.Themes
                    .Where(theme => theme.ThemeId == themeId)
                    .Select(theme => new ThemeViewMODEL
                    {
                        ThemeId = theme.ThemeId,
                        ThemeName = theme.ThemeName,
                        CreatedDate = theme.CreatedDate.ToString(), 
                        ModifiedDate = theme.ModifiedDate.ToString() 
                    })
                    .FirstOrDefaultAsync();

                return themeWithDetails;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve theme with ID {themeId}", ex);
            }
        }

        public async Task<string> DeleteTheme(int themeId)
        {
            try
            {
                var theme = await _authContext.Themes.FindAsync(themeId);
                if (theme == null)
                {
                    return "Theme not found";
                }

                _authContext.Themes.Remove(theme);
                await _authContext.SaveChangesAsync();

                return "Theme Deleted Successfully";
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete theme with ID {themeId}", ex);
            }



        }

         public async Task<string> UpdateTheme(int Id, Themedto model)
        {
            // Find the theme by id
            var theme = await _authContext.Themes.FindAsync(Id);
            if (theme == null)
            {
                return "Theme not found";
            }
            
            theme.ThemeName = model.ThemeName;

            // Update other properties...

            // Save changes
            await _authContext.SaveChangesAsync();

            return "Theme updated successfully";
        }
    }

}
