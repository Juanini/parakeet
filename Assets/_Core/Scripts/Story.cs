using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LoLSDK;
using DG.Tweening;

public class Story : MonoBehaviour {

	public GameObject loading;
	public List<GameObject> storyPanels;

	private int currentPos = 0;

	void Start () 
	{
		LOLSDK.Init("com.catrinaproject.flowershop");
		LOLSDK.Instance.ConfigureSound(0.6f, 0.4f, 0.4f);
		SoundFX.Ins.PlayBackground(SoundFX.Ins.levelSelectMusic);

		showImage();
	}
	
	public void showImage()
	{
		DOTween.ToAlpha(	()=> storyPanels[currentPos].GetComponent<SpriteRenderer>().color, 
							x=> storyPanels[currentPos].GetComponent<SpriteRenderer>().color = x, 1, 2).OnComplete(waitToHide);
	}

	public void waitToHide()
	{
		Invoke("hideImage",1.5f);
	}

	public void hideImage()
	{
		DOTween.ToAlpha(	()=> storyPanels[currentPos].GetComponent<SpriteRenderer>().color, 
							x=> storyPanels[currentPos].GetComponent<SpriteRenderer>().color = x, 0, 2).OnComplete(nextPanel);
	}

	public void nextPanel()
	{
		currentPos++;

		if(currentPos >= storyPanels.Count)
		{
			goToMainMenu();
		}
		else
		{
			showImage();
		}
	}

	public void goToMainMenu()
	{
		loading.SetActive(true);
		SceneManager.LoadScene(Game.S_MAIN_MENU);
	}
}
