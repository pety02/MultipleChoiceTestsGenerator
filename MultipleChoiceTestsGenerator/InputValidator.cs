namespace MultipleChoiceTestsGenerator
{
    /// <summary>
    /// 
    /// </summary>
    public static class InputValidator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsValidNumberInput(string input)
        {
            if(string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            if(input.Length == 1 && input[0] == '0')
            {
                return true;
            }
            
            if ('1' <= input[0] && input[0] <= '9')
            {
                for(int i = 1; i < input.Length; i++)
                {
                    if (input[i] < '0' || '9' < input[i])
                    {
                        return false;
                    }
                }

                return true;
            } 
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupBox"></param>
        /// <returns></returns>
        public static bool HasCheckedAnswers(GroupBox groupBox)
        {
            foreach(CheckBox ch in groupBox.Controls)
            {
                if (ch.Checked)
                {
                    return true;
                }
            }

            return false;
        }
    }
}