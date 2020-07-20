namespace AlgorithmsPractice
{
    /// <summary>
    /// Assume you have a method isSubstring which checks if one word is a substring of another   
    /// Given two strings, s1 and s2, write code to check if s2 is a rotation of s1 
    /// using only one call to isSubstring (i e , “waterbottle” is a rotation of “erbottlewat”) 
    /// </summary>
    public class StringRotationService
    {
        public static bool IsRotation(string s1, string s2)
        {
            if(string.IsNullOrEmpty(s1) && string.IsNullOrEmpty(s2))
            {
                return true;
            }

            if(s1.Length != s2.Length)
            {
                return false;
            }

            var s1s1 = s1 + s1;
            if(s1s1.Contains(s2))
            {
                return true;
            }
            
            return false;
        }
    }
}
