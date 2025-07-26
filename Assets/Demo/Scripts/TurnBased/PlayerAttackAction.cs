using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackAction : TurnBasedAction
{
    public PlayerAttackAction()
    {
        Type = EActionCategory.Attack;
    }

    public override void Execute(TurnBasedCharacter instigator)
    {
        List<EnemyCharacter> enemies = TurnBasedManager.Instance.GetAlliveEnemy();
        Debug.Log($"{instigator.Data.name} Choose Attack");
        TargetSelector.Instance.StartSelectCharacter(enemies, target =>
        {
            Debug.Log($"{instigator.Data.name} Attack {target.Data.Name}");
            instigator.Attack(target);
        });

    }
}
