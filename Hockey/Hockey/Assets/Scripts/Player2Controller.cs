using UnityEngine;
using System.Collections;

public class Player2Controller : MonoBehaviour
{
	private Vector2 touchOrigin = -Vector2.one;
	private Rigidbody2D rb;
	public float speed;
	
	void Update ()
	{
		if (Input.touchCount > 0)
		{
			// The screen has been touched so store the touch
			Touch touch = Input.GetTouch(0);

			if(touch.position.x>Screen.width/2)
				touch=Input.GetTouch (1);
			
			if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
			{
				// If the finger is on the screen, move the object smoothly to the touch position
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));

				if(touchPosition.x<(-2))
					touchPosition.x = -2f;
				if(touchPosition.x>(2))
					touchPosition.x = 2f;
				if(touchPosition.y>(4.12))
					touchPosition.y = 4.12f;
				if(touchPosition.y<(0.55))
					touchPosition.y = 0.55f;

				transform.position = Vector3.Lerp(transform.position, touchPosition, Time.deltaTime*speed);
			}
		}
	}
}
