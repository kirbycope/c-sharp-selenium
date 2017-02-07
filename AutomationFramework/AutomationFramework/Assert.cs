using OpenQA.Selenium;
using System;
using System.Collections;
using System.Text;

namespace AutomationFramework
{
    public class Assert : NUnit.Framework.Assert
    {
        /// <summary>
        /// Asserts that both objects are equal.
        /// </summary>
        /// <param name="expected">The expected object/value</param>
        /// <param name="actual">The actual object/value</param>
        public new static void AreEqual(object expected, object actual)
        {
            // Create a log message
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Assert.AreEqual(expected, actual)");
            sb.AppendLine("    [INFO] Expected Value: " + expected);
            sb.AppendLine("    [INFO] Actual Value: " + actual);
            // Check the if the values are equal and save the result
            bool areEqual = actual.Equals(expected);
            // Handle the result
            if (areEqual)
            {
                // Write result to log
                sb.AppendLine("    [SUCCESS] Values are equal");
                // Write the log to the console
                Console.WriteLine(sb.ToString());
            }
            else
            {
                // Write result to log
                sb.AppendLine("    [FAILURE] Values are not equal");
                // Fail the test
                Fail(sb.ToString());
            }
        }

        /// <summary>
        /// Asserts that both objects are equal.
        /// </summary>
        /// <param name="expected">The expected object/value</param>
        /// <param name="actual">The actual object/value</param>
        /// <param name="failureMessage">The message to write to the console if the assert fails</param>
        public static void AreEqual(object expected, object actual, string failureMessage)
        {
            // Create a log message
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Assert.AreEqual(expected, actual, failureMessage)");
            sb.AppendLine("    [INFO] Expected Value: " + expected);
            sb.AppendLine("    [INFO] Actual Value: " + actual);
            // Check the if the values are equal and save the result
            bool areEqual = actual.Equals(expected);
            // Handle the result
            if (areEqual)
            {
                // Write result to log
                sb.AppendLine("    [SUCCESS] Values are equal");
                // Write the log to the console
                Console.WriteLine(sb.ToString());
            }
            else
            {
                // Write result to log
                sb.AppendLine("    [FAILURE] " + failureMessage);
                // Fail the test
                Fail(sb.ToString());
            }
        }

        /// <summary>
        /// Asserts that both objects are not equal.
        /// </summary>
        /// <param name="expected">The expected object/value</param>
        /// <param name="actual">The actual object/value</param>
        public new static void AreNotEqual(object expected, object actual)
        {
            // Create a log message
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Assert.AreNotEqual(expected, actual)");
            sb.AppendLine("    [INFO] Expected Value: " + expected);
            sb.AppendLine("    [INFO] Actual Value: " + actual);
            // Check the if the values are equal and save the result
            bool areEqual = actual.Equals(expected);
            // Handle the result
            if (areEqual)
            {
                // Write result to log
                sb.AppendLine("    [FAILURE] Values are equal");
                // Fail the test
                Fail(sb.ToString());
            }
            else
            {
                // Write result to log
                sb.AppendLine("    [SUCCESS] Values are not equal");
                // Write the log to the console
                Console.WriteLine(sb.ToString());
            }
        }

        /// <summary>
        /// Asserts that both objects are not equal.
        /// </summary>
        /// <param name="expected">The expected object/value</param>
        /// <param name="actual">The actual object/value</param>
        /// <param name="failureMessage">The message to write to the console if the assert fails</param>
        public static void AreNotEqual(object expected, object actual, string failureMessage)
        {
            // Create a log message
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Assert.AreNotEqual(expected, actual, failureMessage)");
            sb.AppendLine("    [INFO] Expected Value: " + expected);
            sb.AppendLine("    [INFO] Actual Value: " + actual);
            // Check the if the values are equal and save the result
            bool areEqual = actual.Equals(expected);
            // Handle the result
            if (areEqual)
            {
                // Write result to log
                sb.AppendLine("    [FAILURE] " + failureMessage);
                // Fail the test
                Fail(sb.ToString());
            }
            else
            {
                // Write result to log
                sb.AppendLine("    [SUCCESS] Values are not equal");
                // Write the log to the console
                Console.WriteLine(sb.ToString());
            }
        }

        /// <summary>
        /// Asserts that the expected object is contained in the actual object collection.
        /// </summary>
        /// <param name="anObject">The object to find</param>
        /// <param name="collection">The collection to parse</param>
        public static void Contains(object anObject, IList collection)
        {
            // Create a log message
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Assert.Contains(anObject, collection)");
            // Declare a found flag
            bool found = false;
            // Loop through the collection
            foreach (var obj in collection)
            {
                if (obj.Equals(anObject))
                {
                    found = true;
                    break;
                }
            }
            // Handle the result
            if (found)
            {
                // Write result to log
                sb.AppendLine("    [SUCCESS] Expected object is contained in the collection");
                // Write the log to the console
                Console.WriteLine(sb.ToString());
            }
            else
            {
                // Write result to log
                sb.AppendLine("    [FAILURE] Expected object is not contained in the collection");
                // Fail the test
                Fail(sb.ToString());
            }
        }

