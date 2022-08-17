using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatalogInfo : MonoBehaviour {

	public static CatalogInfo Ins;

	[HeaderAttribute("Main Panel")]
	public Image panelImage;

	[HeaderAttribute("Elements")]
	public List<Transform> animalButtons;
	public List<Transform> plantButtons;
	public List<Sprite> spritesList;

	[HeaderAttribute("Cursors")]
	public Transform plantCursor;
	public Transform animalCursor;

	public int currentPos = 1;

	void Awake () 
	{
		Ins = this;	
	}
	
	void Start () 
	{
		selectItem(1);
	}

	void OnEnable()
	{
		Time.timeScale = 0;

		if(Game.currentLevel == Game.LEVEL_2 &&
			Tutorial.Ins.isTutoActive)
		{
			Tutorial.Ins.clickOnCat();
		}
	}

	public void hideCatalog()
	{
		Time.timeScale = 1;
		SoundFX.Ins.Play(SoundFX.Ins.pageSound);
		gameObject.SetActive(false);


		if(Game.currentLevel == Game.LEVEL_2 &&
			Tutorial.Ins.isTutoActive)
		{
			Tutorial.Ins.tutoLvl2End();
		}
	}

	public void selectItem(int _pos)
	{
		plantCursor.position = plantButtons[_pos -1 ].position;
		animalCursor.position = animalButtons[_pos - 1].position;

		panelImage.overrideSprite = spritesList[_pos - 1];
	}
}
