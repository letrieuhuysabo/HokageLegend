using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Scriptable Objects/Character")]
public class Character : ScriptableObject
{
    public Transform root;
    public Sprite avatar;
}
