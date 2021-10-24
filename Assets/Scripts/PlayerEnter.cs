using UnityEngine;

public class PlayerEnter : MonoBehaviour {

	public GameObject[] stuff;

	void Start()
	{
		Set (false);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player"))
		{
			Set (true);

			Destroy (this);
		}
	}

	void Set(bool state)
	{
		foreach (GameObject thing in stuff) 
		{
			thing.SetActive (true);
			Renderer[] rends = thing.GetComponentsInChildren<Renderer> ();
			Collider[] cols = thing.GetComponentsInChildren<Collider> ();

			if (rends != null)
			{
				foreach (Renderer rend in rends) 
				{
					rend.enabled = state;
				}
			}

			if (cols != null)
			{
				foreach (Collider col in cols) 
				{
					col.enabled = state;
				}
			}

			thing.SetActive (state);
		}
	}
}
