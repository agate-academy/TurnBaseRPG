using UnityEngine;
using UnityEngine.Events;

public interface IDamagable
{
    public int HealthPoint { get; }
    public bool IsDead { get; }
    public UnityEvent<float, float> OnDamage { get; }
    public UnityEvent<TurnBasedCharacter> OnDeath { get; }
    public void Damage(int value);
    public void Death();
}
