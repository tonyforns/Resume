using UnityEngine;
using UnityEngine.UIElements;

public class DialogueView : Singleton<DialogueView>, IDialogueView
{
    private DialogueController _controller;
    [SerializeField] private GameObject viewGO;
    [SerializeField] private TextMesh messageText; 

    void Awake()
    {
        base.Awake();
        _controller = new DialogueController(this);
    }

    public void Show(DialogueModel dialogue)
    {
        Update(dialogue);
        viewGO.SetActive(true);
    }

    public void Next()
    {
        _controller.Next();
    }

    public void Hide()
    {
        viewGO.SetActive(false);
    }

    public void Update(DialogueModel dialogue)
    {
        messageText.text = dialogue.message;
    }
}
