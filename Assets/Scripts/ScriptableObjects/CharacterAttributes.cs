using UnityEngine;

[CreateAssetMenu(fileName = "CharacterAttributes", menuName = "Scriptable Objects/CharacterAttributes")]
public class CharacterAttributes : ScriptableObject
{
    public float moveSpeed, jumpForce;
    public int startDamage, startHp, startMp;
    public Sprite skill1_icon, skill2_icon, skill3_icon, skill4_icon;
    public string skill1_name, skill2_name, skill3_name, skill4_name;
}
