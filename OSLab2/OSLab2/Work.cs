using System;
using System.IO;

namespace OSLab2
{
  class Work
  {
    public static void Find()
    {
      string start;
      string[] addreses = new string[50];
      bool[] visited = new bool[50];
      string A = " ", B = " ", C = " ", D = " ";
      string[] E = new string[5];
      start = File.ReadAllText("./test.txt");
      var tmp = start.Split(' ');
      int i = 0;
      while (tmp[i] != "end")
      {
        if (i < 50)
        {
          addreses[i] = tmp[i];
          visited[i] = false;
        }
        else
        {
          if (tmp[i] == "A")
          {
            A = tmp[i + 1];
          }
          else if (tmp[i] == "B")
          {
            B = tmp[i + 1];
          }
          else if (tmp[i] == "C")
          {
            C = tmp[i + 1];
          }
          else if (tmp[i] == "D")
          {
            D = tmp[i + 1];
          }
        }
        i++;
      }
      for (int j = 0; j < 4; j++)
      {
        if (j == 0)
        {
          int temp = 0;
          temp = Convert.ToInt32(A);
          do
          {
            A = A + ' ' + addreses[temp];
            visited[temp] = true;
            temp = Convert.ToInt32(addreses[temp]);
          }
          while (addreses[temp] != "eof");
          visited[temp] = true;
          A = A + ' ' + "eof";
          Console.WriteLine("A: " + A);
        }
        else if (j == 1)
        {
          int temp = 0;
          temp = Convert.ToInt32(B);
          do
          {
            B = B + ' ' + addreses[temp];
            visited[temp] = true;
            temp = Convert.ToInt32(addreses[temp]);
          }
          while (addreses[temp] != "eof");
          visited[temp] = true;
          B = B + ' ' + "eof";
          Console.WriteLine("B: " + B);
        }
        if (j == 2)
        {
          int temp = 0;
          temp = Convert.ToInt32(C);
          do
          {
            C = C + ' ' + addreses[temp];
            visited[temp] = true;
            temp = Convert.ToInt32(addreses[temp]);
          }
          while (addreses[temp] != "eof");
          visited[temp] = true;
          C = C + ' ' + "eof";
          Console.WriteLine("C: " + C);
        }
        if (j == 3)
        {
          int temp = 0;
          temp = Convert.ToInt32(D);
          do
          {
            D = D + ' ' + addreses[temp];
            visited[temp] = true;
            temp = Convert.ToInt32(addreses[temp]);
          }
          while (addreses[temp] != "eof");
          visited[temp] = true;
          D = D + ' ' + "eof";
          Console.WriteLine("D: " + D);
        }
      }
      for (int j = 0; j < 50; j++)
      {
        if (addreses[j] == "bad")
          visited[j] = true;
      }
      E = NotEmpty(visited, addreses);
      string[] splited = new string[3];
      for (int j = 0; j < 5; j++)
      {
        if (E[j] != "eof")
        {
          Console.WriteLine("Найдна неименованная часть данных. Записана под именами E, F, G");
          Console.WriteLine("E: " + E[j]);
          Console.WriteLine("F: " + E[j + 2]);
          Console.WriteLine("G: " + E[j + 3]);
          break;
        }
      }
      IsEqual(A, B, C, D, addreses);
      for (int j = 0; j < 5; j++)
      {
        if (E[j] != "eof")
        {
          Console.WriteLine("E: " + E[j]);
          Console.WriteLine("F: " + E[j + 2]);
          Console.WriteLine("G: " + E[j + 3]);
          break;
        }
      }
    }

    public static string IsEqual(string A, string B, string C, string D, string[] addreses)
    {
      Console.WriteLine("Найдены пересекающиеся файлы. Исправленная ФС: ");
      string temp = "";
      int k = 0;
      var tmpA = A.Split(' ');
      var tmpB = B.Split(' ');
      var tmpC = C.Split(' ');
      var tmpD = D.Split(' ');
      for (int i = 0; i < 6; i++)
      {
        switch (i)
        {
          case 1:
            for (int j = 0; j < 6; j++)
            {
              if (tmpB[j] == tmpC[j])
              {
                if (j < 5)
                {
                  for (k = Convert.ToInt32(tmpC[j]); k < 50; k++)
                  {
                    if (addreses[k] == "0" && j < 5)
                    {
                      addreses[k] = "1";
                      tmpC[j] = k.ToString();
                      addreses[Convert.ToInt32((tmpC[j - 1]))] = k.ToString();
                      break;
                    }
                  }
                }
                else if (addreses[k] == "1" && j > 5)
                {
                  tmpC[j] = "eof";
                }
              }
            }
            break;
          case 2:
            for (int j = 0; j < 6; j++)
            {
              if (tmpB[j] == tmpD[j])
              {
                if (j < 5)
                {
                  for (k = Convert.ToInt32(tmpD[j]); k < 50; k++)
                  {
                    if (addreses[k] == "0" && j < 5)
                    {
                      addreses[k] = "1";
                      tmpD[j] = k.ToString();
                      addreses[Convert.ToInt32((tmpD[j - 1]))] = k.ToString();
                      break;
                    }
                  }
                }
                else if (addreses[k] == "1" && j > 5)
                {
                  tmpD[j] = "eof";
                }
              }
            }
            break;
        }
        
      };
      temp = "";
      for (int i = 0; i < 6; i++)
      {
        temp = temp + tmpA[i] + ' ';
      }
      Console.WriteLine("A: " + temp);
      temp = "";
      for (int i = 0; i < 6; i++)
      {
        temp = temp + tmpB[i] + ' ';
      }
      Console.WriteLine("B: " + temp);
      temp = "";
      for (int i = 0; i < 6; i++)
      {
        temp = temp + tmpC[i] + ' ';
      }
      Console.WriteLine("C: " + temp);
      temp = "";
      for (int i = 0; i < 6; i++)
      {
        temp = temp + tmpD[i] + ' ';
      }
      Console.WriteLine("D: " + temp);
      return temp;
    }
      
    

    public static string[] NotEmpty(bool[] visited, string[] addreses)
    {
      int temp = 0, i = 0, j = 0;
      string[] E = new string[5];
      do
      {
        temp = i;
        if ((visited[i] == false) && (addreses[i] != "0"))
        {
          if (j < 4)
            E[j] = E[j] + i;
          while ((addreses[temp] != "eof") && visited[temp] == false)
          {
            E[j] = E[j] + ' ' + addreses[temp];
            visited[temp] = true;
            temp = Convert.ToInt32(addreses[temp]);
          }
          if (addreses[temp] == "eof")
          {
            E[j] = E[j] + ' ' + "eof";
            j++;
          }
        }
        i++;
      }
      while (i < 50);
      return E;
    }
  }
}
