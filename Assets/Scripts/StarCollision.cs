using UnityEngine;

public class StarCollision : MonoBehaviour {
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Destroy")) {
            Destroy(gameObject);
        }
    }
}