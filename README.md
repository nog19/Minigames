# Jogo — Coletar / Evitar objetos (Unity)

Resumo
---- -
Projeto Unity simples: o jogador move-se horizontalmente (invertendo direção ao clicar/tocar) e deve coletar objetos de vida ou evitar objetos que causam dano. Objetos caem do topo gerados por um spawner que aumenta a dificuldade ao longo do tempo. Há telas de Game Over e um cronômetro/contador de tempo.

Como usar (rápido)
------------------
1. Abra a cena principal no Unity (por exemplo `Main` ou `Game`).
2. Verifique os GameObjects principais e suas configurações (veja "Configuração" abaixo).
3. Execute o jogo no Editor (Play). Clique ou toque para inverter a direção do jogador.

Controles
---------
- Clique / Toque (botão esquerdo do mouse / tela): inverte a direção do jogador.

Configuração (GameObjects e tags importantes)
---------------------------------------------
Tags necessárias:
- `Player` — jogador.
- `Wall` — paredes que invertem a direção quando colididas.
- `Dano` — objetos que causam dano.
- `Vida` — objetos que dão vida.
- `chao` — chão (usado por `DestruirNoChao` para destruir objetos que tocam o chão).

Componentes / Scripts principais
-------------------------------
- Cronometro.cs
  - Mostra tempo em um `TextMeshProUGUI`.
  - Chamado por `Jogador.GameOver()` para parar o tempo quando terminar.
- TempoController.cs
  - Alternativa simples que usa `UnityEngine.UI.Text`. (Escolher uma solução de timer para evitar duplicação.)
- Jogador.cs
  - Controla movimento constante (velocidade e inversão ao clicar).
  - Gerencia `vidas`, colisões com `Wall`, `Dano`, `Vida`.
  - Em `GameOver()` pausa o tempo (`Time.timeScale = 0`) e ativa `painelGameOver`.
- VidaDoPlayer.cs
  - Singleton (`VidaDoPlayer.instance`) que também gerencia vida e Game Over (pausa e ativa `telaGameOver`).
  - OBS: há sobreposição de responsabilidades com `Jogador.vidas` — escolher qual sistema usar.
- VidaUI.cs
  - Atualiza texto de vidas (usa `Jogador.vidas` no código atual).
- ObjectSpawner.cs
  - Instancia objetos de um array (`objetos`) em intervalos que diminuem com o tempo (aumentando a dificuldade).
  - Ajustar `intervaloInicial`, `dificuldadeIncremento`, `tempoEntreDificuldade`.
- ObjetoQueCai.cs
  - Ao colidir com o `Player` chama `VidaDoPlayer` (ganhar/perder vida) e destrói o objeto.
- DestruirNoChao.cs
  - Destroi o objeto ao colidir com o `chao`.
- UIController.cs
  - Reinicia a cena (restaura `Time.timeScale = 1`).

Recomendações / Observações importantes
--------------------------------------
- Unificar o sistema de vidas:
  -Atualmente existem duas abordagens conflituosas:
    - `Jogador.vidas` (gerencia colisões e GameOver).
    - `VidaDoPlayer` (singleton que também gerencia vida e GameOver).
  - Recomendo escolher uma abordagem (por exemplo, usar apenas `VidaDoPlayer` e remover o gerenciamento de GameOver de `Jogador`, ou manter `Jogador` como fonte única de verdade) e atualizar `VidaUI` para referenciar corretamente a fonte de verdade.
- Timer duplicado:
  - `Cronometro.cs` (TextMeshPro)e `TempoController.cs` (Unity UI Text) estão ambos implementando timers. Remova ou combine conforme necessário.
- README.cs
  - O arquivo `README.cs` no projeto é apenas um MonoBehaviour vazio. Substitua-o por este `README.md` e remova `README.cs` do build/Assets para evitar confusão.
- Pausa do jogo:
  -Ao chamar GameOver o código seta `Time.timeScale = 0f`. Certifique-se de restaurar para `1f` antes de reiniciar a cena.

Configurações sugeridas no Editor
--------------------------------
- Player:
  -Tag: `Player`
  - Componentes: `Rigidbody2D` (com `Gravity Scale = 0` se não quiser cair), `Collider2D`, script `Jogador`.
- Spawner:
  -Posicione o `ObjectSpawner` no topo da cena (y alto) e ajuste `largura` ou o cálculo de x para se adaptar à sua câmera.
  - Adicione prefabs com componentes `Collider2D` e `Rigidbody2D` (se necessário) e as tags `Dano` ou `Vida`.
- UI:
  -Painel Game Over: atribua em `Jogador.painelGameOver` ou `VidaDoPlayer.telaGameOver`.
  - `Cronometro.textoTempo` (TextMeshProUGUI) deve ser atribuído no inspetor.
  - `VidaUI.textoVidas` (TextMeshProUGUI) deve ser atribuído e `jogador` referenciado.

Problemas conhecidos / TODO
--------------------------
- Duplicidade de gestão de vidas e GameOver (ver "Recomendações").
- Remover `README.cs` e substituir por `README.md`.
- Ajustar o cálculo de largura no `ObjectSpawner` para usar a largura da câmera (em vez de valor fixo 3f).
- Considerar pooling de objetos para melhorar performance em vez de Instantiate/Destroy contínuos.
- Melhorar tratamento de colisões (usar tags com constantes ou enums para evitar strings mágicas espalhadas).

Como contribuir
---------------
- Faça um fork, crie uma branch, corrija/una os sistemas (vidas/timer), e abra um pull request descrevendo a mudança.
- Testes manuais: execute a cena, simule colisões e verifique se o Game Over e UI funcionam conforme esperado.

Licença
-------
Escolha e adicione uma licença apropriada (por exemplo MIT) se for publicar.

Contato
-------
Se precisar que eu ajuste o README.md mais (ex.: traduzir para inglês, incluir imagens, ou adicionar instruções de build/export), diga o que quer que eu inclua e eu atualizo.
