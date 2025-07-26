using UnityEngine;
using UnityEngine.UI;

public class CharacterTurnItemUI : MonoBehaviour
{
    [SerializeField]
    private Image _turnThumbnail;
    [SerializeField]
    private GameObject _turnIcon;
    [SerializeField]
    private GameObject _deadOverlay;

    public void ShowTurnIcon()
    {
        _turnIcon.SetActive(true);
    }

    public void HideTurnIcon()
    {
        _turnIcon.SetActive(false);
    }

    public void SetTurnThumbnail(Sprite image)
    {
        _turnThumbnail.sprite = image;
    }

    public void ShowDeadOverlay()
    {
        _deadOverlay.SetActive(true);
    }

    public void HideDeadOverlay()
    {
        _deadOverlay.SetActive(false);
    }
}
