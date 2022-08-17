using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantType : MonoBehaviour {

	public enum typeEnum {
		beeType = 1,
		hummingbirdType,
		flyType,
		batType,
		hermitType,
		squirrelType,
		windType
	}

	[HeaderAttribute("Image")]
	public bool isGUI = false;
	public SpriteRenderer mSpriteR;
	public Image mImage;

	[HeaderAttribute("Images References")]
	public List<Sprite> imagesList;

	public typeEnum plantType;

	void Start()
	{
		setType((int)plantType);
	}

	public void setType(int _type)
	{
		plantType = (typeEnum)_type;
		setPlantImage();
		setPropertiesByType();

		if(GetComponent<Plant>())
			GetComponent<Plant>().setUpIcons();
	}

	public void setPlantImage()
	{
		if(!isGUI)
		{
			mSpriteR.sprite = imagesList[ (int)plantType - 1];
		}
		else
		{
			mImage.overrideSprite = imagesList[(int)plantType - 1];
		}
	}

	public int getPlantType()
	{
		return (int)plantType;
	}

	public void setPropertiesByType()
	{
		Properties mProps;
		mProps = GetComponent<Properties>();

		if(!mProps) { return; }

		switch((int)plantType)
		{
			case Game.TYPE_BEE: 
			mProps.setProperties(	Game.COLOR_YELLOW,
									Game.NECTAR_PRESENT,
									Game.ODOR_FRESH,
									Game.SHAPE_LANDING);
			break;

			case Game.TYPE_HUMMING: 
			mProps.setProperties(	Game.COLOR_RED,
									Game.NECTAR_HIDDEN,
									Game.ODOR_NONE,
									Game.SHAPE_TUBULAR);
			break;
			
			case Game.TYPE_FLY: 
			mProps.setProperties(	Game.COLOR_DARK,
									Game.NECTAR_NONE,
									Game.ODOR_PUTRID,
									Game.SHAPE_TRAP);
			break;

			case Game.TYPE_BAT: 
			mProps.setProperties(	Game.COLOR_LIGHT,
									Game.NECTAR_ABUNDANT_HIDDEN,
									Game.ODOR_FRUITSY,
									Game.SHAPE_BOWL);
			break;

			case Game.TYPE_HERMIT: 
			mProps.isHermmit = true;
			break;

			case Game.TYPE_SQUIRREL: 
			mProps.isSquirrel = true;
			break;

			case Game.TYPE_WIND: 
			mProps.isWind = true;
			break;
		}
	}
}
