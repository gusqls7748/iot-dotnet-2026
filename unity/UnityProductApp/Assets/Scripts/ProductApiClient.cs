using NUnit.Framework;
using System.Collections;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using Newtonsoft.Json;

public class ProductApiClient : MonoBehaviour
{
    //[SerializeField]
    //private TMP_Text txtLog;

    [SerializeField]
    private string serviceUrl = "http://localhost:5179/api/products";

    [SerializeField]
    private Transform content;

    [SerializeField]
    private ProductRowUi productRowPrefab;

    public void LoadProducts()
    {
        StartCoroutine(GetProducts());
    }

    private IEnumerator GetProducts()
    {
        using UnityWebRequest request = UnityWebRequest.Get(serviceUrl);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(request.error);
            yield break;
        }

        string json = request.downloadHandler.text;
        List<Product> products = JsonConvert.DeserializeObject<List<Product>>(json);

        // 1. ClearRows()를 먼저 호출해서 이전 목록을 비워야 합니다.
        ClearRows();

        foreach (Product item in products)
        {
            Debug.Log($"{item.productId}/{item.productName}/{item.Price}/{item.Stock}");

            // 1. 유니티 내장 Instantiate 사용
            ProductRowUi row = Instantiate(productRowPrefab, content);

            // 2. [수정] products(리스트 전체)가 아니라 item(개별 상품)을 전달합니다.
            row.SetData(item);
        }
    }

    // 3. ClearRows 메서드 추가 (필수)
    private void ClearRows()
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }
    }
}