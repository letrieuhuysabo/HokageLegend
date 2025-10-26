using System.Threading.Tasks;
using UnityEngine;

public abstract class UpgradeChiSoPanel : MonoBehaviour
{
    public int number, potentialNeed;
    public abstract void Upgrade();
    public void LostPotentialAndLoadDatasAgain()
    {
        CharacterProperties characterProperties = SaveAndLoadSystem.LoadCharacterProperties();
        characterProperties.potentialPoint -= potentialNeed;
        SaveAndLoadSystem.SaveCharacterProperties(characterProperties);
        // await Task.Yield();
        PlayerMenuKiNang.instance.LoadDatas();
        LoadDatasController.instance.LoadTiemNang(characterProperties);
    }
}
