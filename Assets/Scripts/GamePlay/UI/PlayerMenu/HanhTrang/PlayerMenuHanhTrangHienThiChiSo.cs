using TMPro;
using UnityEngine;

public class PlayerMenuHanhTrangHienThiChiSo : MonoBehaviour
{
    public static PlayerMenuHanhTrangHienThiChiSo instance;
    [SerializeField] TextMeshProUGUI hpText, mpText, damageText;
    void Awake()
    {
        instance = this;
    }
    void OnEnable()
    {
        LoadDatas();
    }
    public void LoadDatas()
    {
        
        LoadHp();
        LoadMp();
        LoadDamage();
    }
    public void LoadHp()
    {
        CharacterFinalAttributes characterFinalAttributes = new();
        int currentHp = PlayerFinalAttributes.instance.CurrentHp;
        int maxHp = characterFinalAttributes.maxHp;
        hpText.text = "HP: " + currentHp + "/" + maxHp;
    }
    public void LoadMp()
    {
        CharacterFinalAttributes characterFinalAttributes = new();
        int currentMp = PlayerFinalAttributes.instance.CurrentMp;
        int maxMp = characterFinalAttributes.maxMp;
        mpText.text = "Chakra: " + currentMp + "/" + maxMp;
    }
    public void LoadDamage()
    {
        CharacterFinalAttributes characterFinalAttributes = new();
        int damage = characterFinalAttributes.damage;
        damageText.text = "Sức đánh: " + damage;
    }
}
