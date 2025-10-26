using System.Collections.Generic;
using UnityEngine;

public class CharacterProperties
{
    // tên nhân vật
    public string name;
    // sức mạnh, tiềm năng
    public int strengthPoint, potentialPoint;
    // vàng, ngọc
    public int vang, ngoc;
    // cấp độ skill
    public List<int> levelOfSkills;
    public CharacterProperties(string name)
    {
        this.name = name;
        strengthPoint = 2000;
        potentialPoint = 2000;
        vang = 100000;
        ngoc = 200;
        levelOfSkills = new();
        for (int i = 0; i < 5; i++)
        {
            levelOfSkills.Add(0);
        }
        levelOfSkills[1] = 1;
        levelOfSkills[2] = levelOfSkills[3] = levelOfSkills[4] = 0;
    }
}
