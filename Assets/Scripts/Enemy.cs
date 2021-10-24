using UnityEngine;

public class Enemy : MonoBehaviour {

	public float startHealth = 100;
	public float damage = 20;
	public float moveSpeed, rotateSpeed, seeRange, maxDistanceRange, attackRange, hitSpeed, hitTime;
	private float currentHealth;
	public enum type { Normal, Zombie, Capsule, muscledMutant }
	public type enemyType = type.Normal;
	[HideInInspector]public Transform target;
	private GameObject TargetObj;
	[HideInInspector]public Animator anim;
	[HideInInspector]public bool dead = false;

	void Awake()
	{
		TargetObj = GameObject.FindGameObjectWithTag ("Player");
		currentHealth = startHealth;
		anim = GetComponent<Animator> ();
		if (anim == null) 
		{
			anim = GetComponentInChildren<Animator> ();
		}
	}

	void ApplyDamage(float damage)
	{
		currentHealth -= damage;
		if (enemyType == type.muscledMutant) 
		{
			anim.SetTrigger ("GetHit");
		}
	}

	void Update()
	{
		if (dead || TargetObj == null)
			return;
		target = TargetObj.transform;
		if (currentHealth <= 0) 
		{
			Die ();
		}
	}

	void Die()
	{
		dead = true;
		if (enemyType == type.Zombie || enemyType == type.Capsule || enemyType == type.muscledMutant) 
		{
			anim.SetTrigger ("Die");
		}

		Destroy (gameObject, 5);
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (transform.position, seeRange);
		Gizmos.DrawWireSphere (transform.position, maxDistanceRange);
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, attackRange);
	}
}
