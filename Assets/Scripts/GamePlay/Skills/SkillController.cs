using System.Collections;
using UnityEngine;

public abstract class SkillController : MonoBehaviour
{
    protected PlayerAnimator playerAnimator;
    protected bool isCD;
    [SerializeField] int chakraLost;
    [SerializeField] float cdTime;
    void Awake()
    {
        isCD = false;
        playerAnimator = transform.parent.parent.parent.GetComponent<PlayerAnimator>();
    }
    public abstract void UseSkill();
    public void StartCD()
    {
        StartCoroutine(StartCDCoroutine());
    }
    IEnumerator StartCDCoroutine()
    {
        isCD = true;
        float duration = cdTime;
        while (duration > 0)
        {
            duration -= Time.deltaTime;
            yield return null;
        }
        isCD = false;
    }
    protected abstract bool CanUse();
    protected abstract void CreateSkillEffects();
}
