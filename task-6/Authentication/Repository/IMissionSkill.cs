
using Authentication.Entities;
using Authentication.Model;

namespace Authentication.Repository
{

    public interface IMissionSkill
    {
        Task<List<MissionSkillViewModel>> GetSkillWithDetails();
        Task<string> CreateSkill(MissionSkilldto model);
        Task<MissionSkillViewModel> GetSkillDetailsById(int SkillId);

        Task<string> DeleteSkill(int id);
        Task<string> UpdateSkill(int id, MissionSkilldto model);
    }
}
