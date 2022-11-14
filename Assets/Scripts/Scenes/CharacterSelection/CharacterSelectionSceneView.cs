using UnityEngine;
using TMPro;
public class CharacterSelectionSceneView : Singleton<CharacterSelectionSceneView>, ICharatcerSelectionSceneView
{
    private CharacterSelectionSceneController _controller;
    [SerializeField] private int allowCharacterId = 0;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private UnityEngine.Transform _modelParent;
    [SerializeField] private GameObject _stats;

    new void Awake()
    {
        base.Awake();
        _controller = new CharacterSelectionSceneController(this, allowCharacterId);
    }

    public void NextCharacter()
    {
        _controller.NextCharacter();
    }

    public void ChoseCharacter()
    {
        _controller.CharacterSelected();
    }

    public void PreviousCharacter()
    {
        _controller.PreviousCharacter();
    }

    public void UpdateCharacter(CharacterModel newCharacter)
    {
        _name.text = newCharacter.name;
        _description.text = newCharacter.description;
        SetCharacterModel(newCharacter);
        SetStats(newCharacter);
    }

    private void SetCharacterModel(CharacterModel newCharacter)
    {
        if (_modelParent.childCount != 0)
        {
            Destroy(_modelParent.GetChild(0).gameObject);
        }
        Instantiate(newCharacter.prefab, _modelParent);
    }

    private void SetStats(CharacterModel newCharacter)
    {

    }

    private void OnDestroy()
    {
        _controller.OnDestroy();
    }

}
