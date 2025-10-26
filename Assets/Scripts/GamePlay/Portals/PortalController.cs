using UnityEngine;
using UnityEngine.SceneManagement;
public class PortalController : MonoBehaviour
{
    [SerializeField] int scene;
    [SerializeField] Vector2 posAfterGo, scaleAfterGo;
    bool inRange;
    void Awake()
    {
        inRange = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;
        }
    }
    void LateUpdate()
    {
        if (Input.GetKeyDown(InputConfigs.confirm) && inRange)
        {
            UpdateDataLocation();
            SceneManager.LoadScene(scene);
        }
    }
    public void UpdateDataLocation()
    {
        CharacterLocation characterLocation = new(posAfterGo, scaleAfterGo, scene);
        SaveAndLoadSystem.SaveCharacterLocation(characterLocation);
    }
    public void ClickGo()
    {
        if (inRange)
        {
            UpdateDataLocation();
            SceneManager.LoadScene(scene);
        }
    }
}
