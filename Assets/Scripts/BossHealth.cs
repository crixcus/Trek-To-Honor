using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

	public int health = 500;

	public GameObject deathEffect;
    public UIManager scoreCount;

    public bool isInvulnerable = false;

	public void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.CompareTag("Weapon"))
		{
			TakeDamage(50);
		}
	}

	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;

		if (health <= 200)
		{
			GetComponent<Animator>().SetBool("IsEnraged", true);
		}

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		scoreCount.soulScore++;
		SoundManager.Instance.PlayBossDefeatedSound();
		Destroy(gameObject);
	}

}
