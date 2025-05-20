using UnityEngine;

namespace AppRefactoring.Scripts {
    public abstract class Tower : MonoBehaviour, ITickble {
        [SerializeField] protected int maxProjectile = 10;
        [SerializeField] protected float intervalShoot = 0.5f;
        [SerializeField] protected float range = 4f;
        [SerializeField] protected Transform shootPoint;
        
        protected ITickble[] _tickble;
        private Monster[] _monsters;
        protected Monster _target;
        private float _timer;

        public abstract void Initialize();
        public abstract void Tick();

        public void SetTarget(Monster[] monsters) { _monsters = monsters; }
        
        public void FindTarget() {
            _target = null;
            float closestDistance = Mathf.Infinity;
            foreach (Monster monster in _monsters) {
                if (monster.gameObject.activeInHierarchy == false) continue;
                float distance = Vector3.Distance(monster.transform.position, shootPoint.position);
                if (distance < closestDistance && distance <= range) {
                    closestDistance = distance;
                    _target = monster;
                }
            }
        }
        
        public void UpdateShoot() {
            if (_target == null) return;
            _timer -= Time.deltaTime;
            if (_timer <= 0f) {
                Shoot(_target);
                _timer = intervalShoot;
            }
        }

        public virtual void Shoot(Monster monster) { }
        
        public void TickProjectiles() {
            for (int i = 0; i < _tickble.Length; i++) {
                _tickble[i].Tick();
            }
        }
    }
}