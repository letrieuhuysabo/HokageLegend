using UnityEngine;

public static class Configs
{
    public static float timeToRespawnEnemy = 5;
    public static string FormatNumber(int n)
    {
        return FormatNumber(n + "");
    }
    public static string FormatNumber(string s)
    {
        string tmp = "";
        int dem = 0;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (dem == 3)
            {
                tmp = s[i] + "." + tmp;
                dem = 1;
            }
            else
            {
                tmp = s[i] + tmp;
                dem++;
            }
        }
        return tmp;
    }
}
