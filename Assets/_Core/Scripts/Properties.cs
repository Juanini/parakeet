using UnityEngine;

public class Properties : MonoBehaviour {

	public enum colorEnum 	{ Yellow 	= 1, Red, 		Light, 				Dark,		Zero}
	public enum nectarEnum 	{ Present 	= 1, Hidden, 	Abundant_Hidden, 	None, 		Zero}
	public enum odorEnum 	{ Fresh  	= 1, None, 		Fruitsy, 			Putrid, 	Zero}	
	public enum shapeEnum 	{ Landing 	= 1, Tubular, 	Bowl, 				Traplike, 	Zero}
	
	
	[HeaderAttribute("Color")]
	public colorEnum mColor;

	[HeaderAttribute("Nectar")]
	public nectarEnum mNectar;

	[HeaderAttribute("Odor")]
	public odorEnum mOdor;

	[HeaderAttribute("Shape")]
	public shapeEnum mShape;

	[SpaceAttribute(20)]
	public bool isHermmit;
	public bool isSquirrel;
	public bool isWind;
	
	public bool isPropertiesMatch(Properties _otherProps)
	{
		if(isHermmit && !_otherProps.isHermmit) 	{ return false; }
		if(isSquirrel && !_otherProps.isSquirrel) 	{ return false; }
		if(isWind && !_otherProps.isWind) 			{ return false; }

		if(isHermmit || isSquirrel || isWind) { return true; }

		if((int)mColor != (int)_otherProps.mColor) 		{ return false; }

		if((int)mNectar != (int)_otherProps.mNectar) 	{ return false; }

		if((int)mOdor != (int)_otherProps.mOdor) 		{ return false; }

		if((int)mShape != (int)_otherProps.mShape) 		{ return false; }
		
		return true;
	}

	public void setProperties(int _color, int _nectar, int _odor, int _shape)
	{
		mColor 	= (colorEnum)_color;
		mNectar = (nectarEnum)_nectar;
		mOdor 	= (odorEnum)_odor;
		mShape 	= (shapeEnum)_shape;

		isHermmit = isSquirrel = isWind = false;
	}
}
