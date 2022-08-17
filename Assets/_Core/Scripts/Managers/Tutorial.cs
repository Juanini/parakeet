using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

	public static Tutorial Ins;

	public GameObject plantA;
	public GameObject plantB;

	[HeaderAttribute("Elements")]
	public Button pollinatorsBttn;
	public Button infoBttn;
	public Button catalogBttn;
	public Button pauseBttn;
	public Button closePickerBttn;
	public GameObject plantsTutoA;
	public GameObject plantsTutoB;
	public GameObject beeSelTuto;
	

	[HeaderAttribute("panelPhases")]
	public GameObject dialogA;
	public GameObject dialogB;
	public GameObject dialogC;
	public GameObject dialogD;
	public GameObject dialogE;

	[HeaderAttribute("State")]
	public bool isTutoActive = false;

	[HeaderAttribute("panelPhases")]
	public List<GameObject> phasesList;

	[HeaderAttribute("Sub Phases")]
	public GameObject subPhase4_A;
	public GameObject subPhase4_B;
	public GameObject selectMark;
	public GameObject subPhase5_A;
	public GameObject subPhase5_B;
	public GameObject subPhase6_B;

	[HeaderAttribute("Tuto Levels")]
	public GameObject tutoLevel2;
	public GameObject tutoLevel5;
	public GameObject tutoLevel5_Btnn;
	public GameObject tutoLevel7;
	public GameObject tutoLevel7_Btnn;
	

	private enum tutoPhaseEn { phaseA = 1, phaseB, phaseC, phaseD, phaseE}
	private int currentPhade = -1;

	private bool canContinue = true;

	public Button nextButton;

	private bool flowerShowed = false;

	void Awake()
	{
		Ins = this;
	}
	
	void Start () 
	{
		if(Game.currentLevel == Game.LEVEL_1)
		{
			pollinatorsBttn.gameObject.SetActive(false);
			blockButtonsForTuto();

			isTutoActive = true;
			nextButton.gameObject.SetActive(true);
			nextState();

			plantsTutoA.GetComponent<BoxCollider2D>().enabled = false;
			plantsTutoB.GetComponent<BoxCollider2D>().enabled = false;
			//dialogA.SetActive(true);
		}
		else if(Game.currentLevel == Game.LEVEL_2)
		{
			isTutoActive = true;
			blockButtonsForTuto();
			tutoLevel2.SetActive(true);
			catalogBttn.interactable 		= true;
		}	
		else if(Game.currentLevel == Game.LEVEL_5)
		{
			isTutoActive = true;
			blockButtonsForTuto();
			tutoLevel5.SetActive(true);
			tutoLevel5_Btnn.SetActive(true);
			pollinatorsBttn.gameObject.SetActive(false);
		}	
		else if(Game.currentLevel == Game.LEVEL_7)
		{
			isTutoActive = true;
			blockButtonsForTuto();
			tutoLevel7.SetActive(true);
			tutoLevel7_Btnn.SetActive(true);
			pollinatorsBttn.gameObject.SetActive(false);
		}	
	}

	public void blockButtonsForTuto()
	{
		pollinatorsBttn.interactable 	= false;
		catalogBttn.interactable 		= false;
		pauseBttn.interactable 			= false;
		closePickerBttn.interactable 	= false;
	}

	public void unlockButtonsForTuto()
	{
		pollinatorsBttn.interactable 	= true;
		catalogBttn.interactable 		= true;
		pauseBttn.interactable 			= true;
		closePickerBttn.interactable 	= true;
	}

	//LEVEL 2
	public void clickOnCat()
	{
		tutoLevel2.SetActive(false);
	}

	public void tutoLvl2End()
	{
		isTutoActive = false;
		unlockButtonsForTuto();
	}

	//LEVEL 5
	public void tutoLvl5End()
	{
		isTutoActive = false;
		unlockButtonsForTuto();
		tutoLevel5.SetActive(false);
		tutoLevel5_Btnn.SetActive(false);
		pollinatorsBttn.gameObject.SetActive(true);
	}

	//LEVEL 5
	public void tutoLvl7End()
	{
		isTutoActive = false;
		unlockButtonsForTuto();
		tutoLevel7.SetActive(false);
		tutoLevel7_Btnn.SetActive(false);
		pollinatorsBttn.gameObject.SetActive(true);
	}

	void Update()
	{
		if(!isTutoActive) { return; }

	}

	public void nextState()
	{
		if(!canContinue) { return; }
		SoundFX.Ins.Play(SoundFX.Ins.guiSnd);

		for(int i = 0 ; i < phasesList.Count ; i++)
		{
			phasesList[i].SetActive(false);
		}
		
		currentPhade ++;
		
		if(currentPhade < phasesList.Count)
			phasesList[currentPhade].SetActive(true);

		checkSpecialPhase();
	}

	public void checkSpecialPhase()
	{
		if(currentPhade == 2)
		{
			plantA.SetActive(true);
			plantB.SetActive(true);
			return;
		}
		else if(currentPhade == 3)
		{
			nextButton.gameObject.SetActive(false);
			pollinatorsBttn.interactable = true;
			pollinatorsBttn.gameObject.SetActive(true);
			subPhase4_A.SetActive(true);
			return;
		}
		else if(currentPhade == 4)
		{
			plantsTutoA.GetComponent<BoxCollider2D>().enabled = true;
			subPhase5_A.SetActive(true);
			nextButton.gameObject.SetActive(false);
			return;
		}
		else if(currentPhade == 5)
		{
			plantsTutoA.GetComponent<BoxCollider2D>().enabled = false;
			plantsTutoB.GetComponent<BoxCollider2D>().enabled = true;
			nextButton.gameObject.SetActive(false);
			return;
		}

		//nextButton.gameObject.SetActive(true);
	}

	public void initPhaseB()
	{
	}

	// CLICK ON POLLINATOORS BUTTON
	public void initPhaseC()
	{
		pollinatorsBttn.interactable 	= false;
		subPhase4_A.SetActive(false);
		subPhase4_B.SetActive(true);
		selectMark.SetActive(true);
	}

	// CLICK ON SELECT FRIEND
	public void initPhaseD()
	{
		subPhase4_A.SetActive(false);
		subPhase4_B.SetActive(false);
		selectMark.SetActive(false);
		nextState();
	}

	// Go to Female Plant 
	public void initPhaseE()
	{
		if(flowerShowed) { return; }

		flowerShowed = true;
		nextState();
		Invoke("showCollectFlowers",1.5f);
	}

	public void showCollectFlowers()
	{
		nextState();
	}

	public void initPhaseGoToMaleF()
	{
		subPhase5_A.SetActive(false);
		subPhase5_B.SetActive(true);
	}

	public void initPhaseGoToFemaleF()
	{
		nextState();
	}

	public void initPhaseG()
	{
		dialogD.SetActive(false);
	}

	public void tutoEnd()
	{
		isTutoActive = false;

		for(int i = 0 ; i < phasesList.Count ; i++)
		{
			phasesList[i].SetActive(false);
		}
	}

}
