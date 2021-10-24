using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	private Enemy e;
	private float countdown = 0;
	private Rigidbody rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody> ();
		e = GetComponent<Enemy> ();
	}

	void Update()
	{
		if (e.enemyType == Enemy.type.muscledMutant) 
		{
			e.anim.SetBool ("Dead", e.dead);
		}
		if (e.dead || e.target == null)
			return;

		countdown -= Time.deltaTime;

		Vector3 dir = e.target.position - transform.position;
		dir.y = 0;

		if (dir.magnitude < e.attackRange) 
		{
			if (countdown <= 0) 
			{
				countdown = e.hitSpeed;

				StartCoroutine (Hit ());
			}
		} else if (dir.magnitude < e.seeRange || dir.magnitude > e.maxDistanceRange) 
		{
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (dir), e.rotateSpeed * Time.deltaTime);
			transform.Translate (Vector3.forward * e.moveSpeed * Time.deltaTime);
			//rb.MovePosition(rb.position + Vector3.forward * e.moveSpeed * Time.deltaTime);
		} else 
		{
			
		}

		if (e.enemyType == Enemy.type.Capsule || e.enemyType == Enemy.type.muscledMutant) 
		{
			e.anim.SetBool ("walking", dir.magnitude < e.seeRange || dir.magnitude > e.maxDistanceRange);
		}
		if (e.enemyType == Enemy.type.muscledMutant) 
		{
			e.anim.SetBool ("running", dir.magnitude < e.seeRange / 2);
		}
	}

	IEnumerator Hit()
	{
		if (e.enemyType == Enemy.type.Zombie || e.enemyType == Enemy.type.Capsule || e.enemyType == Enemy.type.muscledMutant) 
		{
			e.anim.SetTrigger ("hit");
		}
		yield return new WaitForSeconds (e.hitTime);
		PlayerStats.health -= e.damage;
	}
}
