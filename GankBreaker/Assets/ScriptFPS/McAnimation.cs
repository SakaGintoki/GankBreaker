using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string firstPersonHandTag = "FirstPersonHand";
    Animator Anim;

    private void Awake()
    {
        GameObject firstPersonHand = GameObject.FindGameObjectWithTag(firstPersonHandTag);
        Anim = firstPersonHand.GetComponent<Animator>();
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
