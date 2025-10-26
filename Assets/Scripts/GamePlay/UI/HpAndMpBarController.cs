using UnityEngine;
using UnityEngine.UI;

public class HpAndMpBarController : MonoBehaviour
{
    [SerializeField] Image hpFill, mpFill;
    public static HpAndMpBarController instance;
    void Awake()
    {
        instance = this;
    }
    public void UpdateHpFill()
    {
        int currentHp = PlayerFinalAttributes.instance.CurrentHp;
        int maxHp = new CharacterFinalAttributes().maxHp;
        hpFill.fillAmount = currentHp * 1.0f / maxHp;
    }
    public void UpdateMpFill()
    {
        int currentMp = PlayerFinalAttributes.instance.CurrentMp;
        int maxMp = new CharacterFinalAttributes().maxMp;
        mpFill.fillAmount = currentMp * 1.0f / maxMp;
    }
    
}
