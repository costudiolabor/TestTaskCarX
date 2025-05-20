using UnityEngine;

namespace AppRefactoring.Scripts {

	public class GuidedProjectile : Projectile {
		[SerializeField] private float delayHide = 3.0f;
		[SerializeField] private Rigidbody rigidBody;
		private Transform _target;
		private Transform _thisTransform;
		private float _timer;
		private bool _isActive;
		public void Initialize() { _thisTransform = transform; }
		public void SetTarget(Transform target) {_target = target; }

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
			if (_target == null) {
				Hide();
				return;
			}
			Vector3 direction = _target.position - _thisTransform.position;
			direction = direction.normalized;
			rigidBody.linearVelocity = direction * speed;
		}

		private void TimerHide() {
			if (_timer <= 0f) { Hide(); }
			_timer -= Time.deltaTime;
		}
	}
}