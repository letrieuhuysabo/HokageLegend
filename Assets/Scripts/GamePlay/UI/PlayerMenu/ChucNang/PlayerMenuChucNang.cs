using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMenuChucNang : MonoBehaviour
{
    public void Exit()
    {
        UpdateLocationController.instance.UpdateLocation();
        SceneManager.LoadScene(0);
    }
}
