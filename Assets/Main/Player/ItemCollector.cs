using System;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField]
    private float _detectionRange = 5f;
    [SerializeField]
    private GameObject _actionHint;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        var item = DetectItemInCenter();

        _actionHint.SetActive(item != null);

        if (item != null && Input.GetKeyDown(KeyCode.Space))
        {
            item.Collect();
        }
    }

    private Item DetectItemInCenter()
    {
        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        RaycastHit hit;

        // レイキャストを行い、中央にあるオブジェクトを判定
        if (Physics.Raycast(ray, out hit, _detectionRange))
        {
            // アイテムタグを持つオブジェクトかどうかを判定
            if (hit.transform.TryGetComponent(out Item item))
            {
                return item;
            }
        }
        return null;
    }
}
