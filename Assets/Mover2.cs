using UnityEngine;
using System.Collections;

public class Mover2 : MonoBehaviour {

	public float area = 40;

	private float spacing = 0.1f;

	public int maxRepetitions = 10;

	private int repetition = 0;

	public float speed = 2;

	private Vector3 direction;
	private Vector3 prevPosition;

	public int step = 0;


	private Color gizmoColour;

	void Start () {
		gizmoColour = Color.green;
		direction = Vector3.forward;
		
		prevPosition = transform.position;

		spacing = 0.5f* area / (float)maxRepetitions;
		
	}
	
	
	void Update () {
		
		
		if ( repetition >= maxRepetitions ){
			ParticleSystem ps = transform.GetComponent<ParticleSystem>();
			ps.enableEmission = false;
			gizmoColour = Color.red;
		} else {
			if ( step == 0 && Vector3.Distance( prevPosition, transform.position ) >= area ){
				direction = Vector3.right;
				prevPosition = transform.position;
				step = 1;
				//Debug.Log( "changing to step: " + step );
			} else if ( step == 1 && Vector3.Distance( prevPosition, transform.position ) >= spacing ){
				direction = Vector3.back;
				prevPosition = transform.position;			
				step = 2;
				//Debug.Log( "changing to step: " + step );
			} else if ( step == 2 && Vector3.Distance( prevPosition, transform.position ) >= area ){
				direction = Vector3.right;
				prevPosition = transform.position;
				step = 3;
				repetition++;
				//Debug.Log( "changing to step: " + step );
			} else if ( step == 3 && Vector3.Distance( prevPosition, transform.position ) >= spacing ){
				direction = Vector3.forward;
				prevPosition = transform.position;
				step = 0;
				//Debug.Log( "changing to step: " + step );				
			}

			transform.position += direction * speed * Time.deltaTime;
		}

	
	}

	void OnDrawGizmos(){
		Gizmos.color = gizmoColour;
		Gizmos.DrawSphere( transform.position, 0.5f );
	}

}
