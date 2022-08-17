using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using LoLSDK;

public class LevelManager : MonoBehaviour {

	public static LevelManager Ins;

	////////////////////
	//TOP BAR
	////////////////////
	[HeaderAttribute("TOP BAR")]
	public List<GameObject> countersList;
	private int countersAmount;
	private GameObject currentCounterObj;

	private int totalFlowerNeeded 	= 0;
	private int currentFlowers 		= 0;

	[HeaderAttribute("Menus")]
	public GameObject ResultMenu;
	public GameObject GameOverMenu;

	[HeaderAttribute("Pollinators Spawn Pos")]
	public Transform pollinatorsSpawnPos;

	[HeaderAttribute("Seeds Pool")]
	public Pool seedsPool;

	public bool isControlsBlocked = false;
	
	//Time
	[Header("Level time elements")]
	public float timer = 0;
	private float maxTime;

	public Slider timeSlider;
	public Text timeLabel;

	[HeaderAttribute("Loading")]
	public GameObject loadingGui;

	private bool isTimeActive = false;

    private int minutes;
    private int seconds;
    private int hundredths;
	
	private bool isLevelComplete = false;

	void Awake () 
	{
		Ins = this;		
	}

	void Start()
	{

		#if UNITY_EDITOR
		if(Game.Initialized == 0)
			LOLSDK.Init ("com.catrina.flowershop");
		#endif
		
		//LOLSDK.Instance.DisplayPerformanceTestTool();

		startLevel();
		SoundFX.Ins.PlayBackground(SoundFX.Ins.levelMusic);

		LevelPool.Ins.setCountersType();
	}
	
	void Update () 
	{
		if(!isTimeActive) { return; }
		
		checkTime();
	}

	public void goToMainMenu()
	{
		Time.timeScale = 1;
		loadingGui.SetActive(true);

		SoundFX.Ins.stopBackground(SoundFX.Ins.levelMusic);
		
		Game.wasIngame = true;

		SceneManager.LoadScene(Game.S_MAIN_MENU);
	}

	public void retry()
	{
		Time.timeScale = 1;
		loadingGui.SetActive(true);

		SoundFX.Ins.stopBackground(SoundFX.Ins.levelMusic);
		SceneManager.LoadScene(Game.S_GAME);
	}

	public void setTimer(int _time)
	{
		maxTime = _time;
		timer = _time;
	}

	//TIMER
	public void startLevel()
	{
		isTimeActive = true;
		timeSlider.maxValue = timer;
	}

	public void levelComplete()
	{
		if(isLevelComplete) { return; }

		if((Game.currentLevel == Game.LEVEL_8) && !Game.gameCompletedReported)
		{
			Game.gameCompletedReported = true;
		}

		isTimeActive = false;
		isLevelComplete = true;
		Invoke("showResultScreen",1);

		if(Game.currentLevel == Game.LEVEL_1 &&
			Tutorial.Ins.isTutoActive)
		{
			Tutorial.Ins.tutoEnd();
		}
	}

	////////////////////
	// Result Screen
	///////////////////

	public void showResultScreen()
	{
		ResultMenu.SetActive(true);
		ResultScreen.Ins.setData((int)timer,(int)maxTime);

		SoundFX.Ins.stopBackground(SoundFX.Ins.levelMusic);
		SoundFX.Ins.Play(SoundFX.Ins.levelEndSnd);
	}

	public void checkTime()
	{
		if(Game.currentLevel != Game.LEVEL_1) 
		{ 
			timer -= Time.deltaTime;
		}

		if(timer < 0) 
		{  
			minutes = 0;
        	seconds = 0;
        	hundredths = 0;

			isTimeActive = false;
			gameOver();
		}
		else
		{
			minutes = Mathf.FloorToInt(timer / 60F);
        	seconds = Mathf.FloorToInt(timer - minutes * 60);
			timeSlider.value = timer;
		}
        
        string niceTime = string.Format("{0:00} : {1:00}" , minutes, seconds);

        timeLabel.text = niceTime;
	}

	///////////////
	// GAME OVER
	//////////////

	public void gameOver()
	{
		Time.timeScale = 0;
		GameOverMenu.SetActive(true);
	}

	///////////////
	// LEVEL SETUP
	//////////////
	public void setCountersAmount(int _amount)
	{
		countersAmount = _amount;

		for( int i = 0 ; i < _amount ; ++i )
		{
			countersList[i].SetActive(true);
		}	
	}

	public void setCountersType(int _c1, int _c2 = 1, int _c3 = 1, int _c4 = 1)
	{
		countersList[0].GetComponent<PlantType>().setType(_c1);
		countersList[1].GetComponent<PlantType>().setType(_c2);
		countersList[2].GetComponent<PlantType>().setType(_c3);
		countersList[3].GetComponent<PlantType>().setType(_c4);
	}

	public void setCountersValues(int _val1, int _val2, int _val3, int _val4)
	{
		countersList[0].GetComponent<FlowerCounter>().setMaxValue(_val1);
		countersList[1].GetComponent<FlowerCounter>().setMaxValue(_val2);
		countersList[2].GetComponent<FlowerCounter>().setMaxValue(_val3);
		countersList[3].GetComponent<FlowerCounter>().setMaxValue(_val4);

		totalFlowerNeeded = _val1 + _val2 + _val3 + _val4; 
	}


	public Vector2 getCounterPosition(int _type)
	{
		for( int i = 0 ; i < countersList.Count ; i++ )
		{
			if(countersList[i].GetComponent<PlantType>().getPlantType() == _type) 
			{
				return countersList[i].transform.position;
			}
		}	
		return Vector2.zero;
	}

	public void increaseCounter(int _type)
	{
		for( int i = 0 ; i < countersList.Count ; i++ )
		{
			if(countersList[i].GetComponent<PlantType>().getPlantType() == _type) 
			{
				countersList[i].GetComponent<FlowerCounter>().increaseValue();
			}
		}	
	}

	public void flowerAdded()
	{
		currentFlowers++;

		if(currentFlowers >= totalFlowerNeeded)
		{
			levelComplete();
		}
	}
}
