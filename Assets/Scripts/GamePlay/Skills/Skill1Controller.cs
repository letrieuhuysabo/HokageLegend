using UnityEngine;

public abstract class Skill1Controller : SkillController
{
    [SerializeField] protected float damage, range;
    protected Transform targetTransform;
    public override void UseSkill()
    {
        if (isCD || !CanUse())
        {
            return;
        }
        playerAnimator.ChangeAnim("Skill1");
        targetTransform = PlayerSelectionView.instance.GetSelectingTransform();
        
        // CreateSkillEffects();
        StartCD();
        
    }
    protected override bool CanUse()
    {
        return PlayerSelectionView.instance.GetSelectingTransform() != null &&
                Vector3.Distance(PlayerSelectionView.instance.GetSelectingTransform().position, transform.position) <= range;
    }
    public void Attack() // hàm này đc animation clip của skill1 gọi
    {
        Debug.Log(targetTransform.gameObject.name);
        targetTransform.Find("HurtBox").GetComponent<EnemyHurtBox>().BeDamaged((int)(damage * new CharacterFinalAttributes().damage));
    }
}
