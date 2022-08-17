using System.Collections.Generic;
using UnityEngine;
using LoLSDK;

public class SoundFX : MonoBehaviour {

	public static SoundFX Ins;

	private AudioSource audioSrc;

	[HeaderAttribute("Plant Sounds")]
	public string pollenAdded;
	public string pollenRemoved;
	public string seedDrop;
	public string plantAppear;
	public string plantAdded;

	[HeaderAttribute("Background Music")]
	public string levelMusic;
	public string levelSelectMusic;

	[HeaderAttribute("GUI Sounds")]
    //public AudioClip guiSnd;
	public string guiSnd;
	public string levelEndSnd;
	public string gameOverSnd;
	public string starSnd;
	
	[HeaderAttribute("NPC Sounds")]
    public string floristAfirmationSnd;
    public string floristQuestionSnd;

    public string parrotSurpriseSnd;
    public string parrotSnd_A;
    public string parrotSnd_B;

	[HeaderAttribute("World Sounds")]
	public string charSel;
	public string cashRegisterSnd;
	public string scoreSnd;
	public string doorOpeningSnd;
	public string matchSuccessSnd;
	public string matchFailSnd;
	public string windSnd;
	public string pageSound;

    private List<AudioClip> sfxList;
    
    void Awake()
	{
		Ins = this;

		audioSrc = gameObject.AddComponent<AudioSource>();
		audioSrc.spatialBlend = 0;
	}

    void OnDestroy() { Ins = null; }

	public void Play(string _clip) 
    {
		LOLSDK.Instance.PlaySound(_clip);
	}

	public void PlayBackground(string _clip)
	{
		LOLSDK.Instance.PlaySound(_clip,true,true);
	}

	public void stopBackground(string _clip)
	{
		LOLSDK.Instance.StopSound(_clip);
	}
}
