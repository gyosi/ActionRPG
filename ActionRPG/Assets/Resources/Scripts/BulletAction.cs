using UnityEngine;
using System.Collections;

public class BulletAction : MonoBehaviour {

    public float bulletSpeed = 0;       //유니티 총알 프리팹에서 속도 조절함.

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
        Destroy(gameObject, 3f);        //3초동안 아무일도 일어나지 않으면 강제로 총알을 삭제한다.
	}

    void OnTriggerEnter(Collider col)   //어딘가에 부딛혔는지 체크
    {
        //무조건 어딘가에 부딛히면 총알은 사라지고, 파괴 이펙트 생성
        //스파크 이펙트를 불러온다.
        GameObject SparkEff = (GameObject)Resources.Load("Player/Effect/FireSparkEff");
        SparkEff = (GameObject)Instantiate(SparkEff, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
}
