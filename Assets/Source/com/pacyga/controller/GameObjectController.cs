using UnityEngine;
using System.Collections;
using com.pacyga.manager;

namespace com.pacyga.controller
{
	public class GameObjectController : MonoBehaviour 
	{
		public float health = 100f;

		protected ObjectManager _objectManager;
		protected UIManager _uiManager;
		protected GameManager _gameManager;
		protected MouseManager _mouseManager;

		public bool activeGameObject = false;
		
		protected virtual void Start () 
		{
			GameObject managers = GameObject.Find("Managers");
			_objectManager = managers.GetComponent<ObjectManager>();
			_uiManager = managers.GetComponent<UIManager>();
			_gameManager = managers.GetComponent<GameManager>();
			_mouseManager = managers.GetComponent<MouseManager>();

			if (activeGameObject)
			{
				onPurchase();
			}
		}

		protected virtual void Update()
		{
			if (Input.GetMouseButtonUp(0) && _mouseManager.didRaycastHitState && _mouseManager.raycastHit.collider == collider)
			{
				_objectManager.setSelectedGameObject(gameObject);
				_uiManager.showGameObjectEditUI();
				_uiManager.setGameObjectEditUITransformRelativeTo(transform);
			}

			if (health <= 0)
			{
				Destroy(gameObject);
			}
		}

		public virtual void onPurchase() { }
		public virtual void onDestroy() { }
		
	}
}

