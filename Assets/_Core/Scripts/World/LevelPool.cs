using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPool : MonoBehaviour {

	public static LevelPool Ins;

	[HeaderAttribute("Levels")]
	public List<GameObject> levelList;

	private Level mLevel;

	void Awake () 
	{
		Ins = this;
	}

	void Start () 
	{
		levelList[ Game.currentLevel - 1 ].SetActive(true);
		mLevel = levelList[ Game.currentLevel - 1 ].GetComponent<Level>();
		mLevel.getLevelPlants();
	}

	public void turnOnPlantIcons()
	{
		mLevel.turnOnPlantIcons();
	}

	public void turnOnPlantIconsAndOff()
	{
		turnOnPlantIcons();
		Invoke("turnOffPlantIcons",5);
	}

	public void turnOffPlantIcons()
	{
		mLevel.turnOffPlantIcons();
	}

	public void setCountersType()
	{
		switch (Game.currentLevel)
		{
			case Game.LEVEL_1: 
			LevelManager.Ins.setTimer(60 * 2);
			LevelManager.Ins.setCountersAmount(1);
			LevelManager.Ins.setCountersValues(2,0,0,0);
			LevelManager.Ins.setCountersType(Game.TYPE_BEE); 
			break;
			
			case Game.LEVEL_2: 
			LevelManager.Ins.setTimer(60 * 2);
			LevelManager.Ins.setCountersAmount(2);
			LevelManager.Ins.setCountersValues(2,2,0,0);
			LevelManager.Ins.setCountersType(Game.TYPE_BEE,Game.TYPE_HUMMING); 
			break;

			case Game.LEVEL_3: 
			LevelManager.Ins.setTimer(60 * 3);
			LevelManager.Ins.setCountersAmount(3);
			LevelManager.Ins.setCountersValues(4,4,4,0);
			LevelManager.Ins.setCountersType(Game.TYPE_BEE,Game.TYPE_HUMMING, Game.TYPE_FLY);  
			break;

			case Game.LEVEL_4: 
			LevelManager.Ins.setTimer(60 * 3);
			LevelManager.Ins.setCountersAmount(4);
			LevelManager.Ins.setCountersValues(2,2,2,2);
			LevelManager.Ins.setCountersType(Game.TYPE_BEE,Game.TYPE_HUMMING, Game.TYPE_FLY, Game.TYPE_BAT); 
			 break;

			//Hermit Level
			case Game.LEVEL_6: 
			LevelManager.Ins.setTimer(60 * 3);
			LevelManager.Ins.setCountersAmount(1);
			LevelManager.Ins.setCountersValues(8,0,0,0);
			LevelManager.Ins.setCountersType(Game.TYPE_HERMIT); 
			break;

			case Game.LEVEL_5: 
			LevelManager.Ins.setTimer(60 * 2);
			LevelManager.Ins.setCountersAmount(1);
			LevelManager.Ins.setCountersValues(3,0,0,0);
			LevelManager.Ins.setCountersType(Game.TYPE_SQUIRREL); 
			break;

			//Wind Level
			case Game.LEVEL_7: 
			LevelManager.Ins.setTimer(60 * 4);
			LevelManager.Ins.setCountersAmount(1);
			LevelManager.Ins.setCountersValues(16,0,0,0);
			LevelManager.Ins.setCountersType(Game.TYPE_WIND); 
			break;

			case Game.LEVEL_8: 
			LevelManager.Ins.setTimer(60 * 5);
			LevelManager.Ins.setCountersAmount(4);
			LevelManager.Ins.setCountersValues(2,2,4,4);
			LevelManager.Ins.setCountersType(Game.TYPE_WIND, Game.TYPE_BEE, Game.TYPE_HUMMING, Game.TYPE_BAT); 
			break;
		}
	}
}
