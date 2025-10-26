using UnityEngine;

public static class GetDatas
{
    public static int GetStrengthPoint()
    {
        CharacterProperties characterProperties = SaveAndLoadSystem.LoadCharacterProperties();
        return characterProperties.strengthPoint;
    }
    public static int GetPotentialPoint()
    {
        CharacterProperties characterProperties = SaveAndLoadSystem.LoadCharacterProperties();
        return characterProperties.potentialPoint;
    }
    public static int GetVang()
    {
        CharacterProperties characterProperties = SaveAndLoadSystem.LoadCharacterProperties();
        return characterProperties.vang;
    }
    public static int GetNgoc()
    {
        CharacterProperties characterProperties = SaveAndLoadSystem.LoadCharacterProperties();
        return characterProperties.ngoc;
    }
}
