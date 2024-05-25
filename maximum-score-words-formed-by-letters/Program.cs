namespace maximum_score_words_formed_by_letters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            var words = new string[] { "dog", "cat", "dad", "good" };
            var letters = new char[] { 'a', 'a', 'c', 'd', 'd', 'd', 'g', 'o', 'o' };
            var score = new int[] { 1, 0, 9, 5, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var ans = sol.MaxScoreWords(words, letters, score);
            Console.WriteLine(ans);
        }
    }

    public class Solution
    {
        public int MaxScoreWords(string[] words, char[] letters, int[] score)
        {
            var frequency = new int[score.Length];
            foreach (char c in letters)
            {
                frequency[c - 'a']++;
            }
            int Dfs(int i)
            {
                int max = 0;
                for (int j = i; j < words.Length; j++)
                {
                    int res = 0;
                    var valid = true;
                    foreach (char c in words[j].ToCharArray())
                    {
                        frequency[c - 'a']--;
                        res += score[c - 'a'];
                        if (frequency[c - 'a'] < 0) valid = false;
                    }
                    if (valid)
                    {
                        res += Dfs(j + 1);
                        max = Math.Max(res, max);
                    }
                    foreach (char c in words[j].ToCharArray())
                    {
                        frequency[c - 'a']++;
                        res = 0;
                    }
                }
                return max;
            }
            return Dfs(0);
        }
    }
}
