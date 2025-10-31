using UnityEngine;

public class KeyController : MonoBehaviour
{

    ChestController Chest;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Chest = GetComponentInParent<ChestController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            EffectManager.Instance.AddExplosion(transform.position);
            Chest.isOpening = true;
            GameObject.Destroy(gameObject);
        }
    }
}
