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

        // ���C�L���X�g���s���A�����ɂ���I�u�W�F�N�g�𔻒�
        if (Physics.Raycast(ray, out hit, _detectionRange))
        {
            // �A�C�e���^�O�����I�u�W�F�N�g���ǂ����𔻒�
            if (hit.transform.TryGetComponent(out Item item))
            {
                return item;
            }
        }
        return null;
    }
}
