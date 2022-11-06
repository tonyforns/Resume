public class DialogueModel
{
    public int idDialogue;
    public DialogueType type;
    public string message;
    public int idCharacter;
    public DialogueModel nextDialogue;

    public DialogueModel(int idDialogue, string message, int idCharacter, DialogueModel nextDialogue)
    {
        this.idDialogue = idDialogue;
        this.message = message;
        this.idCharacter = idCharacter;
        this.nextDialogue = nextDialogue;
    }

    public DialogueModel()
    {
    }

    
}