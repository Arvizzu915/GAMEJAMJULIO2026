using UnityEngine;

public class ICrashable : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] AudioSource rock;


    
     private void Start()
    {
        LevelManager.singleton.OccupySpot(transform);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rock.Play();
            CrashWithPlayer(collision.gameObject.GetComponent<LanchaManager>());
        }
    }
    
    public virtual void CrashWithPlayer(LanchaManager lancha)
    {
        lancha.genteManager.Crash(damage);
    }
}
