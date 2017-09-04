﻿ViewModel Properties
====================
In DotVVM, every page has a thing called a viewmodel. It stores data from page controls, or anything in the page that is dynamic and can change when the user interacts with the page.

The viewmodel is a C# class and the data are stored in public properties.

Declare 3 properties – `Number1`, `Number2` and `Result`, all of them should be of type `int`.

[<sample Incorrect="../samples/Lesson1ViewModelStep4Incorrect.cs"
         Correct="../samples/Lesson1ViewModelStep4Correct.cs"
         Validator="Lesson1Step4Validator" />]

> The values entered by the user will be stored in `Number1` and `Number2` properties, and we'll put the sum in the `Result` property when the user clicks the button.