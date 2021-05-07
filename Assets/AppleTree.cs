using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Unspector")]
    // Шаблон для создания яблок
    public GameObject applePrefab;

    // Скорость движения яблони
    public float speed = 1f;

    // Расстояние, на котором должно измениться направление движения яблони
    public float leftAndRightEdge = 10f;

    // Вероятность случайного изменения направления движения
    public float chanceToChangeDirections = 0.1f;

    // Частота создания экземпляров яблок
    public float secondsBetweenAppleDrops = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // Сбрасывать яблоки паз в секунду
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
        // Простое перемещение
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Изменение направления
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }

    void FixedUpdate()
    {
        // Теперь случайная смена направления привязана ко времени,
        // потому что выполняется в FixedUpdate()
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
}
