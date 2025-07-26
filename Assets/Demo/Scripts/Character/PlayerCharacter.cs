using UnityEngine;

public class PlayerCharacter : TurnBasedCharacter
{
    protected override void Awake()
    {
        base.Awake();
        _actions.Add(new PlayerAttackAction());
    }
}
