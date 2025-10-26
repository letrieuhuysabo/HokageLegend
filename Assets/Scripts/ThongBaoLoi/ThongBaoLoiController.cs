using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThongBaoLoiController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI content;
    public static ThongBaoLoiController instance;
    [SerializeField] GameObject thongBaoPanel;
    void Awake()
    {
        instance = this;
    }
    public void ThongBao(string s)
    {
        thongBaoPanel.SetActive(true);
        content.text = s;
    }
    public void DongThongBao()
    {
        thongBaoPanel.SetActive(false);
    }
}
