using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Encrypt(string input, int shift)
    {
        ViewBag.Original = input;
        ViewBag.Encrypted = CaesarCipher(input, shift);
        return View("Index");
    }

    [HttpPost]
    public IActionResult Decrypt(string encryptedInput, int shift)
    {
        ViewBag.EncryptedInput = encryptedInput;
        ViewBag.Decrypted = CaesarCipher(encryptedInput, -shift);
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
                buffer[i] = (char)((letter + shift - d + 26) % 26 + d);
            }
        }
        return new string(buffer);
    }
}