using System;
using System.Collections.Generic;
using System.Linq;

internal class BattleSkillBarController
{
    private IBattleSkillBarView _view;
    private Action<SkillModel> _OnSkillSelected;
    private SkillList _skills;
    private Dictionary<string, SkillModel> _skillsDictionary;

    public BattleSkillBarController(IBattleSkillBarView view)
    {
        _view = view;
    }

    public void SetSkills(SkillList skills)
    {
        _skills = skills;
        _view.UpdateSkills(_skillsDictionary.Keys.ToList());
    }

    public void GenerateDictionary()
    {
        _skillsDictionary.Clear();
        foreach (SkillModel skill in _skills.List())
        {
            _skillsDictionary.Add(skill.name, skill);
        }
    }

    public void SkillSelected(string skillName)
    {
        SkillModel skill;
        _skillsDictionary.TryGetValue(skillName, out skill);
        _OnSkillSelected.Invoke(skill);
    }

    internal void SetOnSelectedSkillEvent(Action<SkillModel> action)
    {
        _OnSkillSelected = action;
    }
}