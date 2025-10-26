using System.Collections;
using TMPro;
using UnityEngine;

public class ChatController : MonoBehaviour
{
    [SerializeField] GameObject chatPanel;
    [SerializeField] TMP_InputField contentChat;
    [SerializeField] GameObject chatBubblePrefab;
    Coroutine waitConfirmButtonCoroutine;
    void Update()
    {
        if (Input.GetKeyDown(InputConfigs.openChat) && !chatPanel.activeInHierarchy)
        {
            OpenChatMenu();
        }
    }
    public void OpenChatMenu()
    {
        if (!OnlyOneMenu.instance.showing)
        {
            contentChat.text = "";
            chatPanel.SetActive(true);
            contentChat.Select();
            OnlyOneMenu.instance.showing = true;
            DontTakeInput.banInput = true;
            SkillHotKeysController.instance.HideHotKeys();
            waitConfirmButtonCoroutine = StartCoroutine(WaitConfirmButtonCoroutine());
        }

    }
    IEnumerator WaitConfirmButtonCoroutine()
    {
        while (true)
        {
            if (Input.GetKeyDown(InputConfigs.confirm))
            {
                Chat();
            
            }
            if (Input.GetKeyDown(InputConfigs.cancel))
            {
                CloseChatMenu();
            }
            yield return null;
        }
    }
    public void CloseChatMenu()
    {
        StopCoroutine(waitConfirmButtonCoroutine);
        chatPanel.SetActive(false);
        OnlyOneMenu.instance.showing = false;
        DontTakeInput.banInput = false;
        SkillHotKeysController.instance.UnHideHotKeys();
    }
    public void Chat()
    {
        StopCoroutine(waitConfirmButtonCoroutine);
        if (contentChat.text == "")
        {
            CloseChatMenu();
            return;
        }
        GameObject canvas = GameObject.Find("CanvasPlayer");
        GameObject chatBubble = Instantiate(chatBubblePrefab);
        chatBubble.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = contentChat.text;
        chatBubble.transform.SetParent(canvas.transform, true);
        Destroy(chatBubble, 5);
        RectTransform chatBubbleRect = chatBubble.GetComponent<RectTransform>();
        chatBubbleRect.anchoredPosition = new Vector2(0,0.5f);
        chatBubbleRect.sizeDelta = new Vector2(1, 1);
        chatBubble.transform.localScale = new Vector3(1, 1, 0);
        CloseChatMenu();
    }
}
