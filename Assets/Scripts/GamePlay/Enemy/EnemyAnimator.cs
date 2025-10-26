using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void ChangeAnim(string s)
    {
        anim.SetTrigger(s);
    }
    public void ChangeAnim(string s, bool b)
    {
        anim.SetBool(s, b);
    }
}
