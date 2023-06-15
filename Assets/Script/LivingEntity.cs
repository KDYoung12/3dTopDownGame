using UnityEngine;
using System.Collections;
public class LivingEntity : MonoBehaviour, IDamageable
{
    public float startingHealth;
    protected float health;
    protected bool dead;

    // protected virtual : 가상 클래스
    // 사용 이유 : 두 개의 클래스를 받아버렸기 때문에 어느 하나라도 무시되지 않게하기 위하여 protected virtual을 사용함
    protected virtual void Start()
    {
        health = startingHealth;
    }
    public void TakeHit(float damage, RaycastHit hit)
    {
        Debug.Log("Hit");
        health -= damage;
        if (health <= 0 && !dead)
        {
            Die();
        }
    }
    protected void Die()
    {
        dead = true;
        GameObject.Destroy(gameObject);
    }
}
