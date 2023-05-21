namespace Pryuf1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string Graph = new("Graph.txt");
            string[] mas = new string[Graph.Length];
            mas = File.ReadAllLines(Graph);
            string[,] fileGraph = new string[mas.Length, mas.Length];
            int sh = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                string[] tmp = mas[i].Split(";");
                for (int j = 0; j < tmp.Length; j++)
                {
                    fileGraph[i, j] = tmp[j];
                    sh++;
                }
                for (int j = 0; j < mas.Length; j++)
                {
                    if (fileGraph[i, j] == null) fileGraph[i, j] = "0";
                }
            }

            string codePruf = $"";


            while (codePruf.Length <= sh - 2)
            {
                int[] chisl = new int[mas.Length];
                int indexchislI = 0;
                int indexchislJ = 0;
                int minchisl = int.MaxValue;
                int newPruf = 0;

                for (int i = 0; i < mas.Length; i++)
                {
                    for (int j = mas.Length - 1; j >= 1; j--)
                    {
                        if (Convert.ToInt32(fileGraph[i, j]) != 0)
                        {
                            chisl[i] = Convert.ToInt32(fileGraph[i, j]);
                            if (chisl[i] < minchisl)
                            {
                                minchisl = chisl[i];
                                indexchislI = i;
                                indexchislJ = j;
                                newPruf = Convert.ToInt32(fileGraph[i, j - 1]);
                            }
                            break;
                        }
                    }
                   
                }

                fileGraph[indexchislI, indexchislJ] = "0";

                for (int i = 1; i < mas.Length; i++)
                    for (int j = 0; j < mas.Length; j++)
                    {
                        if (fileGraph[i, j] == fileGraph[i - 1, j] && fileGraph[i, j] != "0")
                            if (fileGraph[i, j + 1] == fileGraph[i - 1, j + 1] && 
                                ((fileGraph[i, j + 2] != "0" && 
                                fileGraph[i - 1, j + 2] == "0") || 
                                (fileGraph[i, j + 2] == "0" && fileGraph[i - 1, j + 2] != "0")))
                            {
                                for (int ik = 0; ik < mas.Length; ik++)
                                    for (int jk = 0; jk < mas.Length; jk++) fileGraph[i, jk] = "0";
                            }
                    }
                codePruf += $"{newPruf} ";

                Console.WriteLine($"\nКод Прюфера: {codePruf}");
            }
            string otvet = "otvet.txt";
            File.WriteAllText(otvet, codePruf);
        }
    }
}