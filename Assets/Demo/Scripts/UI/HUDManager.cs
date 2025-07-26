using UnityEngine;

public class HUDManager : SingletonBehaviour<HUDManager>
{
    [SerializeField]
    private PlayerStatusUI _playerStatusUI;
    [SerializeField]
    private CharacterTurnUI _characterTurnUI;
    [SerializeField]
    private PlayerActionUI _playerActionUI;

    public PlayerStatusUI PlayerStatusUI { get => _playerStatusUI; }
    public CharacterTurnUI CharacterTurnUI { get => _characterTurnUI; }
    public PlayerActionUI PlayerActionUI { get => _playerActionUI; }
}
