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

		public bool activeGameObject = false;
		
		protected virtual void Start () 
		{
			GameObject managers = GameObject.Find("Managers");
			_objectManager = managers.GetComponent<ObjectManager>();
			_uiManager = managers.GetComponent<UIManager>();
			_gameManager = managers.GetComponent<GameManager>();

			if (activeGameObject)
			{
				onPurchase();
			}
		}
		
		void OnMouseUp()
		{
			_objectManager.setSelectedGameObject(gameObject);
			_uiManager.showGameObjectEditUI();
			_uiManager.setGameObjectEditUITransformRelativeTo(transform);
		}

		protected virtual void Update()
		{
			if (health <= 0)
			{
				Destroy(gameObject);
			}
		}

		public virtual void onPurchase() { }
		public virtual void onDestroy() { }
		
	}
}

