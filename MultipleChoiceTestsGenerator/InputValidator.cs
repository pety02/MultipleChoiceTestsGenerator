namespace MultipleChoiceTestsGenerator
{
    /// <summary>
    /// InputValidator class.
    /// </summary>
    public static class InputValidator
    {
        /// <summary>
        /// Validating the numbers (for e.g. questions count or seconds count).
        /// </summary>
        /// <param name="input"> string input - should contains only digits </param>
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
        /// Validating that at least one check box of the answers groupBox is checked.
        /// </summary>
        /// <param name="groupBox"> the groupBox of check boxes </param>
        /// <returns> true if at least one check box is checked and false if is not </returns>
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