using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueView : Singleton<DialogueView>, IDialogueView
{
    private DialogueController _controller;
    [SerializeField] private GameObject _viewGO;
    [SerializeField] private int layerId = 0;
    [Header("Character")]
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private Transform _modelParent;
    [Header("Dialogue")]
    [SerializeField] private Button _nextBttn;
    [SerializeField] private DialogueMessageTextComponent _dialogueMessageTextComponent;

    private int _currentPlayerId;

    public Action OnDialogueStart;
    public Action OnDialogueFinish;

    new void Awake()
    {
        base.Awake();
        _controller = new DialogueController(this);
    }
    public bool IsDialogueActive()
    {
        return _viewGO.activeSelf;
    }

    public void DialogueStart()
    {
        OnDialogueStart?.Invoke();
    }

    private void Update()
    {
        CheckInput();
    }

    public void DialogueFinish()
    {
        OnDialogueFinish?.Invoke();
    }

    public void Show(int id)
    {
        _controller.Show(id);
    }

    public void Show(DialogueModel dialogue, CharacterModel character)
    {
        _viewGO.SetActive(true);
        UpdateDialogue(dialogue, character);
    }

    public void Next()
    {
        _controller.Next();
    }

    public void Hide()
    {
        _viewGO.SetActive(false);
    }

    public void UpdateDialogue(DialogueModel dialogue, CharacterModel character)
    {
        SoundManager.Instance.PlaySound(GameSounds.CharacterDialogue);

        _dialogueMessageTextComponent.Show(dialogue.message);

        _name.text = character.name;

        if (_currentPlayerId == dialogue.idCharacter) return;
        _currentPlayerId = dialogue.idCharacter;
        if (_modelParent.childCount != 0)
        {
            Destroy(_modelParent.GetChild(0).gameObject);
        }
        GameObject model = Instantiate(character.prefab, _modelParent);
        model.layer = layerId;

    }
  
    public void CheckInput()
    {
        if(Input.anyKeyDown && _viewGO.activeSelf)
        {
            if (_dialogueMessageTextComponent.IsShowingMessage())
            {
                _dialogueMessageTextComponent.Complete();
            } else {
                Next();
            }
        }
    }

   
}
