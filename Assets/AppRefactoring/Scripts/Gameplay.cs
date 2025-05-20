using System;
using UnityEngine;

namespace AppRefactoring.Scripts {
    public class Gameplay : MonoBehaviour {
        private bool _isRunning;
        private Tower[] _tower;
        private Monster[] _monsters;
        private float _timer;
        private float _spawnInterval;
       
        public event Action SpawnEvent; 
        
        public void Initialize(float spawnInterval) {
            _spawnInterval = spawnInterval;
        }

        public void SetTowers(Tower[] tower) {
            _tower = tower;
        }
        
        public void SetMonsters(Monster[] monsters) {
            _monsters = monsters;
        }

        public void Run() {
            _isRunning = true;
        }
        
        public void Update() {
            if(_isRunning == false) return; 
            UpdateTowers();
            UpdateMonsters();
            UpdateSpawn();
        }

        private void UpdateTowers() {
            for (int i = 0; i  < _tower.Length; i ++) {
                _tower[i].Tick();
            }
        }
        
        private void UpdateMonsters() {
            for (int i = 0; i  < _monsters.Length; i ++) {
                _monsters[i].Tick();
            }
        }
        
        public void UpdateSpawn() {
            _timer -= Time.deltaTime;
            if (_timer <= 0f) {
                Spawn();
                _timer = _spawnInterval;
            }
        }
        
        public void Spawn() {
            SpawnEvent?.Invoke();
        }
        
    }
}