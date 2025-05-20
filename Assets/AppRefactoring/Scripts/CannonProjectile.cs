using UnityEngine;

namespace AppRefactoring.Scripts {
    public class CannonProjectile : Projectile {
        [SerializeField] private float delayHide = 3.0f;
        [SerializeField] private Rigidbody rigidBody;
        private float _timer;
        private bool _isActive;
        
        public void OnEnable() {
            _isActive = true;
            _timer = delayHide;
        }
        
        public void OnDisable() {
            _isActive = false;
        }

        public override void Tick() {
            if (_isActive == false) return; 
            TimerHide();
        }
        
        private void TimerHide() {
            _timer -= Time.deltaTime;
            if (_timer <= 0f) { Hide(); }
        }

        public void Shoot(Vector3 direction) {
            rigidBody.linearVelocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero; 
            direction = direction.normalized;
            rigidBody.linearVelocity = direction * speed;
        } 
    }
}