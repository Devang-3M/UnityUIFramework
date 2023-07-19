using UnityEngine;

public class SafeArea : MonoBehaviour
{
	RectTransform panel;
	Rect lastSafeArea = new Rect(0, 0, 0, 0);
	public bool applyHorizontal = true;
	public bool applyVertical = true;
	Rect safeArea;

	void Awake()
	{
		panel = GetComponent<RectTransform>();
		Refresh();
	}

	void Update()
	{
		Refresh();
	}

	void Refresh()
	{
		safeArea = GetSafeArea();

		ApplySafeArea(safeArea);

		//if (safeArea != lastSafeArea)
		//{
		//	ApplySafeArea(safeArea);
		//}
	}

	Rect GetSafeArea()
	{
		return Screen.safeArea;
	}

	void ApplySafeArea(Rect r)
	{
		lastSafeArea = r;

		Vector2 anchorMin = r.position;
		Vector2 anchorMax = r.position + r.size;

		if (applyHorizontal && applyVertical)
		{
			anchorMin.x /= Screen.width;
			anchorMin.y /= Screen.height;

			anchorMax.x /= Screen.width;
			anchorMax.y /= Screen.height;
		}
		else if (!applyHorizontal && !applyVertical)
		{
			anchorMin.x = 0;
			anchorMin.y = 0;

			anchorMax.x = 1;
			anchorMax.y = 1;
		}
		else if (applyHorizontal)
		{
			anchorMin.x /= Screen.width;
			anchorMin.y = 0;

			anchorMax.x /= Screen.width;
			anchorMax.y = 1;
		}
		else if (applyVertical)
		{
			anchorMin.x = 0;
			anchorMin.y /= Screen.height;

			anchorMax.x = 1;
			anchorMax.y /= Screen.height;
		}

		panel.anchorMin = anchorMin;
		panel.anchorMax = anchorMax;
	}

}
