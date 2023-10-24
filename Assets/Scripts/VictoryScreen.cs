using UnityEngine;

public class VictoryScreen : MonoBehaviour
{
   [SerializeField] private GameObject victoryPanel;
    public static VictoryScreen instance; // Esta vari�vel deve ser atribu�da no Inspector.

    private void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        // Certifique-se de que o painel de vit�ria est� desativado no in�cio do jogo.
        victoryPanel.SetActive(false);
    }
    
    public void ShowVictoryScreen()
    {
        // Ative o painel de vit�ria quando o jogador vencer.
        victoryPanel.SetActive(true);
    }

    public void HideVictoryScreen()
    {
        // Desative o painel de vit�ria quando o jogador quiser reiniciar o jogo, por exemplo.
        victoryPanel.SetActive(false);
    }
}
