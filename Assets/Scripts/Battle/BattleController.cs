using System;
using UnityEngine;

public class BattleController
{
    private IBattleView _view;
    private ICharacterBattleView _player;
    private ICharacterBattleView _enemy;
    private ICharacterBattleView _characterOnTurn;

    [SerializeField] public CharacterModel player;
    [SerializeField] public CharacterModel enemy;

    public BattleController(IBattleView battleView, ICharacterBattleView playerView, ICharacterBattleView enemyView)
    {
        _view = battleView;
        _player = playerView;
        _enemy = enemyView;
    }

    public void StartBattle(CharacterModel playerModel, CharacterModel enemyModel)
    {
        _player.StartBattle(playerModel);
        _enemy.StartBattle(enemyModel);
        _characterOnTurn = playerModel.stats.dexterity > enemyModel.stats.dexterity ? _player : _enemy;
        _characterOnTurn.EnableTurn();
    }

    public void SwitchTurn()
    {
        _characterOnTurn = _characterOnTurn == _player ? _enemy : _player;
        _characterOnTurn.EnableTurn();
    }
}