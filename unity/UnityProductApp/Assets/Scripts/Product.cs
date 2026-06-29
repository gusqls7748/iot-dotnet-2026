using System;
using UnityEngine;

[Serializable]
public class Product
{
    /*
     *  product_id INT NOT NULL AUTO_INCREMENT Primary Key,
        product_name VARCHAR(100) NOT NULL,
        category VARCHAR(50) NULL,
        price DECIMAL(10,0) NOT NULL,
        stock INT NOT NULL,
        created_at DATETIME
     */
    public int productId { get; set; }
    public string productName { get; set; }

    // ? nullable
    public string category { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public DateTime createdAt { get; set; }
}
