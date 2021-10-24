using UnityEngine;

[System.Serializable]
public class WeaponBlueprint  {

	public GameObject prefab;
	[HideInInspector]public bool justFound;
	[HideInInspector]public bool found;
	public float damage, hitSpeed;
}
