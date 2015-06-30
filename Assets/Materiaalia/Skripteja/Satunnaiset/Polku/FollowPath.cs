using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowPath : MonoBehaviour {


	public enum FollowType
	{
		MoveTowards,
		Lerp
	
	}


	public FollowType Type = FollowType.MoveTowards;
	public PathDefinition Path;
	public float speed4 = 1;
	public float speed3 = 0.09f;
	public float MaxDistanceToGoal = .1f;

	private IEnumerator<Transform> _currentPoint;


	public void Start(){


		if (Path == null) {
		
			Debug.LogError("ei voi olla",gameObject);
			return;
		
		}


		_currentPoint = Path.GetPathEnumerator ();
		_currentPoint.MoveNext ();

		if (_currentPoint.Current == null)
			return;


		transform.position = _currentPoint.Current.position;


	
	
	
	
	
	}

	public void Update(){

		Vector3 dir = _currentPoint.Current.position - transform.position;
		dir.Normalize ();

		float zAngle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90;
		
		
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, zAngle), speed3);


	
	
	if (_currentPoint == null || _currentPoint.Current == null)
			return;
	
	
	if (Type == FollowType.MoveTowards)
			transform.position = Vector3.MoveTowards (transform.position, _currentPoint.Current.position, Time.deltaTime * speed4);
		else if (Type == FollowType.Lerp)
			transform.position = Vector3.Lerp (transform.position, _currentPoint.Current.position, Time.deltaTime * speed4);

	
		var distanceSquared = (transform.position - _currentPoint.Current.position).sqrMagnitude;

		if(distanceSquared < MaxDistanceToGoal*MaxDistanceToGoal)
			_currentPoint.MoveNext();




	}





}
