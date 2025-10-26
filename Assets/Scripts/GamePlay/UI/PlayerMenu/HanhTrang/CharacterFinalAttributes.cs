using UnityEngine;

public class CharacterFinalAttributes
{
    public int maxHp, maxMp, damage;
    public CharacterFinalAttributes()
    {
        GetAttributesFromBaseAttributes();
        GetAttributesFromEquipments();
    }
    void GetAttributesFromBaseAttributes()
    {
        CharacterBaseAttributes characterBaseAttributes = SaveAndLoadSystem.LoadCharacterBaseAttributes();
        this.maxHp = characterBaseAttributes.baseHp;
        this.maxMp = characterBaseAttributes.baseMp;
        this.damage = characterBaseAttributes.baseDamage;
    }
    void GetAttributesFromEquipments()
    {
        
    }
}
