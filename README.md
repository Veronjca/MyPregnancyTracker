# My Pregnancy Tracker
This project is used for educational purposes only.
<p><strong>Sources used:</strong></p>
<ul>
<li><a href="https://feia.bg/apps/pregnancy/">Feia Pregnancy</a></li>
<li><a href="https://timesofindia.indiatimes.com/etimes">ETimes Entertainment</a></li>
</ul>

# Summary
<p>This app provides accurate information about every single gestational week of a human pregnancy. Every user have tasks for the current gestational week of the pregnancy, additional info for the nutrition, mother and some advices. In the articles page you can find helpful information about pregnancy. Also we provide a forum where you can asks questions, comment on other people topics and react to them. </p>

# Application Flow
## Home page
<p>Here you can navigate to login if you already have an account otherwise create one using register button.</p>
<img height="500em" src="https://i.ibb.co/TRxW7fd/homePage.png" alt="homePage" />

## Login page
<p>Enter the application using your email and password.</p>

<img height="500em" src="https://i.ibb.co/s3ByWMS/login-Page.png" alt="login-Page" />

## Register Page 
<p>To register you need to fill out following required fields:</p>
<ul>
<li>User name - needs to be unique</li>
<li>Email - needs to be unique</li>
<li>Password</li>
<li>Confirm password</li>
<li>First day of your last menstruation </li>
<li>Accept our terms of agreement and privacy policy </li>
</ul>

<img height="500em" src="https://i.ibb.co/DLrBmkx/register-Page.png" alt="register-Page" />

