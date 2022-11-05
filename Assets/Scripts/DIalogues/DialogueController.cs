public class DialogueController
{
    private IDialogueView _view;
    private DialogueModel currentDialogue;

    public DialogueController(IDialogueView view)
    {
        _view = view;
        _view.Hide();
    }

    public void Show(int id)
    {
        currentDialogue = DataManager.Instance.GetDialogue(id);
        _view.Show(currentDialogue);

    }

    public void Next()
    {
        currentDialogue = currentDialogue.nextDialogue;
        if (currentDialogue == null)
        {
            _view.DialogueFinish();
            Hide();
        }
        else
        {
            _view.UpdateDialogue(currentDialogue);
        }
    }   

    public void Hide()
    {
        _view.Hide();
    }
}