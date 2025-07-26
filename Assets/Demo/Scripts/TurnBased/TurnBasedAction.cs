using UnityEngine;

public abstract class TurnBasedAction
{
    public EActionCategory Type { get; protected set; }

    public abstract void Execute(TurnBasedCharacter instigator);
}