        /// <summary>
        /// Asserts that the expected object is contained in the actual object collection.
        /// </summary>
        /// <param name="anObject">The object to find</param>
        /// <param name="collection">The collection to parse</param>
        /// <param name="failureMessage">The message to write to the console if the assert fails</param>
        public static void Contains(object anObject, IList collection, string failureMessage)
        {
            // Create a log message
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Assert.Contains(anObject, collection, failureMessage)");
            // Declare a found flag
            bool found = false;
            // Loop through the collection
            foreach (var obj in collection)
            {
                if (obj.Equals(anObject))
                {
                    found = true;
                    break;
                }
            }
            // Handle the result
            if (found)
            {
                // Write result to log
                sb.AppendLine("    [SUCCESS] Expected object is contained in the collection");
                // Write the log to the console
                Console.WriteLine(sb.ToString());
            }
            else
            {
                // Write result to log
                sb.AppendLine("    [FAILURE] " + failureMessage);
                // Fail the test
                Fail(sb.ToString());
            }
        }

        /// <summary>
        /// Asserts that the expected text is contained in the actual text.
        /// </summary>
        /// <param name="expected">The expected object/value</param>
        /// <param name="actual">The actual object/value</param>
        public static void ContainsText(string expected, string actual)
        {
            // Create a log message
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Assert.ContainsText(expected, actual)");
            sb.AppendLine("    [INFO] Expected Value: " + expected);
            sb.AppendLine("    [INFO] Actual Value: " + actual);
            // Check if the expected text is contained within the actual text and save the result
            bool containsText = actual.Contains(expected);
            // Handle the result
            if (containsText)
            {
                // Write result to log
                sb.AppendLine("    [SUCCESS] Expected text is contained in acutal text");
                // Write the log to the console
                Console.WriteLine(sb.ToString());
            }
            else
            {
                // Write result to log
                sb.AppendLine("    [FAILURE] Expected text is not contained in acutal text");
                // Fail the test
                Fail(sb.ToString());
            }
        }

        /// <summary>
        /// Asserts that the expected text is contained in the actual text.
        /// </summary>
        /// <param name="expected">The expected object/value</param>
        /// <param name="actual">The actual object/value</param>
        /// <param name="failureMessage">The message to write to the console if the assert fails</param>
        public static void ContainsText(string expected, string actual, string failureMessage)
        {
            // Create a log message
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Assert.ContainsText(expected, actual, failureMessage)");
            sb.AppendLine("    [INFO] Expected Value: " + expected);
            sb.AppendLine("    [INFO] Actual Value: " + actual);
            // Check if the expected text is contained within the actual text and save the result
            bool containsText = actual.Contains(expected);
            // Handle the result
            if (containsText)
            {
                // Write result to log
                sb.AppendLine("    [SUCCESS] Expected text is contained in acutal text");
                // Write the log to the console
                Console.WriteLine(sb.ToString());
            }
            else
            {
                // Write result to log
                sb.AppendLine("    [FAILURE] " + failureMessage);
                // Fail the test
                Fail(sb.ToString());
            }
        }

        /// <summary>
        /// Asserts that the given element exists in the DOM.
        /// </summary>
        /// <param name="element">The element to check</param>
        public static void ElementExists(IWebElement element)
        {
            // Create a log message
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Assert.ElementExists(element)");
            try { sb.AppendLine("    [INFO] Element to check: " + element.GetAttribute("outerHTML")); } catch { /* do nothing */ }
            // Handle result
            if (element.GetAttribute("outerHTML") != null)
            {
                // Write result to log
                sb.AppendLine("    [SUCCESS] Element is present");
                // Pass the test
                Pass(sb.ToString());
            }
            else
            {
                // Write result to log
                sb.AppendLine("    [FAILURE] Element is not present");
                // Fail the test
                Fail(sb.ToString());
            }
        }

        /// <summary>
        /// Asserts that the given element exists in the DOM.
        /// </summary>
        /// <param name="element">The element to check</param>
        /// <param name="failureMessage">The message to write to the console if the assert fails</param>
        public static void ElementExists(IWebElement element, string failureMessage)
        {
            // Create a log message
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Assert.ElementExists(element)");
            try { sb.AppendLine("    [INFO] Element to check: " + element.GetAttribute("outerHTML")); } catch { /* do nothing */ }
            // Handle result
            if (element.GetAttribute("outerHTML") != null)
            {
                // Write result to log
                sb.AppendLine("    [SUCCESS] Element is present");
                // Pass the test
                Pass(sb.ToString());
            }
            else
            {
                // Write result to log
                sb.AppendLine("    [FAILURE] " + failureMessage);
                // Fail the test
                Fail(sb.ToString());
            }
        }

