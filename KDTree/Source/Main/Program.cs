using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KDTree
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                string filePath;

                if (args.Length > 0)
                {
                    filePath = args[0];
                }
                else
                {
                    filePath = Console.ReadLine();
                }

                BoundingBox sceneBoundingBox = SceneFileReaderUtility.GetSceneBoundingBox(filePath);
                Console.WriteLine("Scene bounding box ready...");

                KDTreeNode rootNode = KDTreeBuildUtility.BuildKdTree(sceneBoundingBox, 0);
                Console.WriteLine("Scene kd tree box ready...");

                UserMessaging messagingAgent = new ConsoleUserMessaging();

                const string TERMINATION_COMMAND = "exit";

                Application.Run(new GraphicsWindow(sceneBoundingBox.Shapes));

                while (true)
                {
                    string command = Console.ReadLine();

                    if (command == TERMINATION_COMMAND)
                    {
                        break;
                    }

                    string[] cordinates = command.Split(' ');
                    if (cordinates.Length > 2)
                    {
                        Console.WriteLine("Invalid point coordinates.");
                    }
                    else
                    {
                        float x = float.Parse(cordinates[0]);
                        float y = float.Parse(cordinates[1]);

                        KDTreeIntersectionUtility.IntersectTree(rootNode, new Point(x, y), messagingAgent);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}
