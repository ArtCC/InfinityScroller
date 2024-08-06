using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float upForce;
    [SerializeField] private float bounds;

    private float yInput;
    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        yInput = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() {
        float newYPosition = rb.position.y + Vector2.up.y * upForce * yInput * Time.fixedDeltaTime;

        if (newYPosition <= bounds) {
            rb.AddForce(Vector2.up * upForce * yInput);
        }
    }
}
