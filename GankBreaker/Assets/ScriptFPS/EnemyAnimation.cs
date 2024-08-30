using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string firstPersonEnemyTag = "FirstPersonEnemy";
    Animator Anim;

    private void Awake()
    {
        GameObject firstPersonEnemy = GameObject.FindGameObjectWithTag(firstPersonEnemyTag);
        Anim = firstPersonEnemy.GetComponent<Animator>();
    }
    public void SetAnimationPunch()
    {
        Anim.SetTrigger("Punch");
    }

    public void SetAnimationDefault()
    {
        Anim.SetTrigger("Default");
    }

    public void SetAnimationShield()
    {
        Anim.SetTrigger("Shield");
    }
}
