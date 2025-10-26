using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SkillHotKeysController : MonoBehaviour
{
    [SerializeField] List<Image> hotkeySprites;
    public static SkillHotKeysController instance;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        ShowKeys();
    }
    public void HideHotKeys()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
    public void UnHideHotKeys()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    public void ShowKeys()
    {
        string path = SaveAndLoadSystem.LoadCharacterPath().path;
        CharacterAttributes characterAttributes = GetRootFromPath.GetCharacter(path).root.GetComponent<PlayerAttributes>().characterAttributes;
        Sprite[] skillSprites = {null,characterAttributes.skill1_icon,characterAttributes.skill2_icon, characterAttributes.skill3_icon, characterAttributes.skill4_icon};
        CharacterSkillHotKeys characterSkillHotKeys = SaveAndLoadSystem.LoadCharacterSkillHotKeys();
        bool flag = false;
        for (int i = 0; i < hotkeySprites.Count; i++)
        {
            hotkeySprites[i].gameObject.SetActive(true);
        }
        // ô số 5
        if (characterSkillHotKeys.skillInKeys[5] == 0)
        {
            hotkeySprites[4].sprite = null;
            if (!flag)
            {
                hotkeySprites[4].gameObject.SetActive(false);
            }

        }
        else
        {
            flag = true;
            hotkeySprites[4].sprite = skillSprites[characterSkillHotKeys.skillInKeys[5]];
        }
        // ô số 4
        if (characterSkillHotKeys.skillInKeys[4] == 0)
        {
            hotkeySprites[3].sprite = null;
            if (!flag)
            {
                hotkeySprites[3].gameObject.SetActive(false);
            }

        }
        else
        {
            flag = true;
            hotkeySprites[3].sprite = skillSprites[characterSkillHotKeys.skillInKeys[4]];
        }
        // ô số 3
        if (characterSkillHotKeys.skillInKeys[3] == 0)
        {
            hotkeySprites[2].sprite = null;
            if (!flag)
            {
                hotkeySprites[2].gameObject.SetActive(false);
            }

        }
        else
        {
            flag = true;
            hotkeySprites[2].sprite = skillSprites[characterSkillHotKeys.skillInKeys[3]];
        }
        // ô số 2
        if (characterSkillHotKeys.skillInKeys[2] == 0)
        {
            hotkeySprites[1].sprite = null;
            if (!flag)
            {
                hotkeySprites[1].gameObject.SetActive(false);
            }

        }
        else
        {
            // Debug.Log("hello");
            flag = true;
            hotkeySprites[1].sprite = skillSprites[characterSkillHotKeys.skillInKeys[2]];
        }
        // ô số 1
        if (characterSkillHotKeys.skillInKeys[1] == 0)
        {
            hotkeySprites[0].sprite = null;
        }
        else
        {
            hotkeySprites[0].sprite = skillSprites[characterSkillHotKeys.skillInKeys[1]];
        }

        // thiếp lập các controller
        SkillHotKeyLink.SetDataForKeys();
    }
}
