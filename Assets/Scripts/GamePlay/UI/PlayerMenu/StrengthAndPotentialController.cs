using TMPro;
using UnityEngine;

public class StrengthAndPotentialController : MonoBehaviour
{
    public static StrengthAndPotentialController instance;
    [SerializeField] TextMeshProUGUI strengthPointText, potentialPointText;
    void Awake()
    {
        instance = this;
    }
    public void GainExp(int n)
    {
        GainStrength(n);
        GainPotential(n);
    }
    public void GainStrength(int n)
    {
        // cập nhật dữ liệu 
        CharacterProperties characterProperties = SaveAndLoadSystem.LoadCharacterProperties();
        characterProperties.strengthPoint += n;
        SaveAndLoadSystem.SaveCharacterProperties(characterProperties);
        // cập nhật UI
        LoadDatasController.instance.LoadSucManh(characterProperties);
    }
    public void GainPotential(int n)
    {
        // cập nhật dữ liệu 
        CharacterProperties characterProperties = SaveAndLoadSystem.LoadCharacterProperties();
        characterProperties.potentialPoint += n;
        SaveAndLoadSystem.SaveCharacterProperties(characterProperties);
        // cập nhật UI
        LoadDatasController.instance.LoadTiemNang(characterProperties);
    }
}
