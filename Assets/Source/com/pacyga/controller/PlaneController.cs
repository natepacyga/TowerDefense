using UnityEngine;
using System.Collections;
using com.pacyga.manager;

namespace com.pacyga.controller
{
	public class PlaneController : MonoBehaviour 
	{
		private MouseManager _mouseManager;
		private ObjectManager _objectManager;

		private RaycastHit _raycastHit;
		
		void Start () 
		{
			GameObject managers = GameObject.Find("Managers");
			_objectManager = managers.GetComponent<ObjectManager>();
			_mouseManager = managers.GetComponent<MouseManager>();
		}
		
		void Update()
		{
			bool didRaycastHit = _mouseManager.didRaycastHitState;

			if (didRaycastHit && _mouseManager.raycastHit.collider == collider) 
			{
				_objectManager.showPreviewObject(_mouseManager.raycastHit.point);
			}
			else 
			{
				_objectManager.hidePreviewObject();
			}

			if (Input.GetMouseButtonUp(0) && didRaycastHit && _mouseManager.raycastHit.collider == collider)
			{
				_objectManager.instantiatePlayerGameObject(_mouseManager.raycastHit.point);
			}
		}

	}
}