using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueView : Singleton<DialogueView>, IDialogueView
{
    private DialogueController _controller;
    [SerializeField] private GameObject viewGO;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Button nextBttn;
    public Action OnDialogueFinish;


    new void Awake()
    {
        base.Awake();
        _controller = new DialogueController(this);
    }

    public void DialogueFinish()
    {
        OnDialogueFinish?.Invoke();
    }

    public void Show(int id)
    {
        _controller.Show(id);
    }

    public void Show(DialogueModel dialogue)
    {
        UpdateDialogue(dialogue);
        viewGO.SetActive(true);
    }

    public void Next()
    {
        Debug.Log("Next Dialogue");
        _controller.Next();
    }

    public void Hide()
    {
        viewGO.SetActive(false);
    }

    public void UpdateDialogue(DialogueModel dialogue)
    {
        messageText.text = dialogue.message;
    }

    public void CheckInput()
    {
        if(Input.anyKeyDown && viewGO.activeSelf)
        {
            Next();
        }
    }

    private void Update()
    {
        CheckInput();
    }
}
