public interface IDialogueView
{
    void Show(DialogueModel dialogue);
    void Hide();
    void Next();
    void Update(DialogueModel dialogue);
}