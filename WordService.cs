
namespace Anachronism
{
    public class WordService : IWordService
    {
        public string GetWordBeginningWith(char x)
        {
            switch(char.ToLower(x))
            {
                case 'a':
                    return "Again";
                case 'b':
                    return "Below";
                case 'c':
                    return "Chain";
                case 'd':
                    return "Dark";
                case 'e':
                    return "Eat";
                case 'f':
                    return "Facts";
                case 'g':
                    return "Glad";
                case 'h':
                    return "Honest";
                case 'i':
                    return "Isle";
                case 'j':
                    return "Jet";
                case 'k':
                    return "Kip";
                case 'l':
                    return "Light";
                case 'm':
                    return "Many";
                case 'n':
                    return "None";
                case 'o':
                    return "Occur";
                case 'p':
                    return "Par";
                case 'q':
                    return "Qat";
                case 'r':
                    return "Risky";
                case 's':
                    return "Sauce";
                case 't':
                    return "Tender";
                case 'u':
                    return "Unable";
                case 'v':
                    return "Vex";
                case 'w':
                    return "Why";
                case 'x':
                    return "Xis";
                case 'y':
                    return "Yep";
                case 'z':
                    return "Zig";
                default:
                    return $"{x}";
            }
        }
    }
}
