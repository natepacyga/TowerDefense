using UnityEngine;
using System.Collections;

namespace com.pacyga.manager
{
	public class MouseManager : MonoBehaviour 
	{
		public Texture2D mouseCursor;

		void Start()
		{
			Cursor.SetCursor(mouseCursor, Vector2.zero, CursorMode.Auto);
		}

	}
}