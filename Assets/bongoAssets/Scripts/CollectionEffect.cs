using UnityEngine;

public class CollectionEffect : MonoBehaviour
{
    public int points = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            points++;
            Destroy(other.gameObject);
        }
    }
}
