using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ī��(��Ÿ)���� ���
public class Player : MonoBehaviour
{
    // �տ� ������ �Ⱥ��̸� �Ϲ��� private (�ν����Ϳ� �Ⱥ���)
    public float speed = 10f; 
    private Rigidbody playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>(); // �˾Ƽ� ã�Ƴ���
    }

    // Update is called once per frame
    // ��ȭ �ʴ� 24������, ����� 1�� 30������, PC 1�� 60������, �ְܼ��� 1�� 30������
    // 1�ʿ� �뷫 60��, �� ��߿� ���� �ٸ� => ��� ����Ǵ����� ���������� ����
    // �ܼ� Collapse�� ���� �޼��� ������
    void Update()
    {
        //Debug.Log("����~");

        // ���� �Է��� ����
        // Input.GetKey(KeyCode.W) Ű����� �� ���ھ��̵� ����. �ٵ� Ű�ڵ�� ��ü����

        float inputX = Input.GetAxis("Horizontal"); // -1 ~ +1   ���̽�ƽ�� ���� bool �ƴ� ����
                                                    // "Horizontal" : <- ->�� a d�� �Ҵ�Ǿ�����   A<- -1 0 1  ->D
        float inputZ = Input.GetAxis("Vertical");

        // AddForce ���� ���ǵ带 �ٷ� �������ֱ�
        float fallSpeed = playerRigidbody.velocity.y;
 
        Vector3 velocity = new Vector3(inputX, 0, inputZ);

        velocity = velocity * speed;

        velocity.y = fallSpeed;

        // (inputX* speed, fallSpeed, inputZ* speed)
        playerRigidbody.velocity = velocity;

    }
}
