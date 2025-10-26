using UnityEngine;

public abstract class PlayerAttackController : MonoBehaviour
{
    Transform skillsTransform;
    PlayerMovement playerMovement;
    void Awake()
    {
        skillsTransform = transform.Find("Skills");
        playerMovement = GetComponent<PlayerMovement>();
    }
    void Update()
    {
        if (DontTakeInput.banInput)
        {
            return;
        }
        if (Input.GetKeyDown(InputConfigs.skill1))
        {
            UseSkillAtKey1();
        }
        if (Input.GetKeyDown(InputConfigs.skill2))
        {
            UseSkillAtKey2();
        }
        if (Input.GetKeyDown(InputConfigs.skill3))
        {
            UseSkillAtKey3();
        }
        if (Input.GetKeyDown(InputConfigs.skill4))
        {
            UseSkillAtKey4();
        }
        if (Input.GetKeyDown(InputConfigs.skill5))
        {
            UseSkillAtKey5();
        }
    }
    public void UseSkillAtKey1()
    {
        SkillHotKeyLink.skillControllerAtKey[1]?.UseSkill();
    }
    public void UseSkillAtKey2()
    {
        SkillHotKeyLink.skillControllerAtKey[2]?.UseSkill();
    }
    public void UseSkillAtKey3()
    {
        SkillHotKeyLink.skillControllerAtKey[3]?.UseSkill();
    }
    public void UseSkillAtKey4()
    {
        SkillHotKeyLink.skillControllerAtKey[4]?.UseSkill();
    }
    public void UseSkillAtKey5()
    {
        SkillHotKeyLink.skillControllerAtKey[5]?.UseSkill();
    }
    public void UseSkill1() // hàm này đc animation clip của skill1 gọi
    {
        CharacterProperties characterProperties = SaveAndLoadSystem.LoadCharacterProperties();
        skillsTransform.Find("Skill1").GetChild(characterProperties.levelOfSkills[1] - 1).GetComponent<Skill1Controller>().Attack();
        DontTakeInput.banInput = false;
    }
}
