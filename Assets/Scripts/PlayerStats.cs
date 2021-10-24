using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public float startHealth;
	public static float health;
	public float maxHealth;
	public static bool goldKeyFound = false, silverKeyFound = false;

	void Awake()
	{
		health = startHealth;
	}

	void Update()
	{
		health = Mathf.Clamp (health, 0, maxHealth);
	}
}
