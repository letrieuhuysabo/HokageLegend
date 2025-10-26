using System.Collections.Generic;
using UnityEngine;

public class CharacterSkillHotKeys
{
    public List<int> skillInKeys;
    public CharacterSkillHotKeys()
    {
        // Debug.Log("hello");
        skillInKeys = new(6);
        for (int i = 0; i < 6; i++)
        {
            skillInKeys.Add(0);
        }
        skillInKeys[1] = 1;
        skillInKeys[2] = skillInKeys[3] = skillInKeys[4] = skillInKeys[5] = 0;
    }
}
