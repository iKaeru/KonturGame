using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban
{
    public class DrawController
    {
        public void DrawScene(SpriteBatch spriteBatch, Background background, Robot robot,
            Box box, BoxPlace boxPlace)
        {
            spriteBatch.Begin();
            background.Draw(spriteBatch);
            robot.Draw(spriteBatch);
            boxPlace.Draw(spriteBatch);
            box.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}