using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;

public class ZoomCamera : MonoBehaviour
{
	CinemachineVirtualCamera mainCamera;

	float touchesPrevPosDifference, touchesCurPosDifference, zoomModifier;

	Vector2 firstTouchPrevPos, secondTouchPrevPos;

	[SerializeField]
	float zoomModifierSpeed = 0.01f;

	[SerializeField]
	TextMeshProUGUI text;

	// Use this for initialization
	void Start()
	{
		mainCamera = GetComponent<CinemachineVirtualCamera>();
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

			if (touchesPrevPosDifference > touchesCurPosDifference)
				mainCamera.m_Lens.OrthographicSize += zoomModifier;
			if (touchesPrevPosDifference < touchesCurPosDifference)
				mainCamera.m_Lens.OrthographicSize -= zoomModifier;

		}

		mainCamera.m_Lens.OrthographicSize = Mathf.Clamp(mainCamera.m_Lens.OrthographicSize, 2f, 10f);
		text.text = "Camera size " + mainCamera.m_Lens.OrthographicSize;

	}
}
