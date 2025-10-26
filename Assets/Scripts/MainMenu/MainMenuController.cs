using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject sureNewGamePanel, continueGame;
    private void Start() {
        CharacterPath cp = SaveAndLoadSystem.LoadCharacterPath();
        if (cp != null)
        {
            continueGame.SetActive(true);
        }
    }
    public void CheckNewGame(){
        sureNewGamePanel.SetActive(true);
    }
    public void CloseCheckNewGame(){
        sureNewGamePanel.SetActive(false);
    }
    public void NewGame(){
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void ContinueGame()
    {
        int scene = SaveAndLoadSystem.LoadCharacterLocation().currentScene;
        SceneManager.LoadScene(scene);
    }
}
