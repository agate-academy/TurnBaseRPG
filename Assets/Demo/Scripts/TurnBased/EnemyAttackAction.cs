using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAction : TurnBasedAction
{
    public EnemyAttackAction()
    {
        Type = EActionCategory.Attack;
    }

    public override void Execute(TurnBasedCharacter instigator)
    {
        List<PlayerCharacter> players = TurnBasedManager.Instance.GetAllivePlayer();
        Debug.Log($"{instigator.Data.name} Choose Attack");
        TargetSelector.Instance.AutoSelectCharacter(players, target =>
        {
            Debug.Log($"{instigator.Data.name} Attack {target.Data.Name}");
            instigator.Attack(target);
        });
    }
}
