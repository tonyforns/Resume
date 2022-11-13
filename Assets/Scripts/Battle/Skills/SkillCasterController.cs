using System.Collections.Generic;
using UnityEngine;

internal class SkillCasterController
{
    private ISkillCasterView _view;
    private SkillList _skills;
    private Dictionary<string, SkillModel> _skillsDictionary;
    private Dictionary<string, ISkillView> _skillsInstance;
    public SkillCasterController(ISkillCasterView view)
    {
        _view = view;
    }

    public void LoadSkills(SkillList skills)
    {
        _skills = skills;
        foreach (SkillModel model in _skills.List())
        {
            _skillsDictionary.Add(model.name, model);
        }
    }

    public void CastSkill(string skillName, Stats stats, Transform position)
    {
        ISkillView skillToCast;
        _skillsInstance.TryGetValue(skillName, out skillToCast);
        skillToCast = skillToCast == null ? InstantiateSkill(skillName) : skillToCast;
        skillToCast.SetPosition(position);
        skillToCast.Act(stats);
    }

    private ISkillView InstantiateSkill(string skillName)
    {
        SkillModel model;
        _skillsDictionary.TryGetValue(skillName, out model);
        ISkillView skill = _view.InstantiateSkill(model);
        _skillsInstance.Add(skillName, skill);
        return skill;
    }
}