using UnityEngine;

public class CollectionEffect : MonoBehaviour
{
    public int points = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            points++;
            print("Points collected: " + points);
            AudioSource sound = other.GetComponent<AudioSource>();
            if (sound != null)
            {
                sound.Play();
            }
            // destroy after clip length to allow sound to play
            Destroy(other.gameObject, sound.clip.length); 
        }

        else if (other.gameObject.CompareTag("Speed"))
        {
            // Handle speed power-up logic
            Destroy(other.gameObject);
        }
    }
}
