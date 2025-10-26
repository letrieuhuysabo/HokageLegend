using TMPro;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;

public class PlayerMenuKiNang : MonoBehaviour
{
    [Header("Chỉ số cơ bản")]
    [SerializeField] TextMeshProUGUI baseHpText;
    [SerializeField] TextMeshProUGUI baseMpText; 
    [SerializeField] TextMeshProUGUI baseDamageText;
    [SerializeField] TextMeshProUGUI baseHpContent, baseMpContent, baseDamageContent;
    [Space]
    [Header("Bảng nâng cấp chỉ số")]
    [SerializeField] GameObject upgradeAttributesMenu;
    [SerializeField] GameObject upgradeMenu_1_Time, upgradeMenu_10_Time, upgradeMenu_100_Time;
    [Space]
    [Header("Kĩ năng")]
    [SerializeField] GameObject skill1Container; 
    [SerializeField] GameObject skill2Container, skill3Container, skill4Container;
    public static PlayerMenuKiNang instance;
    [Space]
    [Header("Các thao tác với hệ thống kĩ năng")]
    [SerializeField] GameObject skillFeaturesMenu;
    [SerializeField] GameObject ganPhimMenu;
    int skillDangThaoTac; // biến này để lưu trữ xem người dùng đang thao tác với skill nào, để lưu skill đó vào dữ liệu gắn phím
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
        // nạp data lên

        CharacterBaseAttributes characterBaseAttributes = SaveAndLoadSystem.LoadCharacterBaseAttributes();
        
        // nạp chỉ số gốc và content
        LoadHpDatas(characterBaseAttributes);
        LoadMpDatas(characterBaseAttributes);
        LoadDamageDatas(characterBaseAttributes);

