using UnityEngine;

public class starter : MonoBehaviour {

	public GameObject[] stuff;

	void Awake()
	{
		foreach (GameObject thing in stuff) 
		{
			thing.SetActive (true);
		}
	}
}
