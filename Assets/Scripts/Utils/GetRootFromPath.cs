using System.Collections.Generic;
using UnityEngine;

public static class GetRootFromPath
{
    static Dictionary<string, Character> path_root = new();
    public static Character GetCharacter(string path)
    {
        if (!path_root.ContainsKey(path))
        {
            Character root = Resources.Load<Character>("ScriptableObjects/Characters/" + path);
            // Debug.Log(root);
            path_root[path] = root;
        }
        return path_root[path];
    }
}
