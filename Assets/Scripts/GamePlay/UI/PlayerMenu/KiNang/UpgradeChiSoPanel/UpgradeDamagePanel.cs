using UnityEngine;

public class UpgradeDamagePanel : UpgradeChiSoPanel
{
    public override void Upgrade()
    {
        CharacterBaseAttributes characterBaseAttributes = SaveAndLoadSystem.LoadCharacterBaseAttributes();
        characterBaseAttributes.baseDamage += number;
        SaveAndLoadSystem.SaveCharacterBaseAttributes(characterBaseAttributes);

        LostPotentialAndLoadDatasAgain();
    }
}
