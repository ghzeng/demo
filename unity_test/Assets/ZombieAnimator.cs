using UnityEngine;
using System.Collections;

public class ZombieAnimator : MonoBehaviour {

	public Sprite[] sprites;
	public float framesPerSecond;
	private SpriteRenderer spriteRenderer;
	public float moveSpeed;
	private Vector3 moveDirection;

	// Use this for initialization
	void Start () {
		spriteRenderer = renderer as SpriteRenderer;
	}
	
	// Update is called once per frame
	void Update () {
		int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
		index = index % sprites.Length;
		spriteRenderer.sprite = sprites[ index ];
		// 1
		Vector3 currentPosition = transform.position;
		// 2
		if (Input.GetButton ("Fire1")) {
			// 3
			Vector3 moveToward = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			// 4
			moveDirection = moveToward - currentPosition;
			moveDirection.z = 0;
			moveDirection.Normalize ();
		}
	}
}
