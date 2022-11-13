using UnityEngine;

public class BattleView : Singleton<BattleView>, IBattleView
{
    private BattleController _controller;
    [SerializeField] private ICharacterBattleView _playerView;
    [SerializeField] private ICharacterBattleView _enemyView;
    [SerializeField] private IBattleSkillBarView _skillBar;

    [SerializeField] public CharacterList characterList;

    new void Awake()
    {
        base.Awake();
        _controller = new BattleController(this, _playerView, _enemyView);
    }

    public void StartBattleTest()
    {
        _controller.StartBattle(characterList.GetElement(0), characterList.GetElement(1));

    }

    public void StartBattle(CharacterModel player, CharacterModel enemy)
    {
        _controller.StartBattle(player, enemy);
    }

    public void AbilitySelected(SkillModel skill)
    {
       // _controller
    }
}
