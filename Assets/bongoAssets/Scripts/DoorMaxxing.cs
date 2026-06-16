using UnityEngine;

public class DoorMaxxing : MonoBehaviour
{
    private CollectionEffect collectionEffect;
    private int totalPoints;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        totalPoints = GameObject.FindGameObjectsWithTag("Point").Length;
        collectionEffect = FindObjectOfType<CollectionEffect>();
        if (collectionEffect != null)
        {
            print("Total points in the scene: " + totalPoints);
        }
        else
        {
            Debug.LogWarning("DoorMaxxing could not find a CollectionEffect in the scene.");
        }
    }

    // Update is called once per frame

    private void PlayExplodeAudio(GameObject pickup)
    {
        AudioSource sound = pickup.GetComponent<AudioSource>();
        if (sound != null && sound.clip != null)
        {
            AudioSource.PlayClipAtPoint(sound.clip, pickup.transform.position);
        }
    }
    void Update()
    {
        // check if the player has collected all the points in the scene by comparing it with the "points" variable from collectioneffect
        if (collectionEffect != null && collectionEffect.points >= totalPoints)
        {
            // if the player has collected all the points, destroy the door
            PlayExplodeAudio(gameObject);
            Destroy(gameObject);
            print("All points collected! Door destroyed.");
        }
    }
}
