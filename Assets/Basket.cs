using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;

    // Start is called before the first frame update
    void Start()
    {
        // �������� ������ �� ������� ������ ScoreCounter
        GameObject scoreGo = GameObject.Find("ScoreCounter");
        // �������� ��������� Text ����� �������� �������
        scoreGT = scoreGo.GetComponent<Text>();
        // ���������� ���������� ��������
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        // �������� ������� ���������� ��������� ���� �� ������ �� Input
        Vector3 mousePos2D = Input.mousePosition;

        // ���������� z ������ ����������, ��� ������ � ���������� ������������ ��������� ��������� ����
        mousePos2D.z = -Camera.main.transform.position.z;

        // ������������� ����� �� ��������� ��������� ������ � ���������� ���������� ����
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // ����������� ������� ����� ��� X � ���������� X ��������� ����
        Vector3 pos = transform.position;
        pos.x = mousePos3D.x;
        transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �������� ������, �������� � ��� �������
        GameObject collidedWidth = collision.gameObject;
        if (collidedWidth.tag == "Apple")
        {
            Destroy(collidedWidth);

            // ������������� ����� ScoreGT � ����� �����
            int score = int.Parse(scoreGT.text);
            // �������� ���� �� ��������� ������
            score += 100;
            scoreGT.text = score.ToString();

            // ��������� ������ ����������
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}
