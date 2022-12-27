using UnityEngine;
using TMPro;
public class CharacterSelectionSceneView : Singleton<CharacterSelectionSceneView>, ICharatcerSelectionSceneView
{
    private CharacterSelectionSceneController _controller;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private TextMeshProUGUI _lvl;
    [SerializeField] private TextMeshProUGUI _life;
    [SerializeField] private TextMeshProUGUI _strenght;
    [SerializeField] private TextMeshProUGUI _intelligent;
    [SerializeField] private TextMeshProUGUI _wisdom;
    [SerializeField] private TextMeshProUGUI _charisma;
    [SerializeField] private TextMeshProUGUI _dexterity;
    [SerializeField] private Transform _modelParent;
    [SerializeField] private GameObject _stats;

    new void Awake()
    {
        base.Awake();
        _controller = new CharacterSelectionSceneController(this, DataManager.Instance.GetAllowCharacterSelectionId());
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
        _lvl.text = $"{newCharacter.stats.lvl} / 100"; 
        _life.text = $"{newCharacter.stats.life}";
        _strenght.text = $"{newCharacter.stats.strenght}";
        _intelligent.text = $"{newCharacter.stats.intelligent}";
        _wisdom.text = $"{newCharacter.stats.wisdom}";
        _charisma.text = $"{newCharacter.stats.charisma}";
        _dexterity.text = $"{newCharacter.stats.dexterity}";

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
