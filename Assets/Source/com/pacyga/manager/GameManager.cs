using UnityEngine;
using System.Collections;
using com.pacyga.enumeration;

namespace com.pacyga.manager
{
	public class GameManager : MonoBehaviour 
	{
		private const float RESOURCES_TICK = 1f;
		private const int STARTING_GOLD = 50000;
		private const int STARTING_WOOD = 20000;

		private readonly Vector3[] SPAWN_POINTS = new Vector3[4] {new Vector3(-143, 1, 130), new Vector3(145, 1, 135), new Vector3(-143, 1, -145), new Vector3(145, 1, 135)};

		private float _spawnTick = 60f;
		
		private ObjectManager _objectManager;
		
		private int _gold = STARTING_GOLD;
		public int gold {get {return _gold;}}
		
		private int _wood = STARTING_WOOD;
		public int wood {get {return _wood;}}
		
		private int _residences;
		public int residences {get {return _residences;}}
		
		private int _banks;
		public int banks {get {return _banks;}}
		
		private int _lumberyards;
		public int lumberyards {get {return _lumberyards;}}
		
		private int _trees;
		public int trees {get {return _trees;}}
		
		private float _reourcesTickCount = 0;
		private float _spawnTickCount = 0f;
		
		private string _mode;
		public string mode {get {return _mode;}}
		private int _modeIndex = 0;

		public bool canBuyGameObject = false;
		public int gameObjectGoldPrice = 0;
		public int gameObjectWoodPrice = 0;
		
		void Start()
		{
			GameObject managers = GameObject.Find("Managers");
			_objectManager = managers.GetComponent<ObjectManager>();
		}
		
		void Update () 
		{
			checkResourcesTick();
			checkSpawnTick();
			checkModeChangeKey();
		}

		private void checkSpawnTick()
		{
			_spawnTickCount += Time.deltaTime;
			if (_spawnTickCount >= _spawnTick)
			{
				_spawnTickCount = 0;
				_objectManager.instantiateEnemy(SPAWN_POINTS[Random.Range(0, (SPAWN_POINTS.Length-1))]);
			}
		}

		private void checkResourcesTick()
		{
			_reourcesTickCount += Time.deltaTime;
			if (_reourcesTickCount >= RESOURCES_TICK)
			{
				_gold +=_banks * _residences;
				_wood += _trees * _lumberyards;
				_reourcesTickCount = 0;
			}
		}
		
		public void checkModeChangeKey()
		{
			if (Input.GetKeyUp (KeyCode.Q))
			{
				_objectManager.hidePreviewObject();
				modifyModeIndex(1);
				setMode();
			}
		}
		
		public void modifyModeIndex(int amount)
		{
			_modeIndex += amount;
			
			if (_modeIndex > (ModeEnum.MODES_COUNT - 1))
			{
				_modeIndex = 0;
			}
			else if (_modeIndex < 0)
			{
				_modeIndex = (ModeEnum.MODES_COUNT - 1);
			}
		}
		
		public void setMode()
		{
			_mode = ModeEnum.MODES[_modeIndex];
		}
		
		public void modifyGold(int amount)
		{
			_gold += amount;
		}
		
		public void modifyWood(int amount)
		{
			_wood += amount;
		}
		
		public void modifyResidences(int amount)
		{
			_residences += amount;
		}
		
		public void modifyBanks(int amount)
		{
			_banks += amount;
		}
		
		public void modifyLumberyards(int amount)
		{
			_lumberyards += amount;
		}
		
		public void modifyTrees(int amount)
		{
			_trees += amount;
		}
		
	}
}