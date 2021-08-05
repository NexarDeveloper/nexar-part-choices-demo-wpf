# Nexar.PartChoices Demo

[nexar.com]: https://nexar.com/

Demo Altium 365 component browser powered by Nexar.

**Projects:**

- `Nexar.PartChoices` - WPF application, component browser
- `Nexar.Client` - GraphQL StrawberryShake client

## Prerequisites

Visual Studio 2019.

You need your Altium Live credentials and have to be a member of at least one Altium 365 workspace.

In addition, you need an application at [nexar.com] with the Design scope.
Use the application client ID and secret and set environment variables `NEXAR_CLIENT_ID` and `NEXAR_CLIENT_SECRET`.

## How to use

Open the solution in Visual Studio.
Ensure `Nexar.PartChoices` is the startup project, build, and run.

If you run with the debugger then it may break due to "cannot read settings".
Ignore and continue (<kbd>F5</kbd>). The settings are stored on exiting.
Next runs should not have this issue.

The identity server sign in page appears. Enter your credentials and click `Sign In`.

The application window appears with the left tree panel populated with your workspaces.

Expand workspaces to component folders, expand folders to components, select a component.
The right panel is populated with the selected component manufacturers and suppliers parts.

## Building blocks

The app is built using Windows Presentation Foundation, .NET Framework 4.7.2.

The data are provided by Nexar API: <https://api.nexar.com/graphql>.
This is the GraphQL endpoint and also the Banana Cake Pop GraphQL IDE in browsers.

The [HotChocolate StrawberryShake](https://github.com/ChilliCream/hotchocolate) package
is used for generating strongly typed C# client code for invoking GraphQL queries.
Note that StrawberryShake generated code must be compiled as netstandard.
That is why it is in the separate project `Nexar.Client` (netstandard).
The main project `Nexar.PartChoices` (net472) references `Nexar.Client`.
