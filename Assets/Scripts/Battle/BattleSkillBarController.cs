using System;
using System.Collections.Generic;
using System.Linq;

internal class BattleSkillBarController
{
    private IBattleSkillBarView _view;
    private Action<string> _OnSkillSelected;
    private SkillList _skills;
    private Dictionary<string, SkillModel> _skillsDictionary = new Dictionary<string, SkillModel>();

    public BattleSkillBarController(IBattleSkillBarView view)
    {
        _view = view;
    }

    public void SetSkills(SkillList skills)
    {
        _skills = skills;
        GenerateDictionary();
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
        _OnSkillSelected.Invoke(skillName);
    }

    internal void SetOnSelectedSkillEvent(Action<string> action)
    {
        _OnSkillSelected = action;
    }
}