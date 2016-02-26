using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZigZag;

namespace UnitTestProject1
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void TestMethod1()
    {

      int[][] allSequences = new int[][] {
        new int[] { 1, 7, 4, 9, 2, 5 },
        new int[] { 1, 17, 5, 10, 13, 15, 10, 5, 16, 8 },
        new int[] {44},
        new int[]{ 1, 2, 3, 4, 5, 6, 7, 8, 9 },
        new int[]{ 70, 55, 13, 2, 99, 2, 80, 80, 80, 80, 100, 19, 7, 5, 5, 5, 1000, 32, 32 },
        new int[] { 374, 40, 854, 203, 203, 156, 362, 279, 812, 955,
600, 947, 978, 46, 100, 953, 670, 862, 568, 188,
67, 669, 810, 704, 52, 861, 49, 640, 370, 908,
477, 245, 413, 109, 659, 401, 483, 308, 609, 120,
249, 22, 176, 279, 23, 22, 617, 462, 459, 244 }
      };
      int[] allMax = new int[] { 6, 7, 1, 2, 8, 36 };

      Program p = new Program();
      int length = allSequences.Length;
      for (int i = 0; i < length; i++)
      {
        int[] sequence = allSequences[i];

        int[] actualSubSequence = null;
        int actual = p.longestZigZag(sequence, out actualSubSequence);

        int expected = allMax[i];

        Assert.AreEqual(expected, actual);
      }
    }
  }
}
