using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour {

	public static InfoPanel Ins;

	public GameObject fruitImg;
	public GameObject panel;

	[HeaderAttribute("Info icons")]
	public GameObject selBttn;
	public Image nameText;

	[HeaderAttribute("Info icons")]
	public Image colorImg;
	public Image nectarImg;
	public Image odorImg;
	public Image shapeImg;

	[HeaderAttribute("Color Sprites")]
	public Sprite colorYellow;
	public Sprite colorRed;
	public Sprite colorLight;
	public Sprite colorDark;

	[HeaderAttribute("Nectar Sprites")]
	public Sprite nectarPresent;
	public Sprite nectarHidden;
	public Sprite nectarAbundant_Hidden;
	public Sprite nectarNone;

	[HeaderAttribute("Odor Sprites")]
	public Sprite odorFresh;
	public Sprite odorNone;
	public Sprite odorFruitsy;
	public Sprite odorPutrid;

	[HeaderAttribute("Shape Sprites")]
	public Sprite shapeLanding;
	public Sprite shapeTubular;
	public Sprite shapeBowl;
	public Sprite shapeTraplike;

	[HeaderAttribute("Fruit Sprites")]
	public Sprite berriSpr;
	public Sprite acornSpr;
	public Sprite liliSpr;

	[HeaderAttribute("Res Pos")]
	public Transform idlePos;

	[HeaderAttribute("Name Sprites")]
	public Sprite beeName;
	public Sprite humName;
	public Sprite flyName;
	public Sprite batName;
	public Sprite hermmitName;
	public Sprite squirrelName;
	public Sprite windName;
	
	private RectTransform mRect;
	void Awake () 
	{
		Ins = this;
		mRect = GetComponent<RectTransform>();
	}

	void Start () 
	{
		
	}
	
	void Update () 
	{
		
	}

	public void callFriend () 
	{
		FriendsPicker.Ins.hidePicker();
		FriendsPicker.Ins.currentCharacter.GetComponent<FriendButton>().callFriend();
		setIdle();

		if(Game.currentLevel == Game.LEVEL_1 &&
			Tutorial.Ins.isTutoActive)
		{
			Tutorial.Ins.initPhaseD();
		}
	}

	public void setIdle()
	{
		goToPos(idlePos.position);
		showSelectBttn(false);
	}

	public void goToPos(Vector2 _pos)
	{
		mRect.transform.position = _pos;
	}

	public void showSelectBttn(bool _show)
	{
		selBttn.SetActive(_show);
		nameText.gameObject.SetActive(!_show);
	}

	public void setUpInfo()
	{
		switch(Game.currentCharacter)
		{
			case Game.TYPE_BEE:
			panel.SetActive(true);
			fruitImg.SetActive(false);

			colorImg.overrideSprite 	= colorYellow;
			nectarImg.overrideSprite 	= nectarPresent;
			odorImg.overrideSprite 		= odorFresh;
			shapeImg.overrideSprite 	= shapeLanding;

			nameText.overrideSprite = beeName;
			break;

			case Game.TYPE_HUMMING:
			panel.SetActive(true);
			fruitImg.SetActive(false);

			colorImg.overrideSprite 	= colorRed;
			nectarImg.overrideSprite 	= nectarHidden;
			odorImg.overrideSprite 		= odorNone;
			shapeImg.overrideSprite 	= shapeTubular;

			nameText.overrideSprite = humName;			
			break;

			case Game.TYPE_FLY:
			panel.SetActive(true);
			fruitImg.SetActive(false);

			colorImg.overrideSprite 	= colorDark;
			nectarImg.overrideSprite 	= nectarNone;
			odorImg.overrideSprite 		= odorPutrid;
			shapeImg.overrideSprite 	= shapeTraplike;

			nameText.overrideSprite = flyName;			
			break;

			case Game.TYPE_BAT:
			panel.SetActive(true);
			fruitImg.SetActive(false);

			colorImg.overrideSprite 	= colorLight;
			nectarImg.overrideSprite 	= nectarAbundant_Hidden;
			odorImg.overrideSprite 		= odorFruitsy;
			shapeImg.overrideSprite 	= shapeBowl;

			nameText.overrideSprite = batName;
			break;

			case Game.TYPE_HERMIT:
			panel.SetActive(false);
			fruitImg.SetActive(true);

			fruitImg.GetComponent<Image>().overrideSprite = berriSpr;

			nameText.overrideSprite = hermmitName;
			break;

			case Game.TYPE_SQUIRREL:
			panel.SetActive(false);
			fruitImg.SetActive(true);
			fruitImg.GetComponent<Image>().overrideSprite = acornSpr;

			nameText.overrideSprite = squirrelName;
			break;

			case Game.TYPE_WIND:
			panel.SetActive(false);
			fruitImg.SetActive(true);
			
			fruitImg.GetComponent<Image>().overrideSprite = liliSpr;

			nameText.overrideSprite = windName;
			break;
		}
	}
}
