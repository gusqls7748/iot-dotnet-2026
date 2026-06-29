using System;
using TMPro;
using UnityEngine;

public class ProductRowUi : MonoBehaviour
{
    [SerializeField] private TMP_Text txtProductId;
    [SerializeField] private TMP_Text txtProductName;
    [SerializeField] private TMP_Text txtCategory;
    [SerializeField] private TMP_Text txtPrice;
    [SerializeField] private TMP_Text txtStock;
    [SerializeField] private TMP_Text txtCreatedAt;

    public void SetData(Product product)
    {
        txtProductId.text = product.productId.ToString();
        txtProductName.text = product.productName;
        txtCategory.text = product.category;
        txtPrice.text = $"{product.Price:NO}원";
        txtStock.text = $"{product.Stock:NO}";
        txtCreatedAt.text = product.createdAt.ToString();
    }

    internal void SetData(object product)
    {
        throw new NotImplementedException();
    }
}
