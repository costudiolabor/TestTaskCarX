using System.Collections.Generic;
using UnityEngine;
using System;

namespace AppRefactoring.Scripts {
    
    [Serializable]
    public class TowersSpawner {
        private TowerConfig _towerConfig;
        private Factory _factory;

        public TowersSpawner(TowerConfig towerConfig) {
            _towerConfig = towerConfig;
            _factory = new Factory();
        }

        public Tower GetTower(TowerType towerType, Transform parent, Vector3 position = default(Vector3), Quaternion rotation = default(Quaternion)) {
            return towerType switch {
                TowerType.Cannon => _factory.Get(_towerConfig.CannonTowerPrefab, parent, position, rotation),
                TowerType.Simple => _factory.Get(_towerConfig.SimpleTowerPrefab, parent, position, rotation),
                _ => throw new ArgumentOutOfRangeException($"Not expected direction value: "),
            };
        }
    }
}