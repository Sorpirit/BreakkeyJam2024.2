using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class LockToGrid : MonoBehaviour
{
    public int tilesize = 1;
    public Vector3 tileOffSet = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        if (EditorApplication.isPlaying) {
            Vector3 currentPos = transform.position;
            float snappedX = Mathf.Round(currentPos.x/ tilesize) * tilesize + tileOffSet.x;
            float snappedZ = Mathf.Round(currentPos.z / tilesize) * tilesize + tileOffSet.z;
            float snappedY = tileOffSet.y;

            Vector3 snappedPosition = new Vector3(snappedX, snappedY, snappedZ);
            transform.position = snappedPosition;
        }
    }
}
