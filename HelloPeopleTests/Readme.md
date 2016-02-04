Automation LnL

Lesson 1 - Project White

White is a framework for automating rich client applications based on Win32, WinForms, WPF, Silverlight and SWT (Java) platforms. It is .NET based and does not require the use of any proprietary scripting languages. Tests/automation programs using White can be written with whatever .NET language, IDE and tools you are already using. White provides a consistent object-oriented API, hiding the complexity of Microsoft's UIAutomation library (on which White is based) and windows messages.

Source code - https://github.com/TestStack/White
Documentation - https://github.com/TestStack/TestStack.docs/tree/master/_source/White


Setting up
~~~~~~~~~~

1. Place the unzipped sample application from SimpleApp.zip in a location you will remember

2. Open Visual Studio and create a new Unit Test project.

3. Reference White
	a. use NuGet > install-package TestStack.White
	b. Or add the Castle.Core.dll and TestStack.White.dll references manually. They are both in the WhiteReferences.zip

Task 1
~~~~~~
Create a unit test that verifies when a user clicks the 'Greet' button then a message of greeting is displayed. (At this stage you dont care about the text specifics, just that some text was displayed)

How do you discover what UI elements/controls are available?

Part of the Windows 8.1 SDK
C:\Program Files (x86)\Windows Kits\8.1\bin\x64\inspect.exe
C:\Program Files (x86)\Windows Kits\8.1\bin\x86\UIAVerify\VisualUIAVerifyNative.exe

Task 2
~~~~~~
Create 3 tests that verify that when a different greeting scope is selected, that the correctly scoped message of greeting is displayed. Consider the fact that most of the tests are similar and will resuse functionality. DRY

Task 3
~~~~~~
In each of your existing tests once the window is opened, ensure the 'Add delay' checkbox is checked. Do each of your tests pass consistently each time? No? Then fix them. (Unchecking the 'Add delay' checkbox doesn't count!)


Next time?
~~~~~~~~~~

Converting the tests we have written into SpecFlow scenarios driven by gherkin based feature files.