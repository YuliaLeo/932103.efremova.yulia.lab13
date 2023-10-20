using System.ComponentModel.DataAnnotations;

namespace lab13.Models
{
    public class Expression
    {
        public int id { get; set; }

        public int firstValue { get; set; }

        public int secondValue { get; set; }

        public string operation { get; set; }

        public int answer { get; set; }

        [Required]
        public int userAnswer { get; set; }

        public Expression(int expId) {
            Random random = new Random(DateTime.Now.Millisecond);

            id = expId;
            firstValue = random.Next() % 10;
            secondValue = random.Next() % 10;

            if (random.Next() % 2 == 1)
            {
                operation = "+";
                answer = firstValue + secondValue;
            } else {
                operation = "-";
                answer = firstValue - secondValue;
            }
        }

        public class ExpressionValidationAttribute : ValidationAttribute
        {
            string[] _names;

            public ExpressionValidationAttribute(string[] names)
            {
                _names = names;
            }
            public override bool IsValid(object value)
            {
                if (value != null && _names.Contains(value.ToString()))
                    return true;

                return false;
            }
        }
    }
}
