using UnityEngine;

public class melee : MonoBehaviour {

	private WeaponSwitch switcher;
	public enum type { bat = 0, cleaver, crowbar }
	public type weaponType;
	private Animator anim;
	private WeaponBlueprint stats;
	private float countdown = 0;

	void Awake()
	{
		switcher = FindObjectOfType<WeaponSwitch> ();
		anim = GetComponent<Animator> ();

		int index = (int)weaponType;

		stats = switcher.weapons [index];
	}

	void Update()
	{
		countdown -= Time.deltaTime;

		countdown = Mathf.Clamp (countdown, 0, stats.hitSpeed);

		if (countdown == 0) 
		{
			if (Input.GetButtonDown ("Fire1")) 
			{
				Hit ();
			}
		}
	}

	void Hit()
	{
		countdown = stats.hitSpeed;
		anim.SetTrigger ("hit");
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Enemy")) 
		{
			other.SendMessage ("ApplyDamage", stats.damage);
		}
	}
}
