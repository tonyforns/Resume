using System;
using System.Collections.Generic;

public interface IBattleSkillBarView
{
    void UpdateSkills(List<string> skills);
    void EnableSkills();
    void SetOnSelectedSkillEvent(Action<SkillModel> action);
}