using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FlowerCounter : MonoBehaviour {

	public enum typeEn { }
	
	[HeaderAttribute("Elements")]
	public Image flowerImage;
	public Slider mSlider;
	public Text mText;
	public int maxValue = 2;

	private RectTransform mRectTrans;
	private PlantType mPlantType;

	private int mValue = 0;

	private Vector3 punchAmount;
	private float punchValue = 0.8f;


	void Awake () 
	{
		mRectTrans = GetComponent<RectTransform>();
		mPlantType = GetComponent<PlantType>();
		punchAmount = new Vector3(punchValue,punchValue,punchValue);
	}

	public Vector2 getPosition()
	{
		return mRectTrans.transform.position;
	}

	public void setValue(int _val)
	{
		mValue = _val;
	}

	public void setMaxValue(int _val)
	{
		mSlider.maxValue = _val;
		maxValue = _val;
		mText.text = mValue + " / " + maxValue;
	}

	public void increaseValue()
	{
		SoundFX.Ins.Play(SoundFX.Ins.plantAdded);

		mValue ++;
		mSlider.value = mValue;
		mText.text = mValue + " / " + maxValue;

		//mRectTrans.transform.localScale = new Vector3(1,1,1);
		mRectTrans.DOComplete(gameObject);
		mRectTrans.DOPunchScale(punchAmount, 0.5f,0,0).OnComplete(reportIncrement);
	}

	public void reportIncrement()
	{
		LevelManager.Ins.flowerAdded();
	}
}
