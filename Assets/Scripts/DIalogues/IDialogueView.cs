public interface IDialogueView
{
    void Show(int id);
    void Show(DialogueModel dialogue, CharacterModel character);
    void Hide();
    void Next();
    void UpdateDialogue(DialogueModel dialogue, CharacterModel character);
    void DialogueFinish();
    void DialogueStart();
}