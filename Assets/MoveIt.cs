using UnityEngine;
using System.Collections;

public class MoveIt : MonoBehaviour {


	public float perlinGrain = 0.4f;
	public float scale = 10;


	void Start () {
	
	}
	

	void Update () {
		
		float x = Mathf.PerlinNoise( Time.time * perlinGrain, 0.0f ) * scale - scale*0.5f ;
		float y = 1;
		float z = Mathf.PerlinNoise( 3000 + Time.time * perlinGrain, 0.0f ) * scale - scale*0.5f;
		

		Vector3 newPos = new Vector3( x, y, z );

		transform.position = newPos;

	}
}
