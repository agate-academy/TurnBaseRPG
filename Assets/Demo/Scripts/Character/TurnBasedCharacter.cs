using UnityEngine;
using UnityEngine.Events;

public class TurnBasedCharacter : MonoBehaviour, IDamagable
{
    [SerializeField]
    private CharacterData _data;
    [SerializeField]
    private Transform _lookPivot;

    public CharacterData Data { get => _data; }
    public Transform LookPivot { get => _lookPivot; }

    public int MaximumHealthPoint { get; set; }
    public int HealthPoint { get; set; }
    public int MaximumSkillPoint { get; set; }
    public int SkillPoint { get; set; }
    public int DamagePoint { get; set; }
    public int DefensePoint { get; set; }
    public int Speed { get; set; }
    public bool IsDead { get; protected set; }

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
    }

    public void Damage(int value)
    {
    }

    public void Death()
    {
    }

    private void Awake()
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
    }
}
