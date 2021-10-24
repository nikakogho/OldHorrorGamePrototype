using UnityEngine;

public class WeaponSwitch : MonoBehaviour {

	public WeaponBlueprint[] weapons;
	private WeaponBlueprint currentWeapon;
	private int index = 0, found = 0;

	void Awake()
	{
		foreach (WeaponBlueprint weapon in weapons) 
		{
			weapon.found = false;
			weapon.justFound = true;
			weapon.prefab.SetActive (false);
		}
	}

	void Update()
	{
		found = 0;
		foreach (WeaponBlueprint weapon in weapons) 
		{
			if (weapon.found)
			{
				found++;
				if (weapon.justFound)
				{
					SetWeapon (weapon);
				}
			}
		}

		if (Input.GetButtonDown("weaponChange")) 
		{
			index++;
		}

		if (found > 1) 
		{
			SwitchWeapons ();
		}
	}

	void SwitchWeapons()
	{
		if (weapons [index].found) 
		{
			SetWeapon(weapons[index]);
		} else 
		{
			index++;
		}
	}

	void SetWeapon(WeaponBlueprint weapon)
	{
		weapon.justFound = false;
		currentWeapon = weapon;
		for (int i = 0; i < weapons.Length; i++) 
		{
			if (weapons [i] != weapon) 
			{
				weapons [i].prefab.SetActive (false);
			} else 
			{
				index = i;
				weapons [i].prefab.SetActive (true);
			}
		} 
	}
}
