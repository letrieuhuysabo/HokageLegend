using UnityEngine;

public class PlayerFinalAttributes : MonoBehaviour
{
    CharacterFinalAttributes characterFinalAttributes;
    [HideInInspector]
    private int currentMp;
    public static PlayerFinalAttributes instance;
    [HideInInspector]
    private int currentHp;

    public int CurrentHp { get => currentHp;
        set {
            currentHp = value;
            
        }
    }
    public int CurrentMp { get => currentMp;
        set
        {
            currentMp = value;
        }
    }

    void Awake()
    {
        instance = this;
        characterFinalAttributes = new();
    }
    void Start()
    {
        currentHp = SaveAndLoadSystem.LoadCharacterCurrentAttributes().currentHp;
        currentMp = SaveAndLoadSystem.LoadCharacterCurrentAttributes().currentMp;
        // Load UI thanh máu và mp
        HpAndMpBarController.instance.UpdateHpFill();
        HpAndMpBarController.instance.UpdateMpFill();
    }
    public void LostHp(int n)
    {
        currentHp -= n;
        HpAndMpBarController.instance.UpdateHpFill();
        PlayerMenuHanhTrangHienThiChiSo.instance.LoadHp();
        SaveCurrentAttributes();
    }
    public void LostMp(int n)
    {
        currentMp -= n;
        HpAndMpBarController.instance.UpdateMpFill();
        PlayerMenuHanhTrangHienThiChiSo.instance.LoadMp();
        SaveCurrentAttributes();
    }
    void SaveCurrentAttributes()
    {
        CharacterCurrentAttributes characterCurrentAttributes = new(currentHp, currentMp);
        SaveAndLoadSystem.SaveCharacterCurrentAttributes(characterCurrentAttributes);
    }
}
