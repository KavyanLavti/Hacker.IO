using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Image_zoomIN_zoomOUT : MonoBehaviour
{

	RectTransform Image_rectTransform;

	float touchesPrevPosDifference, touchesCurPosDifference, zoomModifier;

	Vector2 firstTouchPrevPos, secondTouchPrevPos;
	Vector3 UnitVector;

	[SerializeField]
	float zoomModifierSpeed = 0.01f;
	public float MaxZoom, MinZoom;
	Vector3 scale;

	
	// Use this for initialization
	void Start()
	{
		Image_rectTransform = GetComponent<RectTransform>();
		UnitVector = new Vector3(1,1,1).normalized;
		scale = Image_rectTransform.localScale;
	}

	// Update is called once per frame
	void Update()
	{

		if (Input.touchCount == 2)
		{
			Touch firstTouch = Input.GetTouch(0);
			Touch secondTouch = Input.GetTouch(1);

			firstTouchPrevPos = firstTouch.position - firstTouch.deltaPosition;
			secondTouchPrevPos = secondTouch.position - secondTouch.deltaPosition;

			touchesPrevPosDifference = (firstTouchPrevPos - secondTouchPrevPos).magnitude;
			touchesCurPosDifference = (firstTouch.position - secondTouch.position).magnitude;

			zoomModifier = (firstTouch.deltaPosition - secondTouch.deltaPosition).magnitude * zoomModifierSpeed;

			if (touchesPrevPosDifference < touchesCurPosDifference)
				scale += zoomModifier*UnitVector;
			if (touchesPrevPosDifference > touchesCurPosDifference)
				scale -= zoomModifier * UnitVector;

		}

		Image_rectTransform.localScale = UnitVector*Mathf.Clamp(scale.magnitude, MinZoom, MaxZoom);

	}
}