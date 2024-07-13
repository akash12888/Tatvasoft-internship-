
using Authentication.Model;
using Microsoft.EntityFrameworkCore;
using Authentication.Entities;
using System.Reflection;


namespace Authentication.Repository
{
    public class MissionSkill : IMissionSkill
    {
        private readonly AuthContext _authContext;

        public MissionSkill(AuthContext authContext)
        {
            _authContext = authContext;
        }

        public async Task<List<MissionSkillViewModel>> GetSkillWithDetails()
        {
            try
            {
                var SkillWithDetails = await _authContext.MissionSkill
                    .Select(MissionSkill => new MissionSkillViewModel
                    {
                        SkillId = MissionSkill.SkillId,
                        SkillName = MissionSkill.SkillName,
                        Status = MissionSkill.Status,   
                        CreatedDate = MissionSkill.CreatedDate.ToString(), 
                        ModifiedDate = MissionSkill.ModifiedDate.ToString() 
                    })
                    .ToListAsync();

                return SkillWithDetails;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve MissionSkill with details", ex);
            }
        }

        public async Task<string> CreateSkill(MissionSkilldto model)
        {
            try
            {
                var Skill = new MissionSkilldto
                {
                    SkillId = model.SkillId,
                    SkillName = model.SkillName,
                    Status = model.Status,
                    CreatedDate = model.CreatedDate, 
                    ModifiedDate = model.ModifiedDate 

                };

                _authContext.MissionSkill.Add(Skill);
                await _authContext.SaveChangesAsync();

                return "MissionSkill Created Successfully";
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create MissionSkill", ex);
            }
        }

        public async Task<MissionSkillViewModel> GetSkillDetailsById(int SkillId)
        {
            try
            {
                var SkillWithDetails = await _authContext.MissionSkill
                    .Where(MissionSkill => MissionSkill.SkillId == SkillId)
                    .Select(MissionSkill => new MissionSkillViewModel
                    {
                        SkillId = MissionSkill.SkillId,
                        SkillName = MissionSkill.SkillName,
                        Status = MissionSkill.Status,
                        CreatedDate = MissionSkill.CreatedDate.ToString(),
                        ModifiedDate = MissionSkill.ModifiedDate.ToString()
                    })
                    .FirstOrDefaultAsync();

                return SkillWithDetails;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve MissionSkill with ID {SkillId}", ex);
            }
        }

        public async Task<string> DeleteSkill(int SkillId)
        {
            try
            {
                var skill = await _authContext.MissionSkill.FindAsync(SkillId);
                if (skill == null)
                {
                    return "MissionSkill not found";
                }

                _authContext.MissionSkill.Remove(skill);
                await _authContext.SaveChangesAsync();

                return "MissionSkill Deleted Successfully";
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete theme with ID {SkillId}", ex);
            }



        }

        public async Task<string> UpdateSkill(int Id, MissionSkilldto model)
        {
           
            var skill = await _authContext.MissionSkill.FindAsync(Id);
            if (skill == null)
            {
                return "MissionSkill not found";
            }

           

            if (model.SkillName != "string")
            {
                skill.SkillName = model.SkillName;
            }
            if (model.Status != "string")
            {
                skill.Status = model.Status;
            }
        
            await _authContext.SaveChangesAsync();

            return "MissionSkill updated successfully";
        }
    }

}
