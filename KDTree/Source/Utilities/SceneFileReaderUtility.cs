using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KDTree
{
    public class SceneFileReaderUtility
    {
        public static BoundingBox GetSceneBoundingBox(string sceneFilePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(sceneFilePath);

                BoundingBox boxToReturn = new BoundingBox(new Point(0, 1000), 1000, 1000);

                foreach (var line in lines)
                {
                    string[] data = line.Split(' ');
                    string shapeName = data[0];
                    if (data[1] == "circle")
                    {
                        float x = float.Parse(data[2]);
                        float y = float.Parse(data[3]);
                        float radius = float.Parse(data[4]);

                        Circle newCircle = new Circle(shapeName, new Point(x, y), radius);
                        boxToReturn.Shapes.Add(newCircle);
                    }
                    else
                    if (data[1] == "rect")
                    {
                        float x = float.Parse(data[2]);
                        float y = float.Parse(data[3]);
                        float width = float.Parse(data[4]);
                        float hight = float.Parse(data[5]);

                        Rectangle newRectangle = new Rectangle(shapeName, new Point(x, y), width, hight);
                        boxToReturn.Shapes.Add(newRectangle);
                    }
                    else
                    {
                        throw new InvalidSceneFileException("The file contains invalid shape.");
                    }
                }

                return boxToReturn;
            }
            catch (Exception e)
            {
                throw new InvalidSceneFileException("The file contains invalid data.");
            }
        }
    }
}
