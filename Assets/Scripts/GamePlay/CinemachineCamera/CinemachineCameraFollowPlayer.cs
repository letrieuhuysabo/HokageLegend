using System.Threading.Tasks;
using Unity.Cinemachine;
using UnityEngine;

public class CinemachineCameraFollowPlayer : MonoBehaviour
{
    async void Start()
    {
        await Task.Yield();
        // GameObject player = GameObject.Find("Player")
        CameraTarget cameraTarget = new CameraTarget();
        cameraTarget.TrackingTarget = GameObject.Find("Player").transform.GetChild(0);
        GetComponent<CinemachineCamera>().Target = cameraTarget;
    }
}
