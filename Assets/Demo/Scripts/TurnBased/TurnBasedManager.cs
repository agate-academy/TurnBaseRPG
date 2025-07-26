using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnBasedManager : SingletonBehaviour<TurnBasedManager>
{
    [SerializeField]
    protected List<TurnBasedCharacter> _characters = new List<TurnBasedCharacter>();

    private Queue<TurnBasedCharacter> _characterTurn = new Queue<TurnBasedCharacter>();
    private TurnBasedCharacter _currentCharacter;

    public List<TurnBasedCharacter> Characters { get => _characters; }
    public TurnBasedCharacter CurrentCharacter { get => _currentCharacter; }

    private void Start()
    {
        BindAllCharacterEvent();
        HUDManager.Instance.PlayerStatusUI.InitializePlayerStatusItem(GetAllivePlayer());
        HUDManager.Instance.CharacterTurnUI.InitializeTurnItem(_characters);
        NextTurn();
    }


    public void BindAllCharacterEvent()
    {
        foreach (TurnBasedCharacter character in _characters)
        {
            character.OnCharacterDeath.AddListener(HandlePlayerDeath);
        }
    }

    public List<EnemyCharacter> GetAlliveEnemy()
    {
        return _characters.FindAll(character => !character.IsDead).OfType<EnemyCharacter>().ToList();
    }

    public List<PlayerCharacter> GetAllivePlayer()
    {
        return _characters.FindAll(character => !character.IsDead).OfType<PlayerCharacter>().ToList();
    }

    public void EnqueueTurn()
    {
        _characters.Sort((a, b) => b.Speed.CompareTo(a.Speed));
        _characterTurn.Clear();

        Debug.Log("Enqueue new turn");

        foreach (TurnBasedCharacter character in _characters)
        {
            if (!character.IsDead)
            {
                _characterTurn.Enqueue(character);
            }
        }
    }

    public void NextTurn()
    {
        if (_characterTurn.Count <= 0)
        {
            EnqueueTurn();
        }
        HUDManager.Instance.CharacterTurnUI.HideTurnIconFor(_currentCharacter);
        _currentCharacter = _characterTurn.Dequeue();
        if (!_currentCharacter.IsDead)
        {
            _currentCharacter.BeginTurn();
            HUDManager.Instance.CharacterTurnUI.ShowTurnIconFor(_currentCharacter);
            if (_currentCharacter is PlayerCharacter)
            {
                HUDManager.Instance.PlayerActionUI.Show();
            }
            else
            {
                HUDManager.Instance.PlayerActionUI.Hide();
            }
        }
        else
        {
            NextTurn();
        }
    }

    public void HandlePlayerAction(EActionCategory type)
    {
        HUDManager.Instance.PlayerActionUI.Hide();
        TurnBasedAction action = _currentCharacter.Actions.Find(item => item.Type == type);
        if (action != null)
        {
            action.Execute(_currentCharacter);
        }
    }

    public void HandlePlayerDeath(TurnBasedCharacter character)
    {
        HUDManager.Instance.CharacterTurnUI.ShowDeadOverlayFor(character);
    }
}
