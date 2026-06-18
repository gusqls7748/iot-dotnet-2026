using Unity.VisualScripting;
using UnityEngine; // 유니티 엔진 클래스

// MonoBehaviour C# 스크립트가 기본적으로 상속받는 핵심 클래스
// 개발자코드가 유니티 엔진과 인터렉티브하게 소통할 수 있도록
// 오브젝트에 컴포넌트로 연결, 동작 제어

public class ConveyorBelt : MonoBehaviour
{

    [Header("물체이동 방향")]
    public Vector3 moveDirection = Vector3.right;

    [Header("물체이동 속도")]
    public float speed = 2.0f;

    [Header("벨트 동작여부")]
    public bool isRunning = true;

    // 매 프레임 두 충돌영역이 접촉하고 있는 동안 발생 이벤트 핸들러
    // 매 프레임 두 충돌영역이 접촉하고 있는 동안 발생 이벤트 핸들러
    private void OnCollisionStay(Collision collision)
    {
        Rigidbody rb = collision.rigidbody; // 충돌 감지된 오브젝트 리지드바디 가져오기

        // ❌ 기존 오류: rb != null 이면 return -> rb가 있으면 작동을 안 하던 버그 수정
        if (rb == null) return;

        if (!isRunning)
        {
            // 멈췄을 때 Y축 중력은 유지하고 벨트 방향(X, Z) 속도만 0으로 만드는 것이 자연스럽습니다.
            Vector3 currentVel = rb.linearVelocity;
            rb.linearVelocity = new Vector3(0, currentVel.y, 0);
            return;
        }

        // 이동방향으로 속도만큼 이동 (Y축은 기존 물체의 물리 법칙을 따르도록 설정하는 것이 좋습니다)
        Vector3 targetVelocity = moveDirection.normalized * speed;
        rb.linearVelocity = new Vector3(targetVelocity.x, rb.linearVelocity.y, targetVelocity.z);
    }

    public void Stop()
    {
        isRunning = false;
    }

    public void StartBelt()
    {
        isRunning = true;
    }
}
