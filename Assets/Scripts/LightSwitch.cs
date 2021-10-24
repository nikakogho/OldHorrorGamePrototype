using UnityEngine;

public class LightSwitch : MonoBehaviour {

	public LightBlueprint torchLight, flameTorch;
	private LightBlueprint currentLight;
	private LightBlueprint[] lights;
	private int index = 0, found = 0;
	private bool On = true;

	void Awake()
	{
		lights =  new LightBlueprint[] { torchLight, flameTorch };

		foreach (LightBlueprint light in lights) 
		{
			light.found = false;
			light.justFound = true;
			light.prefab.SetActive (false);
		}
	}

	void Update()
	{
		found = 0;
		foreach (LightBlueprint light in lights) 
		{
			if (light.found && light.justFound) 
			{
				SetLight (light);
			}
			if (light.found) 
			{
				found++;
			}
		}
		if (Input.GetButtonDown("lightChange")) 
		{
			index++;
		}

		index %= lights.Length;

		if (found > 1 && On)
		{
			SwitchLights ();
		}

		if (Input.GetKeyDown ("l")) 
		{
			if (currentLight != null) 
			{
				On = !On;
			}
		}

		if (found > 0) 
		{
			if (currentLight.prefab.activeSelf != On)
			{
				currentLight.prefab.SetActive (On);
			}
		}
	}

	void SwitchLights()
	{
		if (!lights [index].prefab.activeSelf)
			return;
		if (lights [index].found) 
		{
			SetLight (lights [index]);
		} else 
		{
			index++;
		}
	}

	void SetLight(LightBlueprint light)
	{
		light.justFound = false;
		currentLight = light;

		for (int i = 0; i < lights.Length; i++) 
		{
			if (currentLight == lights [i]) 
			{
				index = i;
			}
		}

		foreach (LightBlueprint thing in lights) 
		{
			if (thing != currentLight) 
			{
				thing.prefab.SetActive (false);
			}
		}
	}
}
