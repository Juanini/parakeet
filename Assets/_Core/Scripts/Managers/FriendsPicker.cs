using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class FriendsPicker : MonoBehaviour {

	public static FriendsPicker Ins;

	[HeaderAttribute("Call-Info Container")]
	public GameObject infoMenu;

	[HeaderAttribute("Friends Container")]
	public GameObject friendsPickerMenu;
	public GameObject currentCharacter;

	[SpaceAttribute(20)]
	public FriendButton initButton;

	[HeaderAttribute("Friends Buttons")]
	public List<FriendButton> friendsButtons;

	void Awake () 
	{
		Ins = this;
		hideInfoPanel();
	}

	void Start()
	{
		for(int i = Game.currentLevel ; i < friendsButtons.Count ; i++)
		{
			friendsButtons[i].setLocked();
		}

		if(Game.currentLevel == Game.LEVEL_5)
		{
			friendsButtons[5].setUnlocked();
		}
	}
	
	void Update () 
	{
		
	}

	public void hideInfoPanel()
	{
		friendsPickerMenu.SetActive(false);
	}

	public void showPicker()
	{
		LevelPool.Ins.turnOnPlantIcons();

		if(Game.currentLevel == Game.LEVEL_1 &&
			Tutorial.Ins.isTutoActive)
		{
			Tutorial.Ins.initPhaseC();
		}

		infoMenu.SetActive(false);
		friendsPickerMenu.SetActive(true);

		initButton.onButtonClick();
	}

	public void hidePicker()
	{
		LevelPool.Ins.turnOffPlantIcons();

		infoMenu.SetActive(true);
		friendsPickerMenu.SetActive(false);
		InfoPanel.Ins.setIdle();
	}

	public void setSelected(GameObject _obj)
	{
		currentCharacter = _obj;
		InfoPanel.Ins.setUpInfo();
		InfoPanel.Ins.goToPos(_obj.GetComponent<FriendButton>().infoPos.transform.position);
		InfoPanel.Ins.showSelectBttn(true);
	}

	public void setLevelButtons(bool l1)
	{
		
	}
}
