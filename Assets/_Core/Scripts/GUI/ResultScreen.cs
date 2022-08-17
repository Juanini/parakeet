using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using LoLSDK;

public class ResultScreen : MonoBehaviour {

	public static ResultScreen Ins;

	public Text timeText;
	public Text scoreText;

	private int timeMax;
	public int timeLeft;

	private int starsEarned;

	private int timePortion;

	[HeaderAttribute("Stars")]
	public Sprite starOn;	
	public GameObject star1;
	public GameObject star2;
	public GameObject star3;

	public Button continueButton;

	private int starIter = 1;

	private Vector3 punchAmount;
	private float punchValue = 0.8f;

	void Awake()
	{
		Ins = this;
		punchAmount = new Vector3(punchValue,punchValue,punchValue);
	}

	public void setData(int _timeLeft, int _timeMax)
	{
		timeLeft = _timeLeft;
		timeMax = _timeMax;

		timePortion = timeMax / 3;

		if(timeLeft >= (timeMax - timePortion))
		{
			starsEarned = 3;
		} 
		else if(timeLeft >= (timeMax - timePortion * 2))
		{
			starsEarned = 2;
		}
		else if(timeLeft >= (timeMax - timePortion * 3))
		{
			starsEarned = 1;
		}

		setLevelStars();

		Invoke("showTime",0.5f);
	}

	public void setStarA()
	{
		if(starsEarned >= 1)
		{
			SoundFX.Ins.Play(SoundFX.Ins.starSnd);
			star1.GetComponent<Image>().overrideSprite = starOn;
		}
		star1.transform.DOPunchScale(punchAmount, 0.5f,0,0).OnComplete(setStarB);
	}

	public void setStarB()
	{
		if(starsEarned >= 2)
		{
			SoundFX.Ins.Play(SoundFX.Ins.starSnd);
			star2.GetComponent<Image>().overrideSprite = starOn;
		}

		star2.transform.DOPunchScale(punchAmount, 0.5f,0,0).OnComplete(setStarC);
	}

	public void setStarC()
	{
		if(starsEarned >= 3)
		{
			SoundFX.Ins.Play(SoundFX.Ins.starSnd);
			star3.GetComponent<Image>().overrideSprite = starOn;
		}

		star3.transform.DOPunchScale(punchAmount, 0.5f,0,0).OnComplete(enableButton);
	}

	public void enableButton()
	{
		continueButton.interactable = true;
	}

	public void showScore()
	{
		SoundFX.Ins.Play(SoundFX.Ins.guiSnd);
		int resultScore;
		
		resultScore = (100 * starsEarned) * Game.currentLevel;
		Game.SCORE += resultScore;

		LOLSDK.Instance.SubmitProgress(0, resultScore, 99999);

		scoreText.text  = "<color=orange>" + resultScore + " points" + "</color>";

		Invoke("setStarA",0.5f);
	}

	public void showTime()
	{
		SoundFX.Ins.Play(SoundFX.Ins.guiSnd);

		int minutes = Mathf.FloorToInt(timeLeft / 60F);
        int seconds = Mathf.FloorToInt(timeLeft - minutes * 60);

		string niceTime = string.Format("{0:00} : {1:00}" , minutes, seconds);

        timeText.text = "<color=orange>" + niceTime + "</color>";

		Invoke("showScore",0.5f);
	}

	public void setLevelStars()
	{
		switch (Game.currentLevel)
		{
			case Game.LEVEL_1: Game.STARS_LEVEL_1 = starsEarned; break;
			case Game.LEVEL_2: Game.STARS_LEVEL_2 = starsEarned; break;
			case Game.LEVEL_3: Game.STARS_LEVEL_3 = starsEarned; break;
			case Game.LEVEL_4: Game.STARS_LEVEL_4 = starsEarned; break;
			case Game.LEVEL_5: Game.STARS_LEVEL_5 = starsEarned; break;
			case Game.LEVEL_6: Game.STARS_LEVEL_6 = starsEarned; break;
			case Game.LEVEL_7: Game.STARS_LEVEL_7 = starsEarned; break;
			case Game.LEVEL_8: Game.STARS_LEVEL_8 = starsEarned; break;
		}

		switch (Game.currentLevel)
		{
			case 1: Game.UNLOCKED_LEVEL_2 = true; break;
			case 2: Game.UNLOCKED_LEVEL_3 = true; break;
			case 3: Game.UNLOCKED_LEVEL_4 = true; break;
			case 4: Game.UNLOCKED_LEVEL_5 = true; break;
			case 5: Game.UNLOCKED_LEVEL_6 = true; break;
			case 6: Game.UNLOCKED_LEVEL_7 = true; break;
			case 7: Game.UNLOCKED_LEVEL_8 = true; break;
			case 8: Game.UNLOCKED_LEVEL_8 = true; break;
			
		}
	}
}
