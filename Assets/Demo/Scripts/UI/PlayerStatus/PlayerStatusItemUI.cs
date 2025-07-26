using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusItemUI : MonoBehaviour
{
    [SerializeField]
    private Image _potraitImage;
    [SerializeField]
    private Image _healthPointBar;
    [SerializeField]
    private Image _skillPointBar;
    [SerializeField]
    private TMP_Text _healthPointText;
    [SerializeField]
    private TMP_Text _skillPointText;
    [SerializeField]
    private GameObject _deadOverlay;

    public void SetPotraitImage(Sprite image)
    {
        _potraitImage.sprite = image;
    }

    public void SetHealthPoint(float health, float maxHealth)
    {
        _healthPointBar.fillAmount = health / maxHealth;
        _healthPointText.text = $"{health} / {maxHealth}";
    }

    public void SetSkillPoint(float skill, float maxSkill)
    {
        _skillPointBar.fillAmount = skill / maxSkill;
        _skillPointText.text = $"{skill} / {maxSkill}";
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
