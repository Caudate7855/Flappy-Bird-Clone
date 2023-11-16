
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Mover))]
public class Bird : MonoBehaviour
{
    private Mover _mover;
    private int _score;

    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged; 

    private void Start()
    {
        _mover = GetComponent<Mover>();
    }

    public void IncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }
    
    public void ResetPlayer()
    {
        _score = 0;
        _mover.ResetBird();
        ScoreChanged?.Invoke(_score);
    }

    public void Die()
    {
        GameOver?.Invoke();
        Time.timeScale = 0;
    }
}
