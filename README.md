<h2>Brief Description:</h2>
<p>
  This is a multithread server-client application for generating random multiple choice tests. In the application the users can provides 
  their own nicknames, to choose how many questions want to have in their own test and to choose how many seconds the will have to answer 
  all test's questions. Also after test compleation the application prepare a short report about the test and write it in a plain text file 
  with the nickname of the user. Every user has the opportunity to add his/her own questions as extra questions for answering them in his/her
  own test. Also, every user can go forward or backward throug the questions in order to change his/her answers.
</p>
<h2>Technologies:</h2>
<ul>
  <li>C# .NET</li>
  <li>Windows Forms Application</li>
  <li>Multithread TCP Client/TCP Listener socket server</li>
  <li>Asyncronuos programming</li>
</ul>
<h2>Main Displays:</h2>
<h3>Server started</h3>
![1](https://github.com/pety02/MultipleChoiceTestsGenerator/assets/47276102/a190a2a8-6941-469b-ab82-10de50cb4e2d)
<p>
  After starting the server, it asyncronuously prints on the console message.
</p>
<h3>Client connected</h3>
![2](https://github.com/pety02/MultipleChoiceTestsGenerator/assets/47276102/da1826ef-6b26-4c1b-8b08-3e9c54cd1d66)
<p>
  After connecting a client to the server, the application opens a WFA Form to allow the user to provide his/her data such as: nickname,
  time for solving the test in seconds and questions count. Also, there they can provide their personal extra questions.
</p>
![4](https://github.com/pety02/MultipleChoiceTestsGenerator/assets/47276102/b21c313e-d7ca-497d-bc91-6b4bc0f29231)
<p>Trying to save extra questions without provided extra questions count message.</p>
![5](https://github.com/pety02/MultipleChoiceTestsGenerator/assets/47276102/82145bdc-b795-4867-8602-569fdd92a86f)
<p>Trying to save extra questions with provided extra questions count message.</p>
![6](https://github.com/pety02/MultipleChoiceTestsGenerator/assets/47276102/0ebf0116-acd8-4392-90c8-b3de8a0804ac)
<p>Saving an extra question message.</p>
<h3>Test Form</h3>
![7](https://github.com/pety02/MultipleChoiceTestsGenerator/assets/47276102/19be677c-eac6-42ff-9bb6-b7f09a7cf108)
<p>
  On this display the users can view their questions, answer them, save their answers, go on the next question, go on the previous question
  and see the timer with the left time.
</p>
<h3>Test Compleation</h3>
![3](https://github.com/pety02/MultipleChoiceTestsGenerator/assets/47276102/4d8d9d85-eeed-444f-b872-48826d173d28)
<p>
  On test compleation the client view a similar message box.
</p>











