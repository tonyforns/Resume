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
        for (int i = 0; i < _skillsName.Count - 1; i++)
        {
            _skillsName[i].text = skills[i];
        }
    }

    public void SkillSelected(TextMeshProUGUI skillName)
    {
        _controller.SkillSelected(skillName.text);
        _skillSelectionBlock.SetActive(false);
    }

    public void EnableSkills()
    {
        _skillSelectionBlock.SetActive(true);
    }

    public void SetOnSelectedSkillEvent(Action<SkillModel> action)
    {
        _controller.SetOnSelectedSkillEvent(action);
    }
}
