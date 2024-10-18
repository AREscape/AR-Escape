using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.ARFoundation;

public class QuizManager : MonoBehaviour
{

    public GameObject keyPadObject;
    public Vector2 spawnAreaSize = new Vector2(10f, 10f); // 객체가 생성될 최대 크기 (x, z)
    public float moveRadius = 2f; // 이동 반경

    private void Start()
    {
        keyPadObject.GetComponent<Transform>().Translate(new Vector3(Random.Range(0, 5) * ((Random.Range(0, 2) % 2 == 0) ? -1 : 1),
            keyPadObject.GetComponent<Transform>().position.y,
            Random.Range(0, 5) * ((Random.Range(0, 2) % 2 == 0) ? -1 : 1)));

    }
}
