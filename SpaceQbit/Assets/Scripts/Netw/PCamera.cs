using UnityEngine;
	public class PCamera : BoltSingletonPrefab<PCamera>
	{
		
		private Vector3 _b = Vector3.zero;
		
		// camera target
		Transform _target;

		private Vector3 _offset;

		[SerializeField]
		Transform cam;
		
		public Camera myCamera 
		{
			get { return transform.GetComponent<Camera> (); }
		}

		void Awake ()
		{
			DontDestroyOnLoad (gameObject);
		}

		void UpdateCamera ()
		{
			Vector3 targetPosition = _target.position;

			targetPosition += _offset;
        
			transform.position = 
				Vector3.SmoothDamp(transform.position, 
					targetPosition, 
					ref _b, 
					0.5f);
		}

		public void SetTarget (BoltEntity entity)
		{
			_target = entity.transform;
			_offset = new Vector3(1.2f, 3, 1.5f);
			UpdateCamera ();
		}
    
		void LateUpdate()
		{
			UpdateCamera();
		}
		
}