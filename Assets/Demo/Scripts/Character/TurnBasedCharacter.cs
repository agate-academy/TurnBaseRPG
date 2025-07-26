using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnBasedCharacter : MonoBehaviour, IDamagable
{
    [SerializeField]
    private CharacterData _data;
    [SerializeField]
    private Transform _lookPivot;
    [SerializeField]
    private Transform _attackerPosition;

    public CharacterData Data { get => _data; }
    public Transform LookPivot { get => _lookPivot; }
    private Vector3 _originPosition;

    protected List<TurnBasedAction> _actions = new List<TurnBasedAction>();

    public int MaximumHealthPoint { get; set; }
    public int HealthPoint { get; set; }
    public int MaximumSkillPoint { get; set; }
    public int SkillPoint { get; set; }
    public int DamagePoint { get; set; }
    public int DefensePoint { get; set; }
    public int Speed { get; set; }
    public bool IsDead { get; protected set; }
    public List<TurnBasedAction> Actions { get => _actions; }
    public Vector3 AttackerPosition { get => (_attackerPosition != null) ? _attackerPosition.position : Vector3.zero; }

    public UnityEvent<float, float> OnDamage => OnCharacterDamage;
    public UnityEvent<TurnBasedCharacter> OnDeath => OnCharacterDeath;

    public UnityEvent OnBeginTurn;
    public UnityEvent OnEndTurn;
    public UnityEvent<float, float> OnCharacterDamage;
    public UnityEvent<TurnBasedCharacter> OnCharacterDeath;

    public virtual void BeginTurn()
    {
        Debug.Log($"{Data.Name} Begin Turn");
        OnBeginTurn?.Invoke();
    }

    public virtual void EndTurn()
    {
        Debug.Log($"{Data.Name} End Turn");
        OnEndTurn?.Invoke();
        TurnBasedManager.Instance.NextTurn();
    }

    public void Damage(int value)
    {
        HealthPoint -= value;
        OnDamage?.Invoke(HealthPoint, MaximumHealthPoint);
        if (HealthPoint <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        IsDead = true;
        OnDeath?.Invoke(this);
    }

    public void Attack(TurnBasedCharacter target)
    {
        StartCoroutine(PerformAttack(target));
    }

    public IEnumerator PerformAttack(TurnBasedCharacter target)
    {
        transform.position = target.AttackerPosition;
        yield return new WaitForSeconds(3);
        target.Damage(DamagePoint);
        transform.position = _originPosition;
        EndTurn();
    }

    protected virtual void Awake()
    {
        InitializeData();
    }

    protected void InitializeData()
    {
        MaximumHealthPoint = Data.MaximumHealthPoint;
        HealthPoint = Data.MaximumHealthPoint;
        MaximumSkillPoint = Data.MaximumSkillPoint;
        SkillPoint = Data.MaximumSkillPoint;
        DamagePoint = Data.DamagePoint;
        DefensePoint = Data.DefensePoint;
        Speed = Data.Speed;
        _originPosition = transform.position;
    }
}
