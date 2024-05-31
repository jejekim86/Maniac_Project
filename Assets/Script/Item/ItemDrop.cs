using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab; // ������ ������

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("������ ȹ��");
            ItemGet itemGet = other.GetComponent<ItemGet>();
            
            if (itemGet != null)
            {
                itemGet.ItemGet_Gun(other.gameObject);
            }

            Destroy(gameObject);
        }
    }
}