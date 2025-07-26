using System.Collections.Generic;
using UnityEngine;

public class CharacterTurnUI : MonoBehaviour
{
    [SerializeField]
    protected GameObject _panel;
    [SerializeField]
    protected Transform _turnItemUIRect;
    [SerializeField]
    protected CharacterTurnItemUI _turnItemPrefab;

    private List<(TurnBasedCharacter character, CharacterTurnItemUI item)> _bindings = new();

    public void Show()
    {
        _panel.SetActive(true);
    }

    public void Hide()
    {
        _panel.SetActive(false);
    }

    public void InitializeTurnItem(List<TurnBasedCharacter> characters)
    {
        _bindings.Clear();

        foreach (TurnBasedCharacter character in characters)
        {
            CharacterTurnItemUI item = Instantiate<CharacterTurnItemUI>(_turnItemPrefab, _turnItemUIRect);
            item.SetTurnThumbnail(character.Data.TurnImage);
            item.HideTurnIcon();
            _bindings.Add((character, item));
        }
    }

    public void UpdateTurnOrderUI(List<TurnBasedCharacter> sortedCharacters)
    {
        // Sort _bindings sesuai urutan karakter yang baru (speed urutan)
        List<(TurnBasedCharacter character, CharacterTurnItemUI item)> newOrder = new();
        foreach (TurnBasedCharacter character in sortedCharacters)
        {
            var binding = _bindings.Find(b => b.character == character);
            if (binding.item != null)
            {
                newOrder.Add(binding);
            }
        }
        _bindings = newOrder;

        // Atur ulang posisi UI berdasarkan urutan baru
        for (int i = 0; i < _bindings.Count; i++)
        {
            _bindings[i].item.transform.SetSiblingIndex(i);
            _bindings[i].item.SetTurnThumbnail(_bindings[i].character.Data.TurnImage);
        }
    }

    public void ShowTurnIconFor(TurnBasedCharacter character)
    {
        var binding = _bindings.Find(bindItem => bindItem.character == character);
        binding.item?.ShowTurnIcon();
    }

    public void HideTurnIconFor(TurnBasedCharacter character)
    {
        var binding = _bindings.Find(bindItem => bindItem.character == character);
        binding.item?.HideTurnIcon();
    }

    public void ShowDeadOverlayFor(TurnBasedCharacter character)
    {
        var binding = _bindings.Find(bindItem => bindItem.character == character);
        binding.item?.ShowDeadOverlay();
    }

    public void HideDeadOverlayFor(TurnBasedCharacter character)
    {
        var binding = _bindings.Find(bindItem => bindItem.character == character);
        binding.item?.HideDeadOverlay();
    }
}

