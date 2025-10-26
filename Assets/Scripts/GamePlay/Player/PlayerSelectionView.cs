using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectionView : MonoBehaviour
{
    HashSet<Transform> selections;
    Transform activeSelection;
    [SerializeField] GameObject arrowSelectionPrefab;
    public static PlayerSelectionView instance;
    void Awake()
    {
        selections = new();
        activeSelection = null;
        instance = this;
    }
    void Update()
    {
        if (Input.GetKeyDown(InputConfigs.changeSelection))
        {
            ChangeAnotherSelection();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Selection"))
        {
            AddThisSelection(collision.transform);
        }
    }
    public void AddThisSelection(Transform selection)
    {
        selections.Add(selection);
        if (activeSelection == null)
        {
            SelectThisSelection(selection);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Selection"))
        {
            RemoveThisSelection(collision.transform);
        }
    }
    public void RemoveThisSelection(Transform selection)
    {
        selections.Remove(selection);
        if (activeSelection == selection)
        {
            ChooseNearestSelection();
        }
    }
    public void SelectThisSelection(Transform selection)
    {
        if (activeSelection != null)
        {
            DestroyArrowInThisTransform(activeSelection);
        }
        if (selection != null)
        {
            GameObject arrow = Instantiate(arrowSelectionPrefab);
            arrow.transform.SetParent(selection.parent.Find("Canvas").Find("Select"), true);
            arrow.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            arrow.GetComponent<RectTransform>().sizeDelta = new Vector2(1, 1);
        }
        activeSelection = selection;
    }
    public void DestroyArrowInThisTransform(Transform selection)
    {
        Transform tmp = selection.parent.Find("Canvas").Find("Select");
        if (tmp.childCount > 0)
        {
            Destroy(tmp.GetChild(0).gameObject);
        }
    }
    public void ChooseNearestSelection()
    {
        float minDis = 0;
        bool flag = false;
        Transform playerTransform = GameObject.Find("Player").transform.GetChild(0);
        if (playerTransform == null)
        {
            return;
        }
        Transform nearestSelection = null;
        foreach (Transform t in selections)
        {
            if (!flag || Vector3.Distance(t.position, playerTransform.position) < minDis)
            {
                flag = true;
                minDis = Vector3.Distance(t.position, playerTransform.position);
                nearestSelection = t;
            }
        }
        SelectThisSelection(nearestSelection);
    }
    void ChangeAnotherSelection()
    {
        List<Transform> tmp = new(selections);
        Debug.Log(tmp.Count);
        tmp.Remove(activeSelection);
        if (tmp.Count > 0)
        {
            SelectThisSelection(tmp[Random.Range(0, tmp.Count)]);
        }
    }
    public Transform GetSelectingTransform()
    {
        return activeSelection.parent;
    }
}
