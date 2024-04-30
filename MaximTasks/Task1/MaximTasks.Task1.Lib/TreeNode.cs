namespace MaximTasks.Task1.Lib
{
    public class TreeNode
    {
        /// <summary>
        /// Значение узла.
        /// </summary>
        char Value {  get; set; }

        /// <summary>
        /// Левый узел.
        /// </summary>
        TreeNode? Left { get; set; } = null;

        /// <summary>
        /// Правый узел.
        /// </summary>
        TreeNode? Right { get; set; } = null;

        /// <summary>
        /// Конструктор с одним параметром.
        /// </summary>
        /// <param name="value">Значение узла.</param>
        public TreeNode(char value)
        {
            Value = value;
        }

        /// <summary>
        /// Вставляет узел в дерево.
        /// </summary>
        /// <param name="node">Вставляемый узел.</param>
        public void Insert(TreeNode node)
        {
            if (node.Value < Value)
            {
                if (Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.Insert(node);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.Insert(node);
                }
            }
        }

        /// <summary>
        /// Преобразовывает дерево в строку.
        /// </summary>
        /// <param name="result"></param>
        /// <returns>Возвращает дерево в виде строки.</returns>
        public string ToString(string result = "")
        {
            if (Left != null)
            {
                result = Left.ToString(result);
            }

            result += Value;

            if (Right != null)
            {
                result = Right.ToString(result);
            }

            return result;
        }
    }
}
