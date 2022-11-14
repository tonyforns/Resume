using UnityEngine;

public class EnemyBattleController : CharacterBattleController
{
    public EnemyBattleController(ICharacterBattleView view, Transform enemyTransform, ISkillCasterView skillCaster) : base(view, enemyTransform, skillCaster)
    {

    }

    public void CastRandomSkill()
    {
        var skillModel = _model.skills.GetElement(Random.Range(0, _model.skills.Count()));
        CastSkill(skillModel.name);
    }
}
