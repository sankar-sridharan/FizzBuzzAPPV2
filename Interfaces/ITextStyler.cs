namespace FizzBuzzAPP.Services
{
    public interface ITextStyler
    {
        string StyleFizzText(string text);
        string StyleBuzzText(string text);
    }

    public class RegularTextStyler : ITextStyler
    {
        public string StyleFizzText(string text) => "Fizz";
        public string StyleBuzzText(string text) => "Buzz";
    }

    public class WednesdayTextStyler : ITextStyler
    {
        public string StyleFizzText(string text) => "Wizz";
        public string StyleBuzzText(string text) => "Wuzz";
    }
    
}
