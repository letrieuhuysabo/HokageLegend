using TMPro;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.UI;
public class LoadDatasController : MonoBehaviour
{
    [Header("Avatar, tên")]
    [SerializeField] Image avatar;
    [SerializeField] TextMeshProUGUI nameOfPlayer;
    [Header("Sức mạnh, tiềm năng")]
    [SerializeField] TextMeshProUGUI strengthPoint;
    [SerializeField] TextMeshProUGUI potentialPoint;
    [Header("Vàng, Ngọc")]
    [SerializeField] TextMeshProUGUI vang;
    [SerializeField] TextMeshProUGUI ngoc;
    public static LoadDatasController instance;
    // void Update()
    // {
    //     CharacterBaseAttributes characterBaseAttributes = SaveAndLoadSystem.LoadCharacterBaseAttributes();
    //     Debug.Log(characterBaseAttributes.baseHp);
    // }
    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontTakeInput.banInput = false;
        OnlyOneMenu.instance.showing = false;
        // Load Data lên
        avatar.sprite = GetRootFromPath.GetCharacter(SaveAndLoadSystem.LoadCharacterPath().path).avatar;


        CharacterProperties characterProperties = SaveAndLoadSystem.LoadCharacterProperties();

        nameOfPlayer.text = characterProperties.name;

        LoadSucManh(characterProperties);
        LoadTiemNang(characterProperties);

        LoadVang(characterProperties);
        LoadNgoc(characterProperties);

        // tạo nhân vật
        Transform root = GetRootFromPath.GetCharacter(SaveAndLoadSystem.LoadCharacterPath().path).root;
        GameObject player = Instantiate(root.gameObject);
        player.transform.SetParent(GameObject.Find("Player").transform, false);
        // Load Vị trí
        CharacterLocation characterLocation = SaveAndLoadSystem.LoadCharacterLocation();

        player.transform.position = new Vector3(characterLocation.posX, characterLocation.posY, 0);
        player.transform.localScale = new Vector3(characterLocation.scaleX, characterLocation.scaleY, 0);

        player.GetComponent<PlayerMovement>().ReCalculateFacingRight();

    }
    public void LoadSucManh(CharacterProperties characterProperties)
    {
        strengthPoint.text = "Sức mạnh:\n" + Configs.FormatNumber(characterProperties.strengthPoint);
    }
    public void LoadTiemNang(CharacterProperties characterProperties)
    {
        potentialPoint.text = "Tiềm năng:\n" + Configs.FormatNumber(characterProperties.potentialPoint);
    }
    public void LoadVang(CharacterProperties characterProperties)
    {
        vang.text = Configs.FormatNumber(characterProperties.vang);
    }
    public void LoadNgoc(CharacterProperties characterProperties)
    {
        ngoc.text = Configs.FormatNumber(characterProperties.ngoc);
    }
}
