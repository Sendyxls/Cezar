using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Encrypt(string input, int shift = 3)
    {
        ViewBag.Original = input;
        ViewBag.Encrypted = CaesarCipher(input, shift);
        return View("Index");
    }

    private string CaesarCipher(string text, int shift)
    {
        char[] buffer = text.ToCharArray();
        for (int i = 0; i < buffer.Length; i++)
        {
            char letter = buffer[i];
            if (char.IsLetter(letter))
            {
                char d = char.IsUpper(letter) ? 'A' : 'a';
                buffer[i] = (char)((letter + shift - d) % 26 + d);
            }
        }
        return new string(buffer);
    }
}
