using UnityEngine;

public class VictoryScreen : MonoBehaviour
{
   [SerializeField] private GameObject victoryPanel;
    public static VictoryScreen instance; // Esta variável deve ser atribuída no Inspector.

    private void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        // Certifique-se de que o painel de vitória está desativado no início do jogo.
        victoryPanel.SetActive(false);
    }
    
    public void ShowVictoryScreen()
    {
        // Ative o painel de vitória quando o jogador vencer.
        victoryPanel.SetActive(true);
    }

    public void HideVictoryScreen()
    {
        // Desative o painel de vitória quando o jogador quiser reiniciar o jogo, por exemplo.
        victoryPanel.SetActive(false);
    }
}
