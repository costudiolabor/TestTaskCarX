using System.Collections.Generic;
using UnityEngine;

namespace AppRefactoring.Scripts {
    public class EntryPoint : MonoBehaviour {
        
        [SerializeField] private Map mapPrefab;
        [SerializeField] private Gameplay gameplay;
        [SerializeField] private TowerConfig towerConfig;
        [SerializeField] private MonsterConfig monsterConfig;

        private TowersSpawner _towersSpawner;
        private MonsterSpawner _monsterSpawner;
        private readonly List<Tower> _towers = new();
        private Monster[] _monsters;
        private Map map;

        private void Awake() => Initialize();

        private void Initialize() {
            map = Instantiate(mapPrefab);
            CrateMap();
            CreateMonsters();
            gameplay.Initialize(map.SpawnInterval);
            gameplay.SetTowers(_towers.ToArray());
            gameplay.SetMonsters(_monsters);
            SetTargetForTowers();
            gameplay.Run();
            Subscription();
        }

        public void CrateMap() {
            _towersSpawner = new TowersSpawner(towerConfig);
            foreach (var cannon in map.CannonTowers) {
                var tower = _towersSpawner.GetTower(TowerType.Cannon, cannon, cannon.position, cannon.rotation);
                tower.Initialize();
                _towers.Add(tower);
            }
            foreach (var cannon in map.SimpleTowers) {
                var tower = _towersSpawner.GetTower(TowerType.Simple, cannon, cannon.position, cannon.rotation);
                tower.Initialize();
                _towers.Add(tower);
            }
        }

        public void CreateMonsters() {
            _monsterSpawner = new MonsterSpawner(monsterConfig);
            _monsters = _monsterSpawner.CreateMonsters(map.EnemySpawnPoint.position, map.EnemyDestinationPoint.position, map.MonsterCount);
        }

        public void SetTargetForTowers() {
            for (int i = 0; i  < _towers.Count; i ++) {
                _towers[i].SetTarget(_monsters);
            }
        }
        
        private void OnSpawn() {
            _monsterSpawner.Spawn(map.EnemySpawnPoint, map.EnemyDestinationPoint);
        }

        private void Subscription() {
            gameplay.SpawnEvent += OnSpawn;
        }
        private void UnSubscription() {
            gameplay.SpawnEvent -= OnSpawn;
        }
        private void OnDestroy() => UnSubscription();
    }
}