using Path_Finding_Visualizer.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Path_Finding_Visualizer.VisualizingLogic.Algortihms
{
    internal class PathFindingAlgorithm
    {
        private static Task animationTask;
        private static CancellationTokenSource cts;
        private static CancellationToken ct;

        private static async Task AnimateVisitedNodes(List<Node> visitedNodesInOrder, double delayInMilliseconds)
        {
            foreach(Node n in visitedNodesInOrder)
            {
                ct.ThrowIfCancellationRequested();
                MainGrid.SetNodeState(n, NodeState.Visited);
                await Task.Delay(TimeSpan.FromMilliseconds(delayInMilliseconds));
            }
        }

        private static async Task AnimateShortestPath(List<Node> shortestPathNodesInOrder, double delayInMilliseconds)
        {
            foreach (Node n in shortestPathNodesInOrder)
            {
                ct.ThrowIfCancellationRequested();
                MainGrid.SetNodeState(n, NodeState.ShortestPath);
                await Task.Delay(TimeSpan.FromMilliseconds(delayInMilliseconds));
            }
        }

        public static void StartAnimation()
        {
            IPathFindingAlgorithm algorithm = new Dijkstra();
            List<Node> visitedNodesInOrder = algorithm.GetVisitedNodesInOrder();
            List<Node> shortestPathNodesInOrder = algorithm.GetShortestPathNodesInOrder();

            int delay = 10;
            cts = new CancellationTokenSource();
            ct = cts.Token;

            animationTask = Task.Run(() =>
            {
                Application.Current.Dispatcher.Invoke(async () =>
                {
                    Task animateVisitedNodesTask = PathFindingAlgorithm.AnimateVisitedNodes(visitedNodesInOrder, delay);
                    await animateVisitedNodesTask;
                    Task animateShortestPathNodesTask = PathFindingAlgorithm.AnimateShortestPath(shortestPathNodesInOrder, delay / 3);
                    await animateShortestPathNodesTask;
                    MainWindow.mainMenu.PlayPauseButtonClicked();
                });
            }, cts.Token);
        }

        public static void PauseAnimation()
        {
        }

        public static void ResumeAnimation()
        {
        }

        public static void StopAnimation()
        {
            cts.Cancel();
        }

        public static int Distance(Coordinate pos1, Coordinate pos2)
        {
            return Math.Abs(pos1.x - pos2.x) + Math.Abs(pos1.y - pos2.y);
        }
    }
}