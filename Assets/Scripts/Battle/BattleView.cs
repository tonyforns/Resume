using UnityEngine;

public class BattleView : Singleton<BattleView>, IBattleView
{
    private BattleController _controller;
    [SerializeField] private CharacterBattleView _playerView;
    [SerializeField] private CharacterBattleView _enemyView;
    [SerializeField] private IBattleSkillBarView _skillBar;

    [SerializeField] public CharacterList characterList;

    new void Awake()
    {
        base.Awake();
        _controller = new BattleController(this, _playerView, _enemyView);
    }

    public void StartBattleTest()
    {
        //var characterList = DataManager.Instance.GetCharacterList();
        _controller.StartBattle(characterList.GetElement(0), characterList.GetElement(1));

    }

    public void StartBattle(CharacterModel player, CharacterModel enemy)
    {
        _controller.StartBattle(player, enemy);
    }

    public void SwitchTurn()
    {
        _controller.SwitchTurn();
    }

    public void AbilitySelected(SkillModel skill)
    {
       // _controller
    }
}
