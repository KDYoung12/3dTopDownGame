using UnityEngine;
using System.Collections;
public class LivingEntity : MonoBehaviour, IDamageable
{
    public float startingHealth;
    protected float health;
    protected bool dead;

    // protected virtual : ���� Ŭ����
    // ��� ���� : �� ���� Ŭ������ �޾ƹ��ȱ� ������ ��� �ϳ��� ���õ��� �ʰ��ϱ� ���Ͽ� protected virtual�� �����
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
