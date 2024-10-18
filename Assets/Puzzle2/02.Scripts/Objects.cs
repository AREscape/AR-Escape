using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    public enum Type { Object, Key, Item };
    public Type objectType;
    public enum SpawnPositionType { Fixed, NotFixed };
    public SpawnPositionType positionType;

    public string objectname; //이름
    public List<string> objectExp; //설명

    public bool ignore; //상호작용이 끝났으면 입력을받지않는다
    public float spawnRange = 2f; // 생성할 범위 반경
    private float raycastDistance = 1f; // 레이캐스트를 쏠 거리
    //private void Start()
    //{
    //    if (positionType == SpawnPositionType.NotFixed)
    //    {
    //        Vector3 randomOffset = new Vector3(Random.Range(-spawnRange, spawnRange), 0f, Random.Range(-spawnRange, spawnRange));
    //        Vector3 spawnPosition = ARObjectSpawner.instance.pos.position + randomOffset;
    //        transform.position = spawnPosition;

    //        // 모든 물체를 감지하여 충돌 여부를 확인
    //        Collider[] colliders = Physics.OverlapSphere(transform.position, raycastDistance, LayerMask.GetMask("Parent"));

    //        // 감지된 물체들과의 충돌을 확인하여 위치를 조정
    //        foreach (Collider collider in colliders)
    //        {
    //            if (collider.gameObject != gameObject)
    //            {
    //                Vector3 direction = collider.gameObject.transform.position - transform.position;
    //                float overlapDistance = raycastDistance - direction.magnitude;

    //                if (overlapDistance > 0)
    //                {
    //                    transform.position -= direction.normalized * overlapDistance;
    //                }
    //            }
    //        }

    //    }
    //}

    public void IgnoreObject() //마우스입력안받게
    {
        ignore = true;
    }
    public void TextChange(string[] text)
    {
        objectExp.Clear();
        for (int i = 0; i < text.Length; i++)
        {
            objectExp.Add(text[i]);
        }
    }
}
