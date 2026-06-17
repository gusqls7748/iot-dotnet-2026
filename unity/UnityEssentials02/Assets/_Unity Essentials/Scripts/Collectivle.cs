using UnityEngine;

public class Collectable : MonoBehaviour
{
    [Header("회전 설정")]
    [Tooltip("프레임당 회전 속도")]
    [Range(0, 10)]
    public float rotationSpeed = 0.5f;

    [Tooltip("아이템 획득시 이펙트 지정")]
    public GameObject collectEffect;

    [Header("이펙트 사운드")]
    public AudioClip pickupSound;

    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 이펙트가 지정되어 있는지 확인 후 생성
            if (collectEffect != null)
            {
                Instantiate(collectEffect, transform.position, transform.rotation);
            }

            // 사운드가 지정되어 있는지 확인 후 재생
            if (pickupSound != null)
            {
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            }

            Destroy(gameObject);
        }
    } // <-- 이 괄호가 OnTriggerEnter를 닫습니다.
} // <-- 이 괄호가 클래스 전체를 닫습니다.