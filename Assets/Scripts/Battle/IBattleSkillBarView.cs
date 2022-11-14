using System;
using System.Collections.Generic;

public interface IBattleSkillBarView
{
    void SetSkills(SkillList skills);
    void UpdateSkills(List<string> skills);
    void EnableSkills(bool enable);
    void SetOnSelectedSkillEvent(Action<string> action);
}