using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour {

	public bool isUnlocked = false;	
	
	[RangeAttribute(1,8)]
	public int levelNum = 1;

	[HeaderAttribute("Button Elements")]
	public GameObject lockImg;
	public GameObject buttonElements;

	[HeaderAttribute("Stars")]
	public List<Image> stars;
	public Sprite starOnSprt;

	public Image numberImage;
	public List<Sprite> numbersList;
	
	private Button mButton;

	void Awake()
	{
		mButton = GetComponent<Button>();
	}

	void Start () 
	{
		checkLock();
		checkState();
		numberImage.overrideSprite = numbersList[levelNum - 1];
		setStars();
	}

	public void play()
	{
		Game.currentLevel = levelNum;

		MainMenuManager.Ins.loadingGui.SetActive(true);
		
		SoundFX.Ins.stopBackground(SoundFX.Ins.levelSelectMusic);
		SceneManager.LoadScene(Game.S_GAME);
	}

	public void checkState()
	{
		mButton.interactable = isUnlocked;
		lockImg.SetActive(!isUnlocked);
		buttonElements.SetActive(isUnlocked);	
	}

	public void setStars()
	{
		int totalStars = 0;

		switch (levelNum)
		{
			case Game.LEVEL_1: totalStars = Game.STARS_LEVEL_1; break;	
			case Game.LEVEL_2: totalStars = Game.STARS_LEVEL_2; break;	
			case Game.LEVEL_3: totalStars = Game.STARS_LEVEL_3; break;	
			case Game.LEVEL_4: totalStars = Game.STARS_LEVEL_4; break;	
			case Game.LEVEL_5: totalStars = Game.STARS_LEVEL_5; break;	
			case Game.LEVEL_6: totalStars = Game.STARS_LEVEL_6; break;	
			case Game.LEVEL_7: totalStars = Game.STARS_LEVEL_7; break;	
			case Game.LEVEL_8: totalStars = Game.STARS_LEVEL_8; break;	
		}

		for (int i = 0; i < totalStars; i++)
		{
			stars[i].overrideSprite = starOnSprt;
		}
	}

	public void checkLock()
	{
		switch (levelNum)
		{
			case 1: isUnlocked = Game.UNLOCKED_LEVEL_1; break;
			case 2: isUnlocked = Game.UNLOCKED_LEVEL_2; break;
			case 3: isUnlocked = Game.UNLOCKED_LEVEL_3; break;
			case 4: isUnlocked = Game.UNLOCKED_LEVEL_4; break;
			case 5: isUnlocked = Game.UNLOCKED_LEVEL_5; break;
			case 6: isUnlocked = Game.UNLOCKED_LEVEL_6; break;
			case 7: isUnlocked = Game.UNLOCKED_LEVEL_7; break;
			case 8: isUnlocked = Game.UNLOCKED_LEVEL_8; break;
			
		}
	}
}
