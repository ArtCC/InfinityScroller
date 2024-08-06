using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {
    [SerializeField] private GameObject explosionPrefab, starParticlesPrefab;

    private int obstaclePoints = 1;

    private void OnCollisionEnter2D(Collision2D collision) {
        GameManager.Instance.StopGame();
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Star star = collision.gameObject.GetComponent<Star>();

        if (star != null) {
            GameManager.Instance.AddScore(star.GetPoints());
            Instantiate(starParticlesPrefab, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Obstacle")) {
            GameManager.Instance.AddScore(obstaclePoints);
        }
    }
}