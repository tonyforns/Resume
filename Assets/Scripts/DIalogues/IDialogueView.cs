public interface IDialogueView
{
    void Show(int id);
    void Show(DialogueModel dialogue);
    void Hide();
    void Next();
    void UpdateDialogue(DialogueModel dialogue);
    void DialogueFinish();
}