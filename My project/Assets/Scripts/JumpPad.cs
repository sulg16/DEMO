using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] float jumpImpulse = 12f;          // 점프 힘
    [SerializeField] bool usePadUpDirection = true;    // 패드 방향을 기준으로 점프
    [SerializeField] string targetTag = "Player";      // 플레이어 태그

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(targetTag)) return;

        var rb = other.attachedRigidbody;
        if (rb == null) return;

        // 기존 수직 속도 조정
        var v = rb.velocity;
        v.y = Mathf.Max(0f, v.y);
        rb.velocity = v;

        // 점프 방향
        Vector3 dir = usePadUpDirection ? transform.up : Vector3.up;

        // 점프 힘 주기
        rb.AddForce(dir.normalized * jumpImpulse, ForceMode.Impulse);

        Debug.Log("UP ~! ");
    }


}
