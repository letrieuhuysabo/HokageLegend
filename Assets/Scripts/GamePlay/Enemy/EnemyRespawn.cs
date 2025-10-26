using System.Threading.Tasks;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    Vector3 startPos;

    public Vector3 StartPos { get => startPos; set => startPos = value; }
    void Start()
    {
        startPos = transform.position;
    }
    public async void Respawn()
    {
        await Task.Delay((int)(Configs.timeToRespawnEnemy * 1000));
        gameObject.SetActive(true);
        transform.position = startPos;
    }
}
