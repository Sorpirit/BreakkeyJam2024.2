using UnityEngine;

public class TargetWin : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;

    //temp
    [SerializeField] private GameObject car;
    void Start()
    {
        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    } 

    private void OnTriggerEnter(Collider other) {
        //for future scene with car
        /*if(other.gameObject.TryGetComponent(out CarObject car)) {

        }*/

        if (other.gameObject.Equals(car)) { 
            winScreen.SetActive(true);
        }
  
    }

}
