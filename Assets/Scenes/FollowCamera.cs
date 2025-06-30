using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject thingToFollow;  // Reference to the car or object to follow

    // Follows the car in the game

    // Update is called once per frame
    private void LateUpdate() {
         transform.position = thingToFollow.transform.position + new Vector3(0, 0, -10);
       
    }
}
