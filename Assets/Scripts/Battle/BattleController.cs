﻿using System;
using UnityEngine;

public class BattleController
{
    private IBattleView _view;
    private ICharacterBattleView _player;
    private ICharacterBattleView _enemy;
    private ICharacterBattleView _characterOnTurn;

    public BattleController(IBattleView battleView, ICharacterBattleView playerView, ICharacterBattleView enemyView)
    {
        _view = battleView;
        _player = playerView;
        _enemy = enemyView;
    }

    public void StartBattle(CharacterModel playerModel, CharacterModel enemyModel)
    {
        PlayerBattleView player = _player as PlayerBattleView;
        player.StartBattle(playerModel);
        EnemyBattleView enemy = _enemy as EnemyBattleView;
        enemy.StartBattle(enemyModel);
        _characterOnTurn = playerModel.stats.dexterity > enemyModel.stats.dexterity ? _player : _enemy;
        _characterOnTurn.EnableTurn();
    }

    public void SwitchTurn()
    {
        _characterOnTurn = _characterOnTurn == _player ? _enemy : _player;
        _characterOnTurn.EnableTurn();
    }

    internal void CharacterTakenBySkill(string characterName, string damage)
    {
        _view.SetBattleMessage($"{characterName} was hited and get {damage} life points of damage!");
    }

    internal void CharacterCastSkill(string characterName, string skillName)
    {
        _view.SetBattleMessage($"{characterName} use {skillName}!");
    }

    internal void CharacterTurnStart(string characterName)
    {
        _view.SetBattleMessage($"Is {characterName} turn to attack!");
    }
}