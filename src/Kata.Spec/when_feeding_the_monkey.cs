using System;
using FluentAssertions;
using Machine.Specifications;

namespace Kata.Spec
{
    public class when_feeding_the_monkey
    {
        static Monkey _systemUnderTest;
        
        Establish context = () => 
            _systemUnderTest = new Monkey();

        Because of = () => 
            _systemUnderTest.Eat("banana");

        It should_have_the_food_in_its_belly = () =>
            _systemUnderTest.Belly.Should().Contain("banana");
    }

    public class when_input_is_empty
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };


        It should_return_0 = () => { _result.Should().Be(0); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_adding_one_number
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("3"); };
        It should_return_the_same_number = () => { _result.Should().Be(3); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_user_input_is_two_numbers
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("3,5"); };

        It should_return_the_sum_of_those_two_numbers = () => { _result.Should().Be(8); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_adding_more_than_one_number
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("1,2,3"); };
        It should_return_it_sum = () => { _result.Should().Be(6); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_input_has_newline_delimiter
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("1,5\n2"); };

        It should_split_and_return_the_sum = () => { _result.Should().Be(8); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_using_a_custom_delimeter
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("//;\n1;2"); };
        It should_return_the_sum = () => { _result.Should().Be(3); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_input_has_a_negative_number
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = Catch.Exception(() => _systemUnderTest.Add("-2,3,5")); };

        It should_throw_an_Exception_listing_the_number = () => { _result.Message.Should().Be("negatives not allowed: -2"); };
        private static Exception _result;
        private static Calculator _systemUnderTest;
    }
    
    public class when_input_has_more_than_one_negative_number
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = Catch.Exception(() => _systemUnderTest.Add("-2,-3,5")); };

        It should_throw_an_Exception_listing_the_numbers = () => { _result.Message.Should().Be("negatives not allowed: -2, -3"); };
        private static Exception _result;
        private static Calculator _systemUnderTest;
    }

    public class when_input_contains_numbers_larger_than_1000
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("1,2,1001"); };

        It should_ignore_those_numbers_and_return_the_sum_of_the_rest = () => { _result.Should().Be(3); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_add_with_custom_delimeter_between_brackets
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("//[***]\n1***2***3"); };
        It should_return_the_sum_of_those_numbers = () => { _result.Should().Be(6); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }
    
}

/**
9. Given the user input contains numbers larger than 1000 when calculating the sum it should only sum the numbers less than 1001. (example 2 + 1001 = 2)
10. Given the user input is multiple numbers with a custom multi-character delimiter when calculating the sum then it should return the sum of all the numbers. (example: “//[***]\n1***2***3” should return 6)
11. Given the user input is multiple numbers with multiple custom delimiters when calculating the sum then it should return the sum of all the numbers. (example “//[*][%]\n1*2%3” should return 6)
 **/