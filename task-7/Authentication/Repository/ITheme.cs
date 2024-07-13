
using Authentication.Entities;
using Authentication.Model;

namespace Authentication.Repository
{

    public interface ITheme
    {
        Task<List<ThemeViewMODEL>> GetThemesWithDetails();
        Task<string> CreateTheme(Themedto model);
        Task<ThemeViewMODEL> GetThemesDetailsById(int ThemeId);

        Task<string> DeleteTheme(int id);
        Task<string> UpdateTheme(int id, Themedto model);
    }
}
