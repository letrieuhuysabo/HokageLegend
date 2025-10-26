using UnityEngine;

public class EnemyFinalAttributes : MonoBehaviour
{
    EnemyAttributes enemyAttributes;
    EnemyAnimator enemyAnimator;
    EnemyRespawn enemyRespawn;
    void Awake()
    {
        enemyAttributes = GetComponent<EnemyAttributes>();
        enemyAnimator = GetComponent<EnemyAnimator>();
        enemyRespawn = GetComponent<EnemyRespawn>();
    }
    int hp;
    void OnEnable()
    {
        hp = enemyAttributes.hp;
    }
    public void LostHp(int n)
    {
        hp -= n;
        if (hp > 0)
        {
            enemyAnimator.ChangeAnim("Hitted");
        }
        else
        {
            enemyAnimator.ChangeAnim("Death");
            PlayerSelectionView.instance.RemoveThisSelection(transform.Find("Selection"));
        }
    }
    public void Disappear() // hàm này ddc animation clip death gọi
    {
        enemyRespawn.Respawn();
        gameObject.SetActive(false);
    }
}
