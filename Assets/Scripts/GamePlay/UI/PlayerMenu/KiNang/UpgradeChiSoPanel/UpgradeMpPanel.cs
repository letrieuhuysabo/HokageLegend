using UnityEngine;

public class UpgradeMpPanel : UpgradeChiSoPanel
{
    public override void Upgrade()
    {
        CharacterBaseAttributes characterBaseAttributes = SaveAndLoadSystem.LoadCharacterBaseAttributes();
        characterBaseAttributes.baseMp += number;
        SaveAndLoadSystem.SaveCharacterBaseAttributes(characterBaseAttributes);

        LostPotentialAndLoadDatasAgain();
    }
}
