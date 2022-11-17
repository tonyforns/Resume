public interface IBattleView
{
    void SetBattleMessage(string message);
    void CharacterCastSkill(string characterName, string skillName);
    void CharacterTakenBySkill(string characterName, string damage); // TODO: Add skill type to define damage or buff
    void CharacterTurnStart(string characterName);

}