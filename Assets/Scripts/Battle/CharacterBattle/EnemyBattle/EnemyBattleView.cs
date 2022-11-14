public class EnemyBattleView : CharacterBattleView
{
    private void Awake()
    {
        _controller = new EnemyBattleController(this, _enemyTransform, _skillCaster);
    }
    public override void EnableTurn()
    {
        EnemyBattleController controller = _controller as EnemyBattleController;
        controller.CastRandomSkill();
    }

}
