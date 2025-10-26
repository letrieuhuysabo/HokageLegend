using UnityEngine;

public class OnlyOneMenu : MonoBehaviour
{
    public static OnlyOneMenu instance;
    [HideInInspector]
    public bool showing;
    void Awake()
    {
        instance = this;
        showing = false;
    }
}
