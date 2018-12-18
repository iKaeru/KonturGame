using Microsoft.Xna.Framework.Graphics;

namespace Sokoban
{
    public class DrawController
    {
        public static IGameElement[,] CreateMap(string map, string separator = "\r\n")
        {
            //public static ICreature[,] Map;
            //Map.CreateMap
            return new IGameElement[0,0];
        }

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