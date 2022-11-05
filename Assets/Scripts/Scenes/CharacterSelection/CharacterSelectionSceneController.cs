using UnityEngine;
using System.Collections.Generic;
using System;

public class CharacterSelectionSceneController : BaseSceneController
{

    private ICharatcerSelectionSceneView _view;
    private int _allowCharacterId;
    private CharacterList characterList;
    private int characterIndex = 0;
    private Dictionary<int,int> characterDialogues;
    private int CurrentCharacterId { get => characterList.GetElement(characterIndex).id; }

    public CharacterSelectionSceneController(ICharatcerSelectionSceneView view, int allowCharacterId)
    {
        _view = view;
        _allowCharacterId = allowCharacterId;
        characterList = DataManager.Instance.GetCharacterList();
        characterDialogues = DataManager.Instance.GetCharacterSelectionDialogues();
        DialogueView.Instance.OnDialogueFinish += EvaluateCharacter;
    }

    private void EvaluateCharacter()
    {
        DialogueView.Instance.Hide();
        if (_allowCharacterId == CurrentCharacterId)
        {
            GameManager.Instance.LoadNextScene();
        }
    }

    public void CharacterSelected(int id)
    {
        int characterDialogue = 0;
        characterDialogues.TryGetValue(CurrentCharacterId, out characterDialogue);
        DialogueView.Instance.Show(characterDialogue);
    }

    public void NextCharacter()
    {
        ChangeCharacter(1);
    }

    public void PreviousCharacter()
    {
        ChangeCharacter(-1);
    }

    private void ChangeCharacter(int direction)
    {
        UpdateCharacterIndex(direction);
        CharacterModel newCharacter = characterList.GetElement(characterIndex);
        _view.UpdateCharacter(newCharacter);
    }

    internal void OnDestroy()
    {
        DialogueView.Instance.OnDialogueFinish -= EvaluateCharacter;
    }

    private void UpdateCharacterIndex(int direction)
    {
        characterIndex += direction;
        characterIndex = characterIndex < 0 ? characterList.Count() - 1 : characterList.Count() == characterIndex ? 0 : characterIndex;

    }
}
