using UnityEngine;
using System.Collections;

namespace com.pacyga.manager
{
	public class MouseManager : MonoBehaviour 
	{
		private const int MOUSE_CURSOR_WIDTH = 32;
		private const int MOUSE_CURSOR_HEIGHT = 32;
		private const int MOUSE_CURSOR_HALF_WIDTH = (MOUSE_CURSOR_WIDTH >> 2);
		private const int MOUSE_CURSOR_HALF_HEIGHT = (MOUSE_CURSOR_HEIGHT >> 2);

		public Texture2D mouseCursor;

		public Vector3 mouseLookPosition = new Vector3();

		public RaycastHit raycastHit;
		public bool didRaycastHitState = false;

		void Start()
		{
			Screen.lockCursor = true;
			Screen.showCursor = false;
		}

		void OnMouseDown() 
		{
			Screen.lockCursor = true;
			Screen.showCursor = false;
		}

		void Update()
		{
			float halfScreenWidth = (float)(Screen.width * .5);  //Could change, can't cache it.
			float halfScreenHeight =(float)(Screen.height * .5);
			
			mouseLookPosition.x = (float)(halfScreenWidth - MOUSE_CURSOR_HALF_WIDTH);
			mouseLookPosition.y = (float)(halfScreenHeight - MOUSE_CURSOR_HALF_HEIGHT);
			mouseLookPosition.z = (float)Camera.main.nearClipPlane;

			updateRaycastHit();
		}

		void OnGUI()
		{
			Rect mouseCursorRect = new Rect(mouseLookPosition.x, mouseLookPosition.y, MOUSE_CURSOR_WIDTH, MOUSE_CURSOR_HEIGHT);
			GUI.DrawTexture(mouseCursorRect, mouseCursor);
		}

		private void updateRaycastHit()
		{
			didRaycastHitState = false;
			raycastHit = new RaycastHit();
			Ray ray = Camera.main.ScreenPointToRay(mouseLookPosition);
			if (Physics.Raycast(ray, out raycastHit, 1000)) 
			{
				didRaycastHitState = true;
			}
		}

	}
}