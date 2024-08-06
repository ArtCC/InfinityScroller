using UnityEngine;

public class Scroll : MonoBehaviour {
    [SerializeField] private float velocityScroll;

    void Update() {
        transform.Translate(Vector2.left * Time.deltaTime * velocityScroll);
    }

    public void StopScroll() {
        velocityScroll = 0;
    }
}
