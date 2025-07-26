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
        _currentCharacter = _characterTurn.Dequeue();
        if (!_currentCharacter.IsDead)
        {
            _currentCharacter.BeginTurn();
        }
        else
        {
            NextTurn();
        }
    }
}
