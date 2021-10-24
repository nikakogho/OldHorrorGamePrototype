using UnityEngine;

public class soundSwitch : MonoBehaviour {

	public AudioClip[] clips;
	public AudioClip[] scareClips;
	public float scareTime = 15;
	private AudioSource audioSource;
	private int index = 0;
	private float countdown = 0;

	void Awake()
	{
		audioSource = GetComponent<AudioSource> ();
		countdown = scareTime;
	}

	void Update()
	{
		countdown -= Time.deltaTime;

		if (countdown <= 0) 
		{
			PlaySound (scareClips);
			countdown = scareTime;
			return;
		}

		if (!audioSource.isPlaying) 
		{
			PlaySound (clips);
		}
	}

	void PlaySound(AudioClip[] Clips)
	{
		index = Random.Range (0, Clips.Length);

		audioSource.clip = Clips [index];
		audioSource.Play ();
	}
}
