using UnityEngine;

public class PlayerBattleView : CharacterBattleView
{
    [SerializeField] private BattleSkillBarView _skillBar;

    private void Awake()
    {
        _controller = new PlayerBattleController(this, _enemyTransform, _skillCaster, _skillBar);
    }

    public override void EnableTurn()
    {
        var controller = _controller as PlayerBattleController;
        controller.EnableTurn();
    }

    public override void StartBattle(CharacterModel model)
    {
        var controller = _controller as PlayerBattleController;
        controller.StartBattle(model);
    }

}
