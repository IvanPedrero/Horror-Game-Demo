using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotingAnimatorManager : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isInIdleAnimation(){
        return animator.GetCurrentAnimatorStateInfo(0).IsName("idle");
    }


    public void PlayShootAnimation()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            return;
        }
        animator.SetTrigger("shoot");
    }

    public void PlayReloadAnimation()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            return;
        }
        animator.SetTrigger("reload");
    }

    public void PlayHitAnimation()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            return;
        }
        animator.SetTrigger("hit");
    }
}
