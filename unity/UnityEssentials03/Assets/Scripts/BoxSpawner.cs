using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [Header("프리팹 지정")]
    public GameObject prePrefab;

    [Header("생성 간격")]
    public float interval = 3.0f;

    float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;    // HW 성능별 FPS 고정

        if(timer >= interval)
        {
            timer = 0;

            // instant 예제, 샘플
            // Quaternion.identity 회전값 없는
            Instantiate(prePrefab,
                        transform.position, 
                        Quaternion.identity);

        }
    }
}
