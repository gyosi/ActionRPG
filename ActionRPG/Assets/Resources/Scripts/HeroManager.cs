using UnityEngine;
using System.Collections;

public class HeroManager : MonoBehaviour
{
    float a = 1;

    public enum HeroSTATE
    {
        상태없음,
        걷기,
        달리기,
        //점프,
        라이플_발사,
        라이플_재장전,
        라이플_쏘면서_이동,
        맞음,
        죽음,
        MAX
    }

    public enum WeaponSTATE
    {
        라이플
    }

    //총알 생성 포지션
    public GameObject Weapon_AssultRifle01;

    public Animator anim;

    public float speed = 8f;   //플레이어 이동속도
    public float rotateSpeed = 10f; //플레이어 회전 속도

    public UILabel Bullet_Label;
    public int Bullet_Storage = 0;        //소지한 모든 총알 갯수
    public int Bullet_Max = 0;            //탄창 총알 갯수
    public int Bullet_Current = 0;        //남은 총알 갯수

    public UILabel Message_Label;          //메세지 라벨

    Rigidbody rigidbody;
    Vector3 movement;

    float timer = 2.5f;
    float timer1 = 0.5f;
    bool t = true;
    bool FireFlag = false;

    float horizontalMove;       //좌우 이동키
    float verticalMove;         //위아래 이동키
    //public float JumpPower = 3f;       //점프 강도
    //bool isJumping;             //점프키를 눌렀는지 체크

    HeroSTATE STATE = HeroSTATE.상태없음;       // 현재 상태
    HeroSTATE oldSTATE = HeroSTATE.상태없음;    // 이전 상태
    WeaponSTATE weaponState = WeaponSTATE.라이플;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void OnEnable()
    {
        StartCoroutine("OnEnableCoru");
    }

    IEnumerator OnEnableCoru()
    {
        while (GameManager.Instance == null)
        {
            yield return null;
        }
        GameManager.Instance.heroManager = this;
    }

    void Update()
    {
        Debug.Log(STATE + "   FireFlag : " + FireFlag);

        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");

        //==============================================================================================================================
        //달리기


        if (Bullet_Current <= 0 && Input.GetMouseButton(0) == true)                //탄창에 총알이 없으면
        {
            Bullet_Current = 0;                 //남은 총알을 0으로 표시한다 ( -1 로 표기 될때가 있어서 넣음)
            STATE = HeroSTATE.라이플_재장전;    //재장전 상태로 변환
            horizontalMove = 0;                 //좌우로 움직이지 못하게 한다.  
            verticalMove = 0;                   //위아래로 움직이지 못하게 한다.
        }
        else
        {
            if (horizontalMove != 0 || verticalMove != 0)
            {
                STATE = Input.GetMouseButton(0) ? HeroSTATE.라이플_쏘면서_이동 : HeroSTATE.달리기;
            }
            else
            {
                FireFlag = Input.GetMouseButton(0);
                STATE = Input.GetMouseButton(0) ? HeroSTATE.라이플_발사 : HeroSTATE.상태없음;
            }
        }


        if (oldSTATE != STATE)
        {
            switch (STATE)
            {
                case HeroSTATE.달리기:
                    speed = 8f;
                    anim.SetTrigger("Run");
                    break;

                case HeroSTATE.라이플_쏘면서_이동:
                    speed = 2f;
                    anim.SetTrigger("Walk_Shoot");
                    break;

                case HeroSTATE.라이플_발사:
                    anim.SetTrigger("Rifle_Shoot");
                    break;

                case HeroSTATE.라이플_재장전:
                    anim.SetTrigger("Rifle_Reload");
                    break;

                case HeroSTATE.상태없음:
                    anim.SetTrigger("Idle");
                    break;

            }
        }

        oldSTATE = STATE;


        Bullet_Label.text = "총알 : " + Bullet_Current + " / " + Bullet_Storage;  //총알갯수 화면에 표시하는 UI_Label;
        //==============================================================================================================================
        //실시간 디버깅
        Vector3 position = Weapon_AssultRifle01.transform.FindChild("Position").transform.position;
        Vector3 lookposition = Weapon_AssultRifle01.transform.FindChild("LookPosition").transform.position;
        Vector3 createPosition = lookposition - position;
        createPosition.Normalize();
        Debug.DrawRay(position, createPosition * 100f, Color.red);
        //==============================================================================================================================
    }

    //==================================================================================================================================
    //총알생성      
    //라이플 총알 생성
    public void Rifle_Bullet()
    {
        //총알 생성
        //총알 생성 방향 지정
        Vector3 position = Weapon_AssultRifle01.transform.FindChild("Position").transform.position;             //총알 생성 위치
        Vector3 lookposition = Weapon_AssultRifle01.transform.FindChild("LookPosition").transform.position;     //총알 방향을 비교할 임시적으로 만든 위치
        Vector3 createPosition = lookposition - position;                                                       //임시로 만든 총알 방향을 비교할 위치 - 총알 생성위치 = 총알의 방향이 된다. (모르겠으면 걍 공식이라 생각하고 위우자)

        GameObject bullet = (GameObject)Resources.Load("Player/Bullet");                                        //총알을 로드한다.
        bullet = (GameObject)Instantiate(bullet, position, Quaternion.LookRotation(createPosition));            //총알을 생성한다. Quaternion.LookRotation(createPosition)는 위에서 구해놓은 총알의 방향(createPosition)을 바라보면서 생성된다.

        //발사 이펙트를 불러온다.
        GameObject effect = (GameObject)Resources.Load("Player/Effect/FireEff");
        effect = (GameObject)Instantiate(effect, position, Quaternion.LookRotation(createPosition));
        effect.transform.parent = Weapon_AssultRifle01.transform.FindChild("Position");                         //총알 이펙트를 Position 오브젝트의 자식으로 둔다.(케릭터가 움직여도 이펙트가 총의 총구에 붙어있게 하기 위함)
        Bullet_Current -= 1;
    }

    //재장전
    public void Reload()
    {
        if (Bullet_Storage > 0)
        {
            if (Bullet_Max > Bullet_Storage)
            {   //소지한 총알이 탄창보다 작으면 부족한만큼만 탄창에 넣는다.
                Bullet_Current = Bullet_Storage;
                Bullet_Storage = 0;
            }

            else
            {
                Bullet_Current = Bullet_Max;
                Bullet_Storage -= Bullet_Max;
            }
        }
        else
        {
            if(Message_Label.gameObject.activeSelf == false)
            {
                Message_Label.gameObject.SetActive(true);
            }
            Message_Label.text = "총알이 없습니다.";
            Message();
        }

    }

    void FixedUpdate()
    {
        Run();
        Turn();
    }

    void Run()      //이동 제어
    {
        movement.Set(horizontalMove, 0, verticalMove);
        movement = movement.normalized * speed * Time.deltaTime;

        rigidbody.MovePosition(transform.position + movement);

        //Debug.Log("horizontalMove " + horizontalMove + "    verticalMove " + verticalMove);
    }

    void Turn()     //회전 제어
    {
        if (horizontalMove == 0 && verticalMove == 0)
        {
            return;
        }

        Quaternion newQuaternion = Quaternion.LookRotation(movement);
        rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, newQuaternion, rotateSpeed * Time.deltaTime);
    }

    void Message()
    {
        Message_Label.GetComponent<TweenColor>().ResetToBeginning();
        Message_Label.GetComponent<TweenColor>().enabled = true;

    }
}
