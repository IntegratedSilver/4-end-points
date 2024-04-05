using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace _4_end_points.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class endPointControllers : ControllerBase
    {
        [HttpGet("/MadLib")]
        public ActionResult<string> MadLib(
            [Required] string noun,
            [Required] string verb,
            [Required] string adjective)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return $"Once upon a time, there was a {adjective} {noun} who loved to {verb}.";
        }

        [HttpGet("/OddOrEven")]
        public ActionResult<string> evenOdd(int num1, int num2)
        {
            return $"{num1} is {Compare(num1, num2)} the {num2}.\n" +
                   $"{num2} is {Compare(num2, num1)} the {num1}.";
        }

        private string Compare(int num1, int num2)
        {
            return num1 > num2 ? "greater than" :
                   num1 < num2 ? "less than" :
                   "equal to";
        }

        [HttpGet("/ReverseAlphanumeric")]
        public ActionResult<string> ReverseAlphanumeric([Required] string input)
{
    if (!IsAlphabetic(input))
    {
        return "Please enter letters.";
    }

    char[] charArray = input.ToCharArray();
    Array.Reverse(charArray);
    return $"You entered {input}, reversed is {new string(charArray)}";
}

private bool IsAlphabetic(string input)
{
    foreach (char c in input)
    {
        if (!char.IsLetter(c))
        {
            return false;
        }
    }
    return true;
}

        [HttpGet("/FlipNumbers")]
        public ActionResult<string> FlipNumbers([Required] string input)
        {
            if (!IsNumeric(input))
            {
                return "Please enter numbers.";
            }

            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private bool IsNumeric(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
