# DodgeBoy

Proyecto de videojuego 2D desarrollado en Unity como parte de una asignatura de la **Universidad de Tarapacá (UTA)**.

## Descripción del juego
DodgeBoy es un juego de supervivencia donde el jugador debe **esquivar escombros** que caen continuamente desde la parte superior de la pantalla.

- El personaje se mueve horizontalmente.
- Los escombros aparecen en posiciones aleatorias.
- La dificultad aumenta con el tiempo (los escombros caen con mayor frecuencia).
- El puntaje crece mientras sobrevives.
- El juego termina cuando la vida del jugador llega a 0.

### Escenas principales
- `MainMenu`: menú principal, inicio del juego y ajustes.
- `GameScene`: gameplay principal.

### Controles
- `A / D` o flechas izquierda/derecha: mover personaje.
- `Esc`: pausar/reanudar partida.

## Tecnologías usadas
- **Unity** `6000.1.6f1`
- **C#**
- **TextMeshPro**
- **URP (Universal Render Pipeline)**
- **Unity Input System**

## Estructura del proyecto
Para mantener compatibilidad con Unity, el repositorio conserva estas carpetas clave:

- `Assets/`
- `Packages/`
- `ProjectSettings/`

## Instrucciones para correr el proyecto
1. Instalar **Unity Hub**.
2. Instalar el editor **Unity 6000.1.6f1**.
3. Clonar este repositorio:
   ```bash
   git clone https://github.com/iOrellanaDECK/DodgeBoyGame.git
   ```
4. Abrir Unity Hub → **Add project** → seleccionar la carpeta del proyecto.
5. Abrir la escena `Assets/Scenes/MainMenu.unity` o ejecutar desde la escena cargada.
6. Presionar **Play** en el editor.

## Nota de portafolio
Este proyecto fue desarrollado en contexto académico para una asignatura de la **Universidad de Tarapacá (UTA)** y se publica con fines de portafolio personal.
