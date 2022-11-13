using System;
using UnityEngine;
public class SkillAttackController : SkillController
{
    public SkillAttackController(ISkillView view)
    {
        _view = view;
    }

    public override void Act(Stats stats)
    {
        _stats = stats;
        _view.SetActive(true);
    }

    public override void CharacterHit(ICharacterBattleView character)
    {
        character.Hited(20);
    }
}
