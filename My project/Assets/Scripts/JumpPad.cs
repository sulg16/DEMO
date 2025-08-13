using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] float jumpImpulse = 12f;          // ���� ��
    [SerializeField] bool usePadUpDirection = true;    // �е� ������ �������� ����
    [SerializeField] string targetTag = "Player";      // �÷��̾� �±�

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(targetTag)) return;

        var rb = other.attachedRigidbody;
        if (rb == null) return;

        // ���� ���� �ӵ� ����
        var v = rb.velocity;
        v.y = Mathf.Max(0f, v.y);
        rb.velocity = v;

        // ���� ����
        Vector3 dir = usePadUpDirection ? transform.up : Vector3.up;

        // ���� �� �ֱ�
        rb.AddForce(dir.normalized * jumpImpulse, ForceMode.Impulse);

        Debug.Log("UP ~! ");
    }


}