## User Page 
<p>The user page is initialized on the gestational week you are currently in.</p>
<p>Using buttons marked with #1 you can slide through all of the gestational weeks.</p>
<p>Upon hitting logout button (marked with #2) you will exit the application and redirected to the home page. </p>

<img height="500em" src="https://i.ibb.co/4P9mXSr/user-Page-Marked-Up.png" alt="user-Page-Marked-Up" />



### Functionality and child pages

<p><strong>Button marked with #3 toggles side navigation, see below.</strong></p>

<img src="https://i.ibb.co/8nwrgq7/side-Nav-Marked-Up.png" alt="side-Nav-Marked-Up" />

<p><strong>Upon clicking on button marked with #10 you will see profile page.</strong></p>

<p>Here you can add some additional info such as: first and last name, height, weight and birth date. Also you can check your due date.</p>

<img src="https://i.ibb.co/yQYqmxs/profile-Page.png" alt="profile-Page" />

<p><strong>Button marked with #11 leads to contact us page.</strong></p>

<p>Here you can see our email. Don't hesitate to contact us at any time.</p>

<img src="https://i.ibb.co/YQmTQ0R/contact-Us-Page.png" alt="contact-Us-Page" />

<p><strong> Button marked with #12 leads to tasks page.</strong></p>

<p>Here you can find different tasks for every single gestational week.</p>
<p>You can mark them as done upon clicking ot the checkbox before each of them.</p>
<img src="https://i.ibb.co/Y8nWXzY/tasks-Page.png" alt="tasks-Page" />

<p><strong>#13 expands user settings where you can delete your account.</strong></p>

<p>Note that if you try to login 30 days after deletion, your account will be restored automatically.</p>

<img src="https://i.ibb.co/1sgdQfs/delete-Profile-Page.png" alt="delete-Profile-Page" />

<p><ins><strong>Buttons marked with #7,#8 and #9 opens up modals which contains gestational week specific content.</strong></ins></p>
<p><strong>Button marked with #7 leads to mother page.</strong></p>

<p>In this page you can find some information about changes in your body during pregnancy, symptoms and so on.</p>
<img height="500em" src="https://i.ibb.co/qRSyMBm/mother-Page.png" alt="mother-Page" />

<p><strong>Button marked with #8 leads to nutrition page.</strong></p>

<p>Here you can find some useful information of how to manage your diet during pregnancy. What to eat and what to avoid with given choices of healthy food.</p>
<img height="500em" src="https://i.ibb.co/zRsyCN6/nutrition-Page.png" alt="nutrition-Page" />

<p><strong>Button marked with #9 leads to advices page.</strong></p>

<p>Here are some advices considering the selected gestational week.</p>
<img src="https://i.ibb.co/1ZHzGdp/advices-Page.png" alt="advices-Page" />

## Forum Page
<p><strong>When you click on the button marked with #5 from user page you will open forum page.</strong></p>

<p>Here you can choose the category of the topics you want to see.</p>
<p>The topics table has paginator with 5 topics per page.</p>
<p>Also you are able to sort topics by creation date. </p>

<img height="500em" src="https://i.ibb.co/fGv9YdN/forum-Page.png" alt="forum-Page" />

<p>If you click on the "+" button on the bottom right corner it will open a form where you can submit your topic for the chosen category.</p>

<p><img src="https://i.ibb.co/K0pGLHV/add-Category-Button.png" alt="add-Category-Button" />
<img height="500em" src="https://i.ibb.co/g7v4TLy/add-Category-Form.png" alt="add-Category-Form"/></p>

## Topic Page
<p>On the topic page you will find more information about the topic, such as: title, author, date of creation and comments.</p>
<p>On the topics of your own you will find buttons to edit(marked with #2) or delete(marked with #3) the topic.</p>

<img height="500em" src="https://i.ibb.co/XFnTY67/topic-Page-Marked-Up.png" alt="topic-Page-Marked-Up" />

<p><strong>Upon clicking button marked with #1 you will collapse the topic comments.</strong></p>

<p>Every author is able to delete or edit their comments with the provided action buttons on the comment card.</p>
<p>The comments have paginator with 5 comments per page.</p>

<img height="500em" src="https://i.ibb.co/9nPm85k/comments-Page.png" alt="comments-Page" />

<p>You can also add reaction to every single comment.</p>
<p>Reactions are:</p>
<ul>
  <li>Like</li>
  <li>Love</li>
  <li>Laugh</li>
  <li>Sad</li>
</ul>

<img src="https://i.ibb.co/0rGzsTy/reactions.png" alt="reactions"/>

<p><strong>In the end of the comment table you will find button to add a new comment.</strong></p>

<p><img src="https://i.ibb.co/98C6sxd/add-Comment-Button.png" alt="add-Comment-Button"/>
<img height="500em" src="https://i.ibb.co/93dHH2Q/add-Comment-Form.png" alt="add-Comment-Form" /></p>

## Articles Page
<p>On the articles page are published some very informative articles.</p>
<p>When you finish reading an article you can give your feedback if it was useful for you.</p>
<p>Admins have the ability to add, delete or edit an article.</p>
<p>Also articles have paginator with 1 article per page.</p>

<img height="500em" src="https://i.ibb.co/Wg7vkX0/articles-Page1.png" alt="articles-Page1"/>
<img height="500em" src="https://i.ibb.co/T88YJ4g/articles-Page2.png" alt="articles-Page2"/>

# Technical Documentation
<pre>
1. Clone the repo and open the MyPregnancyTracker.Web.sln project file in the MyPregnancyTracker.Web folder.
2. Initialize following user secrets for the project:
  The Keys needed for the project to work properly are:
  -"SendGridApiKey"
  -"JwtSecretKey"
  -"User"
  -"Password"
  -"ConnectionString"
  -"DataProtectorKey"
3. Register in https://sendgrid.com/ with free account and get the API key that's been given to you(don't give it to anyone else). Add the key to the "SendGridApiKey" secret.
4. Open the frontend project located in MyPregnancyTracker.UI folder with VS Code and run the "ng serve -o" command in the terminal. This will serve the front end project and will be opened on port 4200.
5. Start the Web project under the IIS Express profile.
6. Enjoy!
</pre>

# Tech Stack
## API
<ul>
  <li>ASP.NET Core 6.0</li>
  <li>AutoMapper version="12.0.0"</li>
  <li>Microsoft.AspNetCore.Authentication.JwtBearer version="6.0.9"</li>
  <li>SendGrid version="9.28.1"</li>
  <li>Microsoft.AspNetCore.Identity version="6.0.9"</li>
  <li>EntityFrameworkCore version="6.0.9"</li>
  <li>Swashbuckle.AspNetCore.Swagger version="6.4.0"</li>
</ul>

## Front End
<ul>
  <li>Angular 14.2.4</li>
  <li>Material 14.2.3</li>
  <li>rxjs 7.5.7</li>
  <li>TypeScript 4.7.4</li>
  <li>JwtHelper </li>
</ul>

## Database
<ul>
  <li>MSSql Server </li>
</ul>

## Tests
<ul>
  <li>Microsoft.EntityFrameworkCore.InMemory version="7.0.0" </li>
  <li>Microsoft.NET.Test.Sdk version="17.1.0" </li>
  <li>Moq version="4.18.3" </li>
  <li>NUnit version="3.13.3" </li>
  <li>NUnit3TestAdapter version="4.2.1" </li>
  <li>NUnit.Analyzers version="3.3.0" </li>
  <li>coverlet.collector version="3.1.2" </li>
</ul>

## Git Tools
<ul>
  <li>GitHub</li>
  <li>Tortoise Git</li>
</ul>
  

