using UnityEngine;

public class ChatBubble : MonoBehaviour
{
    Transform characterTransform;
    void Start()
    {
        characterTransform = GameObject.Find("Player").transform.GetChild(0);
    }
    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(-characterTransform.localScale.x / Mathf.Abs(characterTransform.localScale.x), 1, 0);
    }
}
