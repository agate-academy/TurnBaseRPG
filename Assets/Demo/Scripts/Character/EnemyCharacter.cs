using System.Collections;
using UnityEngine;

public class EnemyCharacter : TurnBasedCharacter
{
    protected override void Awake()
    {
        base.Awake();
        _actions.Add(new EnemyAttackAction());
    }

    public override void BeginTurn()
    {
        base.BeginTurn();
        StartCoroutine(StartAction());
    }

    private IEnumerator StartAction()
    {
        yield return new WaitForSeconds(3);
        TurnBasedAction action = _actions.Find(a => a.Type == EActionCategory.Attack);
        if (action != null)
        {
            action.Execute(this);
        }
        else
        {
            EndTurn();
        }
    }
}
