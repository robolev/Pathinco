using Pathinco;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

public class BallSpawner
{
    private RectangleShape spawnPointShape;

    public BallSpawner()
    {
        spawnPointShape = new RectangleShape(new Vector2f(10f, 10f)) { FillColor = Color.Yellow };
    }

    public void HandleInput(Keyboard.Key key)
    {
        if (key == Keyboard.Key.Left)
        {
            MoveSpawnPoint(-10f, 0f);
        }
        else if (key == Keyboard.Key.Right)
        {
            MoveSpawnPoint(10f, 0f);
        }
        else if (key == Keyboard.Key.Space)
        {
            Vector2f spawnPoint = spawnPointShape.Position;
            SpawnBall(spawnPoint);
        }
    }

    private void MoveSpawnPoint(float offsetX, float offsetY)
    {
        Vector2f currentSpawnPoint = spawnPointShape.Position;
        spawnPointShape.Position = currentSpawnPoint + new Vector2f(offsetX, offsetY);
    }

    private void SpawnBall(Vector2f position)
    {
        Vector2f velocity = new Vector2f(100f, 0f); 
        Ball ball = new Ball(10f,new Vector2f(0,0), Color.Blue, position, true);
        Game.PhysicalComponents.Add(ball);
    }

    public void DrawSpawnPoint(RenderWindow window)
    {
        window.Draw(spawnPointShape);
    }
}