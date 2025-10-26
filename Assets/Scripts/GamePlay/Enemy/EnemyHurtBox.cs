using UnityEngine;

public class EnemyHurtBox : MonoBehaviour
{
    EnemyFinalAttributes enemyFinalAttributes;
    void Awake()
    {
        enemyFinalAttributes = transform.parent.GetComponent<EnemyFinalAttributes>();
    }
    public void BeDamaged(int damage)
    {
        // Debug.Log(damage);
        enemyFinalAttributes.LostHp(damage);
    }
}
