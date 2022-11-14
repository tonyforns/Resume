using System;
using UnityEngine;

public class PlayerBattleController : CharacterBattleController
{
    [SerializeField] private BattleSkillBarView _skillBar;

    public PlayerBattleController(ICharacterBattleView view, Transform enemyTransform, ISkillCasterView skillCaster, BattleSkillBarView skillbar) : base(view, enemyTransform, skillCaster)
    {
        _skillBar = skillbar;
    }

    public new void StartBattle(CharacterModel model)
    {
        base.StartBattle(model);
        _skillBar.SetOnSelectedSkillEvent(CastSkill);
        _skillBar.SetSkills(_model.skills);
    }

    public void EnableTurn()
    {
        _skillBar.EnableSkills(true);
    }
}
