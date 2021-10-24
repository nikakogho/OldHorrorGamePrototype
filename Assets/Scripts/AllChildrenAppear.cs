using UnityEngine;
using System.Collections.Generic;

public class AllChildrenAppear : MonoBehaviour {

	private GameObject[] stuff;
	private Transform player;
	public float range;

	private bool Enabled = false;

	void Awake()
	{
		int size = transform.childCount;

		stuff = new GameObject[size];

		for (int i = 0; i < size; i++) 
		{
			stuff [i] = transform.GetChild (i).gameObject;
		}

		player = GameObject.FindGameObjectWithTag ("Player").transform;

		Visible (false);
	}

	void Update()
	{
		if ((player.position - transform.position).magnitude <= range)
		{
			if (!Enabled) 
			{
				Visible (true);
			}
		} else if (Enabled)
		{
			Visible (false);
		}
	}

	void Visible(bool state)
	{
		Enabled = state;
		foreach (GameObject thing in stuff) 
		{
			thing.SetActive (state);
		}
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere (transform.position, range);
	}
}
