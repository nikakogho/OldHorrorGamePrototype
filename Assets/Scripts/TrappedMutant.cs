using UnityEngine;

public class TrappedMutant : MonoBehaviour {

	public bool over = false;
	public GameObject prefab;
	private Animator anim;
	public static bool opened = false;
	private bool seen = false;

	void Awake()
	{
		opened = false;
		anim = GetComponent<Animator> ();
	}

	void Update()
	{
		if (opened && !seen) 
		{
			See ();
		}

		if (over) 
		{
			Instantiate (prefab, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}

	void See()
	{
		seen = true;
		anim.SetTrigger ("See");
	}
}
