using UnityEngine;

public class CharacterLocation
{
    public float posX, posY, scaleX, scaleY;
    public int currentScene;
    public CharacterLocation(){}
    public CharacterLocation(Vector2 pos, Vector2 scale, int scene)
    {
        posX = pos.x;
        posY = pos.y;
        scaleX = scale.x;
        scaleY = scale.y;
        currentScene = scene;
    }
}
