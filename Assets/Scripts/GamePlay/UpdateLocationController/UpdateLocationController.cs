using UnityEngine;
using UnityEngine.SceneManagement;
public class UpdateLocationController : MonoBehaviour
{
    public static UpdateLocationController instance;
    void Awake()
    {
        instance = this;
    }
    void OnApplicationQuit()
    {
        UpdateLocation();
    }
    public void UpdateLocation()
    {
        Transform player = GameObject.Find("Player").transform.GetChild(0);
        CharacterLocation characterLocation = new((Vector2)player.position, (Vector2)player.localScale, SceneManager.GetActiveScene().buildIndex);
        SaveAndLoadSystem.SaveCharacterLocation(characterLocation);
    }
}
