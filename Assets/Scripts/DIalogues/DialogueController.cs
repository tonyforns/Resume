using System.Collections.Generic;
public class DialogueController
{
    private IDialogueView _view;
    private DialogueModel _currentDialogue;
    private Dictionary<int, CharacterModel> _characterModels;

    public DialogueController(IDialogueView view)
    {
        _view = view;
        _view.Hide();
        _characterModels = DataManager.Instance.GetCharacterIdToModelDiccionary();
    }

    public void Show(int id)
    {
        _currentDialogue = DataManager.Instance.GetDialogue(id);
        _view.Show(_currentDialogue, GetDialogueCharacter());

    }

    public void Next()
    {
        _currentDialogue = _currentDialogue.nextDialogue;
        if (_currentDialogue == null)
        {
            _view.DialogueFinish();
            Hide();
        }
        else
        {
            _view.UpdateDialogue(_currentDialogue, GetDialogueCharacter());
        }
    }   

    public void Hide()
    {
        _view.Hide();
    }

    private CharacterModel GetDialogueCharacter()
    {
        CharacterModel characterModel;
        _characterModels.TryGetValue(_currentDialogue.idCharacter, out characterModel);
        return characterModel;
    }
}