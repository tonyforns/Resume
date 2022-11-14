using UnityEngine;
using System.Collections.Generic;

public interface ICharacterBattleView
{
    void Hited(int damage);
    void Faint();
    void StartBattle(CharacterModel model);
    void SetCharacter(string name, int lvl, int maxLife, GameObject prefab);
    void UpdateLife(int newValue);
    void SetDebuff();
    void EnableTurn();
    Transform GetTransform();
}