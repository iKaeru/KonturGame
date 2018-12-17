using Microsoft.Xna.Framework.Graphics;

namespace Sokoban
{
    public class DrawController
    {
        public void DrawScene(SpriteBatch spriteBatch, Background background, Robot robot)
        {
            spriteBatch.Begin();
            background.Draw(spriteBatch);
            robot.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}