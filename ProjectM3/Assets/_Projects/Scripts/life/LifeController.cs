using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public int Hp;

    public void TakeDamage(int damage)
    {
        Hp = Mathf.Max(0, Hp - damage); // per evitare che vada sotto lo zero la vita
    }
    public bool IsAlive()
    {
        return Hp > 0;
    }

}
