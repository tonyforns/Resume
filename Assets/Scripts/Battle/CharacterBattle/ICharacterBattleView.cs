using UnityEngine;
using System.Collections.Generic;

public interface ICharacterBattleView
{
    void Hited(int damage);
    void Faint();
    void StartBattle(CharacterModel model);
    void SetCharacter(string name, int lvl, int maxLife, GameObject prefab, List<string> abilities);
    void UpdateLife(int newValue);
    void SetDebuff();
    void EnableTurn();
    void CastSkill(SkillModel skill);
}