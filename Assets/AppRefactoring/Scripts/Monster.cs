using UnityEngine;

namespace AppRefactoring.Scripts {
    public class Monster : View, ITickble {
        public Transform target;
        [SerializeField] private float speedMove = 0.1f;
        [SerializeField] private  int maxHealth = 30;
        [SerializeField] private float reachDistance = 0.3f;
        [SerializeField] private Rigidbody rigidBody;
        
        private int _health;
        private Transform _thisTransform;

        void Start() {
            _thisTransform = transform;
            ResetHealth();
        }
        
        public void ResetHealth() => _health = maxHealth;
        public void SetHealth(int newHP) => _health = newHP;
        public int GetHealth() => _health;
        
        public Vector3 GetVelocity() => rigidBody.linearVelocity;

        public void Tick() {
            if (target == null)
                return;
		
            if (Vector3.Distance (_thisTransform.position, target.position) <= reachDistance) {
                Hide();
                return;
            }

            Vector3 direction = target.position - _thisTransform.position;
            direction = direction.normalized;
            rigidBody.linearVelocity = direction * speedMove;
        }
    }
}