using UnityEngine;

public class CharacterBaseAttributes
{
    public int baseHp, baseMp, baseDamage;
    public CharacterBaseAttributes()
    {
        string path = SaveAndLoadSystem.LoadCharacterPath().path;
        PlayerAttributes playerAttributes = GetRootFromPath.GetCharacter(path).root.GetComponent<PlayerAttributes>();
        baseHp = playerAttributes.characterAttributes.startHp;
        baseMp = playerAttributes.characterAttributes.startMp;
        baseDamage = playerAttributes.characterAttributes.startDamage;
    }
}
