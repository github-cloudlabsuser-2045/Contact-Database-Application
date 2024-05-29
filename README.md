# User Management Application

This is a simple User Management Application built with ASP.NET MVC. It allows you to create, edit, and view users.

## Features

- **Create User**: This feature allows you to create a new user. You can access this feature by navigating to the `User/Create` route.

- **Edit User**: This feature allows you to edit an existing user. You can access this feature by navigating to the `User/Edit/{id}` route, where `{id}` is the ID of the user you want to edit.

## Setup

1. Clone the repository to your local machine.
2. Open the solution in Visual Studio.
3. Build the solution to restore NuGet packages.
4. Run the application.

## Dependencies

This application uses the following dependencies:

- jQuery
- Bootstrap
- Modernizr

These dependencies are bundled and minified using ASP.NET's bundling and minification feature. The configuration for this can be found in the `BundleConfig.cs` file in the `App_Start` directory.

## Controllers

The main logic of the application is contained in the `UserController.cs` file. This file contains actions for creating and editing users.

## Contributing

Contributions are welcome. Please open an issue or submit a pull request.

## License

This project is licensed under the MIT License.
