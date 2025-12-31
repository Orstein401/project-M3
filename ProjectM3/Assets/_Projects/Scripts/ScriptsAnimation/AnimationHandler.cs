using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private Animator _anim;
    [SerializeField] string verticalSpeedName = "Vspeed";
    [SerializeField] string horizontalSpeedName = "Hspeed";
    [SerializeField] string isDeath = "IsDeath";
    [SerializeField] string isShooting = "IsShooting";




    protected void Awake()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    private void SetVerticalSpeed(float Vspeed)
    {
        _anim.SetFloat(verticalSpeedName, Vspeed);
    }
    private void SetHorizontalSpeed(float Hspeed)
    {
        _anim.SetFloat(horizontalSpeedName, Hspeed);
    }
    public void SetDirectionAnimation(Vector2 direction)
    {
        SetVerticalSpeed(direction.y);
        SetHorizontalSpeed(direction.x);
    }

    public void StartAnimationDeath(bool isDead)
    {
        _anim.SetBool(isDeath,isDead);
    }
    public void StartAnimationShoot(bool isShoot)
    {
        _anim.SetBool(isShooting, isShoot);
    }
}
