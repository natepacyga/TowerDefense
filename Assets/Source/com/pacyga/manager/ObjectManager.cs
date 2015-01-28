using UnityEngine;
using System.Collections;
using com.pacyga.enumeration;
using com.pacyga.controller;

namespace com.pacyga.manager
{
	public class ObjectManager : MonoBehaviour 
	{
		private GameManager _gameManager;

		public GameObject _selectedGameObject;
		private string _gameObjectPath;
		
		private GameObject _previewObject;

		private int _gameObjectEditIndex = 0;

		void Start()
		{
			GameObject managers = GameObject.Find("Managers");
			_gameManager = managers.GetComponent<GameManager>();
			setGameObjectPaths();
			_gameManager.setMode();
		}

		void Update () 
		{
			checkGameObjectEditKeys();
		}

		public void checkGameObjectEditKeys()
		{
			if (Input.GetKeyUp (KeyCode.R) || Input.GetKeyUp (KeyCode.E))
			{
				if (Input.GetKeyUp (KeyCode.R))
				{
					modifyGameObjectEditIndex(1);
				}
				else 
				{
					modifyGameObjectEditIndex(-1);
				}
				hidePreviewObject();
				setGameObjectPaths();
			}
		}

		public void setGameObjectPaths()
		{
			_gameObjectPath = PrefabEnum.GAME_OBJECTS[_gameObjectEditIndex];
		}

		public void setSelectedGameObject(GameObject value)
		{
			_selectedGameObject = value;
		}

		public void modifyGameObjectEditIndex(int amount)
		{
			_gameObjectEditIndex += amount;

			if (_gameObjectEditIndex > (PrefabEnum.GAME_OBJECTS_COUNT - 1))
			{
				_gameObjectEditIndex = 0;
			}
			else if (_gameObjectEditIndex < 0)
			{
				_gameObjectEditIndex = (PrefabEnum.GAME_OBJECTS_COUNT - 1);
			}
		}

		public void showPreviewObject(Vector3 position)
		{
			if (_gameManager.mode != ModeEnum.PLACE_GAME_OBJECTS)
			{
				return;
			}

			if (_previewObject == null)
			{
				_previewObject = GameObject.Instantiate(Resources.Load(_gameObjectPath, typeof(GameObject)))  as GameObject;
			}

			if (_previewObject.collider != null) 
			{
				_previewObject.collider.enabled = false;
			}

			_previewObject.transform.position = position;
		}
		
		public void hidePreviewObject()
		{
			if (_gameManager.mode != ModeEnum.PLACE_GAME_OBJECTS)
			{
				return;
			}

			if (_previewObject != null)
			{
				Destroy(_previewObject);
				_previewObject = null;
			}
		}
		
		public void destroySelectedGameObject()
		{
			Destroy(_selectedGameObject);
			_selectedGameObject = null;
		}
		
		public void instantiatePlayerGameObject(Vector3 position)
		{
			if (_gameManager.mode == ModeEnum.PLACE_GAME_OBJECTS && _gameManager.canBuyGameObject)
			{
				_gameManager.modifyGold(_gameManager.gameObjectGoldPrice);
				_gameManager.modifyWood(_gameManager.gameObjectWoodPrice);
				Vector3 pos = new Vector3(position.x, 1, position.z);
				GameObject go = GameObject.Instantiate(Resources.Load(_gameObjectPath, typeof(GameObject)), pos, Quaternion.identity) as GameObject;
				go.GetComponent<GameObjectController>().activeGameObject = true;
			}
		}

		public void instantiateEnemy(Vector3 position)
		{
			GameObject.Instantiate(Resources.Load(PrefabEnum.TROLL_AVATAR_PATH, typeof(GameObject)), position, Quaternion.identity);
		}

		public void instantiateBullet(Vector3 position, GameObject target)
		{
			GameObject go = GameObject.Instantiate(Resources.Load(PrefabEnum.BULLET_PATH, typeof(GameObject)), position, Quaternion.identity) as GameObject;
			go.GetComponent<BulletController>().setTarget(target);
		}

	}
}