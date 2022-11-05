using UnityEngine;
using TMPro;
public class CharacterSelectionSceneView : Singleton<CharacterSelectionSceneView>, ICharatcerSelectionSceneView
{
    private CharacterSelectionSceneController _controller;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private Transform _modelParent;
    [SerializeField] private GameObject _stats;


    new void Awake()
    {
        base.Awake();
        _controller = new CharacterSelectionSceneController(this);
    }

    public void NextCharacter()
    {
        _controller.NextCharacter();
    }

    public void PreviousCharacter()
    {
        _controller.PreviousCharacter();
    }

    public void UpdateCharacter(CharacterModel newCharacter)
    {
        _name.text = newCharacter.name;
        _description.text = newCharacter.description;
        GameObject model = _modelParent.GetChild(0).gameObject;
        if (model) Destroy(model);
        Instantiate(newCharacter.prefab, _modelParent);
    }

}
