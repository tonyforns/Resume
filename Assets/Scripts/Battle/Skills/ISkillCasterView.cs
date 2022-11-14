using UnityEngine;

public interface ISkillCasterView
{
    public void CastSkill(string name, Stats stats, Transform position);
    public ISkillView InstantiateSkill(SkillModel model);
    public void LoadSkills(SkillList skillList);
}