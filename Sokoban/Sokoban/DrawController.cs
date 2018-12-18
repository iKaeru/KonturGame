using System;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban
{
    public class DrawController
    {
//        private IGameElement[,] map;
        
        public IGameElement[,] CreateMap(string path)
        {
            var result = new IGameElement
            [Constants.WindowHeight / Constants.FieldCellHeight,
                Constants.WindowWidth / Constants.FieldCellWidth];

//            Console.WriteLine(Directory.GetCurrentDirectory());
//            Console.WriteLine(Environment.CurrentDirectory);
//            string projectPath = Path.Combine(Environment.CurrentDirectory, path);
            string projectPath = Path.Combine("/Users/kaeru/GitHub/Sokoban/Sokoban/Sokoban/", path);
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

            return result;
        }

        private void CreateElementBySymbol(IGameElement[,] array, char symbol, int row, int column)
        {
            switch (symbol)
            {
                case '*':
                    array[row, column] = new Robot(Constants.RobotTexture);
                    break;
                case '|':
                    array[row, column] = new Wall(Constants.WallTexture);
                    break;
                case '#':
                    array[row, column] = new Box(Constants.BoxTexture);
                    break;
                case 'X':
                    array[row, column] = new BoxPlace(Constants.BoxPlaceTexture);
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

            Constants.background.Draw(spriteBatch, 0, 0);
            
            string[] path = {"Content", "Levels", "Level_1.txt"};
            var elements = CreateMap(Path.Combine(path));
            
            for (var i = 0; i < elements.GetLength(1); i++)
            {
                for (var j = 0; j < elements.GetLength(0); j++)
                {
                    if (elements[j, i] != null)
                    {
                        elements[j, i].Draw(spriteBatch, i * Constants.FieldCellWidth,
                            j * Constants.FieldCellHeight);
                    }
                }
            }

            spriteBatch.End();
        }
    }
}