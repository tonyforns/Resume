public interface IDialogueView
{
    void Show(DialogueModel dialogue);
    void Hide();
    void Next();
    void UpdateDialogue(DialogueModel dialogue);
}