using UnityEngine;

public class Collect : MonoBehaviour {

	public enum type { crowbar, cleaver, bat, flameTorch, torchLight, morgueGoldKey, morgueSilverKey };
	public type dropType;

	private WeaponSwitch weaponSwitch;
	private LightSwitch lightSwitch;
	private bool near = false;

	void Awake()
	{
		lightSwitch = FindObjectOfType<LightSwitch> ();
		weaponSwitch = FindObjectOfType<WeaponSwitch> ();
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
		if (near && Input.GetKeyDown ("e"))
		{
			switch (dropType)
			{
			case type.flameTorch:
				lightSwitch.flameTorch.found = true;
				break;
			case type.torchLight:
				lightSwitch.torchLight.found = true;
				break;
			case type.morgueGoldKey:
				PlayerStats.goldKeyFound = true;
				break;
			case type.morgueSilverKey:
				PlayerStats.silverKeyFound = true;
				break;
			case type.bat:
				weaponSwitch.weapons [0].found = true;
				break;
			case type.cleaver:
				weaponSwitch.weapons [1].found = true;
				break;
			case type.crowbar:
				weaponSwitch.weapons [2].found = true;
				break;
			}

			Destroy (gameObject);
		}
	}
}
