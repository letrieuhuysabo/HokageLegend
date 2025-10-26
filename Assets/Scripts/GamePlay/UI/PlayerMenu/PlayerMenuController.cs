using UnityEngine;

public class PlayerMenuController : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    [Header("Thông tin nhiệm vụ")]
    [SerializeField] GameObject nhiemVuTren;
    [SerializeField] GameObject nhiemVuDuoi;
    [Header("Thông tin hành trang")]
    [SerializeField] GameObject hanhTrangTren;
    [SerializeField] GameObject hanhTrangDuoi;
    [Header("Thông tin kĩ năng")]
    [SerializeField] GameObject kiNangTren;
    [SerializeField] GameObject kiNangDuoi;
    [Header("Thông tin chức năng")]
    [SerializeField] GameObject chucNangTren;
    [SerializeField] GameObject chucNangDuoi;

    GameObject activeChucNangTren, activeChucNangDuoi;
    void Start()
    {
        OpenNhiemVu();
    }
    void Update()
    {
        if (Input.GetKeyDown(InputConfigs.openMenuPlayer) && !menuPanel.activeInHierarchy)
        {
            OpenMenu();
        }
    }
    public void OpenMenu()
    {
        if (!OnlyOneMenu.instance.showing)
        {
            menuPanel.SetActive(true);
            OnlyOneMenu.instance.showing = true;
            DontTakeInput.banInput = true;
            SkillHotKeysController.instance.HideHotKeys();
        }
        
    }
    public void CloseMenu()
    {
        menuPanel.SetActive(false);
        OnlyOneMenu.instance.showing = false;
        DontTakeInput.banInput = false;
        SkillHotKeysController.instance.UnHideHotKeys();
    }
    public void OpenNhiemVu()
    {
        CloseActiveMenu();
        OpenActiveMenu(nhiemVuTren, nhiemVuDuoi);
    }
    public void OpenHanhTrang()
    {
        CloseActiveMenu();
        OpenActiveMenu(hanhTrangTren, hanhTrangDuoi);
    }
    public void OpenKiNang()
    {
        CloseActiveMenu();
        OpenActiveMenu(kiNangTren, kiNangDuoi);
    }
    public void OpenChucNang()
    {
        CloseActiveMenu();
        OpenActiveMenu(chucNangTren, chucNangDuoi);
    }
    void CloseActiveMenu()
    {
        if (activeChucNangTren != null)
        {
            activeChucNangTren.SetActive(false);
            activeChucNangDuoi.SetActive(false);
        }
    }
    void OpenActiveMenu(GameObject tren, GameObject duoi)
    {
        activeChucNangTren = tren;
        activeChucNangDuoi = duoi;
        activeChucNangTren.SetActive(true);
        activeChucNangDuoi.SetActive(true);
    }
}