        /// <summary>
        /// Asserts that the given element is Displayed (as defined by OpenQA.Selenium).
        /// </summary>
        /// <param name="element">The element to check</param>
        public static void IsDisplayed(IWebElement element)
        {
            // Create a log message
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Assert.IsDisplayed(element)");
            try { sb.AppendLine("    [INFO] Element to check: " + element.GetAttribute("outerHTML")); } catch { /* do nothing */ }
            // Handle result
            if (element.Displayed)
            {
                // Write result to log
                sb.AppendLine("    [SUCCESS] Element is displayed");
                // Write the log to the console
                Console.WriteLine(sb.ToString());
            }
            else
            {
                // Write result to log
                sb.AppendLine("    [FAILURE] Element is not displayed");
                // Fail the test
                Fail(sb.ToString());
            }
        }

        /// <summary>
        /// Asserts that the given element is Displayed (as defined by OpenQA.Selenium).
        /// </summary>
        /// <param name="element">The element to check</param>
        /// <param name="failureMessage">The message to write to the console if the assert fails</param>
        public static void IsDisplayed(IWebElement element, string failureMessage)
        {
            // Create a log message
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Assert.IsDisplayed(element)");
            try { sb.AppendLine("    [INFO] Element to check: " + element.GetAttribute("outerHTML")); } catch { /* do nothing */ }
            // Handle result
            if (element.Displayed)
            {
                // Write result to log
                sb.AppendLine("    [SUCCESS] Element is displayed");
                // Write the log to the console
                Console.WriteLine(sb.ToString());
            }
            else
            {
                // Write result to log
                sb.AppendLine("    [FAILURE] " + failureMessage);
                // Fail the test
                Fail(sb.ToString());
            }
        }

        /// <summary>
        /// Asserts that the condition is false.
        /// </summary>
        /// <param name="condition">The condition being tested</param>
        public static void IsFalse(object condition)
        {
            // Create a log message
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Assert.IsFalse(condition)");
            // Handle result
            if (condition.Equals(true))
            {
                // Write result to log
                sb.AppendLine("    [FAILURE] Condition is true");
                // Write the log to the console
                Console.WriteLine(sb.ToString());
            }
            else
            {
                // Write result to log
                sb.AppendLine("    [SUCCESS] Condition is not true");
                // Fail the test
                Fail(sb.ToString());
            }
        }

        /// <summary>
        /// Asserts that the condition is false.
        /// </summary>
        /// <param name="condition">The condition being tested</param>
        /// <param name="failureMessage">The message to write to the console if the assert fails</param>
        public static void IsFalse(object condition, string failureMessage)
        {
            // Create a log message
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Assert.IsFalse(condition, failureMessage)");
            // Handle result
            if (condition.Equals(true))
            {
                // Write result to log
                sb.AppendLine("    [FAILURE] " + failureMessage);
                // Write the log to the console
                Console.WriteLine(sb.ToString());
            }
            else
            {
                // Write result to log
                sb.AppendLine("    [SUCCESS] Condition is not true");
                // Fail the test
                Fail(sb.ToString());
            }
        }

        /// <summary>
        /// Asserts that the condition is true.
        /// </summary>
        /// <param name="condition">The condition being tested</param>
        public new static void IsTrue(bool condition)
        {
            // Create a log message
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Assert.IsTrue(condition)");
            // Handle result
            if (condition.Equals(true))
            {
                // Write result to log
                sb.AppendLine("    [SUCCESS] Condition is true");
                // Write the log to the console
                Console.WriteLine(sb.ToString());
            }
            else
            {
                // Write result to log
                sb.AppendLine("    [FAILURE] Condition is not true");
                // Fail the test
                Fail(sb.ToString());
            }
        }

        /// <summary>
        /// Asserts that the condition is true.
        /// </summary>
        /// <param name="condition">The condition being tested</param>
        /// <param name="failureMessage">The message to write to the console if the assert fails</param>
        public static void IsTrue(bool condition, string failureMessage)
        {
            // Create a log message
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Assert.IsTrue(condition, failureMessage)");
            // Handle result
            if (condition.Equals(true))
            {
                // Write result to log
                sb.AppendLine("    [SUCCESS] Condition is true");
                // Write the log to the console
                Console.WriteLine(sb.ToString());
            }
            else
            {
                // Write result to log
                sb.AppendLine("    [FAILURE] " + failureMessage);
                // Fail the test
                Fail(sb.ToString());
            }
        }

        /// <summary>
        /// Fails a test by throwing an exception after writing the result to the console.
        /// </summary>
        /// <param name="message">The message to write to the console</param>
        public new static void Fail(string message)
        {
            // Write the message to the log
            Console.WriteLine(message);
            // Throw an exception (failing the test)
            throw new Exception(message);
        }

        /// <summary>
        /// Passes a test by writing the result to the console not throwing an expection
        /// </summary>
        /// <param name="message">The message to write to the console</param>
        public new static void Pass(string message)
        {
            // Write the message to the log
            Console.WriteLine(message);
        }
    }
}
