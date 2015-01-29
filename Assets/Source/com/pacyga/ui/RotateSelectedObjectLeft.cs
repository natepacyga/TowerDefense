using UnityEngine;
using System.Collections;
using com.pacyga.manager;

namespace com.pacyga.ui
{
	public class RotateSelectedObjectLeft : MonoBehaviour 
	{
		private const int ROTATE_AMOUNT = -10;

		private ObjectManager _objectManager;
		private MouseManager _mouseManager;

		void Start () 
		{
			GameObject managers = GameObject.Find("Managers");
			_objectManager = managers.GetComponent<ObjectManager>();
			_mouseManager = managers.GetComponent<MouseManager>();
		}
		
		void Update()
		{
			if (Input.GetMouseButtonUp(0) && _mouseManager.didRaycastHitState && _mouseManager.raycastHit.collider == collider)
			{
				_objectManager._selectedGameObject.transform.Rotate(0, ROTATE_AMOUNT, 0, Space.World);
			}
		} 
	}
}