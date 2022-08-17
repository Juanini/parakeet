using UnityEngine;
using UnityEngine.UI;

public class FriendButton : MonoBehaviour {

	public enum idEnum { Bee = 1 , Hummingbird, Fly, Bat, Hermit, Squirrel, Wind }

	[HeaderAttribute("Character Type")]
	public idEnum type;

	[HeaderAttribute("Called Sprite")]
	public Sprite blackSpr;

	[HeaderAttribute("Called Sound")]
	public string calledSnd;

	[HeaderAttribute("Pollinator Image")]
	public Image img;

	[HeaderAttribute("Panel Info Position")]
	public RectTransform infoPos;
	public RectTransform cursor;
	public RectTransform arrowPos;
	
	private bool isActive = false;

	public void callFriend()
	{
		if(!isActive)
		{
			isActive = true;
			//img.overrideSprite = blackSpr;
			SoundFX.Ins.Play(calledSnd);
			selectPollinator();
		}
		else
		{
			returnFriend();
			//img.overrideSprite = null;
		}
	}

	public void returnFriend()
	{

	}

	public void onButtonClick()
	{
		Game.currentCharacter = (int)type;
		FriendsPicker.Ins.setSelected(gameObject);
		cursor.transform.position = arrowPos.transform.position;
		SoundFX.Ins.Play(SoundFX.Ins.charSel);
	}

	public void setUpCharPos()
	{
		
	}

	public void selectPollinator()
	{
		AnimalRef.Ins.spawnPollinator();
	}

	public void setLocked()
	{
		img.overrideSprite = blackSpr;
		GetComponent<Button>().interactable = false;
	}

	public void setUnlocked()
	{
		img.overrideSprite = null;
		GetComponent<Button>().interactable = true;
	}
}
