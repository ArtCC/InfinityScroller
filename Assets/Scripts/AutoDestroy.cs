using UnityEngine;

public class AutoDestroy : MonoBehaviour {
    private float destroyTime = 2;
    
    void Start() {
        Destroy(gameObject, destroyTime);
    }
}