using UnityEngine;

public class ICrashable : MonoBehaviour
{
    [SerializeField] private int damage;


    
     private void Start()
    {
        LevelManager.singleton.OccupySpot(transform);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CrashWithPlayer(collision.gameObject.GetComponent<LanchaManager>());
        }
    }
    
    public virtual void CrashWithPlayer(LanchaManager lancha)
    {
        lancha.genteManager.Crash(damage);
    }
}
