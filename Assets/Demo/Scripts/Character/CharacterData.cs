using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Game Data/Character")]
public class CharacterData : ScriptableObject
{
    public string Name;
    public int MaximumHealthPoint;
    public int MaximumSkillPoint;
    public int DefensePoint;
    public int DamagePoint;
    public int Speed;
    public Sprite TurnImage;
    public Sprite IconImage;
}
