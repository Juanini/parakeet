using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Animal : MonoBehaviour {

	public GameObject nopeExp;

	[HeaderAttribute("Pollen Bar")]
	public GameObject pollenBar;
	public List<GameObject> pollenBlocks;
	private int MAX_POLLEN = 4;
	private int pollenBarIndex = 0;

	private AnimalMovement mAnMovement;
	private Properties mProperties;

	private Plant currentPlant;
	private Vector3 punchAmount;

	public bool canBeSelected = true;
	public bool isMoving = false;

	[SpaceAttribute(35)]
	public bool isSquirrel = false;

	void Awake () 
	{
		mAnMovement = GetComponent<AnimalMovement>();
		mProperties = GetComponent<Properties>();

		punchAmount = new Vector3(1.2f,1.2f,1.2f);
	}

	public void spawn()
	{
		mAnMovement.spawn();
		//SelectionManager.Ins.setSelection(gameObject);
	}

	void OnTriggerEnter2D(Collider2D _col)
	{
		if(_col.gameObject.tag == "Plant")
		{
			if(!canBeSelected) { return; }

			Plant plant = _col.GetComponent<Plant>();
			currentPlant = plant;

			if(PlantSelectionMngr.Ins.getCurrentSelected() != _col.gameObject) { return; }

			if(mProperties.isPropertiesMatch(_col.GetComponent<Properties>()))
			{
				if(currentPlant.isMale)
				{
					canBeSelected = false;
				}

				plant.onMatchSucces();
				mAnMovement.moveOnPath(plant.getAroundPath());
			}
			else
			{
				mAnMovement.moveOnFailMatch(plant.pistilPos.position);
				canBeSelected = true;
				isMoving = false;
			}
		}
	}

	//Show expression
	public void showFailExpression()
	{
		nopeExp.SetActive(true);
		Invoke("hideFailExpression",2);
	}

	public void hideFailExpression()
	{
		nopeExp.SetActive(false);
	}

	//Pollen Bar
	public void onPathComplete()
	{
		if(currentPlant.isFemale)
		{
			emptyPollenBar();
		}
		else if(currentPlant.isMale)
		{
			startPollenBar();
		}
		else if(currentPlant.isMaleAndFemale)
		{
			canBeSelected = true;
			currentPlant.pollinate();
		}
	}

	public void startPollenBar()
	{
		InvokeRepeating("addPollenBlock",0,0.5f);
	}

	public void emptyPollenBar()
	{
		if(pollenBarIndex <= 0) 
		{
			PlantSelectionMngr.Ins.setSelection(null);
			return; 
		}
		InvokeRepeating("removePollenBlock",0,0.5f);
	}

	public void addPollenBlock()
	{
		SoundFX.Ins.Play(SoundFX.Ins.pollenAdded);
		pollenBlocks[pollenBarIndex].SetActive(true);
		pollenBar.transform.DOPunchScale(punchAmount,0.5f,0,0);
		pollenBarIndex++;

		if(pollenBarIndex >= MAX_POLLEN) 
		{
			pollenBarIndex = MAX_POLLEN - 1;
			CancelInvoke("addPollenBlock");
			canBeSelected = true;
			isMoving = false;

			if(	currentPlant.GetComponent<Properties>().isSquirrel || 
				currentPlant.GetComponent<Properties>().isHermmit)
			currentPlant.dissmissPlant();

			if(Game.currentLevel == Game.LEVEL_1 &&
			Tutorial.Ins.isTutoActive)
			{
				Tutorial.Ins.initPhaseGoToFemaleF();
			}
			return;
		}
	}

	public void removePollenBlock()
	{
		SoundFX.Ins.Play(SoundFX.Ins.pollenRemoved);
		
		pollenBlocks[pollenBarIndex].SetActive(false);
		pollenBar.transform.DOPunchScale(punchAmount,0.5f,0,0);
		pollenBarIndex--;

		if(mProperties.isSquirrel || mProperties.isHermmit) { return; }

		if(pollenBarIndex < 0) 
		{
			canBeSelected = true;
			pollenBarIndex = 0;
			CancelInvoke("removePollenBlock");
			currentPlant.pollinate();
			return;
		}
	}

	public int getCurrentPollen()
	{
		return pollenBarIndex;
	}
}
