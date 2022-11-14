using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System;

public class BattleSkillBarView : MonoBehaviour, IBattleSkillBarView
{
    private BattleSkillBarController _controller;
    [SerializeField] private List<TextMeshProUGUI> _skillsName;
    [SerializeField] private GameObject _skillSelectionBlock;

    void Awake()
    {
        _controller = new BattleSkillBarController(this);
    }

    public void UpdateSkills(List<string> skills)
    {
        for (int i = 0; i < _skillsName.Count; i++)
        {
            _skillsName[i].text = skills[i];
        }
    }

    public void SkillSelected(TextMeshProUGUI skillName)
    {
        _controller.SkillSelected(skillName.text);
        EnableSkills(false);
    }

    public void EnableSkills(bool enable)
    {
        _skillSelectionBlock.SetActive(!enable);
    }

    public void SetOnSelectedSkillEvent(Action<string> action)
    {
        _controller.SetOnSelectedSkillEvent(action);
    }

    public void SetSkills(SkillList skills)
    {
        _controller.SetSkills(skills);
    }
}
