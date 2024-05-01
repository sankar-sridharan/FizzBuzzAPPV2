namespace FizzBuzzAPP.Services
{
    public class FizzBuzzService
    {
        private readonly ITextStyler _textStyler;

        public FizzBuzzService(ITextStyler textStyler)
        {
            _textStyler = textStyler;
        }

        public List<string> GenerateFizzBuzzResults(int inputValue)
        {
            var results = new List<string>();

            for (int i = 1; i <= inputValue; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    results.Add("Fizz Buzz");
                }
                else if (i % 3 == 0)
                {
                    results.Add(_textStyler.StyleFizzText("Fizz"));
                }
                else if (i % 5 == 0)
                {
                    results.Add(_textStyler.StyleBuzzText("Buzz"));
                }
                else
                {
                    results.Add(i.ToString());
                }
            }

            return results;
        }
    }

}
