using System;
using UnityEngine;

public class PlayerBattleController : CharacterBattleController
{
    private IBattleSkillBarView _skillBar;

    public PlayerBattleController(ICharacterBattleView view, Transform enemyTransform,IBattleSkillBarView skillbar) : base(view, enemyTransform)
    {
        _skillBar = skillbar;
        _skillBar.SetOnSelectedSkillEvent(_view.CastSkill);
    }

    /*public new void CastSkill(SkillModel skill, SkillView skillView )
    {

    }*/
}
