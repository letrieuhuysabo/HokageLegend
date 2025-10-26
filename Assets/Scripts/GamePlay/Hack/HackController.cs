using UnityEngine;

public class HackController : MonoBehaviour
{
    // ấn P để nhận 1000 sức mạnh và 1000 tiềm năng
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            // StrengthAndPotentialController.instance.GainExp(1000);
            PlayerFinalAttributes.instance.LostHp(10);
        }
        
    }
}
