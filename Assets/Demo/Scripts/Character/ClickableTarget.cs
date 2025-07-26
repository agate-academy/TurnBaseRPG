using UnityEngine;
using UnityEngine.Events;

public class ClickableTarget : MonoBehaviour
{
    [SerializeField]
    private TurnBasedCharacter _ownerCharacter;

    public bool IsSelecting { get; set; }

    public UnityEvent<TurnBasedCharacter> OnClicked;

    private void OnMouseDown()
    {
        if (IsSelecting)
        {
            Debug.Log($"Click {_ownerCharacter.Data.Name}");
            OnClicked?.Invoke(_ownerCharacter);
        }
    }
}
