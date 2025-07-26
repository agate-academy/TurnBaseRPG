using UnityEngine;
using UnityEngine.Events;

public class PlayerActionUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _panel;

    public UnityEvent<EActionCategory> OnActionInput;

    public void Show()
    {
        _panel.SetActive(true);
    }

    public void Hide()
    {
        _panel.SetActive(false);
    }

    public void OnAttackInput()
    {
        OnActionInput?.Invoke(EActionCategory.Attack);
    }

    public void OnSkillInput()
    {
        OnActionInput?.Invoke(EActionCategory.Skill);
    }

    public void OnItemInput()
    {
        OnActionInput?.Invoke(EActionCategory.Item);
    }

    public void OnDefenseInput()
    {
        OnActionInput?.Invoke(EActionCategory.Defense);
    }
}
