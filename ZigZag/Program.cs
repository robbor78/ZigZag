using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZigZag
{
  public class Program
  {
    static void Main(string[] args)
    {
    }

    public int longestZigZag(int[] sequence, out int[] subsequence)
    {
      subsequence = null;
      int length = sequence.Length;

      if (length == 1)
      {
        subsequence = new int[length];
        Array.Copy(sequence, subsequence, length);
        return 1;
      }
      if (length == 2)
      {
        subsequence = new int[length];
        Array.Copy(sequence, subsequence, length);
        return 2;
      }

      int[] solutions = Enumerable.Repeat(0, length).ToArray();
      solutions[1] = sequence[1] > sequence[0] ? +2 : -2;
      solutions[0] = solutions[1] > 0 ? -1 : 1;
      int max = 2;
      int solStart = 2;

      for (int i = 2; i < length; i++)
      {
        for (int j = i - 1; j >= 0; j--)
        {
          if (sequence[i] != sequence[j] && Math.Sign(sequence[i] - sequence[j]) != Math.Sign(solutions[j]))
          {
            solutions[i] = Math.Abs(solutions[j]) + 1;
            if (solutions[i] > max)
            {
              max = solutions[i];
              solStart = i;
            }
            if (solutions[j] > 0)
            {
              solutions[i] *= -1;
            }
            break;
          }
        }
      }

      Queue<int> q = new Queue<int>();
      q.Enqueue(sequence[solStart]);
      int prev = solutions[solStart];
      for (int i = solStart - 1; i >= 0; i--)
      {
        int curr = solutions[i];
        if (Math.Sign(curr) != Math.Sign(prev))
        {
          q.Enqueue(sequence[i]);
          prev = curr;
        }
      }
      subsequence = q.Reverse().ToArray();

      PrintArray(sequence);
      PrintArray(solutions);

      return max;
    }

    private void PrintArray(int[] arr)
    {
      Console.WriteLine(String.Join(", ", arr));
    }
  }
}
