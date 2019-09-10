﻿using System;
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

    public class when_user_input_is_empty
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add(); };

        It should_return_0 = () => { _result.Should().Be(0); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_adding_just_one_number
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("3"); };
        It should_do_something = () => { _result.Should().Be(3); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_adding_two_numbers_delimited_by_comma
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("2,3"); };

        It should_split_and_return_the_sum = () => { _result.Should().Be(5); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_adding_more_numbers_separated_by_comma
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("1,2,3"); };
        It should_add = () => { _result.Should().Be(6); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_user_input_has_comma_and_newline_as_delimiters
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("1,2\n3"); };

        It should_split_and_return_the_sum_ofd_all_numbers = () => { _result.Should().Be(6); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_using_more_than_one_delimeter
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("//;\n1;2"); };
        It should_add_numbers = () => { _result.Should().Be(3); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_user_input_has_one_negative_number
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = Catch.Exception(() => _systemUnderTest.Add("1,2,-4")); };

        It should_throw_an_exception_showing_that_number = () => { _result.Message.Should().Be("negatives not allowed: -4"); };
        private static Exception _result;
        private static Calculator _systemUnderTest;
    }

    public class when_adding_more_than_one_negative_number
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = Catch.Exception(() => _systemUnderTest.Add("1,-2,-4")); };

        It should_throw_an_exception_showing_that_number = () => { _result.Message.Should().Be("negatives not allowed: -2, -4"); };
        private static Exception _result;
        private static Calculator _systemUnderTest;
    }

    public class when_user_input_contains_numbers_larger_than_1000
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("1,2,1000,1001"); };

        It should_ignore_them_and_sum_the_rest = () => { _result.Should().Be(1003); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_adding_with_multiple_custom_delimeter
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("//[***]\n1***2***3"); };
        It should_add_numbers = () => { _result.Should().Be(6); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_input_has_multiple_multichar_characters
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("//[**][%]\n1**2%3"); };

        It should_return_the_sum_of_all_delimited_numbers = () => { _result.Should().Be(6); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }
}

//11. Given the user input is multiple numbers with multiple custom delimiters when calculating the sum then it should return the sum of all the numbers. (example “//[**][%]\n1**2%3” should return 6)