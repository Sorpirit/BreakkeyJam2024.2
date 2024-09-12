using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class GearInstance : MonoBehaviour
{   
    //temp
    [SerializeField] private GameObject car;

    private void OnTriggerEnter(Collider other) {
        //for future scene with car
        /*if(other.gameObject.TryGetComponent(out CarObject car)) {

        }*/

        if (other.gameObject.Equals(car)) {
            Debug.Log("piip");
            Destroy(this.gameObject);
            ScoreManager.instance.AddPoint();
        }
    }

   


}