        // nạp chiêu thức
        string path = SaveAndLoadSystem.LoadCharacterPath().path;
        CharacterAttributes characterAttributes = GetRootFromPath.GetCharacter(path).root.GetComponent<PlayerAttributes>().characterAttributes;
        CharacterProperties characterProperties = SaveAndLoadSystem.LoadCharacterProperties();
        LoadSkill1(characterAttributes, characterProperties);
        LoadSkill2(characterAttributes, characterProperties);
        LoadSkill3(characterAttributes, characterProperties);
        LoadSkill4(characterAttributes, characterProperties);
    }
    public void LoadHpDatas(CharacterBaseAttributes characterBaseAttributes)
    {
        baseHpText.text = "Hp gốc: " + Configs.FormatNumber(characterBaseAttributes.baseHp);
        baseHpContent.text = "Tăng 20 hp cần " + Configs.FormatNumber(characterBaseAttributes.baseHp * 1) + " điểm tiềm năng";
    }
    public void LoadMpDatas(CharacterBaseAttributes characterBaseAttributes)
    {
        baseMpText.text = "Chakra gốc: " + Configs.FormatNumber(characterBaseAttributes.baseMp);
        baseMpContent.text = "Tăng 20 chakra cần " + Configs.FormatNumber(characterBaseAttributes.baseMp * 1) + " điểm tiềm năng";
    }
    public void LoadDamageDatas(CharacterBaseAttributes characterBaseAttributes)
    {
        baseDamageText.text = "Sức đánh gốc: " + Configs.FormatNumber(characterBaseAttributes.baseDamage);
        baseDamageContent.text = "Tăng 1 sức đánh cần " + Configs.FormatNumber(characterBaseAttributes.baseDamage * 100) + " điểm tiềm năng";
    }
    public void UpgradeHp()
    {
        CharacterBaseAttributes characterBaseAttributes = SaveAndLoadSystem.LoadCharacterBaseAttributes();
        int potentialPointNeedToUpgrade_1Time = CalculatePotenticalPointNeedToUpgrade(characterBaseAttributes.baseHp * 1, 20, 1);
        
        upgradeMenu_1_Time.AddComponent<UpgradeHpPanel>();
        upgradeMenu_10_Time.AddComponent<UpgradeHpPanel>();
        upgradeMenu_100_Time.AddComponent<UpgradeHpPanel>();
        CheckPotentialPointAndPotentialNeed(potentialPointNeedToUpgrade_1Time, 20, "Hp", 20);
    }
    public void UpgradeMp()
    {
        CharacterBaseAttributes characterBaseAttributes = SaveAndLoadSystem.LoadCharacterBaseAttributes();
        int potentialPointNeedToUpgrade_1Time = CalculatePotenticalPointNeedToUpgrade(characterBaseAttributes.baseMp * 1, 20, 1);
        
        upgradeMenu_1_Time.AddComponent<UpgradeMpPanel>();
        upgradeMenu_10_Time.AddComponent<UpgradeMpPanel>();
        upgradeMenu_100_Time.AddComponent<UpgradeMpPanel>();
        CheckPotentialPointAndPotentialNeed(potentialPointNeedToUpgrade_1Time, 20, "Chakra", 20);
    }
    public void UpgradeDamage()
    {
        CharacterBaseAttributes characterBaseAttributes = SaveAndLoadSystem.LoadCharacterBaseAttributes();
        int potentialPointNeedToUpgrade_1Time = CalculatePotenticalPointNeedToUpgrade(characterBaseAttributes.baseDamage * 100, 100, 1);
        
        upgradeMenu_1_Time.AddComponent<UpgradeDamagePanel>();
        upgradeMenu_10_Time.AddComponent<UpgradeDamagePanel>();
        upgradeMenu_100_Time.AddComponent<UpgradeDamagePanel>();
        CheckPotentialPointAndPotentialNeed(potentialPointNeedToUpgrade_1Time, 1, "sức đánh", 100);
    }
    public void CheckPotentialPointAndPotentialNeed(int potentialNeed_1_Time,int attributeNumber, string attributeName, int potentialStep)
    {
        int potentialPoint = GetDatas.GetPotentialPoint();
        // nâng 1 lần
        if (potentialPoint >= potentialNeed_1_Time)
        {
            ShowUpgradePanel_1Time(Configs.FormatNumber(attributeNumber) + " " + attributeName, potentialNeed_1_Time);
            upgradeMenu_1_Time.GetComponent<UpgradeChiSoPanel>().number = attributeNumber;
            upgradeMenu_1_Time.GetComponent<UpgradeChiSoPanel>().potentialNeed = potentialNeed_1_Time;
        }
        else
        {
            Destroy(upgradeMenu_1_Time.GetComponent<UpgradeChiSoPanel>());
            ThongBaoLoiController.instance.ThongBao("Không đủ tiềm năng");
            return;
        }
        // nâng 10 lần
        int potentialNeed_10_Time = CalculatePotenticalPointNeedToUpgrade(potentialNeed_1_Time, potentialStep, 10);
        if (potentialPoint >= potentialNeed_10_Time)
        {
            ShowUpgradePanel_10Time(Configs.FormatNumber(attributeNumber * 10) + " " + attributeName, potentialNeed_10_Time);
            upgradeMenu_10_Time.GetComponent<UpgradeChiSoPanel>().number = attributeNumber*10;
            upgradeMenu_10_Time.GetComponent<UpgradeChiSoPanel>().potentialNeed = potentialNeed_10_Time;
        }
        else
        {
            Destroy(upgradeMenu_10_Time.GetComponent<UpgradeChiSoPanel>());
            return;
        }
        // nâng 100 lần
        int potentialNeed_100_Time = CalculatePotenticalPointNeedToUpgrade(potentialNeed_1_Time, potentialStep, 100);
        if (potentialPoint >= potentialNeed_100_Time)
        {
            ShowUpgradePanel_100Time(Configs.FormatNumber(attributeNumber * 100) + " " + attributeName, potentialNeed_100_Time);
            upgradeMenu_100_Time.GetComponent<UpgradeChiSoPanel>().number = attributeNumber*100;
            upgradeMenu_100_Time.GetComponent<UpgradeChiSoPanel>().potentialNeed = potentialNeed_100_Time;
        }
        else
        {
            Destroy(upgradeMenu_100_Time.GetComponent<UpgradeChiSoPanel>());
        }
    }
    public void ShowUpgradePanel_1Time(string text, int potentialPointNeedToUpgrade)
    {
        upgradeAttributesMenu.SetActive(true);
        upgradeMenu_1_Time.SetActive(true);
        upgradeMenu_1_Time.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = "+" + text;
        upgradeMenu_1_Time.transform.Find("Content").GetComponent<TextMeshProUGUI>().text = "-" + Configs.FormatNumber(potentialPointNeedToUpgrade) + " tiềm năng";
    }
    public void ShowUpgradePanel_10Time(string text, int potentialPointNeedToUpgrade)
    {
        upgradeMenu_10_Time.SetActive(true);
        upgradeMenu_10_Time.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = "+" + text;
        upgradeMenu_10_Time.transform.Find("Content").GetComponent<TextMeshProUGUI>().text = "-" + Configs.FormatNumber(potentialPointNeedToUpgrade) + " tiềm năng";
    }
    public void ShowUpgradePanel_100Time(string text, int potentialPointNeedToUpgrade)
    {
        upgradeMenu_100_Time.SetActive(true);
        upgradeMenu_100_Time.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = "+" + text;
        upgradeMenu_100_Time.transform.Find("Content").GetComponent<TextMeshProUGUI>().text = "-" + Configs.FormatNumber(potentialPointNeedToUpgrade) + " tiềm năng";
    }
    public void CloseUpgradePanels()
    {
        upgradeMenu_100_Time.SetActive(false);
        Destroy(upgradeMenu_100_Time.GetComponent<UpgradeChiSoPanel>());
        upgradeMenu_10_Time.SetActive(false);
        Destroy(upgradeMenu_10_Time.GetComponent<UpgradeChiSoPanel>());
        upgradeMenu_1_Time.SetActive(false);
        Destroy(upgradeMenu_1_Time.GetComponent<UpgradeChiSoPanel>());
        upgradeAttributesMenu.SetActive(false);
    }
    int CalculatePotenticalPointNeedToUpgrade(int firstUpgradeNeed, int stepInc, int timeOfUpgrade)
    {
        if (timeOfUpgrade <= 1)
        {
            return firstUpgradeNeed;
        }
        return firstUpgradeNeed + CalculatePotenticalPointNeedToUpgrade(firstUpgradeNeed + stepInc, stepInc, timeOfUpgrade - 1);
    }
    public void Upgrade(Transform upgradePanelTransform)
    {
        upgradePanelTransform.GetComponent<UpgradeChiSoPanel>().Upgrade();
        HpAndMpBarController.instance.UpdateHpFill();
        HpAndMpBarController.instance.UpdateMpFill();
        CloseUpgradePanels();
    }
    public void LoadSkill1(CharacterAttributes characterAttributes, CharacterProperties characterProperties)
    {
        
        LoadThisSkill(skill1Container, characterAttributes.skill1_name, characterProperties.levelOfSkills[1], characterAttributes.skill1_icon);
    }
    public void LoadSkill2(CharacterAttributes characterAttributes, CharacterProperties characterProperties)
    {
        LoadThisSkill(skill2Container, characterAttributes.skill2_name, characterProperties.levelOfSkills[2], characterAttributes.skill2_icon);
    }
    public void LoadSkill3(CharacterAttributes characterAttributes, CharacterProperties characterProperties)
    {
        LoadThisSkill(skill3Container, characterAttributes.skill3_name, characterProperties.levelOfSkills[3], characterAttributes.skill3_icon);
    }
    public void LoadSkill4(CharacterAttributes characterAttributes, CharacterProperties characterProperties)
    {
        LoadThisSkill(skill4Container, characterAttributes.skill4_name, characterProperties.levelOfSkills[4], characterAttributes.skill4_icon);
    }
    public void LoadThisSkill(GameObject skillContainer, string nameOfSkill, int levelOfSkill, Sprite spriteOfSkill)
    {
        skillContainer.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = nameOfSkill;
        if (levelOfSkill == 0)
        {
            skillContainer.transform.Find("Level").GetComponent<TextMeshProUGUI>().text = "Chưa học";
        }
        else
        {
            skillContainer.transform.Find("Level").GetComponent<TextMeshProUGUI>().text = "Level: " + levelOfSkill;
        }
        
        skillContainer.transform.Find("Image").GetComponent<Image>().sprite = spriteOfSkill;
    }
    public void OpenSkillFeatures(Transform skillContainer)
    {
        skillDangThaoTac = int.Parse(skillContainer.gameObject.name.Substring(skillContainer.gameObject.name.Length - 1));
        skillFeaturesMenu.SetActive(true);
        if (skillContainer.transform.Find("Level").GetComponent<TextMeshProUGUI>().text == "Chưa học") // chưa học skill
        {
            skillFeaturesMenu.transform.Find("LearnSkill").gameObject.SetActive(true);
            skillFeaturesMenu.transform.Find("UpgradeSkill").gameObject.SetActive(false);
            skillFeaturesMenu.transform.Find("GanPhim").gameObject.SetActive(false);
        }
        else
        {
            skillFeaturesMenu.transform.Find("LearnSkill").gameObject.SetActive(false);
            skillFeaturesMenu.transform.Find("UpgradeSkill").gameObject.SetActive(true);
            skillFeaturesMenu.transform.Find("GanPhim").gameObject.SetActive(true);
        }
    }
    public void CloseSkillFeatures()
    {
        skillFeaturesMenu.SetActive(false);
    }
    public void OpenGanPhimMenu()
    {
        ganPhimMenu.SetActive(true);
    }
    public void CloseGanPhimMenu()
    {
        ganPhimMenu.SetActive(false);
    }
    public void GanPhim(int n)
    {
        CharacterSkillHotKeys currentHotkeys = SaveAndLoadSystem.LoadCharacterSkillHotKeys();
        for (int i = 0; i < currentHotkeys.skillInKeys.Count; i++)
        {
            if (currentHotkeys.skillInKeys[i] == skillDangThaoTac)
            {
                currentHotkeys.skillInKeys[i] = 0;
            }
        }
        currentHotkeys.skillInKeys[n] = skillDangThaoTac;
        SaveAndLoadSystem.SaveCharacterSkillHotKeys(currentHotkeys);
        SkillHotKeysController.instance.ShowKeys();
        CloseGanPhimMenu();
        CloseSkillFeatures();
    }
}
