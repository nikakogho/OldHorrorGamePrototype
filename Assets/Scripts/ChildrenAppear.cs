using UnityEngine;
using System.Collections.Generic;

public class ChildrenAppear : MonoBehaviour {

	private Renderer[] stuff;
	private Transform player;
	public float checkRate;
	private float countdown = 0;
	public float range;

	void Awake()
	{
		stuff = GetComponentsInChildren<Renderer> ();

		for (int i = 0; i < stuff.Length; i++) 
		{
			stuff [i].GetComponent<Collider> ().enabled = true;
			stuff [i].enabled = true;
			stuff [i].gameObject.SetActive (false);
		}

		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update()
	{
		countdown -= Time.deltaTime;

		if (countdown <= 0)
		{
			countdown = checkRate;
			Check ();
		}
	}

	void Check()
	{
		foreach (Renderer thing in stuff)
		{
			if ((player.position - thing.transform.position).magnitude <= range)
			{
				if (!thing.gameObject.activeSelf) 
				{
					thing.gameObject.SetActive(true);
				}
			} else if (thing.gameObject.activeSelf) 
			{
				thing.gameObject.SetActive (false);
			}
		}
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere (transform.position, range);
	}
}