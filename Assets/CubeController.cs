using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {

	// キューブの移動速度
	private float speed = -0.2f;

	// 消滅位置
	private float deadLine = -10;

	//AudioClip型にaudiocube変数を定義
	public AudioClip Block;

	//AudioSourceコンポーネントにaudioSource変数を定義
	private AudioSource audioSource;

	//private  ground = GetComponent<> ();


	// Use this for initialization
	void Start(){

	}

	// Update is called once per frame
	void Update () {
		// キューブを移動させる
		transform.Translate (this.speed, 0, 0);

		// 画面外に出たら破棄する
		if (transform.position.x < this.deadLine){
			Destroy (gameObject);
		}
	}

	//衝突判定
	//衝突物の特定
	//cube×unitychanの場合音を音を消す。
	//cube×他の場合は音を鳴らす。
	void OnCollisionEnter2D(Collision2D collision)
	{
		//衝突物の確認
		//Debug.Log("hit!!");
		//Debug.Log(collision.collider.name);
		//cubeがunitychanに衝突した場合
		//UnityChan2Dをタグ指定で取得
		if (collision.gameObject.CompareTag ("Unitychan2D")) {
			//Debug.Log("hit!!");
			audioSource = gameObject.GetComponent<AudioSource> ();
			//音を入れないnullで表現
			audioSource.clip = null;
			audioSource.Play ();
		
		} else if (collision.gameObject.CompareTag ("Cube")) {
			audioSource = gameObject.GetComponent<AudioSource> ();
			audioSource.clip = Block;
			audioSource.Play ();

		} else if (collision.gameObject.CompareTag ("Ground")) {
			//床との衝突を確認
			Debug.Log("hit!!");
			audioSource = gameObject.GetComponent<AudioSource> ();
			audioSource.clip = Block;
			audioSource.Play ();

		}
	}
}