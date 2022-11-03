using System;

public class DialogueController
{
    private IDialogueView _view;
    private DialogueModel currentDialogue;

    public DialogueController(IDialogueView view)
    {
        _view = view;
    }

    public void Show(int id)
    {
        currentDialogue = DataManager.Instance.GetDialogue(id);

    }

    public void Next()
    {
        
    }
}