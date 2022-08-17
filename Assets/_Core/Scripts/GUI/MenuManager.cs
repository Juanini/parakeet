using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	public enum menusEnum { }

	[HeaderAttribute("Menus")]
	public GameObject pauseMenu;
	public GameObject leaveMenu;
	public GameObject catalogMenu;

	public Text leaveText;

	public int currentOpt = 1;

	public int LEAVE_OPT = 1;
	public int RETRY_OPT = 2;
	
	public void showPauseMenu()
	{	
		SoundFX.Ins.Play(SoundFX.Ins.guiSnd);
		pauseMenu.SetActive(true);
		Time.timeScale = 0;
	}

	public void hidePauseMenu()
	{	
		pauseMenu.SetActive(false);
		Time.timeScale = 1;
	}

	public void showLeaveMenu(int _type)
	{
		leaveMenu.SetActive(true);
		currentOpt = _type;

		if(currentOpt == LEAVE_OPT)
		{
			leaveText.text = TextManager.LEAVE_DEST;
		}
		else if(currentOpt == RETRY_OPT)
		{
			leaveText.text = TextManager.RETRY_DEST;;
		}
	}

	public void onOk()
	{
		if(currentOpt == LEAVE_OPT)
		{
			LevelManager.Ins.goToMainMenu();
		}
		else if(currentOpt == RETRY_OPT)
		{
			LevelManager.Ins.retry();
		}
	}

	public void hideLeaveMenu()
	{
		leaveMenu.SetActive(false);
	}

	public void showCatalog()
	{
		SoundFX.Ins.Play(SoundFX.Ins.pageSound);
		catalogMenu.SetActive(true);
	}
}