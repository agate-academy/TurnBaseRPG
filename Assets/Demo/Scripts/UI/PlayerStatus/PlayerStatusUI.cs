using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusUI : MonoBehaviour
{
    [SerializeField]
    protected GameObject _panel;
    [SerializeField]
    private PlayerStatusItemUI _playerStatusItemUIPrefab;
    [SerializeField]
    private Transform _playerStatusUIRect;

    public void InitializePlayerStatusItem(List<PlayerCharacter> characters)
    {
        foreach (PlayerCharacter character in characters)
        {
            PlayerStatusItemUI item = Instantiate<PlayerStatusItemUI>(_playerStatusItemUIPrefab, _playerStatusUIRect);
            item.SetPotraitImage(character.Data.IconImage);
            item.SetHealthPoint(character.HealthPoint, character.Data.MaximumHealthPoint);
            item.SetSkillPoint(character.SkillPoint, character.Data.MaximumSkillPoint);
            character.OnDamage.AddListener(item.SetHealthPoint);
            character.OnDeath.AddListener(character => item.ShowDeadOverlay());
        }
    }

    public void Show()
    {
        _panel.SetActive(true);
    }

    public void Hide()
    {
        _panel.SetActive(false);
    }
}
