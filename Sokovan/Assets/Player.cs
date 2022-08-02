using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 카멜(낙타)명명법 사용
public class Player : MonoBehaviour
{
    // 앞에 접근자 안붙이면 암묵적 private (인스펙터에 안보임)
    public float speed = 10f; 
    private Rigidbody playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>(); // 알아서 찾아넣음
    }

    // Update is called once per frame
    // 영화 초당 24프레임, 모바일 1초 30프레임, PC 1초 60프레임, 콘솔게임 1초 30프레임
    // 1초에 대략 60번, 단 사야엥 따라 다름 => 몇번 실행되는지는 정해져있지 않음
    // 콘솔 Collapse는 같은 메세지 묶어줌
    void Update()
    {
        //Debug.Log("깜빡~");

        // 유저 입력을 넣자
        // Input.GetKey(KeyCode.W) 키보드는 각 숫자아이디를 가짐. 근데 키코드로 대체가능

        float inputX = Input.GetAxis("Horizontal"); // -1 ~ +1   조이스틱을 위해 bool 아닌 숫자
                                                    // "Horizontal" : <- ->와 a d가 할당되어있음   A<- -1 0 1  ->D
        float inputZ = Input.GetAxis("Vertical");

        // AddForce 말고 스피드를 바로 지정해주기
        float fallSpeed = playerRigidbody.velocity.y;
 
        Vector3 velocity = new Vector3(inputX, 0, inputZ);

        velocity = velocity * speed;

        velocity.y = fallSpeed;

        // (inputX* speed, fallSpeed, inputZ* speed)
        playerRigidbody.velocity = velocity;

    }
}
