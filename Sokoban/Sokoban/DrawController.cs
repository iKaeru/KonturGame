using System;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban
{
    public class DrawController
    {
        public IGameElement[,] Map;

        public void CreateMap(string path)
        {
            var result = new IGameElement
            [Constants.WindowHeight / Constants.FieldCellHeight,
                Constants.WindowWidth / Constants.FieldCellWidth];

            string projectPath = Path.Combine(Environment.CurrentDirectory, path);
            using (StreamReader sr = new StreamReader(projectPath))
            {
                string line;
                var row = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    var column = 0;
                    foreach (var symbol in line)
                    {
                        CreateElementBySymbol(result, symbol, row, column);
                        column++;
                    }

                    row++;
                }
            }

            Map = result;
        }

        private void CreateElementBySymbol(IGameElement[,] array, char symbol, int row, int column)
        {
            switch (symbol)
            {
                case '*':
                    array[row, column] = new Robot(Constants.RobotTexture,
                        column * Constants.FieldCellWidth, row * Constants.FieldCellHeight);
                    break;
                case '|':
                    array[row, column] = new Wall(Constants.WallTexture,
                        column * Constants.FieldCellWidth, row * Constants.FieldCellHeight);
                    break;
                case '#':
                    array[row, column] = new Box(Constants.BoxTexture,
                        column * Constants.FieldCellWidth, row * Constants.FieldCellHeight);
                    break;
                case 'X':
                    array[row, column] = new BoxPlace(Constants.BoxPlaceTexture,
                        column * Constants.FieldCellWidth, row * Constants.FieldCellHeight);
                    break;
                case ' ':
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public void DrawScene(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            Constants.background.Draw(spriteBatch);

            for (var i = 0; i < Map.GetLength(1); i++)
            {
                for (var j = 0; j < Map.GetLength(0); j++)
                {
                    if (Map[j, i] != null)
                    {
                        Map[j, i].Draw(spriteBatch);
                    }
                }
            }

            spriteBatch.End();
        }
    }
}