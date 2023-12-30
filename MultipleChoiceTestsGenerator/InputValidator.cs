using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleChoiceTestsGenerator
{
    public static class InputValidator
    {
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
