using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public static class SkillHotKeyLink
{
    public static Dictionary<int, SkillController> skillControllerAtKey = new();
    static CharacterSkillHotKeys characterSkillHotKeys;
    public static async void SetDataForKeys() // hàm này đc gọi ở SkillHotKeysController.ShowKeys, sau khi load các skill vào hot key
    {
        await Task.Yield();
        
        skillControllerAtKey.Clear();
        characterSkillHotKeys = SaveAndLoadSystem.LoadCharacterSkillHotKeys();
        CharacterProperties characterProperties = SaveAndLoadSystem.LoadCharacterProperties();
        for (int i = 1; i < characterSkillHotKeys.skillInKeys.Count; i++)
        {
            if (characterSkillHotKeys.skillInKeys[i] != 0)
            {
                skillControllerAtKey[i] = GameObject.Find("Player").transform.GetChild(0).Find("Skills")
                                        .GetChild(characterSkillHotKeys.skillInKeys[i] - 1) // chiêu nào
                                        .GetChild(characterProperties.levelOfSkills[i] - 1) // level bao nhiêu
                                        .GetComponent<SkillController>();
            }
            else
            {
                skillControllerAtKey[i] = null;
            }
        }
    }

}
