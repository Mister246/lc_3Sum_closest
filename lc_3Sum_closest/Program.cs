
int[] testNums = { 0,0,0 }; 
Console.WriteLine(Solution.ThreeSumClosest(testNums, 1));


public class Solution
{
    static public int ThreeSumClosest(int[] nums, int target)
    {
        Array.Sort(nums);
        int closest = int.MaxValue;

        for (int i = 0; i < nums.Length - 2; i++)
        // for each num in nums
        {
            if (nums[i] > 0) break;
            if (i > 0 && nums[i] == nums[i - 1]) continue;

            int j = i + 1;
            int k = nums.Length - 1;

            while (j < k)
            {
                int sum = nums[i] + nums[j] + nums[k];
                // Console.WriteLine($"sum = {nums[i]} + {nums[j]} + {nums[k]} = {sum}");

                // Console.WriteLine($"{Math.Max(sum, target)} - {Math.Min(sum, target)} < {Math.Max(closest, target)} - {Math.Min(closest, target)} = {Math.Max(sum, target) - Math.Min(sum, target) < Math.Max(closest, target) - Math.Min(closest, target)}");
                if (Math.Max(sum, target) - Math.Min(sum, target) < Math.Max(closest, target) - Math.Min(closest, target)) 
                // if difference between sum and target is less than difference between closest and target
                {
                    closest = sum;
                }

                if (sum == target)
                {
                    while (j < k && nums[j] == nums[j + 1])
                    {
                        j++;
                    }

                    while (j < k && nums[k] == nums[k - 1])
                    {
                        k--;
                    }

                    j++;
                    k--;
                }
                else if (sum < target)
                {
                    j++;
                }
                else // sum > target
                {
                    k--;
                }
            }
        }

        return closest;
    }
}