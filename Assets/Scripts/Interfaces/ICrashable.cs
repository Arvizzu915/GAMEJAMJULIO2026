using UnityEngine;

public class ICrashable : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("crah");

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
