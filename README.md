User Panel

Simple ASP.NET Core MVC application for user registration, login, logout, private dashboard, private notes and admin page.

How to run

dotnet restore
dotnet ef database update
dotnet run

Open the URL shown in terminal.

Test users

Normal user can be created on:

/Account/Register

Admin user:

Email: admin@test.com
Password: Admin123!

This admin password is only for local testing.

Main files

Password hashing and login/logout:
Controllers/AccountController.cs

Authentication configuration:
Program.cs

Private dashboard:
Controllers/DashboardController.cs

Admin page:
Controllers/AdminController.cs

Security

Passwords are not stored as plain text. The app uses PasswordHasher.

Dashboard is protected with [Authorize].

Admin page is protected with [Authorize(Roles = “Admin”)].

Private notes are filtered by current user id, so users cannot see notes of other users.

Questions

Passwords must not be stored as plain text because if the database is leaked, passwords will be visible.

Raw SHA-256 is not good for passwords because it is too fast and easier to brute force.

Salt makes password hashes different, even if two users have the same password.

Salt is stored with the hash. Pepper is secret and should be stored outside the database.

Authentication checks who the user is.

Authorization checks what the user can access.

Hiding a link is not enough because user can type the URL manually.

A message like “there is no such user” is bad because it shows which emails are registered.

Checklist

Registration works.
Login works.
Logout works.
Password is hashed.
Dashboard is private.
Notes are private.
Admin page is only for Admin.
