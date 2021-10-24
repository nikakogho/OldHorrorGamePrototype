using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {

	public bool mutantDoor = false;
	public float closeTime = 2;
	private Animator anim;
	private bool near = false, opened = false;

	void Awake()
	{
		anim = GetComponent<Animator> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player"))
		{
			near = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag ("Player"))
		{
			near = false;
		}
	}

	void Update()
	{
		if (near && Input.GetKeyDown ("e") && !opened) 
		{
			Open ();
		}
	}

	void Open()
	{
		if (mutantDoor)
		{
			TrappedMutant.opened = true;
		}
		opened = true;
		anim.SetTrigger ("Open");
		StartCoroutine (Close());
	}

	IEnumerator Close()
	{
		yield return new WaitForSeconds (closeTime);
		opened = false;
		anim.SetTrigger ("Close");
	}
}
