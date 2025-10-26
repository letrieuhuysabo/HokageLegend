using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ChooseCharacterController : MonoBehaviour
{
    [SerializeField] GameObject narutoButton, sasukeButton, sakuraButton;
    [SerializeField] Transform posOfChar;
    [SerializeField] TMP_InputField nameOfCharIP;
    GameObject activeCharacter;
    string pathOfChar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChooseNaruto();
    }

    public void ChooseNaruto()
    {
        Transform root = GetRootFromPath.GetCharacter("Naruto").root;
        

        narutoButton.GetComponent<Image>().color = Color.yellow;

        ShowRoot(root);
        activeCharacter = narutoButton;
        pathOfChar = "Naruto";
    }
    public void ChooseSasuke()
    {
        Transform root = GetRootFromPath.GetCharacter("Sasuke").root;
        
        sasukeButton.GetComponent<Image>().color = Color.yellow;

        ShowRoot(root);
        activeCharacter = sasukeButton;
        pathOfChar = "Sasuke";
    }
    public void ChooseSakura()
    {
        Transform root = GetRootFromPath.GetCharacter("Sakura").root;
        

        sakuraButton.GetComponent<Image>().color = Color.yellow;

        ShowRoot(root);
        activeCharacter = sakuraButton;
        pathOfChar = "Sakura";
    }
    public void ShowRoot(Transform root)
    {
        if (activeCharacter != null)
        {
            activeCharacter.GetComponent<Image>().color = Color.white;
            Destroy(posOfChar.transform.GetChild(0).gameObject);
        }

        GameObject character = Instantiate(root.gameObject);
        character.transform.SetParent(posOfChar, false);
        character.transform.localPosition = Vector3.zero;
        // xóa các child
        StartCoroutine(DestroyChilds(character.transform));
        DestroyComponents(character.transform);
    }
    IEnumerator DestroyChilds(Transform t)
    {
        while (t.childCount > 0)
        {
            Destroy(t.GetChild(0).gameObject);
            yield return null;
        }
    }
    public void StartGame()
    {
        // lỗi chưa nhập tên
        if (nameOfCharIP.text == "")
        {
            ThongBaoLoiController.instance.ThongBao("Hãy nhập tên");
            return;
        }
        if (nameOfCharIP.text.Length < 3 || nameOfCharIP.text.Length > 15)
        {
            ThongBaoLoiController.instance.ThongBao("Tên có độ dài 3-15 kí tự");
            return;
        }
        // Save Data
        // Save path
        SaveAndLoadSystem.ClearData();
        CharacterPath characterPath = new();
        characterPath.path = pathOfChar;
        SaveAndLoadSystem.SaveCharacterPath(characterPath);
        // Save properties
        CharacterProperties characterProperties = new(nameOfCharIP.text);
        SaveAndLoadSystem.SaveCharacterProperties(characterProperties);
        // Save Location
        CharacterLocation characterLocation = new(new Vector2(-24.1f, -14.21f), new Vector2(4, 4), 2);
        SaveAndLoadSystem.SaveCharacterLocation(characterLocation);
        //Save BaseAtrributes
        CharacterBaseAttributes characterBaseAttributes = new();
        SaveAndLoadSystem.SaveCharacterBaseAttributes(characterBaseAttributes);
        // Save CurrentAttributes
        CharacterFinalAttributes characterFinalAttributes = new();
        CharacterCurrentAttributes characterCurrentAttributes = new(characterFinalAttributes.maxHp,characterFinalAttributes.maxMp);
        SaveAndLoadSystem.SaveCharacterCurrentAttributes(characterCurrentAttributes);
        // Save HotKeys
        CharacterSkillHotKeys characterSkillHotKeys = new();
        SaveAndLoadSystem.SaveCharacterSkillHotKeys(characterSkillHotKeys);
        // vào game
        SceneManager.LoadScene(2);
    }
    public void DestroyComponents(Transform tran)
    {
        Component[] components = tran.gameObject.GetComponents<Component>();
        foreach (Component component in components)
        {
            if (component is not Transform &&
                component is not SpriteRenderer &&
                component is not Animator &&
                component is not Collider2D &&
                component is not Rigidbody2D)
            {
                Destroy(component);
            }
        }
    }
}
