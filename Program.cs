using System.ComponentModel.Design;
using System.Threading.Channels;

TimeComplexity test = new TimeComplexity();
var result = test.FrogJmp(10, 85, 30);
Console.WriteLine(result); //amount of jumps to get to the wanted position

int[] arr = { 2, 3, 1, 5, 6,7,4,9};

var result2 = test.PermMissingElem(arr);
Console.WriteLine(result2);

int[] arr2 = { 3, 1, 2, 4, 3 };
var result3= test.TapeEquilibrium(arr2);
Console.WriteLine(result3);

class TimeComplexity
{
    public int FrogJmp(int currentPosition, int wantedPosition, int jumpDistance)
    {
        return (int)Math.Ceiling((double)(wantedPosition - currentPosition) / jumpDistance);
    }

    public int PermMissingElem(int[] A)
    {
        int N = 0;

        //Gives the expected handshake state to N
        for (int i = 0; i <= A.Length + 1; i++)
        {
            N ^= i;
        }

        //Cancels out the numbers that are in the sequence
        //The missing number is XORed with 0 thus not getting canceled
        for (int i = 0; i < A.Length; i++)
        {
            N ^= A[i];
        }


        return N;
    }

    public int TapeEquilibrium(int[] A)
    {
        int totalSum = 0;
        for (int i = 0; i < A.Length; i++)
        {
            totalSum += A[i];
        }

        int prefixSum = A[0];
        int minDifference = Math.Abs(totalSum - 2 * prefixSum);

        for (int i = 1; i < A.Length - 1; i++)
        {
            prefixSum += A[i];
            int suffixSum = totalSum - prefixSum;
            int difference = Math.Abs(prefixSum - suffixSum);
            minDifference = Math.Min(minDifference, difference);
        }

        return minDifference;
        
    }
    
    
}
