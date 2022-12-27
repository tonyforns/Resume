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
    [SerializeField] private TextMeshProUGUI _messageText;
    [SerializeField] private Button _nextBttn;
    private int _currentPlayerId;
    
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
        UpdateDialogue(dialogue, character);
        _viewGO.SetActive(true);
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
        _messageText.text = dialogue.message;
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
            Next();
        }
    }

   
}
