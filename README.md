# .Net-Homework-1
The Register.aspx page should require that user names must be at
least 4 characters and passwords must contain at least 6 characters
including a number and a special symbol. If the user tries to regis-
ter under an existing user name, they should be informed that the
username already exists. Otherwise, it should register the user.
• Register.aspx should require that both the username and password be
at most 20 characters. Perform this validation prior to any database
operations. Either prevent the user from violating this constraint or
notify them (gracefully) that the constraint has been violated and
ask them to fix the username and/or password and resubmit.
• After successful username and password registration, the user should
be redirected to the login screen. It would be helpful if you also
informed the user at the same time that registration was successful.
• Once added, username/passwords should not be deleted.
• It is not necessary to encrypt passwords, but feel free to add this in
later as an additional exercise if you wish.
• On Default.aspx, 3 failed logins for the same username should result
in a lockout for that username only (it should not be possible to
log on with that username, even if the password is right). How to
enforce this requirement is up to you. After 1 hour, it should be
again possible to log in for that username.
• Once logged in successfully, the user should remain logged in until
they log out. Add a “Log Out” button to Main.aspx for this purpose.
• Page Main.aspx should only display meaningful content if the user
is logged in. Don’t worry about encrypting the cookies for this as-
signment, but feel free to try encrypting cookies later if you have the
time and desire. “Meaningful content” could be, for example, one of
the web pages you wrote in homework 1. If the user is not logged
in, Main.aspx should detect this and mention something to the user
about them needing to log in first.
• Once fully debugged and working, publish your site to Azure. To do
this, right-click on the project in Visual Studio and select Publish....
Check all of the tabs to ensure the information is correct. (If it’s
not correct and you publish, it can be a hassle to change it after the
fact). Under settings, take a moment to read the database connection
string. Ordinarily, we would not include the database password in
the plain text connection string in real life. For this assignment,
however, you may leave it as is.
• Visual Studio will remind you of the URL that your web site has been
published to. Check out the web site to ensure it properly functions.
The graders will look at this as part of your assignment submis-
sion. Submit this URL in the inline text portion of your assignment
submission (<name-you-chose>.azurewebsites.net). Zip up and
submit all project files as an attachment to the assignment.
