namespace LeetCodeSolutions.Medium
{
    public class N17_Letter_Combinations_of_Phone_Number //Solution
    {
        Dictionary<char, char[]> keypad = new Dictionary<char, char[]> {{'2', new char[]{'a', 'b', 'c'}},
                    {'3', new char[]{'d', 'e', 'f'}}, {'4', new char[] {'g', 'h', 'i'}},
                    {'5', new char[] {'j', 'k', 'l'}}, {'6', new char[] {'m', 'n', 'o'}},
                    {'7', new char[] {'p', 'q', 'r', 's'}}, {'8', new char[] {'t', 'u', 'v'}},
                    {'9', new char[] {'w', 'x', 'y', 'z'}}};

        public void AddCombination(string curr, string digits, int index, IList<string> list)
        {
            if (index >= digits.Length) list.Add(curr);
            else
            {
                char[] map = keypad[digits[index]];

                for (int i = 0; i < map.Length; i++)
                {
                    string newCurr = curr + map[i];

                    AddCombination(newCurr, digits, index + 1, list);
                }
            }
        }

        public IList<string> LetterCombinations(string digits)
        {
            IList<string> combinations = new List<string>();

            if (digits.Length > 0) AddCombination("", digits, 0, combinations);

            return combinations;
        }
    }

}


//Пояснение:
//Определение карты клавиатуры:

//Словарь keypad содержит маппинг между цифрами и буквами, которые соответствуют этим цифрам на традиционной телефонной клавиатуре. Например, цифра '2' соответствует буквам 'a', 'b', 'c'.
//Метод AddCombination:

//Этот метод рекурсивно генерирует все возможные комбинации букв.
//Принимает текущую комбинацию curr, строку цифр digits, текущий индекс index и список list, в который добавляются найденные комбинации.
//Если индекс выходит за границы строки digits, это означает, что все цифры обработаны, и текущая комбинация добавляется в список list.
//Если не все цифры обработаны, метод получает массив букв, соответствующих текущей цифре, из словаря keypad.
//Для каждой буквы в массиве создаётся новая комбинация, и вызывается рекурсивный вызов метода для следующей цифры.
//Метод LetterCombinations:

//Этот метод инициализирует процесс генерации комбинаций, создавая список combinations для хранения результатов.
//Если входная строка digits не пуста, вызывается метод AddCombination с начальными параметрами: пустой строкой для текущей комбинации, строкой цифр, начальным индексом 0 и списком результатов.
//Возвращает список всех возможных комбинаций букв.
//Временная и пространственная сложность:
//Временная сложность: O(3 ^ n), где n — количество цифр в строке digits. Это связано с тем, что для каждой цифры на клавиатуре есть набор соответствующих букв, и для каждой цифры мы можем иметь 3 или 4 комбинации, в зависимости от цифры.
//Пространственная сложность: O(3 ^ n), так как в худшем случае мы сохраняем все возможные комбинации в списке.