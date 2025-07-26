using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetSelector : SingletonBehaviour<TargetSelector>
{
    public Action<TurnBasedCharacter> OnTargetSelected;

    private List<TurnBasedCharacter> _targetList = new List<TurnBasedCharacter>();

    public void StartSelectCharacter(IEnumerable<TurnBasedCharacter> targets, Action<TurnBasedCharacter> onSelected)
    {
        OnTargetSelected = onSelected;
        foreach (TurnBasedCharacter target in targets)
        {
            ClickableTarget selector = target.GetComponent<ClickableTarget>();
            if (selector != null)
            {
                _targetList.Add(target);
                selector.OnClicked.AddListener(OnTargetClicked);
                selector.IsSelecting = true;
            }
        }
    }

    public void AutoSelectCharacter(IEnumerable<TurnBasedCharacter> targets, Action<TurnBasedCharacter> onSelected)
    {
        List<TurnBasedCharacter> targetList = targets.ToList();
        OnTargetSelected = onSelected;
        int randomIndex = UnityEngine.Random.Range(0, targetList.Count);
        SelectTarget(targetList[randomIndex]);
    }

    public void OnTargetClicked(TurnBasedCharacter target)
    {
        if (!target.IsDead)
        {
            foreach (TurnBasedCharacter listedTarget in _targetList)
            {
                ClickableTarget selector = listedTarget.GetComponent<ClickableTarget>();
                if (selector != null)
                {
                    selector.OnClicked.RemoveListener(OnTargetClicked);
                    selector.IsSelecting = false;
                }
            }
            SelectTarget(target);
        }
    }

    private void SelectTarget(TurnBasedCharacter target)
    {
        OnTargetSelected?.Invoke(target);
        OnTargetSelected = null;
        _targetList.Clear();
    }
}
