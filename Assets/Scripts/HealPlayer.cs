using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    [SerializeField]
    private int healAmount = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has been healed!");
            other.GetComponent<PlayerHealth>().Heal(healAmount);
        }
    }
}
