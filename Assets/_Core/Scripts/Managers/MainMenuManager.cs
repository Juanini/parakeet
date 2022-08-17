using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using LoLSDK;

public class MainMenuManager : MonoBehaviour {

	public static MainMenuManager Ins;
	public Transform cam;
	public Animator door;

	public List<RectTransform> buttonsList;
	public GameObject buttons;

	[HeaderAttribute("Score Text")]
	public Text scoreText;

	[HeaderAttribute("Loading")]
	public GameObject loadingGui;

	public GameObject levelsCompleted;
	

	private bool isOnLevelSelect = false;

	void Start () 
	{

		if(Game.wasIngame)
		{
			SoundFX.Ins.PlayBackground(SoundFX.Ins.levelSelectMusic);
			openShop();
		}

		if(Game.gameCompletedReported)
		{
			levelsCompleted.SetActive(true);
		}

		Game.wasIngame = false;
		//if(Game.Initialized == 0)
		//	LOLSDK.Init ("com.catrinaproject.flowershop");

		//LOLSDK.Instance.DisplayPerformanceTestTool();

		Game.Initialized = 1;

		//LOLSDK.Instance.ConfigureSound(0.6f, 0.4f, 0.4f);
		//Invoke("playMainMenuMusic",0.5f);
		//SoundFX.Ins.PlayBackground(SoundFX.Ins.levelSelectMusic);

		/*
		for (int i = 0; i < Game.currentLevel; i++)
		{
			buttonsList[i].GetComponent<LevelButton>().isUnlocked = true;
			buttonsList[i].GetComponent<LevelButton>().checkState();
		}
		*/
	}

	public void hideLevelComplete()
	{
		levelsCompleted.SetActive(false);
		LOLSDK.Instance.CompleteGame();
	}
	
	public void playMainMenuMusic()
	{
	}
	void Awake () 
	{
		Ins = this;
	}

	public void openShop()
	{
		if(isOnLevelSelect) { return; }

		isOnLevelSelect = true;

		door.enabled = true;
		SoundFX.Ins.Play(SoundFX.Ins.doorOpeningSnd);
		//closeUp();
		Invoke("closeUp",0.45f);
	}

	public void closeUp()
	{
		cam.DOMove( new Vector3(0,0,-3.4f) , 0.8f ).SetEase(Ease.Linear).OnComplete(welcome);
	}

	

	public void welcome()
	{
		
		
		scoreText.gameObject.SetActive(true);
		scoreText.text = Game.SCORE.ToString() + " Points";

		SoundFX.Ins.Play(SoundFX.Ins.floristAfirmationSnd);
		SoundFX.Ins.Play(SoundFX.Ins.parrotSnd_A);
		Parrot.Ins.talkOneShoot();
		Florist.Ins.talkOneShoot();
		Invoke("showLevelButtons",1.2f);
	}

	public void showLevelButtons()
	{
		buttons.SetActive(true);
	}
}
