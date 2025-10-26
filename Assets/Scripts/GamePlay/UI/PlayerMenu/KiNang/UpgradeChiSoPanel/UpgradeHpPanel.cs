using UnityEngine;

public class UpgradeHpPanel : UpgradeChiSoPanel
{
    public override void Upgrade()
    {
        CharacterBaseAttributes characterBaseAttributes = SaveAndLoadSystem.LoadCharacterBaseAttributes();
        characterBaseAttributes.baseHp += number;
        SaveAndLoadSystem.SaveCharacterBaseAttributes(characterBaseAttributes);
        Debug.Log(SaveAndLoadSystem.LoadCharacterBaseAttributes().baseHp);
        LostPotentialAndLoadDatasAgain();
    }
}
